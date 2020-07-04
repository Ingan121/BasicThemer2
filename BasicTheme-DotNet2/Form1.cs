using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace BasicTheme_DotNet2
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
        }

        [DllImport("DwmApi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int dwAttribute, ref int pvAttribute, int cbAttribute);

        private const int DWMWA_NCRENDERING_POLICY = 2;
        private const int DWMNCRP_DISABLED = 1;
        private const int DWMNCRP_ENABLED = 0;

        private void RemoveDwmFrame(Boolean revert)
        {
            var policyParameter = DWMNCRP_DISABLED;
            if (!revert)
            {
                policyParameter = DWMNCRP_ENABLED;
            }

            DwmSetWindowAttribute(GetForegroundWindow(), DWMWA_NCRENDERING_POLICY, ref policyParameter, sizeof(int));
        }

        delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);

        [DllImport("user32.dll")]
        static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);

        private const uint WINEVENT_OUTOFCONTEXT = 0;
        private const uint EVENT_SYSTEM_FOREGROUND = 3;
        private const uint EVENT_SYSTEM_MINIMIZEEND = 23;

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

        public void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            try
            {
                Log .AppendText(GetActiveWindowTitle() + " (");
                RECT rct;

                if (!GetClientRect(GetForegroundWindow(), out rct))
                {
                    Log.AppendText("==ERROR in GetClientRect==");
                    return;
                }

                ClientHeight = rct.Bottom - rct.Top + 1;
                Log.AppendText(ClientHeight + ", ");

                if (!GetWindowRect(GetForegroundWindow(), out rct))
                {
                    Log.AppendText("==ERROR in GetWindowRect==");
                    return;
                }

                WindowHeight = rct.Bottom - rct.Top + 1;
                Log.AppendText(WindowHeight + ", ");
                HeightDifference = WindowHeight - ClientHeight;
                Log.AppendText(HeightDifference + ", ");
                if (WindowHeight - ClientHeight <= SystemInformation.CaptionHeight)
                {
                    Log.AppendText("Extended)\r\n");
                    Extended = true;
                } else
                {
                    Log.AppendText("Not extended)\r\n");
                    Extended = false;
                }
                if(!Extended | !ExclExtWndsChkBox.Checked) RemoveDwmFrame(!RevModeChkBox.Checked);
                //Log.AppendText("          [" + Extended.ToString() + ", " + ExclExtWndsChkBox.Checked.ToString() + "]\r\n");
            } catch {}
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.allowshowdisplay = true;
            this .Visible = true;
            this.BringToFront();
            this.WindowState = FormWindowState.Normal;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void ExitWndBtn_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void RevModeChkBox_CheckedChanged(object sender, EventArgs e)
        {
            RemoveDwmFrame(!RevModeChkBox.Checked);
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

        private void Form1_Load(object sender, EventArgs e)
        {
            Visible = false;
        }

        private bool allowshowdisplay = false;

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(allowshowdisplay ? value : allowshowdisplay);
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.allowshowdisplay = true;
                this.Visible = !this.Visible;
            }
        }
    }
}
