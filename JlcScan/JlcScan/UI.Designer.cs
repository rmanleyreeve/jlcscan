namespace REMedia.JlcScan {

	partial class UI {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

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
			this.lblLogo = new System.Windows.Forms.Label();
			this.containerPanel = new System.Windows.Forms.Panel();
			this.optionsPanel = new System.Windows.Forms.Panel();
			this.menuSocialEvents = new System.Windows.Forms.ComboBox();
			this.lblScanSocEventInfo = new System.Windows.Forms.Label();
			this.lblScanRegOnlyInfo = new System.Windows.Forms.Label();
			this.lblOptions = new System.Windows.Forms.Label();
			this.btnScanRegOnly = new System.Windows.Forms.Button();
			this.scanPanel = new System.Windows.Forms.Panel();
			this.lblScanFail = new System.Windows.Forms.Label();
			this.lblValid = new System.Windows.Forms.Label();
			this.btnScan = new System.Windows.Forms.Button();
			this.btnSelect = new System.Windows.Forms.Button();
			this.btnScanDone = new System.Windows.Forms.Button();
			this.labelScanInfo = new System.Windows.Forms.Label();
			this.iconBox = new System.Windows.Forms.PictureBox();
			this.lblScanResult = new System.Windows.Forms.Label();
			this.lblScanSum = new System.Windows.Forms.Label();
			this.loadPanel = new System.Windows.Forms.Panel();
			this.lblLoadFile = new System.Windows.Forms.Label();
			this.btnLoadFile = new System.Windows.Forms.Button();
			this.labelLoadWeb = new System.Windows.Forms.Label();
			this.menuEvents = new System.Windows.Forms.ComboBox();
			this.btnLoadFromWeb = new System.Windows.Forms.Button();
			this.btnScanSocialEvents = new System.Windows.Forms.Button();
			this.containerPanel.SuspendLayout();
			this.optionsPanel.SuspendLayout();
			this.scanPanel.SuspendLayout();
			this.loadPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblLogo
			// 
			this.lblLogo.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
			this.lblLogo.ForeColor = System.Drawing.Color.DarkCyan;
			this.lblLogo.Location = new System.Drawing.Point(0, 0);
			this.lblLogo.Name = "lblLogo";
			this.lblLogo.Size = new System.Drawing.Size(238, 24);
			this.lblLogo.Text = "JUDY LANE CONSULTING";
			this.lblLogo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// containerPanel
			// 
			this.containerPanel.BackColor = System.Drawing.Color.Lavender;
			this.containerPanel.Controls.Add(this.lblLogo);
			this.containerPanel.Controls.Add(this.scanPanel);
			this.containerPanel.Controls.Add(this.loadPanel);
			this.containerPanel.Controls.Add(this.optionsPanel);
			this.containerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.containerPanel.Location = new System.Drawing.Point(0, 0);
			this.containerPanel.Name = "containerPanel";
			this.containerPanel.Size = new System.Drawing.Size(238, 295);
			// 
			// optionsPanel
			// 
			this.optionsPanel.BackColor = System.Drawing.Color.CadetBlue;
			this.optionsPanel.Controls.Add(this.btnScanSocialEvents);
			this.optionsPanel.Controls.Add(this.menuSocialEvents);
			this.optionsPanel.Controls.Add(this.lblScanSocEventInfo);
			this.optionsPanel.Controls.Add(this.lblScanRegOnlyInfo);
			this.optionsPanel.Controls.Add(this.lblOptions);
			this.optionsPanel.Controls.Add(this.btnScanRegOnly);
			this.optionsPanel.Location = new System.Drawing.Point(0, 24);
			this.optionsPanel.Name = "optionsPanel";
			this.optionsPanel.Size = new System.Drawing.Size(238, 246);
			this.optionsPanel.Visible = false;
			// 
			// menuSocialEvents
			// 
			this.menuSocialEvents.Location = new System.Drawing.Point(4, 152);
			this.menuSocialEvents.Name = "menuSocialEvents";
			this.menuSocialEvents.Size = new System.Drawing.Size(228, 23);
			this.menuSocialEvents.TabIndex = 5;
			// 
			// lblScanSocEventInfo
			// 
			this.lblScanSocEventInfo.ForeColor = System.Drawing.Color.Black;
			this.lblScanSocEventInfo.Location = new System.Drawing.Point(0, 128);
			this.lblScanSocEventInfo.Name = "lblScanSocEventInfo";
			this.lblScanSocEventInfo.Size = new System.Drawing.Size(238, 20);
			this.lblScanSocEventInfo.Text = "Recording Social Event access";
			this.lblScanSocEventInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblScanRegOnlyInfo
			// 
			this.lblScanRegOnlyInfo.ForeColor = System.Drawing.Color.Black;
			this.lblScanRegOnlyInfo.Location = new System.Drawing.Point(0, 44);
			this.lblScanRegOnlyInfo.Name = "lblScanRegOnlyInfo";
			this.lblScanRegOnlyInfo.Size = new System.Drawing.Size(238, 24);
			this.lblScanRegOnlyInfo.Text = "Recording Event Registration access";
			this.lblScanRegOnlyInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblOptions
			// 
			this.lblOptions.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
			this.lblOptions.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lblOptions.Location = new System.Drawing.Point(0, 0);
			this.lblOptions.Name = "lblOptions";
			this.lblOptions.Size = new System.Drawing.Size(238, 32);
			this.lblOptions.Text = "Choose the Scanner Function:";
			this.lblOptions.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// btnScanRegOnly
			// 
			this.btnScanRegOnly.Location = new System.Drawing.Point(56, 68);
			this.btnScanRegOnly.Name = "btnScanRegOnly";
			this.btnScanRegOnly.Size = new System.Drawing.Size(124, 20);
			this.btnScanRegOnly.TabIndex = 2;
			this.btnScanRegOnly.Text = "Start Scanning";
			this.btnScanRegOnly.Click += new System.EventHandler(this.btnScanRegOnly_Click);
			// 
			// scanPanel
			// 
			this.scanPanel.BackColor = System.Drawing.Color.DarkCyan;
			this.scanPanel.Controls.Add(this.lblScanFail);
			this.scanPanel.Controls.Add(this.lblValid);
			this.scanPanel.Controls.Add(this.btnScan);
			this.scanPanel.Controls.Add(this.btnSelect);
			this.scanPanel.Controls.Add(this.btnScanDone);
			this.scanPanel.Controls.Add(this.labelScanInfo);
			this.scanPanel.Controls.Add(this.iconBox);
			this.scanPanel.Controls.Add(this.lblScanResult);
			this.scanPanel.Controls.Add(this.lblScanSum);
			this.scanPanel.Location = new System.Drawing.Point(0, 24);
			this.scanPanel.Name = "scanPanel";
			this.scanPanel.Size = new System.Drawing.Size(238, 246);
			this.scanPanel.Visible = false;
			// 
			// lblScanFail
			// 
			this.lblScanFail.BackColor = System.Drawing.Color.Lavender;
			this.lblScanFail.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
			this.lblScanFail.ForeColor = System.Drawing.Color.Black;
			this.lblScanFail.Location = new System.Drawing.Point(168, 228);
			this.lblScanFail.Name = "lblScanFail";
			this.lblScanFail.Size = new System.Drawing.Size(72, 20);
			this.lblScanFail.Text = "Failed:";
			// 
			// lblValid
			// 
			this.lblValid.BackColor = System.Drawing.Color.Lavender;
			this.lblValid.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
			this.lblValid.ForeColor = System.Drawing.Color.Black;
			this.lblValid.Location = new System.Drawing.Point(92, 228);
			this.lblValid.Name = "lblValid";
			this.lblValid.Size = new System.Drawing.Size(76, 20);
			this.lblValid.Text = "Valid:";
			// 
			// btnScan
			// 
			this.btnScan.Location = new System.Drawing.Point(4, 32);
			this.btnScan.Name = "btnScan";
			this.btnScan.Size = new System.Drawing.Size(72, 20);
			this.btnScan.TabIndex = 2;
			this.btnScan.Text = "Scan";
			this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
			// 
			// btnSelect
			// 
			this.btnSelect.Location = new System.Drawing.Point(82, 32);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(72, 20);
			this.btnSelect.TabIndex = 6;
			this.btnSelect.Text = "Options";
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			// 
			// btnScanDone
			// 
			this.btnScanDone.Location = new System.Drawing.Point(160, 32);
			this.btnScanDone.Name = "btnScanDone";
			this.btnScanDone.Size = new System.Drawing.Size(72, 20);
			this.btnScanDone.TabIndex = 4;
			this.btnScanDone.Text = "Done";
			this.btnScanDone.Click += new System.EventHandler(this.btnScanDone_Click);
			// 
			// labelScanInfo
			// 
			this.labelScanInfo.BackColor = System.Drawing.Color.DarkCyan;
			this.labelScanInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
			this.labelScanInfo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.labelScanInfo.Location = new System.Drawing.Point(0, 0);
			this.labelScanInfo.Name = "labelScanInfo";
			this.labelScanInfo.Size = new System.Drawing.Size(238, 28);
			this.labelScanInfo.Text = "Ready to Scan";
			this.labelScanInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// iconBox
			// 
			this.iconBox.Location = new System.Drawing.Point(96, 68);
			this.iconBox.Name = "iconBox";
			this.iconBox.Size = new System.Drawing.Size(48, 48);
			// 
			// lblScanResult
			// 
			this.lblScanResult.BackColor = System.Drawing.Color.DarkCyan;
			this.lblScanResult.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
			this.lblScanResult.ForeColor = System.Drawing.Color.White;
			this.lblScanResult.Location = new System.Drawing.Point(0, 128);
			this.lblScanResult.Name = "lblScanResult";
			this.lblScanResult.Size = new System.Drawing.Size(238, 76);
			this.lblScanResult.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblScanSum
			// 
			this.lblScanSum.BackColor = System.Drawing.Color.Lavender;
			this.lblScanSum.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
			this.lblScanSum.ForeColor = System.Drawing.Color.Black;
			this.lblScanSum.Location = new System.Drawing.Point(0, 228);
			this.lblScanSum.Name = "lblScanSum";
			this.lblScanSum.Size = new System.Drawing.Size(92, 20);
			this.lblScanSum.Text = "Scanned:";
			// 
			// loadPanel
			// 
			this.loadPanel.BackColor = System.Drawing.Color.DarkCyan;
			this.loadPanel.Controls.Add(this.lblLoadFile);
			this.loadPanel.Controls.Add(this.btnLoadFile);
			this.loadPanel.Controls.Add(this.labelLoadWeb);
			this.loadPanel.Controls.Add(this.menuEvents);
			this.loadPanel.Controls.Add(this.btnLoadFromWeb);
			this.loadPanel.Location = new System.Drawing.Point(0, 24);
			this.loadPanel.Name = "loadPanel";
			this.loadPanel.Size = new System.Drawing.Size(238, 246);
			// 
			// lblLoadFile
			// 
			this.lblLoadFile.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
			this.lblLoadFile.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lblLoadFile.Location = new System.Drawing.Point(0, 0);
			this.lblLoadFile.Name = "lblLoadFile";
			this.lblLoadFile.Size = new System.Drawing.Size(238, 42);
			this.lblLoadFile.Text = "Select the Venture Event Data File for this event:";
			this.lblLoadFile.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// btnLoadFile
			// 
			this.btnLoadFile.Location = new System.Drawing.Point(56, 48);
			this.btnLoadFile.Name = "btnLoadFile";
			this.btnLoadFile.Size = new System.Drawing.Size(124, 20);
			this.btnLoadFile.TabIndex = 2;
			this.btnLoadFile.Text = "Select Data File";
			this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
			// 
			// labelLoadWeb
			// 
			this.labelLoadWeb.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
			this.labelLoadWeb.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.labelLoadWeb.Location = new System.Drawing.Point(0, 124);
			this.labelLoadWeb.Name = "labelLoadWeb";
			this.labelLoadWeb.Size = new System.Drawing.Size(238, 42);
			this.labelLoadWeb.Text = "Load Event Data from Venture server:";
			this.labelLoadWeb.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// menuEvents
			// 
			this.menuEvents.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
			this.menuEvents.Location = new System.Drawing.Point(4, 172);
			this.menuEvents.Name = "menuEvents";
			this.menuEvents.Size = new System.Drawing.Size(228, 19);
			this.menuEvents.TabIndex = 0;
			this.menuEvents.Visible = false;
			// 
			// btnLoadFromWeb
			// 
			this.btnLoadFromWeb.Location = new System.Drawing.Point(60, 208);
			this.btnLoadFromWeb.Name = "btnLoadFromWeb";
			this.btnLoadFromWeb.Size = new System.Drawing.Size(120, 20);
			this.btnLoadFromWeb.TabIndex = 3;
			this.btnLoadFromWeb.Text = "Load from Venture";
			this.btnLoadFromWeb.Visible = false;
			this.btnLoadFromWeb.Click += new System.EventHandler(this.btnLoadFromWeb_Click);
			// 
			// btnScanSocialEvents
			// 
			this.btnScanSocialEvents.Location = new System.Drawing.Point(52, 184);
			this.btnScanSocialEvents.Name = "btnScanSocialEvents";
			this.btnScanSocialEvents.Size = new System.Drawing.Size(124, 20);
			this.btnScanSocialEvents.TabIndex = 9;
			this.btnScanSocialEvents.Text = "Start Scanning";
			this.btnScanSocialEvents.Click += new System.EventHandler(this.btnScanSocialEvents_Click);
			// 
			// UI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.DarkCyan;
			this.ClientSize = new System.Drawing.Size(238, 295);
			this.Controls.Add(this.containerPanel);
			this.ForeColor = System.Drawing.Color.White;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "UI";
			this.Text = "JLC Scan";
			this.Load += new System.EventHandler(this.Ui_Load);
			this.Closed += new System.EventHandler(this.Ui_Closed);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Ui_KeyUp);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ui_KeyDown);
			this.containerPanel.ResumeLayout(false);
			this.optionsPanel.ResumeLayout(false);
			this.scanPanel.ResumeLayout(false);
			this.loadPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblLogo;
		private System.Windows.Forms.Panel containerPanel;
		private System.Windows.Forms.Panel loadPanel;
		private System.Windows.Forms.Button btnLoadFile;
		private System.Windows.Forms.Label lblLoadFile;
		private System.Windows.Forms.Panel scanPanel;
		private System.Windows.Forms.Label labelScanInfo;
		private System.Windows.Forms.Button btnScan;
		private System.Windows.Forms.Label lblScanSum;
		private System.Windows.Forms.Label lblScanResult;
		private System.Windows.Forms.Button btnScanDone;
		private System.Windows.Forms.PictureBox iconBox;
		private System.Windows.Forms.Button btnLoadFromWeb;
		private System.Windows.Forms.Label labelLoadWeb;
		private System.Windows.Forms.ComboBox menuEvents;
		private System.Windows.Forms.Button btnSelect;
		private System.Windows.Forms.Label lblValid;
		private System.Windows.Forms.Label lblScanFail;
		private System.Windows.Forms.Panel optionsPanel;
		private System.Windows.Forms.Label lblOptions;
		private System.Windows.Forms.Button btnScanRegOnly;
		private System.Windows.Forms.Label lblScanRegOnlyInfo;
		private System.Windows.Forms.Label lblScanSocEventInfo;
		private System.Windows.Forms.ComboBox menuSocialEvents;
		private System.Windows.Forms.Button btnScanSocialEvents;
	}
}