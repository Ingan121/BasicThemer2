using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace BasicThemer2
{
    public partial class Form1 : Form
    {
        public string logs;
        public string[] args = Environment.GetCommandLineArgs();
        private bool Extended = false;
        public RegistryKey bt2ConfReg;
        public IntPtr lastHwnd;
        public int timerSpeed = 100;
        public bool allowshowdisplay = false;
        public bool donthide = false;
        public Version ver = new Version(FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion);

        private const int DWMWA_NCRENDERING_POLICY = 2;
        private const int DWMNCRP_DISABLED = 1;
        private const int DWMNCRP_ENABLED = 0;

        public Form1()
        {
            InitializeComponent();
            bt2ConfReg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Ingan121\\BasicThemer2", RegistryKeyPermissionCheck.ReadWriteSubTree);

            // Load configurations
            if (bt2ConfReg.GetValueNames().Contains("Exclusions"))
            {
                string[] excls = bt2ConfReg.GetValue("Exclusions").ToString().Split(new char[] { '|' });
                ExclListBox.Items.Clear();
                for (int i = 0; i < excls.Length; i++)
                {
                    if (!string.IsNullOrEmpty(excls[i]))
                    {
                        ExclListBox.Items.Add(excls[i]);
                    }
                }
            }
            else
            {
                saveExclList();
            }

            if (bt2ConfReg.GetValueNames().Contains("ExclExtWnds"))
            {
                if (bt2ConfReg.GetValue("ExclExtWnds").ToString() == "0")
                {
                    ExclExtWndsChkBox.Checked = false;
                }
            } else
            {
                bt2ConfReg.SetValue("ExclExtWnds", 1, RegistryValueKind.DWord);
            }

            if (bt2ConfReg.GetValueNames().Contains("TimerSpeed"))
            {
                timerSpeed = (int)bt2ConfReg.GetValue("TimerSpeed");
                TimerSpeedBox.Text = timerSpeed.ToString();
            }
            else
            {
                bt2ConfReg.SetValue("TimerSpeed", 100, RegistryValueKind.DWord);
            }

            if (bt2ConfReg.GetValueNames().Contains("WhitelistMode"))
            {
                if (bt2ConfReg.GetValue("WhitelistMode").ToString() == "1")
                {
                    WhitelistModeChkBox.Checked = true;
                }
            }
            else
            {
                bt2ConfReg.SetValue("WhitelistMode", 0, RegistryValueKind.DWord);
            }

            if (bt2ConfReg.GetValueNames().Contains("AutoUpdChk"))
            {
                if (bt2ConfReg.GetValue("AutoUpdChk").ToString() == "0")
                {
                    AutoUpdChkChkBox.Checked = false;
                }
            }
            else
            {
                bt2ConfReg.SetValue("AutoUpdChk", 1, RegistryValueKind.DWord);
            }


            // Start main window detection loop
            Task.Factory.StartNew(() =>
            {
                for(; ; )
                {
                    if (!PauseChkBox.Checked && lastHwnd != GetForegroundWindow() && GetForegroundWindow() != IntPtr.Zero)
                    {
                        log("[New window detected!] lastHwnd: " + lastHwnd.ToString() + ", GetForegroundWindow(): " + GetForegroundWindow().ToString());
                        try
                        {
                            // Get the client and full window sizes and compare them to check if the window is extended
                            if (!GetClientRect(GetForegroundWindow(), out RECT rct))
                            {
                                log("[ERROR in GetClientRect]");
                                return;
                            }
                            ClientHeight = rct.Bottom - rct.Top + 1;

                            if (!GetWindowRect(GetForegroundWindow(), out rct))
                            {
                                log("[ERROR in GetWindowRect]");
                                return;
                            }
                            WindowHeight = rct.Bottom - rct.Top + 1;

                            HeightDifference = WindowHeight - ClientHeight;
                            Extended = WindowHeight - ClientHeight <= SystemInformation.CaptionHeight;

                            // Apply the basic theme to the window if it is not extended or if the "Exclude all windows with..." checkbox is not checked
                            if (!Extended | !ExclExtWndsChkBox.Checked) RemoveDwmFrameByHwnd(GetForegroundWindow(), RevModeChkBox.Checked);

                            log(ReturnEmptyIfSo(GetWindowTitleOfHwnd(GetForegroundWindow())) + " / " + ReturnEmptyIfSo(GetProcessNameOfHwnd(GetForegroundWindow())) + " / " + GetForegroundWindow().ToString() + " (" + ClientHeight + ", " + WindowHeight + ", " + HeightDifference + ", " + (Extended ? "Extended" : "Not extended") + ")");
                        }
                        catch (Exception ex)
                        {
                            log(ex.ToString());
                        }
                    }
                    lastHwnd = GetForegroundWindow();
                    Thread.Sleep(timerSpeed);
                }
            });

            if (args.Any(x => x.Contains("hidetray")))
            {
                notifyIcon1.Visible = false;
            }

            if (args.Any(x => x.Contains("enablelogging")))
            {
                DoLogChkBox.Checked = true;
            }

            if (args.Any(x => x.Contains("noautoupdchk")))
            {
                AutoUpdChkChkBox.Checked = false;
            }

            if (AutoUpdChkChkBox.Checked)
            {
                updateCheck();
            }

            logs = string.Format("\n{0} : [Application initialization complete (Version " + ver + (IsAdministrator() ? ")]" : ", Not admin)]"), DateTime.Now);
            log("[Current exclusions: " + getExclListAsString() + "]", true);
        }

        delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);

        [DllImport("user32.dll")]
        static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);
            
        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allowshowdisplay = true;
            Visible = true;
            BringToFront();
            WindowState = FormWindowState.Normal;
            log("[UI Visibility: " + (Visible ? "Visible" : "Invisible") + "]");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Exit();

        private void ExitWndBtn_Click(object sender, EventArgs e) => Exit();

        private void RevModeChkBox_CheckedChanged(object sender, EventArgs e)
        {
            // Apply the setting immediately when not paused
            if (!PauseChkBox.Checked)
            {
                RemoveDwmFrameByHwnd(GetForegroundWindow(), RevModeChkBox.Checked);
            }
            log("[Reverting Mode: " + RevModeChkBox.Checked.ToString() + "]");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!donthide)
            {
                e.Cancel = true;
                Visible = false;
                log("[UI Visibility: " + (Visible ? "Visible" : "Invisible") + "]");
            }
        }

        private void Form1_Load(object sender, EventArgs e) => Visible = false;

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("https://github.com/Ingan121/BasicThemer2");

        private void OpenLogBtn_Click(object sender, EventArgs e)
        {
            DoLogChkBox.Checked = false;
            try
            {
                Process.Start("BasicThemer2.log");
            } catch
            {
                new Thread(() =>
                {
                    MessageBox.Show("Log file doesn't exist!", "BasicThemer 2");
                }).Start();
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            string exename = ExclAddNameBox.Text;
            ExclListBox.Items.Add(exename.EndsWith(".exe") ? exename : (exename.EndsWith("/noexe") ? exename.Remove(exename.Length - 6) : exename + ".exe"));
            log("New process was added to the exclusion / inclusion list: " + exename);
            saveExclList();
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(ExclListBox);
            selectedItems = ExclListBox.SelectedItems;

            if (ExclListBox.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                {
                    ExclListBox.Items.Remove(selectedItems[i]);
                }
            }
            saveExclList();
        }

        private void PauseChkBox_CheckedChanged(object sender, EventArgs e)
        {
            RemoveDwmFrameByHwnd(GetForegroundWindow(), RevModeChkBox.Checked);
            log("[Pause: " + PauseChkBox.Checked.ToString() + "]");
        }

        private void DoLogChkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DoLogChkBox.Checked)
            {
                log("[Logging Started]");
            }
            else
            {
                logs += string.Format("\n{0} : [Logging Stopped]", DateTime.Now);
                FileInfo LogFileInfo = new FileInfo("BasicThemer2.log");
                if (!LogFileInfo.Exists || LogFileInfo.Length == 0)
                {
                    logs = logs.Substring(1);
                }
                File.AppendAllText("BasicThemer2.log", logs);
                logs = "";
            }
        }

        protected override void SetVisibleCore(bool value)
        {
            if (args.Any(x => x.Contains("showui")))
            {
                allowshowdisplay = true;
            }
            if (args.Any(x => x.Contains("donthide")))
            {
                donthide = true;
            }

            base.SetVisibleCore(allowshowdisplay ? value : allowshowdisplay);
        }

        private void NotifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                allowshowdisplay = true;
                Visible = donthide || !Visible;
                log("[UI Visibility: " + (Visible ? "Visible" : "Invisible") + "]");
            }
        }

        public void Exit()
        {
            Close();
            Dispose();
            Properties.Settings.Default.Save();
            log("[Application Exiting...]");
            DoLogChkBox.Checked = false;
            Application.Exit();
        }

        [DllImport("DwmApi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int dwAttribute, ref int pvAttribute, int cbAttribute);

        private void RemoveDwmFrameByHwnd(IntPtr hwnd, Boolean revert)
        {
            var policyParameter = DWMNCRP_DISABLED;

            bool condition = ExclListBox.FindString(GetProcessNameOfHwnd(hwnd)) == ListBox.NoMatches;
            if (WhitelistModeChkBox.Checked)
            {
                condition = !condition;
            }

            if (condition)
            {
                if (revert)
                {
                    policyParameter = DWMNCRP_ENABLED;
                }

                DwmSetWindowAttribute(hwnd, DWMWA_NCRENDERING_POLICY, ref policyParameter, sizeof(int));
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);
        private string GetProcessNameOfHwnd(IntPtr hwnd)
        {
            uint pid;
            GetWindowThreadProcessId(hwnd, out pid);
            return Process.GetProcessById((int)pid).ProcessName;
        }

        private string GetMainWndNameOfProcOfHwnd(IntPtr hwnd)
        {
            uint pid;
            GetWindowThreadProcessId(hwnd, out pid);
            return Process.GetProcessById((int)pid).MainWindowTitle;
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        private string GetWindowTitleOfHwnd(IntPtr hwnd)
        {
            const int nChars = 256;
            IntPtr handle = IntPtr.Zero;
            StringBuilder Buff = new StringBuilder(nChars);
            handle = hwnd;

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }

        [DllImport("user32.dll")]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }

        private int ClientHeight, WindowHeight, HeightDifference;

        public static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public string ReturnEmptyIfSo(String str) => string.IsNullOrEmpty(str) ? "{{Empty}}" : str;

        private void dbgBtn_Click(object sender, EventArgs e) // Small debug button located at bottom right
        {
            MessageBox.Show("lastHwnd: " + lastHwnd.ToString() + ", GetForegroundWindow(): " + GetForegroundWindow().ToString());
        }

        private void TimerSpeedBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int timerSpeedInput = int.Parse(TimerSpeedBox.Text);

                if (timerSpeedInput < 0)
                {
                    throw new Exception();
                }

                timerSpeed = timerSpeedInput;
                bt2ConfReg.SetValue("TimerSpeed", timerSpeed, RegistryValueKind.DWord);
                log("[TimerSpeed: " + timerSpeed.ToString() + "]");
                MsOrErrLabel.Text = "ms";
            }
            catch
            {
                MsOrErrLabel.Text = "Err!";
            }
        }

        public void log(string str, bool alwaysLog = false)
        {
            if (DoLogChkBox.Checked)
            {
                logs += string.Format("\n{0} : " + str, DateTime.Now);
            }
        }

        private void ExclExtWndsChkBox_CheckedChanged(object sender, EventArgs e)
        {
            log("[ExclExtWnds:" + ExclExtWndsChkBox.Checked.ToString() + "]");
            bt2ConfReg.SetValue("ExclExtWnds", ExclExtWndsChkBox.Checked, RegistryValueKind.DWord);
        }

        private void WhitelistModeChkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (WhitelistModeChkBox.Checked)
            {
                ExclsOrInclsLabel.Text = "Inclusions";
            }
            else
            {
                ExclsOrInclsLabel.Text = "Exclusions";
            }
            
            log("[Whitelist modet: " + WhitelistModeChkBox.Checked.ToString() + "]");
            bt2ConfReg.SetValue("WhitelistMode", WhitelistModeChkBox.Checked, RegistryValueKind.DWord);
        }

        private void AutoUpdChkChkBox_CheckedChanged(object sender, EventArgs e)
        {
            log("[Automatic update check: " + AutoUpdChkChkBox.Checked.ToString() + "]");
            bt2ConfReg.SetValue("AutoUpdChk", AutoUpdChkChkBox.Checked, RegistryValueKind.DWord);
        }

        private string getExclListAsString()
        {
            string value = "";
            for (int i = 0; i < ExclListBox.Items.Count; i++)
            {
                value = value + ExclListBox.Items[i].ToString() + "|"; //use | for separator as it cannot be used for filenames
            }
            return value;
        }

        private void UpdChkBtn_Click(object sender, EventArgs e)
        {
            updateCheck(true);
        }

        private void saveExclList()
        {
            bt2ConfReg.SetValue("Exclusions", getExclListAsString(), RegistryValueKind.String);
        }

        private void updateCheck(bool alertLatest = false)
        {
            Task.Factory.StartNew(() =>
            {
                log("[Checking for updates...]");
                try
                {
                    WebClient wc = new WebClient();
                    string latestVerStr = wc.DownloadString("https://raw.githubusercontent.com/Ingan121/BasicThemer2/master/latest.txt");
                    //string latestVerStr = wc.DownloadString("http://localhost/latest.txt");
                    log("[Lastest version found: " + latestVerStr + "]");

                    Version latestVer = new Version(latestVerStr);
                    int compare = ver.CompareTo(latestVer);

                    if (compare < 0)
                    {
                        if (MessageBox.Show("New version of BasicThemer 2 is available. Download it now?", "BasicThemer 2", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Process.Start("https://github.com/Ingan121/BasicThemer2/releases");
                        }
                    }
                    else
                    {
                        if (alertLatest)
                        {
                            if (compare == 0)
                            {
                                MessageBox.Show("You are running the latest version of BasicThemer 2.", "BasicThemer 2");
                            }
                            else
                            {
                                MessageBox.Show("You are running a unreleased version of BasicThemer 2.", "BasicThemer 2");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    log(ex.ToString());
                    MessageBox.Show("Update check failed!", "BasicThemer 2");
                }
            });
        }
    }
}
