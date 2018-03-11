/*
 * ScpDriverInstaller - by Mogzol (and of course Scarlet.Crush) - Jan, 2016
 *
 * This is a really barebones installer that installs Scarlet.Crush's SCP Virtual 
 * Bus Driver. The code for this was ripped out of his ScpInstaller source code,
 * so all credit for the code here obviously goes to him.
 *
 * The driver itself is also his work, I haven't touched it at all.
 * 
 * You can download his original source code here:
 * http://forums.pcsx2.net/Thread-XInput-Wrapper-for-DS3-and-Play-com-USB-Dual-DS2-Controller
 * 
 * Silent install mode, installation through embedded resources, and improved
 * error handling added by DavidRieman - Dec, 2017.
 */

using EmbeddedDIFx;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace ScpDriverInstaller
{
    public class ScpDriverInstallException : Exception
    {
        public ScpDriverInstallException(string message) : base(message) { }
    }

    public class ScpDriverUninstallException : Exception
    {
        public ScpDriverUninstallException(string message) : base(message) { }
    }

    public partial class DriverInstaller : Form
    {
        private const string SCP_BUS_CLASS_GUID = "{F679F562-3164-42CE-A4DB-E7DDBE723909}";

        public DriverInstaller()
        {
            InitializeComponent();
        }

        private void credits_Click(object sender, EventArgs e)
        {
            Process.Start("http://forums.pcsx2.net/User-Scarlet-Crush");
        }

        /// <summary>Install the ScpVBus driver.</summary>
        /// <remarks>Throws ScpDriverInstallException upon known errors.</remarks>
        /// <returns>false if a reboot is still required to complete installation, else true to indicate completion.</returns>
        public static bool Install()
        {
            return UsingExtractedDriverAndInstaller((inf, installer) =>
            {
                var devPath = "";
                var instanceId = "";

                var flags = DriverPackageFlags.ONLY_IF_DEVICE_PRESENT | DriverPackageFlags.FORCE;

                if (!Devcon.Find(new Guid(SCP_BUS_CLASS_GUID), ref devPath, ref instanceId))
                {
                    if (!Devcon.Create("System", new Guid("{4D36E97D-E325-11CE-BFC1-08002BE10318}"), "root\\ScpVBus\0\0"))
                    {
                        throw new ScpDriverInstallException("Unable to create SCP Virtual Bus. Cannot continue with installation.");
                    }
                }

                try
                {
                    return installer.DriverPackageInstall(inf, flags);
                }
                catch (Exception ex)
                {
                    throw new ScpDriverInstallException("Driver installation failed: " + ex.Message);
                }
            });
        }

        /// <summary>Uninstall the ScpVBus driver.</summary>
        /// <remarks>Throws ScpDriverUninstallException upon known errors.</remarks>
        /// <returns>false if a reboot is still required to complete uninstallation, else true to indicate completion.</returns>
        public static bool Uninstall()
        {
            return UsingExtractedDriverAndInstaller((inf, installer) =>
            {
                var devPath = "";
                var instanceId = "";

                if (Devcon.Find(new Guid(SCP_BUS_CLASS_GUID), ref devPath, ref instanceId))
                {
                    if (!Devcon.Remove(new Guid(SCP_BUS_CLASS_GUID), devPath, instanceId))
                    {
                        throw new ScpDriverUninstallException("Unable to remove SCP Virtual Bus, cannot continue with uninstallation.");
                    }
                }

                try
                {
                    return installer.DriverPackageUninstall(inf, DriverPackageFlags.DELETE_FILES);
                }
                catch (Win32Exception ex)
                {
                    if ((uint)ex.ErrorCode == 0xe0000302)
                    {
                        throw new ScpDriverUninstallException("Driver not found, are you sure it's installed?");
                    }
                    throw new ScpDriverUninstallException("Driver uninstall failed: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new ScpDriverUninstallException("Driver uninstall failed: " + ex.Message);
                }
            });
        }

        public static int doInstaller(bool uninstall = false, bool quiet = false)
        {
            try
            {
                var fullyCompleted = uninstall ? Uninstall() : Install();

                if (!quiet)
                {
                    var msg = "Driver successfully " + (uninstall ? "un" : "") + "installed" + (fullyCompleted ? "!" : ", but a reboot may be required for it to work properly.");
                    MessageBox.Show(msg, (uninstall ? "Uni" : "I") + "nstallation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return fullyCompleted ? 0 : 1;
            }
            catch (Exception ex)
            {
                if (!quiet)
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return -1;
            }
        }

        private void install_Click(object sender, EventArgs e)
        {
            Color oldColor = install.ForeColor;
            string oldText = install.Text;
            install.ForeColor = Color.LightGray;
            install.Text = "Installing...";
            Update();

            doInstaller();

            install.Text = oldText;
            install.ForeColor = oldColor;
        }

        private void uninstall_Click(object sender, EventArgs e)
        {
            Color oldColor = uninstall.ForeColor;
            string oldText = uninstall.Text;
            uninstall.ForeColor = Color.LightGray;
            uninstall.Text = "Uninstalling...";
            Update();

            doInstaller(true);

            uninstall.Text = oldText;
            uninstall.ForeColor = oldColor;
        }

        private static string GetTemporaryDirectory()
        {
            string tempDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDir);
            return tempDir;
        }

        private static void ExtractDriverResources(string tempDir)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resources = assembly.GetManifestResourceNames();
            var baseResourcePath = "ScpDriverInstaller.Driver.";
            var resourceFiles = new List<string>() { "ScpVBus.inf", "ScpVBus.cat", "amd64\\ScpVBus.sys", "x86\\ScpVBus.sys" };
            foreach (var resourceFile in resourceFiles)
            {
                var pathParts = resourceFile.Split('\\');
                var resourceTempDir = pathParts.Length > 1 ? Path.Combine(tempDir, pathParts[0]) : tempDir;
                var resourceFullPath = Path.Combine(tempDir, resourceFile);
                var embeddedResourcePath = baseResourcePath + string.Join(".", pathParts);
                if (!Directory.Exists(resourceTempDir))
                {
                    Directory.CreateDirectory(resourceTempDir);
                }

                ExtractResourceToFile(assembly, embeddedResourcePath, resourceFullPath);
            }
        }

        private static bool UsingExtractedDriverAndInstaller(Func<string, DIFx, bool> action)
        {
            var tempDir = GetTemporaryDirectory();
            try
            {
                ExtractDriverResources(tempDir);
                var inf = Path.Combine(tempDir, "ScpVBus.inf");
                if (!File.Exists(inf))
                {
                    throw new FileNotFoundException("Could not find ScpVBus.inf after extracting temporary resources.");
                }

                using (var difx = new DIFx())
                {
                    return action(inf, difx);
                }
            }
            finally
            {
                Directory.Delete(tempDir, true);
            }
        }

        private static void ExtractResourceToFile(Assembly assembly, string embeddedResourcePath, string outputFilePath)
        {
            using (var resourceStream = assembly.GetManifestResourceStream(embeddedResourcePath))
            using (var fileStream = new FileStream(outputFilePath, FileMode.Create))
            {
                for (int i = 0; i < resourceStream.Length; i++)
                {
                    fileStream.WriteByte((byte)resourceStream.ReadByte());
                }
            }
        }
    }
}
