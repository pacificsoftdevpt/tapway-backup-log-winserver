namespace BackupSaleFromLog
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonChangePath = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.buttonChangeVenueID = new System.Windows.Forms.Button();
            this.txtVenueID = new System.Windows.Forms.TextBox();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSendData = new System.Windows.Forms.Button();
            this.labelNotiEnterVenue = new System.Windows.Forms.Label();
            this.labelNotiEnterPath = new System.Windows.Forms.Label();
            this.progressBarLoading = new System.Windows.Forms.ProgressBar();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemShow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonChangePath
            // 
            this.buttonChangePath.Location = new System.Drawing.Point(12, 12);
            this.buttonChangePath.Name = "buttonChangePath";
            this.buttonChangePath.Size = new System.Drawing.Size(75, 24);
            this.buttonChangePath.TabIndex = 1;
            this.buttonChangePath.Text = "Path";
            this.buttonChangePath.UseVisualStyleBackColor = true;
            this.buttonChangePath.Click += new System.EventHandler(this.buttonChangePath_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(93, 15);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(290, 20);
            this.txtPath.TabIndex = 2;
            // 
            // buttonChangeVenueID
            // 
            this.buttonChangeVenueID.Location = new System.Drawing.Point(12, 73);
            this.buttonChangeVenueID.Name = "buttonChangeVenueID";
            this.buttonChangeVenueID.Size = new System.Drawing.Size(75, 23);
            this.buttonChangeVenueID.TabIndex = 3;
            this.buttonChangeVenueID.Text = "Venue ID";
            this.buttonChangeVenueID.UseVisualStyleBackColor = true;
            this.buttonChangeVenueID.Click += new System.EventHandler(this.buttonChangeVenueID_Click);
            // 
            // txtVenueID
            // 
            this.txtVenueID.Location = new System.Drawing.Point(93, 75);
            this.txtVenueID.Name = "txtVenueID";
            this.txtVenueID.ReadOnly = true;
            this.txtVenueID.Size = new System.Drawing.Size(290, 20);
            this.txtVenueID.TabIndex = 4;
            this.txtVenueID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVenueID_KeyPress);
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.CustomFormat = "dd-MMM-yyyy";
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStart.Location = new System.Drawing.Point(93, 133);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(290, 20);
            this.dateTimePickerStart.TabIndex = 5;
            this.dateTimePickerStart.ValueChanged += new System.EventHandler(this.dateTimePickerStart_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Start Date";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.CustomFormat = "dd-MMM-yyyy";
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(93, 179);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(290, 20);
            this.dateTimePickerEnd.TabIndex = 7;
            this.dateTimePickerEnd.ValueChanged += new System.EventHandler(this.dateTimePickerEnd_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "End Date";
            // 
            // buttonSendData
            // 
            this.buttonSendData.Location = new System.Drawing.Point(162, 232);
            this.buttonSendData.Name = "buttonSendData";
            this.buttonSendData.Size = new System.Drawing.Size(75, 23);
            this.buttonSendData.TabIndex = 9;
            this.buttonSendData.Text = "Send Data";
            this.buttonSendData.UseVisualStyleBackColor = true;
            this.buttonSendData.Click += new System.EventHandler(this.buttonSendData_Click);
            // 
            // labelNotiEnterVenue
            // 
            this.labelNotiEnterVenue.AutoSize = true;
            this.labelNotiEnterVenue.ForeColor = System.Drawing.Color.Red;
            this.labelNotiEnterVenue.Location = new System.Drawing.Point(90, 98);
            this.labelNotiEnterVenue.Name = "labelNotiEnterVenue";
            this.labelNotiEnterVenue.Size = new System.Drawing.Size(147, 13);
            this.labelNotiEnterVenue.TabIndex = 10;
            this.labelNotiEnterVenue.Text = "Please enter a valid venue ID";
            this.labelNotiEnterVenue.Visible = false;
            // 
            // labelNotiEnterPath
            // 
            this.labelNotiEnterPath.AutoSize = true;
            this.labelNotiEnterPath.ForeColor = System.Drawing.Color.Red;
            this.labelNotiEnterPath.Location = new System.Drawing.Point(90, 38);
            this.labelNotiEnterPath.Name = "labelNotiEnterPath";
            this.labelNotiEnterPath.Size = new System.Drawing.Size(124, 13);
            this.labelNotiEnterPath.TabIndex = 11;
            this.labelNotiEnterPath.Text = "Please enter a valid path";
            this.labelNotiEnterPath.Visible = false;
            // 
            // progressBarLoading
            // 
            this.progressBarLoading.Location = new System.Drawing.Point(15, 217);
            this.progressBarLoading.Name = "progressBarLoading";
            this.progressBarLoading.Size = new System.Drawing.Size(368, 9);
            this.progressBarLoading.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarLoading.TabIndex = 12;
            this.progressBarLoading.Visible = false;
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipTitle = "Tapway Sale Backup Log";
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Tapway Sale Backup Log";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemShow,
            this.toolStripMenuItemExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 48);
            // 
            // toolStripMenuItemShow
            // 
            this.toolStripMenuItemShow.Name = "toolStripMenuItemShow";
            this.toolStripMenuItemShow.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItemShow.Text = "Show";
            this.toolStripMenuItemShow.Click += new System.EventHandler(this.toolStripMenuItemShow_Click);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItemExit.Text = "Exit";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Location = new System.Drawing.Point(12, 279);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.ReadOnly = true;
            this.richTextBoxLog.Size = new System.Drawing.Size(371, 77);
            this.richTextBoxLog.TabIndex = 13;
            this.richTextBoxLog.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Log";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(12, 368);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(261, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "The program will auto send data every day at midnight";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 390);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBoxLog);
            this.Controls.Add(this.progressBarLoading);
            this.Controls.Add(this.labelNotiEnterPath);
            this.Controls.Add(this.labelNotiEnterVenue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonSendData);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.txtVenueID);
            this.Controls.Add(this.buttonChangeVenueID);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.buttonChangePath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "BackupSaleFromLog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonChangePath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button buttonChangeVenueID;
        private System.Windows.Forms.TextBox txtVenueID;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSendData;
        private System.Windows.Forms.Label labelNotiEnterVenue;
        private System.Windows.Forms.Label labelNotiEnterPath;
        private System.Windows.Forms.ProgressBar progressBarLoading;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShow;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

