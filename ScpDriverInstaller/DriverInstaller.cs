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
	public partial class DriverInstaller : Form
	{
		private const string SCP_BUS_CLASS_GUID = "{F679F562-3164-42CE-A4DB-E7DDBE723909}";
		private Difx installer = Difx.Factory();

		public DriverInstaller()
		{
			InitializeComponent();
		}

		private void credits_Click(object sender, EventArgs e)
		{
			Process.Start("http://forums.pcsx2.net/User-Scarlet-Crush");
		}

		private void install_Click(object sender, EventArgs e)
		{
			Color oldColor = install.ForeColor;
			string oldText = install.Text;
			install.ForeColor = Color.LightGray;
			install.Text = "Installing...";
			Update();

			string infPath = @".\Driver\";
			string devPath = "";
			string instanceId = "";

			uint result = 0;
			bool rebootRequired = false;

			DifxFlags flags = DifxFlags.DRIVER_PACKAGE_ONLY_IF_DEVICE_PRESENT | DifxFlags.DRIVER_PACKAGE_FORCE;

			if (!Devcon.Find(new Guid(SCP_BUS_CLASS_GUID), ref devPath, ref instanceId))
			{
				if (!Devcon.Create("System", new Guid("{4D36E97D-E325-11CE-BFC1-08002BE10318}"), "root\\ScpVBus\0\0"))
				{
					MessageBox.Show("Unable to create SCP Virtual Bus, cannot continue with installation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					install.Text = oldText;
					install.ForeColor = oldColor;
					return;
				}
			}

			result = installer.Install(infPath + @"ScpVBus.inf", flags, out rebootRequired);
			if (result == 0)
			{
				if (rebootRequired)
					MessageBox.Show("Driver successfully installed, but a reboot may be required for it to work properly.", "Installation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
				else
					MessageBox.Show("Driver successfully installed!", "Installation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("Driver installation failed with DIFxAPI error 0x" + result.ToString("X8"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

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

			string infPath = @".\Driver\";
			string devPath = "";
			string instanceId = "";

			uint result = 0;
			bool rebootRequired = false;

			if (Devcon.Find(new Guid(SCP_BUS_CLASS_GUID), ref devPath, ref instanceId))
			{
				if (!Devcon.Remove(new Guid(SCP_BUS_CLASS_GUID), devPath, instanceId))
				{
					MessageBox.Show("Unable to remove SCP Virtual Bus, cannot continue with uninstallation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					uninstall.Text = oldText;
					uninstall.ForeColor = oldColor;
					return;
				}
			}

			result = installer.Uninstall(infPath + @"ScpVBus.inf", DifxFlags.DRIVER_PACKAGE_DELETE_FILES, out rebootRequired);
			if (result == 0)
			{
				if (rebootRequired)
					MessageBox.Show("Driver successfully uninstalled, but a reboot may be required to complete uninstallation.", "Uninstall Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
				else
					MessageBox.Show("Driver successfully uninstalled!", "Uninstall Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else if (result == 0xe0000302)
			{
				MessageBox.Show("Driver not found, are you sure it's installed?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				MessageBox.Show("Driver uninstall failed with DIFxAPI error 0x" + result.ToString("X8"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			uninstall.Text = oldText;
			uninstall.ForeColor = oldColor;
		}
	}
}
