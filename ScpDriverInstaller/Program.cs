using System;
using System.Linq;
using System.Windows.Forms;

namespace ScpDriverInstaller
{
    static class Program
    {
        private static bool _quiet = false;
        private static bool _install = false;
        private static bool _uninstall = false;

        /// <summary>The main entry point for the application.</summary>
        [STAThread]
        static int Main(string[] args)
        {
            ParseArgs(args);
            if (_install || _uninstall || _quiet)
                return DriverInstaller.doInstaller(_uninstall, _quiet);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DriverInstaller());
            return 0;
        }

        private static void ParseArgs(string[] args)
        {
            String[] quietArgs = { "/q", "-q", "/quiet", "--quiet", "/s", "-s", "/silent", "--silent" };
            String[] installArgs = { "/i", "-i", "/install", "--install" };
            String[] uninstallArgs = { "/u", "-u", "/uninstall", "--uninstall" };

            var lowerArgs = from arg in args select arg.ToLower();

            _quiet = lowerArgs.Intersect(quietArgs).Any();
            _install = lowerArgs.Intersect(installArgs).Any();
            _uninstall = lowerArgs.Intersect(uninstallArgs).Any();
        }
    }
}
