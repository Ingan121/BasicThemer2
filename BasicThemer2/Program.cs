using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicThemer2
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string[] args = Environment.GetCommandLineArgs();
            if (args.Any(x => x.Contains("help")) || args.Any(x => x.Contains("?"))) {
                MessageBox.Show("showui: Show the UI on startup.\ndonthide: Don't hide the UI ever.\nhidetray: Hide the tray icon completely.", "BasicThemer 2 Command-Line Arguments");
                return;
            }

            if (!IsAdministrator())
            {
                if (MessageBox.Show("BasicThemer 2 requires administrator privileges in order to apply the basic theme to other programs which have administrator privileges. Relaunch as administrator?", "BasicThemer 2", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    RerunAsAdministrator();
                }
                else
                {
                    MessageBox.Show("Relaunch was aborted. Proceeding without Administrator privileges. Other applications running as administrator will not receive basic theme borders.", "BasicThemer 2");
                }
            }
            
            Application.Run(new Form1());
        }

        public static bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static void RerunAsAdministrator()
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 0)
                args = args.Skip(1).ToArray();

            string argString = string.Empty;
            foreach (string s in args)
                argString = argString + "\"" + s + "\" ";

            var exeName = Process.GetCurrentProcess().MainModule.FileName;
            try
            {
                Process.Start(new ProcessStartInfo(exeName, argString)
                {
                    Verb = "runas"
                });
                Process.GetCurrentProcess().Kill();
            }
            catch (Win32Exception) { }
        }
    }
}
