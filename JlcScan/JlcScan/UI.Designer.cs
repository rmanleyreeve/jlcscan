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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI));
			this.lblLogo = new System.Windows.Forms.Label();
			this.containerPanel = new System.Windows.Forms.Panel();
			this.scanPanel = new System.Windows.Forms.Panel();
			this.btnScan = new System.Windows.Forms.Button();
			this.btnSelect = new System.Windows.Forms.Button();
			this.btnScanDone = new System.Windows.Forms.Button();
			this.lblScanReady = new System.Windows.Forms.Label();
			this.imgScanReady = new System.Windows.Forms.PictureBox();
			this.labelScanInfo = new System.Windows.Forms.Label();
			this.lblScanSum = new System.Windows.Forms.Label();
			this.lblValid = new System.Windows.Forms.Label();
			this.lblScanFail = new System.Windows.Forms.Label();
			this.resultPanel = new System.Windows.Forms.Panel();
			this.iconBoxOK = new System.Windows.Forms.PictureBox();
			this.iconBoxFail = new System.Windows.Forms.PictureBox();
			this.iconBoxNo = new System.Windows.Forms.PictureBox();
			this.lblScanResult = new System.Windows.Forms.Label();
			this.btnOverride = new System.Windows.Forms.Button();
			this.imgLogo = new System.Windows.Forms.PictureBox();
			this.loadPanel = new System.Windows.Forms.Panel();
			this.lblLoadFile = new System.Windows.Forms.Label();
			this.btnLoadFile = new System.Windows.Forms.Button();
			this.labelLoadWeb = new System.Windows.Forms.Label();
			this.menuEvents = new System.Windows.Forms.ComboBox();
			this.btnLoadFromWeb = new System.Windows.Forms.Button();
			this.optionsPanel = new System.Windows.Forms.Panel();
			this.lblOptions = new System.Windows.Forms.Label();
			this.lblScanRegOnlyInfo = new System.Windows.Forms.Label();
			this.btnScanRegOnly = new System.Windows.Forms.Button();
			this.lblScanSocEventInfo = new System.Windows.Forms.Label();
			this.menuSocialEvents = new System.Windows.Forms.ComboBox();
			this.btnScanSocialEvents = new System.Windows.Forms.Button();
			this.containerPanel.SuspendLayout();
			this.scanPanel.SuspendLayout();
			this.resultPanel.SuspendLayout();
			this.loadPanel.SuspendLayout();
			this.optionsPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblLogo
			// 
			this.lblLogo.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblLogo.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
			this.lblLogo.ForeColor = System.Drawing.Color.DarkCyan;
			this.lblLogo.Location = new System.Drawing.Point(0, 0);
			this.lblLogo.Name = "lblLogo";
			this.lblLogo.Size = new System.Drawing.Size(238, 24);
			this.lblLogo.Text = "JUDY LANE CONSULTING";
			this.lblLogo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.lblLogo.Visible = false;
			// 
			// containerPanel
			// 
			this.containerPanel.BackColor = System.Drawing.Color.Lavender;
			this.containerPanel.Controls.Add(this.scanPanel);
			this.containerPanel.Controls.Add(this.imgLogo);
			this.containerPanel.Controls.Add(this.lblLogo);
			this.containerPanel.Controls.Add(this.loadPanel);
			this.containerPanel.Controls.Add(this.optionsPanel);
			this.containerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.containerPanel.Location = new System.Drawing.Point(0, 0);
			this.containerPanel.Name = "containerPanel";
			this.containerPanel.Size = new System.Drawing.Size(238, 295);
			// 
			// scanPanel
			// 
			this.scanPanel.BackColor = System.Drawing.Color.DarkCyan;
			this.scanPanel.Controls.Add(this.resultPanel);
			this.scanPanel.Controls.Add(this.btnScan);
			this.scanPanel.Controls.Add(this.btnSelect);
			this.scanPanel.Controls.Add(this.btnScanDone);
			this.scanPanel.Controls.Add(this.lblScanReady);
			this.scanPanel.Controls.Add(this.imgScanReady);
			this.scanPanel.Controls.Add(this.labelScanInfo);
			this.scanPanel.Controls.Add(this.lblScanSum);
			this.scanPanel.Controls.Add(this.lblValid);
			this.scanPanel.Controls.Add(this.lblScanFail);
			this.scanPanel.Location = new System.Drawing.Point(0, 24);
			this.scanPanel.Name = "scanPanel";
			this.scanPanel.Size = new System.Drawing.Size(238, 246);
			this.scanPanel.Visible = false;
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
			// lblScanReady
			// 
			this.lblScanReady.BackColor = System.Drawing.Color.DarkCyan;
			this.lblScanReady.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
			this.lblScanReady.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lblScanReady.Location = new System.Drawing.Point(32, 96);
			this.lblScanReady.Name = "lblScanReady";
			this.lblScanReady.Size = new System.Drawing.Size(176, 32);
			this.lblScanReady.Text = "Scanner Ready...";
			this.lblScanReady.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// imgScanReady
			// 
			this.imgScanReady.Image = ((System.Drawing.Image)(resources.GetObject("imgScanReady.Image")));
			this.imgScanReady.Location = new System.Drawing.Point(104, 128);
			this.imgScanReady.Name = "imgScanReady";
			this.imgScanReady.Size = new System.Drawing.Size(32, 32);
			// 
			// labelScanInfo
			// 
			this.labelScanInfo.BackColor = System.Drawing.Color.DarkCyan;
			this.labelScanInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
			this.labelScanInfo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.labelScanInfo.Location = new System.Drawing.Point(0, 0);
			this.labelScanInfo.Name = "labelScanInfo";
			this.labelScanInfo.Size = new System.Drawing.Size(238, 28);
			this.labelScanInfo.Text = "Recording";
			this.labelScanInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
			// resultPanel
			// 
			this.resultPanel.BackColor = System.Drawing.Color.Lavender;
			this.resultPanel.Controls.Add(this.lblScanResult);
			this.resultPanel.Controls.Add(this.iconBoxOK);
			this.resultPanel.Controls.Add(this.iconBoxFail);
			this.resultPanel.Controls.Add(this.iconBoxNo);
			this.resultPanel.Controls.Add(this.btnOverride);
			this.resultPanel.Location = new System.Drawing.Point(30, 60);
			this.resultPanel.Name = "resultPanel";
			this.resultPanel.Size = new System.Drawing.Size(180, 150);
			this.resultPanel.Visible = false;
			this.resultPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawBorder);
			// 
			// iconBoxOK
			// 
			this.iconBoxOK.Image = ((System.Drawing.Image)(resources.GetObject("iconBoxOK.Image")));
			this.iconBoxOK.Location = new System.Drawing.Point(64, 4);
			this.iconBoxOK.Name = "iconBoxOK";
			this.iconBoxOK.Size = new System.Drawing.Size(48, 48);
			this.iconBoxOK.Visible = false;
			// 
			// iconBoxFail
			// 
			this.iconBoxFail.Image = ((System.Drawing.Image)(resources.GetObject("iconBoxFail.Image")));
			this.iconBoxFail.Location = new System.Drawing.Point(64, 4);
			this.iconBoxFail.Name = "iconBoxFail";
			this.iconBoxFail.Size = new System.Drawing.Size(48, 48);
			this.iconBoxFail.Visible = false;
			// 
			// iconBoxNo
			// 
			this.iconBoxNo.Image = ((System.Drawing.Image)(resources.GetObject("iconBoxNo.Image")));
			this.iconBoxNo.Location = new System.Drawing.Point(64, 4);
			this.iconBoxNo.Name = "iconBoxNo";
			this.iconBoxNo.Size = new System.Drawing.Size(48, 48);
			this.iconBoxNo.Visible = false;
			// 
			// lblScanResult
			// 
			this.lblScanResult.BackColor = System.Drawing.Color.Lavender;
			this.lblScanResult.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
			this.lblScanResult.ForeColor = System.Drawing.Color.Black;
			this.lblScanResult.Location = new System.Drawing.Point(3, 56);
			this.lblScanResult.Name = "lblScanResult";
			this.lblScanResult.Size = new System.Drawing.Size(174, 60);
			this.lblScanResult.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// btnOverride
			// 
			this.btnOverride.Location = new System.Drawing.Point(52, 124);
			this.btnOverride.Name = "btnOverride";
			this.btnOverride.Size = new System.Drawing.Size(72, 20);
			this.btnOverride.TabIndex = 4;
			this.btnOverride.Text = "Allow In";
			this.btnOverride.Visible = false;
			// 
			// imgLogo
			// 
			this.imgLogo.Image = ((System.Drawing.Image)(resources.GetObject("imgLogo.Image")));
			this.imgLogo.Location = new System.Drawing.Point(0, 0);
			this.imgLogo.Name = "imgLogo";
			this.imgLogo.Size = new System.Drawing.Size(238, 24);
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
			this.lblLoadFile.ForeColor = System.Drawing.Color.White;
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
			// optionsPanel
			// 
			this.optionsPanel.BackColor = System.Drawing.Color.CadetBlue;
			this.optionsPanel.Controls.Add(this.lblOptions);
			this.optionsPanel.Controls.Add(this.lblScanRegOnlyInfo);
			this.optionsPanel.Controls.Add(this.btnScanRegOnly);
			this.optionsPanel.Controls.Add(this.lblScanSocEventInfo);
			this.optionsPanel.Controls.Add(this.menuSocialEvents);
			this.optionsPanel.Controls.Add(this.btnScanSocialEvents);
			this.optionsPanel.Location = new System.Drawing.Point(0, 24);
			this.optionsPanel.Name = "optionsPanel";
			this.optionsPanel.Size = new System.Drawing.Size(238, 246);
			this.optionsPanel.Visible = false;
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
			// lblScanRegOnlyInfo
			// 
			this.lblScanRegOnlyInfo.ForeColor = System.Drawing.Color.Black;
			this.lblScanRegOnlyInfo.Location = new System.Drawing.Point(0, 44);
			this.lblScanRegOnlyInfo.Name = "lblScanRegOnlyInfo";
			this.lblScanRegOnlyInfo.Size = new System.Drawing.Size(238, 24);
			this.lblScanRegOnlyInfo.Text = "Recording Event Registration access";
			this.lblScanRegOnlyInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
			// lblScanSocEventInfo
			// 
			this.lblScanSocEventInfo.ForeColor = System.Drawing.Color.Black;
			this.lblScanSocEventInfo.Location = new System.Drawing.Point(0, 128);
			this.lblScanSocEventInfo.Name = "lblScanSocEventInfo";
			this.lblScanSocEventInfo.Size = new System.Drawing.Size(238, 20);
			this.lblScanSocEventInfo.Text = "Recording Social Event access";
			this.lblScanSocEventInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// menuSocialEvents
			// 
			this.menuSocialEvents.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
			this.menuSocialEvents.Location = new System.Drawing.Point(4, 152);
			this.menuSocialEvents.Name = "menuSocialEvents";
			this.menuSocialEvents.Size = new System.Drawing.Size(228, 19);
			this.menuSocialEvents.TabIndex = 5;
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
			this.scanPanel.ResumeLayout(false);
			this.resultPanel.ResumeLayout(false);
			this.loadPanel.ResumeLayout(false);
			this.optionsPanel.ResumeLayout(false);
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
		private System.Windows.Forms.Button btnScanDone;
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
		private System.Windows.Forms.PictureBox imgLogo;
		private System.Windows.Forms.Panel resultPanel;
		private System.Windows.Forms.PictureBox iconBoxOK;
		private System.Windows.Forms.Label lblScanResult;
		private System.Windows.Forms.PictureBox iconBoxNo;
		private System.Windows.Forms.PictureBox iconBoxFail;
		private System.Windows.Forms.Button btnOverride;
		private System.Windows.Forms.Label lblScanReady;
		private System.Windows.Forms.PictureBox imgScanReady;
	}
}