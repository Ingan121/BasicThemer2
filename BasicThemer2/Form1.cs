using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
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
        WinEventDelegate dele = null;

        public string logs;

        public string[] args = Environment.GetCommandLineArgs();

        public Form1()
        {
            InitializeComponent();
            dele = new WinEventDelegate(WinEventProc);
            SetWinEventHook(EVENT_SYSTEM_FOREGROUND, EVENT_SYSTEM_FOREGROUND, IntPtr.Zero, dele, 0, 0, WINEVENT_OUTOFCONTEXT);
            SetWinEventHook(EVENT_SYSTEM_MINIMIZEEND, EVENT_SYSTEM_MINIMIZEEND, IntPtr.Zero, dele, 0, 0, WINEVENT_OUTOFCONTEXT);
            SetWinEventHook(EVENT_OBJECT_CREATE, EVENT_OBJECT_CREATE, IntPtr.Zero, dele, 0, 0, WINEVENT_OUTOFCONTEXT);
            if (args.Any(x => x.Contains("hidetray")))
            {
                notifyIcon1.Visible = false;
            }
            logs = string.Format("\n{0} : [Application Initialization Completed" + (IsAdministrator() ? "]" : " (Not admin)]"), DateTime.Now);
        }

        delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);

        [DllImport("user32.dll")]
        static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);

        private bool Extended = false;

        public void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            Task.Factory.StartNew(() =>
            {
                if (!PauseChkBox.Checked)
                {
                    if (eventType == EVENT_SYSTEM_FOREGROUND | eventType == EVENT_SYSTEM_MINIMIZEEND)
                    {
                        //For foreground windows
                        try
                        {
                            //Get the client and full window sizes and compare them to check if the window is extended
                            if (!GetClientRect(GetForegroundWindow(), out RECT rct))
                            {
                                log("[FG: ERROR in GetClientRect]");
                                return;
                            }
                            ClientHeight = rct.Bottom - rct.Top + 1;

                            if (!GetWindowRect(GetForegroundWindow(), out rct))
                            {
                                log("[FG: ERROR in GetWindowRect]");
                                return;
                            }
                            WindowHeight = rct.Bottom - rct.Top + 1;

                            HeightDifference = WindowHeight - ClientHeight;
                            Extended = WindowHeight - ClientHeight <= SystemInformation.CaptionHeight;

                            //Apply the basic theme to the window if it is not extended or if the "Exclude all windows with..." checkbox is not checked
                            if (!Extended | !ExclExtWndsChkBox.Checked) RemoveDwmFrameOfForegroundWindow(RevModeChkBox.Checked);

                            log("[FG] " + ReturnEmptyIfSo(GetActiveWindowTitle()) + " / " + ReturnEmptyIfSo(GetProcessNameOfHwnd(GetForegroundWindow())) + " (" + ClientHeight + ", " + WindowHeight + ", " + HeightDifference + ", " + (Extended ? "Extended" : "Not extended") + ")");
                        }
                        catch (Exception ex)
                        {
                            log(ex.ToString());
                        }
                    }
                    else
                    {
                        //For background windows

                        //Wait for some milliseconds to prevent false positives
                        if (!DoLogChkBox.Checked)
                        {
                            Thread.Sleep(20);
                        }

                        try
                        {
                            //Get the client and full window sizes and compare them to check if the window is extended
                            if (!GetClientRect(hwnd, out RECT rct))
                            {
                                log("[BG: ERROR in GetClientRect]");
                                return;
                            }
                            ClientHeight = rct.Bottom - rct.Top + 1;

                            if (!GetWindowRect(hwnd, out rct))
                            {
                                log("[BG: ERROR in GetWindowRect]");
                                return;
                            }
                            WindowHeight = rct.Bottom - rct.Top + 1;

                            HeightDifference = WindowHeight - ClientHeight;
                            Extended = WindowHeight - ClientHeight <= SystemInformation.CaptionHeight;

                            //Apply the basic theme to the window if it is not extended or if the "Exclude all windows with..." checkbox is not checked
                            if ((!Extended | !ExclExtWndsChkBox.Checked)) RemoveDwmFrameByHwnd(hwnd, RevModeChkBox.Checked);

                            log("[BG] " + ReturnEmptyIfSo(GetWindowTitleOfHwnd(hwnd)) + " / " + ReturnEmptyIfSo(GetProcessNameOfHwnd(hwnd)) + " (" + ClientHeight + ", " + WindowHeight + ", " + HeightDifference + ", " + (Extended ? "Extended" : "Not extended") + ")");
                        }
                        catch (Exception ex)
                        {
                            log(ex.ToString());
                        }
                    }
                }
            });
        }
            
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
            //Apply the setting immediately when not paused
            if (!PauseChkBox.Checked)
            {
                RemoveDwmFrameOfForegroundWindow(RevModeChkBox.Checked);
            }
            log("[Reverting Mode: " + RevModeChkBox.Checked.ToString() + "]");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!donthide)
            {
                e.Cancel = true;
                Visible = false;
                log("[UI Visibility: " + Visible.ToString() + "]");
            }
        }

        private void Form1_Load(object sender, EventArgs e) => Visible = false;

        private bool allowshowdisplay = false;

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
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(ExclListBox);
            selectedItems = ExclListBox.SelectedItems;

            if (ExclListBox.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    ExclListBox.Items.Remove(selectedItems[i]);
            }
        }

        private void PauseChkBox_CheckedChanged(object sender, EventArgs e)
        {
            RemoveDwmFrameOfForegroundWindow(RevModeChkBox.Checked);
            log("[Pause: " + PauseChkBox.Checked.ToString() + "]");
        }

        public bool donthide = false;

        private void ExclExtWndsChkBox_CheckedChanged(object sender, EventArgs e)
        {
            log("[ExclExtWnds:" + ExclExtWndsChkBox.Checked.ToString() + "]");
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
                log("[UI Visibility: " + Visible.ToString() + "]");
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

        private const int DWMWA_NCRENDERING_POLICY = 2;
        private const int DWMNCRP_DISABLED = 1;
        private const int DWMNCRP_ENABLED = 0;

        private void RemoveDwmFrameOfForegroundWindow(Boolean revert)
        {
            var policyParameter = DWMNCRP_DISABLED;
            if (ExclListBox.FindString(GetProcessNameOfHwnd(GetForegroundWindow())) == ListBox.NoMatches)
            {
                if (revert)
                {
                    policyParameter = DWMNCRP_ENABLED;
                }

                DwmSetWindowAttribute(GetForegroundWindow(), DWMWA_NCRENDERING_POLICY, ref policyParameter, sizeof(int));
            }
        }

        private void RemoveDwmFrameByHwnd(IntPtr hwnd, Boolean revert)
        {
            var policyParameter = DWMNCRP_DISABLED;
            if (ExclListBox.FindString(GetProcessNameOfHwnd(hwnd)) == ListBox.NoMatches)
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

        private const uint WINEVENT_OUTOFCONTEXT = 0;
        private const uint EVENT_SYSTEM_FOREGROUND = 3;
        private const uint EVENT_SYSTEM_MINIMIZEEND = 23;
        private const uint EVENT_OBJECT_CREATE = 0x8000;

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        private string GetActiveWindowTitle()
        {
            const int nChars = 256;
            IntPtr handle = IntPtr.Zero;
            StringBuilder Buff = new StringBuilder(nChars);
            handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }

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

        public void log(string str)
        {
            if (DoLogChkBox.Checked)
            {
                logs += string.Format("\n{0} : " + str, DateTime.Now);
            }
        }
    }
}
