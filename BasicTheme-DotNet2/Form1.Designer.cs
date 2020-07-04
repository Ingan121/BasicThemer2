namespace BasicTheme_DotNet2
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
            this.Log = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitWndBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.RevModeChkBox = new System.Windows.Forms.CheckBox();
            this.ExclExtWndsChkBox = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Log
            // 
            this.Log.Location = new System.Drawing.Point(11, 31);
            this.Log.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Log.Multiline = true;
            this.Log.Name = "Log";
            this.Log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Log.Size = new System.Drawing.Size(387, 326);
            this.Log.TabIndex = 0;
            this.Log.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Logs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(417, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Exclusions";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(511, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "WIP";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "BasicThemer 2";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(116, 52);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(115, 24);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(115, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // ExitWndBtn
            // 
            this.ExitWndBtn.Location = new System.Drawing.Point(634, 391);
            this.ExitWndBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExitWndBtn.Name = "ExitWndBtn";
            this.ExitWndBtn.Size = new System.Drawing.Size(155, 46);
            this.ExitWndBtn.TabIndex = 5;
            this.ExitWndBtn.Text = "Exit";
            this.ExitWndBtn.UseVisualStyleBackColor = true;
            this.ExitWndBtn.Click += new System.EventHandler(this.ExitWndBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 422);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(223, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "BasicThemer 2 v0.2 by Ingan121";
            // 
            // RevModeChkBox
            // 
            this.RevModeChkBox.AutoSize = true;
            this.RevModeChkBox.Location = new System.Drawing.Point(15, 382);
            this.RevModeChkBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RevModeChkBox.Name = "RevModeChkBox";
            this.RevModeChkBox.Size = new System.Drawing.Size(132, 19);
            this.RevModeChkBox.TabIndex = 7;
            this.RevModeChkBox.Text = "Reverting Mode";
            this.RevModeChkBox.UseVisualStyleBackColor = true;
            this.RevModeChkBox.CheckedChanged += new System.EventHandler(this.RevModeChkBox_CheckedChanged);
            // 
            // ExclExtWndsChkBox
            // 
            this.ExclExtWndsChkBox.AutoSize = true;
            this.ExclExtWndsChkBox.Checked = true;
            this.ExclExtWndsChkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ExclExtWndsChkBox.Location = new System.Drawing.Point(421, 338);
            this.ExclExtWndsChkBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExclExtWndsChkBox.Name = "ExclExtWndsChkBox";
            this.ExclExtWndsChkBox.Size = new System.Drawing.Size(330, 19);
            this.ExclExtWndsChkBox.TabIndex = 8;
            this.ExclExtWndsChkBox.Text = "Exclude all windows with extended client area";
            this.ExclExtWndsChkBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ExclExtWndsChkBox);
            this.Controls.Add(this.RevModeChkBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ExitWndBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Log);
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

        private System.Windows.Forms.TextBox Log;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button ExitWndBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox RevModeChkBox;
        private System.Windows.Forms.CheckBox ExclExtWndsChkBox;
    }
}

