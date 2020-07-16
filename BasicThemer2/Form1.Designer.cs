namespace BasicThemer2
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label2 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitWndBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
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
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Exclusions (WIP)";
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(105, 48);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.showToolStripMenuItem.Text = "&Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // ExitWndBtn
            // 
            this.ExitWndBtn.Location = new System.Drawing.Point(154, 297);
            this.ExitWndBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExitWndBtn.Name = "ExitWndBtn";
            this.ExitWndBtn.Size = new System.Drawing.Size(145, 26);
            this.ExitWndBtn.TabIndex = 5;
            this.ExitWndBtn.Text = "&Exit";
            this.ExitWndBtn.UseVisualStyleBackColor = true;
            this.ExitWndBtn.Click += new System.EventHandler(this.ExitWndBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 327);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(198, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "BasicThemer 2 v0.4.2 by Ingan121";
            // 
            // RevModeChkBox
            // 
            this.RevModeChkBox.AutoSize = true;
            this.RevModeChkBox.Location = new System.Drawing.Point(154, 256);
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
            this.ExclExtWndsChkBox.Location = new System.Drawing.Point(10, 238);
            this.ExclExtWndsChkBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExclExtWndsChkBox.Name = "ExclExtWndsChkBox";
            this.ExclExtWndsChkBox.Size = new System.Drawing.Size(288, 16);
            this.ExclExtWndsChkBox.TabIndex = 8;
            this.ExclExtWndsChkBox.Text = "Exclude all windows with extended &client area";
            this.ExclExtWndsChkBox.UseVisualStyleBackColor = true;
            // 
            // PauseChkBox
            // 
            this.PauseChkBox.AutoSize = true;
            this.PauseChkBox.Location = new System.Drawing.Point(10, 257);
            this.PauseChkBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PauseChkBox.Name = "PauseChkBox";
            this.PauseChkBox.Size = new System.Drawing.Size(60, 16);
            this.PauseChkBox.TabIndex = 9;
            this.PauseChkBox.Text = "&Pause";
            this.PauseChkBox.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(255, 327);
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
            this.DoLogChkBox.Location = new System.Drawing.Point(10, 277);
            this.DoLogChkBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DoLogChkBox.Name = "DoLogChkBox";
            this.DoLogChkBox.Size = new System.Drawing.Size(235, 16);
            this.DoLogChkBox.TabIndex = 11;
            this.DoLogChkBox.Text = "Enable &Logging (Unstable and slow!)";
            this.DoLogChkBox.UseVisualStyleBackColor = true;
            // 
            // OpenLogBtn
            // 
            this.OpenLogBtn.Location = new System.Drawing.Point(10, 297);
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
            "chrome.exe"});
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 346);
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
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ExitWndBtn);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "BasicThemer 2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button ExitWndBtn;
        private System.Windows.Forms.Label label4;
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
    }
}

