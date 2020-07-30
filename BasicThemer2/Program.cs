using System;
using System.Collections.Generic;
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
                MessageBox.Show("Run as administrator to apply the basic theme to privileged programs", "BasicThemer 2");
            }
            Application.Run(new Form1());
        }

        public static bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
