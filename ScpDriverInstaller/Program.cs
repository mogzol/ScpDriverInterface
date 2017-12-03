using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ScpDriverInstaller
{
	static class Program
	{
		/// <summary>The main entry point for the application.</summary>
		[STAThread]
		static int Main(string[] args)
		{
			if (UserRequestedQuietMode(args))
			{
				return RunQuietInstall();
			}

			return Run();
		}

		private static bool UserRequestedQuietMode(string[] args)
		{
			var silentArgs = new List<string>() { "/q", "-q", "/quiet", "--quiet", "/s", "-s", "/silent", "--silent" };
			var lowerArgs = from arg in args select arg.ToLower();
			return lowerArgs.Intersect(silentArgs).Any();
		}

		private static int Run()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new DriverInstaller());
			return 0;
		}

		private static int RunQuietInstall()
		{
			try
			{
				if (!DriverInstaller.Install())
				{
					Console.WriteLine("Installation incomplete; Requires reboot.");
					return 1;
				}
				return 0;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
			return -1;
		}
	}
}
