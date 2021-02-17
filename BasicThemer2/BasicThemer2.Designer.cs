namespace BasicThemer2
{
    partial class BasicThemer2
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasicThemer2));
            this.ExclsOrInclsLabel = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitWndBtn = new System.Windows.Forms.Button();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.RevModeChkBox = new System.Windows.Forms.CheckBox();
            this.ExclExtWndsChkBox = new System.Windows.Forms.CheckBox();
            this.PauseChkBox = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.DoLogChkBox = new System.Windows.Forms.CheckBox();
            this.OpenLogBtn = new System.Windows.Forms.Button();
            this.ExclListBox = new System.Windows.Forms.ListBox();
            this.ExclAddNameBox = new System.Windows.Forms.TextBox();
            this.AddBtn = new System.Windows.Forms.Button();
            this.DelBtn = new System.Windows.Forms.Button();
            this.dbgBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TimerSpeedBox = new System.Windows.Forms.TextBox();
            this.MsOrErrLabel = new System.Windows.Forms.Label();
            this.WhitelistModeChkBox = new System.Windows.Forms.CheckBox();
            this.AutoUpdChkChkBox = new System.Windows.Forms.CheckBox();
            this.UpdChkBtn = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExclsOrInclsLabel
            // 
            this.ExclsOrInclsLabel.AutoSize = true;
            this.ExclsOrInclsLabel.Location = new System.Drawing.Point(10, 7);
            this.ExclsOrInclsLabel.Name = "ExclsOrInclsLabel";
            this.ExclsOrInclsLabel.Size = new System.Drawing.Size(68, 12);
            this.ExclsOrInclsLabel.TabIndex = 2;
            this.ExclsOrInclsLabel.Text = "Exclusions";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "BasicThemer 2";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 48);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.showToolStripMenuItem.Text = "&Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // ExitWndBtn
            // 
            this.ExitWndBtn.Location = new System.Drawing.Point(154, 315);
            this.ExitWndBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExitWndBtn.Name = "ExitWndBtn";
            this.ExitWndBtn.Size = new System.Drawing.Size(145, 26);
            this.ExitWndBtn.TabIndex = 5;
            this.ExitWndBtn.Text = "&Exit";
            this.ExitWndBtn.UseVisualStyleBackColor = true;
            this.ExitWndBtn.Click += new System.EventHandler(this.ExitWndBtn_Click);
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.Location = new System.Drawing.Point(10, 345);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(201, 12);
            this.InfoLabel.TabIndex = 6;
            this.InfoLabel.Text = "BasicThemer 2 v{ver} by Ingan121";
            // 
            // RevModeChkBox
            // 
            this.RevModeChkBox.AutoSize = true;
            this.RevModeChkBox.Location = new System.Drawing.Point(154, 252);
            this.RevModeChkBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RevModeChkBox.Name = "RevModeChkBox";
            this.RevModeChkBox.Size = new System.Drawing.Size(112, 16);
            this.RevModeChkBox.TabIndex = 7;
            this.RevModeChkBox.Text = "&Reverting Mode";
            this.RevModeChkBox.UseVisualStyleBackColor = true;
            this.RevModeChkBox.CheckedChanged += new System.EventHandler(this.RevModeChkBox_CheckedChanged);
            // 
            // ExclExtWndsChkBox
            // 
            this.ExclExtWndsChkBox.AutoSize = true;
            this.ExclExtWndsChkBox.Checked = true;
            this.ExclExtWndsChkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ExclExtWndsChkBox.Location = new System.Drawing.Point(10, 234);
            this.ExclExtWndsChkBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExclExtWndsChkBox.Name = "ExclExtWndsChkBox";
            this.ExclExtWndsChkBox.Size = new System.Drawing.Size(288, 16);
            this.ExclExtWndsChkBox.TabIndex = 8;
            this.ExclExtWndsChkBox.Text = "Exclude all windows with extended &client area";
            this.ExclExtWndsChkBox.UseVisualStyleBackColor = true;
            this.ExclExtWndsChkBox.CheckedChanged += new System.EventHandler(this.ExclExtWndsChkBox_CheckedChanged);
            // 
            // PauseChkBox
            // 
            this.PauseChkBox.AutoSize = true;
            this.PauseChkBox.Location = new System.Drawing.Point(10, 253);
            this.PauseChkBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PauseChkBox.Name = "PauseChkBox";
            this.PauseChkBox.Size = new System.Drawing.Size(60, 16);
            this.PauseChkBox.TabIndex = 9;
            this.PauseChkBox.Text = "&Pause";
            this.PauseChkBox.UseVisualStyleBackColor = true;
            this.PauseChkBox.CheckedChanged += new System.EventHandler(this.PauseChkBox_CheckedChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(255, 345);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(42, 12);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "&GitHub";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // DoLogChkBox
            // 
            this.DoLogChkBox.AutoSize = true;
            this.DoLogChkBox.Location = new System.Drawing.Point(10, 273);
            this.DoLogChkBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DoLogChkBox.Name = "DoLogChkBox";
            this.DoLogChkBox.Size = new System.Drawing.Size(112, 16);
            this.DoLogChkBox.TabIndex = 11;
            this.DoLogChkBox.Text = "Enable &Logging";
            this.DoLogChkBox.UseVisualStyleBackColor = true;
            this.DoLogChkBox.CheckedChanged += new System.EventHandler(this.DoLogChkBox_CheckedChanged);
            // 
            // OpenLogBtn
            // 
            this.OpenLogBtn.Location = new System.Drawing.Point(10, 315);
            this.OpenLogBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OpenLogBtn.Name = "OpenLogBtn";
            this.OpenLogBtn.Size = new System.Drawing.Size(138, 26);
            this.OpenLogBtn.TabIndex = 12;
            this.OpenLogBtn.Text = "&Open log file";
            this.OpenLogBtn.UseVisualStyleBackColor = true;
            this.OpenLogBtn.Click += new System.EventHandler(this.OpenLogBtn_Click);
            // 
            // ExclListBox
            // 
            this.ExclListBox.FormattingEnabled = true;
            this.ExclListBox.ItemHeight = 12;
            this.ExclListBox.Items.AddRange(new object[] {
            "ApplicationFrameHost.exe",
            "steam.exe",
            "mspaint.exe",
            "wordpad.exe",
            "Discord.exe",
            "code.exe",
            "MovieMaker.exe",
            "chrome.exe",
            "TreeSizeFree.exe"});
            this.ExclListBox.Location = new System.Drawing.Point(12, 22);
            this.ExclListBox.Name = "ExclListBox";
            this.ExclListBox.Size = new System.Drawing.Size(285, 172);
            this.ExclListBox.TabIndex = 13;
            // 
            // ExclAddNameBox
            // 
            this.ExclAddNameBox.Location = new System.Drawing.Point(12, 202);
            this.ExclAddNameBox.Name = "ExclAddNameBox";
            this.ExclAddNameBox.Size = new System.Drawing.Size(159, 21);
            this.ExclAddNameBox.TabIndex = 14;
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(178, 202);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(48, 23);
            this.AddBtn.TabIndex = 15;
            this.AddBtn.Text = "&Add";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // DelBtn
            // 
            this.DelBtn.Location = new System.Drawing.Point(232, 202);
            this.DelBtn.Name = "DelBtn";
            this.DelBtn.Size = new System.Drawing.Size(67, 23);
            this.DelBtn.TabIndex = 16;
            this.DelBtn.Text = "&Delete";
            this.DelBtn.UseVisualStyleBackColor = true;
            this.DelBtn.Click += new System.EventHandler(this.DelBtn_Click);
            // 
            // dbgBtn
            // 
            this.dbgBtn.Location = new System.Drawing.Point(305, 360);
            this.dbgBtn.Name = "dbgBtn";
            this.dbgBtn.Size = new System.Drawing.Size(13, 15);
            this.dbgBtn.TabIndex = 17;
            this.dbgBtn.UseVisualStyleBackColor = true;
            this.dbgBtn.Click += new System.EventHandler(this.dbgBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(152, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "Timer speed: ";
            // 
            // TimerSpeedBox
            // 
            this.TimerSpeedBox.Location = new System.Drawing.Point(234, 268);
            this.TimerSpeedBox.Name = "TimerSpeedBox";
            this.TimerSpeedBox.Size = new System.Drawing.Size(34, 21);
            this.TimerSpeedBox.TabIndex = 19;
            this.TimerSpeedBox.Text = "100";
            this.TimerSpeedBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TimerSpeedBox.TextChanged += new System.EventHandler(this.TimerSpeedBox1_TextChanged);
            // 
            // MsOrErrLabel
            // 
            this.MsOrErrLabel.AutoSize = true;
            this.MsOrErrLabel.Location = new System.Drawing.Point(272, 274);
            this.MsOrErrLabel.Name = "MsOrErrLabel";
            this.MsOrErrLabel.Size = new System.Drawing.Size(23, 12);
            this.MsOrErrLabel.TabIndex = 18;
            this.MsOrErrLabel.Text = "ms";
            // 
            // WhitelistModeChkBox
            // 
            this.WhitelistModeChkBox.AutoSize = true;
            this.WhitelistModeChkBox.Location = new System.Drawing.Point(195, 5);
            this.WhitelistModeChkBox.Name = "WhitelistModeChkBox";
            this.WhitelistModeChkBox.Size = new System.Drawing.Size(106, 16);
            this.WhitelistModeChkBox.TabIndex = 20;
            this.WhitelistModeChkBox.Text = "Whitelist Mode";
            this.WhitelistModeChkBox.UseVisualStyleBackColor = true;
            this.WhitelistModeChkBox.CheckedChanged += new System.EventHandler(this.WhitelistModeChkBox_CheckedChanged);
            // 
            // AutoUpdChkChkBox
            // 
            this.AutoUpdChkChkBox.AutoSize = true;
            this.AutoUpdChkChkBox.Checked = true;
            this.AutoUpdChkChkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoUpdChkChkBox.Location = new System.Drawing.Point(10, 293);
            this.AutoUpdChkChkBox.Name = "AutoUpdChkChkBox";
            this.AutoUpdChkChkBox.Size = new System.Drawing.Size(100, 16);
            this.AutoUpdChkChkBox.TabIndex = 21;
            this.AutoUpdChkChkBox.Text = "Automatically";
            this.AutoUpdChkChkBox.UseVisualStyleBackColor = true;
            this.AutoUpdChkChkBox.CheckedChanged += new System.EventHandler(this.AutoUpdChkChkBox_CheckedChanged);
            // 
            // UpdChkBtn
            // 
            this.UpdChkBtn.Location = new System.Drawing.Point(105, 290);
            this.UpdChkBtn.Name = "UpdChkBtn";
            this.UpdChkBtn.Size = new System.Drawing.Size(121, 20);
            this.UpdChkBtn.TabIndex = 22;
            this.UpdChkBtn.Text = "check for updates";
            this.UpdChkBtn.UseVisualStyleBackColor = true;
            this.UpdChkBtn.Click += new System.EventHandler(this.UpdChkBtn_Click);
            // 
            // BasicThemer2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 365);
            this.Controls.Add(this.UpdChkBtn);
            this.Controls.Add(this.AutoUpdChkChkBox);
            this.Controls.Add(this.WhitelistModeChkBox);
            this.Controls.Add(this.TimerSpeedBox);
            this.Controls.Add(this.MsOrErrLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dbgBtn);
            this.Controls.Add(this.DelBtn);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.ExclAddNameBox);
            this.Controls.Add(this.ExclListBox);
            this.Controls.Add(this.OpenLogBtn);
            this.Controls.Add(this.DoLogChkBox);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.PauseChkBox);
            this.Controls.Add(this.ExclExtWndsChkBox);
            this.Controls.Add(this.RevModeChkBox);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.ExitWndBtn);
            this.Controls.Add(this.ExclsOrInclsLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "BasicThemer2";
            this.Text = "BasicThemer 2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label ExclsOrInclsLabel;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button ExitWndBtn;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.CheckBox RevModeChkBox;
        private System.Windows.Forms.CheckBox ExclExtWndsChkBox;
        private System.Windows.Forms.CheckBox PauseChkBox;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.CheckBox DoLogChkBox;
        private System.Windows.Forms.Button OpenLogBtn;
        private System.Windows.Forms.ListBox ExclListBox;
        private System.Windows.Forms.TextBox ExclAddNameBox;
        private System.Windows.Forms.Button DelBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button dbgBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TimerSpeedBox;
        private System.Windows.Forms.Label MsOrErrLabel;
        private System.Windows.Forms.CheckBox WhitelistModeChkBox;
        private System.Windows.Forms.CheckBox AutoUpdChkChkBox;
        private System.Windows.Forms.Button UpdChkBtn;
    }
}

