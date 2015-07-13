namespace SDK.English.JlcScan {

	partial class UI {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.MainMenu mainMenu1;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.lblLogo = new System.Windows.Forms.Label();
			this.containerPanel = new System.Windows.Forms.Panel();
			this.scanPanel = new System.Windows.Forms.Panel();
			this.lblScanResult = new System.Windows.Forms.Label();
			this.lblScanSum = new System.Windows.Forms.Label();
			this.labelScanInfo = new System.Windows.Forms.Label();
			this.btnScan = new System.Windows.Forms.Button();
			this.loadPanel = new System.Windows.Forms.Panel();
			this.lblInfo = new System.Windows.Forms.Label();
			this.btnLoadFile = new System.Windows.Forms.Button();
			this.containerPanel.SuspendLayout();
			this.scanPanel.SuspendLayout();
			this.loadPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblLogo
			// 
			this.lblLogo.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
			this.lblLogo.ForeColor = System.Drawing.Color.CadetBlue;
			this.lblLogo.Location = new System.Drawing.Point(0, 5);
			this.lblLogo.Name = "lblLogo";
			this.lblLogo.Size = new System.Drawing.Size(238, 25);
			this.lblLogo.Text = "JUDY LANE CONSULTING";
			this.lblLogo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// containerPanel
			// 
			this.containerPanel.BackColor = System.Drawing.Color.Lavender;
			this.containerPanel.Controls.Add(this.scanPanel);
			this.containerPanel.Controls.Add(this.lblLogo);
			this.containerPanel.Controls.Add(this.loadPanel);
			this.containerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.containerPanel.Location = new System.Drawing.Point(0, 0);
			this.containerPanel.Name = "containerPanel";
			this.containerPanel.Size = new System.Drawing.Size(238, 295);
			// 
			// scanPanel
			// 
			this.scanPanel.BackColor = System.Drawing.Color.RoyalBlue;
			this.scanPanel.Controls.Add(this.lblScanResult);
			this.scanPanel.Controls.Add(this.lblScanSum);
			this.scanPanel.Controls.Add(this.labelScanInfo);
			this.scanPanel.Controls.Add(this.btnScan);
			this.scanPanel.Location = new System.Drawing.Point(0, 31);
			this.scanPanel.Name = "scanPanel";
			this.scanPanel.Size = new System.Drawing.Size(238, 236);
			this.scanPanel.Visible = false;
			// 
			// lblScanResult
			// 
			this.lblScanResult.BackColor = System.Drawing.Color.RoyalBlue;
			this.lblScanResult.Location = new System.Drawing.Point(8, 112);
			this.lblScanResult.Name = "lblScanResult";
			this.lblScanResult.Size = new System.Drawing.Size(224, 44);
			// 
			// lblScanSum
			// 
			this.lblScanSum.BackColor = System.Drawing.Color.RoyalBlue;
			this.lblScanSum.Location = new System.Drawing.Point(36, 181);
			this.lblScanSum.Name = "lblScanSum";
			this.lblScanSum.Size = new System.Drawing.Size(44, 20);
			this.lblScanSum.Text = "0";
			// 
			// labelScanInfo
			// 
			this.labelScanInfo.BackColor = System.Drawing.Color.RoyalBlue;
			this.labelScanInfo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.labelScanInfo.Location = new System.Drawing.Point(0, 20);
			this.labelScanInfo.Name = "labelScanInfo";
			this.labelScanInfo.Size = new System.Drawing.Size(235, 45);
			this.labelScanInfo.Text = "Scan the Badge";
			this.labelScanInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.labelScanInfo.ParentChanged += new System.EventHandler(this.labelScanInfo_ParentChanged);
			// 
			// btnScan
			// 
			this.btnScan.Location = new System.Drawing.Point(56, 68);
			this.btnScan.Name = "btnScan";
			this.btnScan.Size = new System.Drawing.Size(124, 20);
			this.btnScan.TabIndex = 2;
			this.btnScan.Text = "Scan";
			this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
			// 
			// loadPanel
			// 
			this.loadPanel.BackColor = System.Drawing.Color.CadetBlue;
			this.loadPanel.Controls.Add(this.lblInfo);
			this.loadPanel.Controls.Add(this.btnLoadFile);
			this.loadPanel.Location = new System.Drawing.Point(0, 35);
			this.loadPanel.Name = "loadPanel";
			this.loadPanel.Size = new System.Drawing.Size(265, 232);
			// 
			// lblInfo
			// 
			this.lblInfo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lblInfo.Location = new System.Drawing.Point(0, 20);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(238, 45);
			this.lblInfo.Text = "Select the Venture Event Data File for this event:";
			this.lblInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// btnLoadFile
			// 
			this.btnLoadFile.Location = new System.Drawing.Point(56, 68);
			this.btnLoadFile.Name = "btnLoadFile";
			this.btnLoadFile.Size = new System.Drawing.Size(124, 20);
			this.btnLoadFile.TabIndex = 2;
			this.btnLoadFile.Text = "Select Data File";
			this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
			// 
			// UI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(238, 295);
			this.Controls.Add(this.containerPanel);
			this.ForeColor = System.Drawing.Color.White;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "UI";
			this.Text = "JLC Scan";
			this.Load += new System.EventHandler(this.Ui_Load);
			this.Closed += new System.EventHandler(this.Ui_Closed);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Ui_KeyPress);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Ui_KeyUp);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ui_KeyDown);
			this.containerPanel.ResumeLayout(false);
			this.scanPanel.ResumeLayout(false);
			this.loadPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblLogo;
		private System.Windows.Forms.Panel containerPanel;
		private System.Windows.Forms.Panel loadPanel;
		private System.Windows.Forms.Button btnLoadFile;
		private System.Windows.Forms.Label lblInfo;
		private System.Windows.Forms.Panel scanPanel;
		private System.Windows.Forms.Label labelScanInfo;
		private System.Windows.Forms.Button btnScan;
		private System.Windows.Forms.Label lblScanSum;
		private System.Windows.Forms.Label lblScanResult;
	}
}