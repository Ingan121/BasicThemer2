using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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
            if (Environment.GetCommandLineArgs().Length >= 2)
            {
                if (Environment.GetCommandLineArgs()[1].EndsWith("help") | Environment.GetCommandLineArgs()[1].EndsWith("?"))
                {
                    MessageBox.Show("showui: Show the UI on startup.\ndonthide: Don't hide the UI ever.", "BasicThemer 2 Command-Line Arguments");
                    return;
                }
            }
            if (!IsAdministrator())
            {
                MessageBox.Show("Run as administrator to apply the basic theme to privileged programs");
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
