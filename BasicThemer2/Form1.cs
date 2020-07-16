using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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

        public Form1()
        {
            InitializeComponent();
            dele = new WinEventDelegate(WinEventProc);
            SetWinEventHook(EVENT_SYSTEM_FOREGROUND, EVENT_SYSTEM_FOREGROUND, IntPtr.Zero, dele, 0, 0, WINEVENT_OUTOFCONTEXT);
            SetWinEventHook(EVENT_SYSTEM_MINIMIZEEND, EVENT_SYSTEM_MINIMIZEEND, IntPtr.Zero, dele, 0, 0, WINEVENT_OUTOFCONTEXT);
            SetWinEventHook(EVENT_OBJECT_CREATE, EVENT_OBJECT_CREATE, IntPtr.Zero, dele, 0, 0, WINEVENT_OUTOFCONTEXT);
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

        delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);

        [DllImport("user32.dll")]
        static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);

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

        int ClientHeight, WindowHeight, HeightDifference;
        bool Extended = false;

        public string ReturnEmptyIfSo(String str) => string.IsNullOrEmpty(str) ? "{Empty}" : str;

        public void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            if (!PauseChkBox.Checked)
            {
                /* For foreground windows: */
                try
                {
                    if (!GetClientRect(GetForegroundWindow(), out RECT rct))
                    {
                        if (DoLogChkBox.Checked) using (StreamWriter writer = new StreamWriter(File.Open("BasicThemer2.log", FileMode.Append)))
                        {
                            TextWriterTraceListener listener = new TextWriterTraceListener(writer);
                            Debug.Listeners.Add(listener);
                            Debug.WriteLine(string.Format("{0} : [FG: ERROR in GetClientRect]", DateTime.Now));
                        }
                        return;
                    }
                    ClientHeight = rct.Bottom - rct.Top + 1;

                    if (!GetWindowRect(GetForegroundWindow(), out rct))
                    {
                        if (DoLogChkBox.Checked) using (StreamWriter writer = new StreamWriter(File.Open("BasicThemer2.log", FileMode.Append)))
                        {
                            TextWriterTraceListener listener = new TextWriterTraceListener(writer);
                            Debug.Listeners.Add(listener);
                            Debug.WriteLine(string.Format("{0} : [FG: ERROR in GetWindowRect]", DateTime.Now));
                        }
                        return;
                    }
                    WindowHeight = rct.Bottom - rct.Top + 1;
                    
                    HeightDifference = WindowHeight - ClientHeight;
                    Extended = WindowHeight - ClientHeight <= SystemInformation.CaptionHeight;
                    
                    if (!Extended | !ExclExtWndsChkBox.Checked) RemoveDwmFrameOfForegroundWindow(RevModeChkBox.Checked);
                    //Log.AppendText("          [" + Extended.ToString() + ", " + ExclExtWndsChkBox.Checked.ToString() + "]\r\n");

                    if (DoLogChkBox.Checked) using (StreamWriter writer = new StreamWriter(File.Open("BasicThemer2.log", FileMode.Append)))
                    {
                        TextWriterTraceListener listener = new TextWriterTraceListener(writer);
                        Debug.Listeners.Add(listener);
                        Debug.WriteLine(string.Format("{0} : [FG] " + ReturnEmptyIfSo(GetActiveWindowTitle()) + " / " + ReturnEmptyIfSo(GetProcessNameOfHwnd(GetForegroundWindow())) + " (" + ClientHeight + ", " + WindowHeight + ", " + HeightDifference + ", " + (Extended ? "Extended" : "Not extended") + ")", DateTime.Now));
                    }
                }
                catch { /* Ignored */ }

                /* For background windows: */
                try
                {
                    if (!DoLogChkBox.Checked)
                    {
                        Thread.Sleep(20);
                    }

                    if (!GetClientRect(hwnd, out RECT rct))
                    {
                        if (DoLogChkBox.Checked) using (StreamWriter writer = new StreamWriter(File.Open("BasicThemer2.log", FileMode.Append)))
                        {
                            TextWriterTraceListener listener = new TextWriterTraceListener(writer);
                            Debug.Listeners.Add(listener);
                            Debug.WriteLine(string.Format("{0} : [BG: ERROR in GetClientRect]", DateTime.Now));
                        }
                        return;
                    }
                    ClientHeight = rct.Bottom - rct.Top + 1;

                    if (!GetWindowRect(hwnd, out rct))
                    {
                        if (DoLogChkBox.Checked) using (StreamWriter writer = new StreamWriter(File.Open("BasicThemer2.log", FileMode.Append)))
                        {
                            TextWriterTraceListener listener = new TextWriterTraceListener(writer);
                            Debug.Listeners.Add(listener);
                            Debug.WriteLine(string.Format("{0} : [BG: ERROR in GetWindowRect]", DateTime.Now));
                        }
                        return;
                    }
                    WindowHeight = rct.Bottom - rct.Top + 1;
                    
                    HeightDifference = WindowHeight - ClientHeight;
                    Extended = WindowHeight - ClientHeight <= SystemInformation.CaptionHeight;
                    
                    if ((!Extended | !ExclExtWndsChkBox.Checked)) RemoveDwmFrameByHwnd(hwnd, RevModeChkBox.Checked);
                    
                    if (DoLogChkBox.Checked) using (StreamWriter writer = new StreamWriter(File.Open("BasicThemer2.log", FileMode.Append)))
                    {
                        TextWriterTraceListener listener = new TextWriterTraceListener(writer);
                        Debug.Listeners.Add(listener);
                        Debug.WriteLine(string.Format("{0} : [BG] " + ReturnEmptyIfSo(GetWindowTitleOfHwnd(hwnd)) + " / " + ReturnEmptyIfSo(GetProcessNameOfHwnd(hwnd)) + " (" + ClientHeight + ", " + WindowHeight + ", " + HeightDifference + ", " + (Extended ? "Extended)" : "Not extended" + ")"), DateTime.Now));
                    }
                }
                catch { /* Ignored */ }
            }
        }
            
        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.allowshowdisplay = true;
            this .Visible = true;
            this.BringToFront();
            this.WindowState = FormWindowState.Normal;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Exit();

        private void ExitWndBtn_Click(object sender, EventArgs e) => Exit();

        private void RevModeChkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!PauseChkBox.Checked)
            {
                RemoveDwmFrameOfForegroundWindow(!RevModeChkBox.Checked);
            }
        }

        public void Exit()
        {
            this.Close();
            this.Dispose();
            Properties.Settings.Default.Save();
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e) => Visible = false;

        private bool allowshowdisplay = false;

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("https://github.com/Ingan121/BasicThemer2");

        private void OpenLogBtn_Click(object sender, EventArgs e)
        {
            DoLogChkBox.Checked = false;
            Process.Start("BasicThemer2.log");
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            ExclListBox.Items.Add(ExclAddNameBox.Text.EndsWith(".exe") ? ExclAddNameBox.Text : ExclAddNameBox.Text + ".exe");
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

        protected override void SetVisibleCore(bool value) => base.SetVisibleCore(allowshowdisplay ? value : allowshowdisplay);

        private void NotifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.allowshowdisplay = true;
                this.Visible = !this.Visible;
            }
        }
    }
}
