namespace OnvifAssistant
{
    partial class FormOnvif
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelVideo = new System.Windows.Forms.Panel();
            this.textLog = new System.Windows.Forms.TextBox();
            this.tabLog = new System.Windows.Forms.TabControl();
            this.tabPageCams = new System.Windows.Forms.TabPage();
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.btnPlay = new System.Windows.Forms.PictureBox();
            this.btnRecord = new System.Windows.Forms.Button();
            this.btnSnapshot = new System.Windows.Forms.Button();
            this.labelDeviceInfo = new System.Windows.Forms.Label();
            this.groupBoxDeviceInfo = new System.Windows.Forms.GroupBox();
            this.tabLog.SuspendLayout();
            this.tabPageCams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlay)).BeginInit();
            this.groupBoxDeviceInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelVideo
            // 
            this.panelVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelVideo.Location = new System.Drawing.Point(321, 22);
            this.panelVideo.Name = "panelVideo";
            this.panelVideo.Size = new System.Drawing.Size(773, 523);
            this.panelVideo.TabIndex = 0;
            // 
            // textLog
            // 
            this.textLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textLog.Location = new System.Drawing.Point(3, 3);
            this.textLog.Multiline = true;
            this.textLog.Name = "textLog";
            this.textLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textLog.Size = new System.Drawing.Size(308, 285);
            this.textLog.TabIndex = 1;
            // 
            // tabLog
            // 
            this.tabLog.Controls.Add(this.tabPageCams);
            this.tabLog.Controls.Add(this.tabPageLog);
            this.tabLog.Location = new System.Drawing.Point(-7, 306);
            this.tabLog.Name = "tabLog";
            this.tabLog.SelectedIndex = 0;
            this.tabLog.Size = new System.Drawing.Size(322, 317);
            this.tabLog.TabIndex = 2;
            // 
            // tabPageCams
            // 
            this.tabPageCams.Controls.Add(this.textLog);
            this.tabPageCams.Location = new System.Drawing.Point(4, 22);
            this.tabPageCams.Name = "tabPageCams";
            this.tabPageCams.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCams.Size = new System.Drawing.Size(314, 291);
            this.tabPageCams.TabIndex = 0;
            this.tabPageCams.Text = "Cameras";
            this.tabPageCams.UseVisualStyleBackColor = true;
            // 
            // tabPageLog
            // 
            this.tabPageLog.Location = new System.Drawing.Point(4, 22);
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLog.Size = new System.Drawing.Size(314, 537);
            this.tabPageLog.TabIndex = 1;
            this.tabPageLog.Text = "Log";
            this.tabPageLog.UseVisualStyleBackColor = true;
            // 
            // btnPlay
            // 
            this.btnPlay.Enabled = false;
            this.btnPlay.Location = new System.Drawing.Point(675, 562);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(0);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(60, 48);
            this.btnPlay.TabIndex = 5;
            this.btnPlay.TabStop = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnRecord
            // 
            this.btnRecord.Enabled = false;
            this.btnRecord.Location = new System.Drawing.Point(915, 562);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(81, 48);
            this.btnRecord.TabIndex = 6;
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Visible = false;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // btnSnapshot
            // 
            this.btnSnapshot.Enabled = false;
            this.btnSnapshot.Location = new System.Drawing.Point(1002, 562);
            this.btnSnapshot.Name = "btnSnapshot";
            this.btnSnapshot.Size = new System.Drawing.Size(81, 48);
            this.btnSnapshot.TabIndex = 7;
            this.btnSnapshot.UseVisualStyleBackColor = true;
            this.btnSnapshot.Visible = false;
            // 
            // labelDeviceInfo
            // 
            this.labelDeviceInfo.AutoSize = true;
            this.labelDeviceInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDeviceInfo.Location = new System.Drawing.Point(3, 16);
            this.labelDeviceInfo.Name = "labelDeviceInfo";
            this.labelDeviceInfo.Size = new System.Drawing.Size(0, 13);
            this.labelDeviceInfo.TabIndex = 0;
            // 
            // groupBoxDeviceInfo
            // 
            this.groupBoxDeviceInfo.Controls.Add(this.labelDeviceInfo);
            this.groupBoxDeviceInfo.Enabled = false;
            this.groupBoxDeviceInfo.Location = new System.Drawing.Point(4, 12);
            this.groupBoxDeviceInfo.Name = "groupBoxDeviceInfo";
            this.groupBoxDeviceInfo.Size = new System.Drawing.Size(311, 288);
            this.groupBoxDeviceInfo.TabIndex = 8;
            this.groupBoxDeviceInfo.TabStop = false;
            this.groupBoxDeviceInfo.Text = "Device Information";
            this.groupBoxDeviceInfo.Visible = false;
            // 
            // FormOnvif
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 616);
            this.Controls.Add(this.groupBoxDeviceInfo);
            this.Controls.Add(this.btnSnapshot);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.tabLog);
            this.Controls.Add(this.panelVideo);
            this.Name = "FormOnvif";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Camera Detector";
            this.tabLog.ResumeLayout(false);
            this.tabPageCams.ResumeLayout(false);
            this.tabPageCams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlay)).EndInit();
            this.groupBoxDeviceInfo.ResumeLayout(false);
            this.groupBoxDeviceInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelVideo;
        private System.Windows.Forms.TextBox textLog;
        private System.Windows.Forms.TabControl tabLog;
        private System.Windows.Forms.TabPage tabPageCams;
        private System.Windows.Forms.TabPage tabPageLog;
        private System.Windows.Forms.PictureBox btnPlay;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Button btnSnapshot;
        private System.Windows.Forms.Label labelDeviceInfo;
        private System.Windows.Forms.GroupBox groupBoxDeviceInfo;
    }
}