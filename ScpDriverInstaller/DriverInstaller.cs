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
 */

using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ScpDriverInstaller
{
	public class ScpDriverInstallException : Exception
	{
		public ScpDriverInstallException(string message) : base(message) { }
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
		/// <remarks>Throws exceptions upon errors.</remarks>
		/// <returns>false if a reboot is still required to complete installation, else true to indicate completion.</returns>
		public static bool Install()
		{
			var infPath = @".\Driver\";
			var devPath = "";
			var instanceId = "";
			var installer = Difx.Factory();

			uint result = 0;
			bool rebootRequired = false;

			DifxFlags flags = DifxFlags.DRIVER_PACKAGE_ONLY_IF_DEVICE_PRESENT | DifxFlags.DRIVER_PACKAGE_FORCE;

			if (!Devcon.Find(new Guid(SCP_BUS_CLASS_GUID), ref devPath, ref instanceId))
			{
				if (!Devcon.Create("System", new Guid("{4D36E97D-E325-11CE-BFC1-08002BE10318}"), "root\\ScpVBus\0\0"))
				{
					throw new ScpDriverInstallException("Unable to create SCP Virtual Bus. Cannot continue with installation.");
				}
			}

			result = installer.Install(infPath + @"ScpVBus.inf", flags, out rebootRequired);
			if (result != 0)
			{
				throw new ScpDriverInstallException("Driver installation failed with DIFxAPI error 0x" + result.ToString("X8"));
			}
			return !rebootRequired;
		}

        /// <summary>Uninstall the ScpVBus driver.</summary>
		/// <remarks>Throws exceptions upon errors.</remarks>
		/// <returns>false if a reboot is still required to complete installation, else true to indicate completion.</returns>
        public static bool Uninstall()
        {
            string infPath = @".\Driver\";
            string devPath = "";
            string instanceId = "";

            uint result = 0;
            bool rebootRequired = false;
            var installer = Difx.Factory();

            if (Devcon.Find(new Guid(SCP_BUS_CLASS_GUID), ref devPath, ref instanceId))
            {
                if (!Devcon.Remove(new Guid(SCP_BUS_CLASS_GUID), devPath, instanceId))
                {
                    throw new ScpDriverInstallException("Unable to remove SCP Virtual Bus, cannot continue with uninstallation.");
                }
            }

            result = installer.Uninstall(infPath + @"ScpVBus.inf", DifxFlags.DRIVER_PACKAGE_DELETE_FILES, out rebootRequired);
            if (result == 0xe0000302)
            {
                throw new ScpDriverInstallException("Driver not found, please ensure it is installed.");
            }
            else if (result != 0)
            {
                throw new ScpDriverInstallException("Driver uninstall failed with DIFxAPI error 0x" + result.ToString("X8"));
            }

            return rebootRequired;
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
	}
}
