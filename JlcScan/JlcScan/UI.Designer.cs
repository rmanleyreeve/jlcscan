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
			this.imgLogo = new System.Windows.Forms.PictureBox();
			this.savePanel = new System.Windows.Forms.Panel();
			this.lblSaveInfo = new System.Windows.Forms.Label();
			this.lblScannedInfo = new System.Windows.Forms.Label();
			this.btnSaveToFile = new System.Windows.Forms.Button();
			this.btnSaveToVenture = new System.Windows.Forms.Button();
			this.lblSendToVentureMsg = new System.Windows.Forms.Label();
			this.lblStartOver = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.scanPanel = new System.Windows.Forms.Panel();
			this.lblScanInfo = new System.Windows.Forms.Label();
			this.btnScan = new System.Windows.Forms.Button();
			this.btnOptions = new System.Windows.Forms.Button();
			this.btnScanDone = new System.Windows.Forms.Button();
			this.resultPanel = new System.Windows.Forms.Panel();
			this.iconBoxOK = new System.Windows.Forms.PictureBox();
			this.iconBoxFail = new System.Windows.Forms.PictureBox();
			this.iconBoxNo = new System.Windows.Forms.PictureBox();
			this.lblScanResult = new System.Windows.Forms.Label();
			this.lblOverride = new System.Windows.Forms.Label();
			this.btnOverride = new System.Windows.Forms.Button();
			this.btnNoOverride = new System.Windows.Forms.Button();
			this.lblScanReady = new System.Windows.Forms.Label();
			this.imgScanReady = new System.Windows.Forms.PictureBox();
			this.lblScanSum = new System.Windows.Forms.Label();
			this.lblValid = new System.Windows.Forms.Label();
			this.lblScanFail = new System.Windows.Forms.Label();
			this.optionsPanel = new System.Windows.Forms.Panel();
			this.lblOptions = new System.Windows.Forms.Label();
			this.lblScanRegOnlyInfo = new System.Windows.Forms.Label();
			this.btnScanRegOnly = new System.Windows.Forms.Button();
			this.lblScanSocEventInfo = new System.Windows.Forms.Label();
			this.menuSocialEvents = new System.Windows.Forms.ComboBox();
			this.btnScanSocialEvents = new System.Windows.Forms.Button();
			this.loadPanel = new System.Windows.Forms.Panel();
			this.lblLoadFile = new System.Windows.Forms.Label();
			this.btnLoadFile = new System.Windows.Forms.Button();
			this.lblLoadFromVenture = new System.Windows.Forms.Label();
			this.menuEvents = new System.Windows.Forms.ComboBox();
			this.btnLoadFromVenture = new System.Windows.Forms.Button();
			this.containerPanel.SuspendLayout();
			this.savePanel.SuspendLayout();
			this.scanPanel.SuspendLayout();
			this.resultPanel.SuspendLayout();
			this.optionsPanel.SuspendLayout();
			this.loadPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblLogo
			// 
			this.lblLogo.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblLogo.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
			this.lblLogo.ForeColor = System.Drawing.Color.DarkCyan;
			this.lblLogo.Location = new System.Drawing.Point(0, 0);
			this.lblLogo.Name = "lblLogo";
			this.lblLogo.Size = new System.Drawing.Size(238, 28);
			this.lblLogo.Text = "JUDY LANE CONSULTING";
			this.lblLogo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.lblLogo.Visible = false;
			// 
			// containerPanel
			// 
			this.containerPanel.BackColor = System.Drawing.Color.Lavender;
			this.containerPanel.Controls.Add(this.imgLogo);
			this.containerPanel.Controls.Add(this.lblLogo);
			this.containerPanel.Controls.Add(this.loadPanel);
			this.containerPanel.Controls.Add(this.optionsPanel);
			this.containerPanel.Controls.Add(this.scanPanel);
			this.containerPanel.Controls.Add(this.savePanel);
			this.containerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.containerPanel.Location = new System.Drawing.Point(0, 0);
			this.containerPanel.Name = "containerPanel";
			this.containerPanel.Size = new System.Drawing.Size(238, 295);
			// 
			// imgLogo
			// 
			this.imgLogo.Image = ((System.Drawing.Image)(resources.GetObject("imgLogo.Image")));
			this.imgLogo.Location = new System.Drawing.Point(0, 0);
			this.imgLogo.Name = "imgLogo";
			this.imgLogo.Size = new System.Drawing.Size(238, 28);
			// 
			// savePanel
			// 
			this.savePanel.BackColor = System.Drawing.Color.DarkCyan;
			this.savePanel.Controls.Add(this.lblSaveInfo);
			this.savePanel.Controls.Add(this.lblScannedInfo);
			this.savePanel.Controls.Add(this.btnSaveToFile);
			this.savePanel.Controls.Add(this.btnSaveToVenture);
			this.savePanel.Controls.Add(this.lblSendToVentureMsg);
			this.savePanel.Controls.Add(this.lblStartOver);
			this.savePanel.Controls.Add(this.btnExit);
			this.savePanel.Location = new System.Drawing.Point(0, 28);
			this.savePanel.Name = "savePanel";
			this.savePanel.Size = new System.Drawing.Size(238, 246);
			this.savePanel.Visible = false;
			// 
			// lblSaveInfo
			// 
			this.lblSaveInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
			this.lblSaveInfo.ForeColor = System.Drawing.Color.White;
			this.lblSaveInfo.Location = new System.Drawing.Point(0, 0);
			this.lblSaveInfo.Name = "lblSaveInfo";
			this.lblSaveInfo.Size = new System.Drawing.Size(238, 24);
			this.lblSaveInfo.Text = "Scanning Complete!";
			this.lblSaveInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblScannedInfo
			// 
			this.lblScannedInfo.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
			this.lblScannedInfo.Location = new System.Drawing.Point(0, 32);
			this.lblScannedInfo.Name = "lblScannedInfo";
			this.lblScannedInfo.Size = new System.Drawing.Size(236, 20);
			this.lblScannedInfo.Text = "0 valid Registrations scanned";
			this.lblScannedInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// btnSaveToFile
			// 
			this.btnSaveToFile.Location = new System.Drawing.Point(44, 72);
			this.btnSaveToFile.Name = "btnSaveToFile";
			this.btnSaveToFile.Size = new System.Drawing.Size(144, 20);
			this.btnSaveToFile.TabIndex = 3;
			this.btnSaveToFile.Text = "Save data to PDA";
			this.btnSaveToFile.Click += new System.EventHandler(this.btnSaveToFile_Click);
			// 
			// btnSaveToVenture
			// 
			this.btnSaveToVenture.Location = new System.Drawing.Point(44, 116);
			this.btnSaveToVenture.Name = "btnSaveToVenture";
			this.btnSaveToVenture.Size = new System.Drawing.Size(144, 20);
			this.btnSaveToVenture.TabIndex = 4;
			this.btnSaveToVenture.Text = "Save data to Venture";
			this.btnSaveToVenture.Visible = false;
			this.btnSaveToVenture.Click += new System.EventHandler(this.btnSaveToVenture_Click);
			// 
			// lblSendToVentureMsg
			// 
			this.lblSendToVentureMsg.BackColor = System.Drawing.Color.DarkCyan;
			this.lblSendToVentureMsg.Location = new System.Drawing.Point(8, 140);
			this.lblSendToVentureMsg.Name = "lblSendToVentureMsg";
			this.lblSendToVentureMsg.Size = new System.Drawing.Size(224, 72);
			this.lblSendToVentureMsg.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblStartOver
			// 
			this.lblStartOver.Location = new System.Drawing.Point(8, 220);
			this.lblStartOver.Name = "lblStartOver";
			this.lblStartOver.Size = new System.Drawing.Size(90, 20);
			this.lblStartOver.TabIndex = 8;
			this.lblStartOver.Text = "Start Again";
			this.lblStartOver.Click += new System.EventHandler(this.lblStartOver_Click);
			// 
			// btnExit
			// 
			this.btnExit.Location = new System.Drawing.Point(140, 220);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(90, 20);
			this.btnExit.TabIndex = 12;
			this.btnExit.Text = "Exit Program";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// scanPanel
			// 
			this.scanPanel.BackColor = System.Drawing.Color.DarkCyan;
			this.scanPanel.Controls.Add(this.lblScanInfo);
			this.scanPanel.Controls.Add(this.btnScan);
			this.scanPanel.Controls.Add(this.btnOptions);
			this.scanPanel.Controls.Add(this.btnScanDone);
			this.scanPanel.Controls.Add(this.resultPanel);
			this.scanPanel.Controls.Add(this.lblScanReady);
			this.scanPanel.Controls.Add(this.imgScanReady);
			this.scanPanel.Controls.Add(this.lblScanSum);
			this.scanPanel.Controls.Add(this.lblValid);
			this.scanPanel.Controls.Add(this.lblScanFail);
			this.scanPanel.Location = new System.Drawing.Point(0, 28);
			this.scanPanel.Name = "scanPanel";
			this.scanPanel.Size = new System.Drawing.Size(238, 246);
			this.scanPanel.Visible = false;
			// 
			// lblScanInfo
			// 
			this.lblScanInfo.BackColor = System.Drawing.Color.DarkCyan;
			this.lblScanInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
			this.lblScanInfo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lblScanInfo.Location = new System.Drawing.Point(0, 4);
			this.lblScanInfo.Name = "lblScanInfo";
			this.lblScanInfo.Size = new System.Drawing.Size(238, 24);
			this.lblScanInfo.Text = "Scanning Mode";
			this.lblScanInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// btnScan
			// 
			this.btnScan.BackColor = System.Drawing.Color.Yellow;
			this.btnScan.Location = new System.Drawing.Point(82, 32);
			this.btnScan.Name = "btnScan";
			this.btnScan.Size = new System.Drawing.Size(72, 20);
			this.btnScan.TabIndex = 2;
			this.btnScan.Text = "Scan";
			this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
			// 
			// btnOptions
			// 
			this.btnOptions.Location = new System.Drawing.Point(4, 32);
			this.btnOptions.Name = "btnOptions";
			this.btnOptions.Size = new System.Drawing.Size(72, 20);
			this.btnOptions.TabIndex = 6;
			this.btnOptions.Text = "Options";
			this.btnOptions.Click += new System.EventHandler(this.btnSelect_Click);
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
			// resultPanel
			// 
			this.resultPanel.BackColor = System.Drawing.Color.Lavender;
			this.resultPanel.Controls.Add(this.iconBoxOK);
			this.resultPanel.Controls.Add(this.iconBoxFail);
			this.resultPanel.Controls.Add(this.iconBoxNo);
			this.resultPanel.Controls.Add(this.lblScanResult);
			this.resultPanel.Controls.Add(this.lblOverride);
			this.resultPanel.Controls.Add(this.btnOverride);
			this.resultPanel.Controls.Add(this.btnNoOverride);
			this.resultPanel.Location = new System.Drawing.Point(30, 64);
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
			this.lblScanResult.Location = new System.Drawing.Point(4, 56);
			this.lblScanResult.Name = "lblScanResult";
			this.lblScanResult.Size = new System.Drawing.Size(172, 56);
			this.lblScanResult.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblOverride
			// 
			this.lblOverride.Location = new System.Drawing.Point(4, 122);
			this.lblOverride.Name = "lblOverride";
			this.lblOverride.Size = new System.Drawing.Size(64, 20);
			this.lblOverride.Text = "Allow In?";
			// 
			// btnOverride
			// 
			this.btnOverride.BackColor = System.Drawing.Color.LightSalmon;
			this.btnOverride.Location = new System.Drawing.Point(72, 116);
			this.btnOverride.Name = "btnOverride";
			this.btnOverride.Size = new System.Drawing.Size(40, 30);
			this.btnOverride.TabIndex = 4;
			this.btnOverride.Text = "Yes";
			this.btnOverride.Visible = false;
			this.btnOverride.Click += new System.EventHandler(this.btnOverride_Click);
			// 
			// btnNoOverride
			// 
			this.btnNoOverride.BackColor = System.Drawing.Color.LightSkyBlue;
			this.btnNoOverride.Location = new System.Drawing.Point(136, 116);
			this.btnNoOverride.Name = "btnNoOverride";
			this.btnNoOverride.Size = new System.Drawing.Size(40, 30);
			this.btnNoOverride.TabIndex = 6;
			this.btnNoOverride.Text = "No";
			this.btnNoOverride.Click += new System.EventHandler(this.btnNoOverride_Click);
			// 
			// lblScanReady
			// 
			this.lblScanReady.BackColor = System.Drawing.Color.DarkCyan;
			this.lblScanReady.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
			this.lblScanReady.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lblScanReady.Location = new System.Drawing.Point(32, 76);
			this.lblScanReady.Name = "lblScanReady";
			this.lblScanReady.Size = new System.Drawing.Size(176, 32);
			this.lblScanReady.Text = "Scanner Ready...";
			this.lblScanReady.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// imgScanReady
			// 
			this.imgScanReady.Image = ((System.Drawing.Image)(resources.GetObject("imgScanReady.Image")));
			this.imgScanReady.Location = new System.Drawing.Point(78, 108);
			this.imgScanReady.Name = "imgScanReady";
			this.imgScanReady.Size = new System.Drawing.Size(75, 75);
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
			// optionsPanel
			// 
			this.optionsPanel.BackColor = System.Drawing.Color.DarkCyan;
			this.optionsPanel.Controls.Add(this.lblOptions);
			this.optionsPanel.Controls.Add(this.lblScanRegOnlyInfo);
			this.optionsPanel.Controls.Add(this.btnScanRegOnly);
			this.optionsPanel.Controls.Add(this.lblScanSocEventInfo);
			this.optionsPanel.Controls.Add(this.menuSocialEvents);
			this.optionsPanel.Controls.Add(this.btnScanSocialEvents);
			this.optionsPanel.Location = new System.Drawing.Point(0, 28);
			this.optionsPanel.Name = "optionsPanel";
			this.optionsPanel.Size = new System.Drawing.Size(238, 246);
			this.optionsPanel.Visible = false;
			// 
			// lblOptions
			// 
			this.lblOptions.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
			this.lblOptions.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lblOptions.Location = new System.Drawing.Point(0, 4);
			this.lblOptions.Name = "lblOptions";
			this.lblOptions.Size = new System.Drawing.Size(238, 32);
			this.lblOptions.Text = "Choose the Scanner Mode:";
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
			// loadPanel
			// 
			this.loadPanel.BackColor = System.Drawing.Color.DarkCyan;
			this.loadPanel.Controls.Add(this.lblLoadFile);
			this.loadPanel.Controls.Add(this.btnLoadFile);
			this.loadPanel.Controls.Add(this.lblLoadFromVenture);
			this.loadPanel.Controls.Add(this.menuEvents);
			this.loadPanel.Controls.Add(this.btnLoadFromVenture);
			this.loadPanel.Location = new System.Drawing.Point(0, 28);
			this.loadPanel.Name = "loadPanel";
			this.loadPanel.Size = new System.Drawing.Size(238, 246);
			// 
			// lblLoadFile
			// 
			this.lblLoadFile.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
			this.lblLoadFile.ForeColor = System.Drawing.Color.White;
			this.lblLoadFile.Location = new System.Drawing.Point(0, 4);
			this.lblLoadFile.Name = "lblLoadFile";
			this.lblLoadFile.Size = new System.Drawing.Size(238, 38);
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
			// lblLoadFromVenture
			// 
			this.lblLoadFromVenture.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
			this.lblLoadFromVenture.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lblLoadFromVenture.Location = new System.Drawing.Point(0, 124);
			this.lblLoadFromVenture.Name = "lblLoadFromVenture";
			this.lblLoadFromVenture.Size = new System.Drawing.Size(238, 42);
			this.lblLoadFromVenture.Text = "Load Event Data from Venture server:";
			this.lblLoadFromVenture.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
			// btnLoadFromVenture
			// 
			this.btnLoadFromVenture.Location = new System.Drawing.Point(60, 208);
			this.btnLoadFromVenture.Name = "btnLoadFromVenture";
			this.btnLoadFromVenture.Size = new System.Drawing.Size(120, 20);
			this.btnLoadFromVenture.TabIndex = 3;
			this.btnLoadFromVenture.Text = "Load from Venture";
			this.btnLoadFromVenture.Visible = false;
			this.btnLoadFromVenture.Click += new System.EventHandler(this.btnLoadFromWeb_Click);
			// 
			// UI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.DarkCyan;
			this.ClientSize = new System.Drawing.Size(238, 295);
			this.Controls.Add(this.containerPanel);
			this.ForeColor = System.Drawing.Color.White;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
			this.savePanel.ResumeLayout(false);
			this.scanPanel.ResumeLayout(false);
			this.resultPanel.ResumeLayout(false);
			this.optionsPanel.ResumeLayout(false);
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
		private System.Windows.Forms.Label lblScanInfo;
		private System.Windows.Forms.Button btnScan;
		private System.Windows.Forms.Label lblScanSum;
		private System.Windows.Forms.Button btnScanDone;
		private System.Windows.Forms.Button btnLoadFromVenture;
		private System.Windows.Forms.Label lblLoadFromVenture;
		private System.Windows.Forms.ComboBox menuEvents;
		private System.Windows.Forms.Button btnOptions;
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
		private System.Windows.Forms.Label lblOverride;
		private System.Windows.Forms.Button btnNoOverride;
		private System.Windows.Forms.Panel savePanel;
		private System.Windows.Forms.Label lblSaveInfo;
		private System.Windows.Forms.Label lblScannedInfo;
		private System.Windows.Forms.Button btnSaveToFile;
		private System.Windows.Forms.Button btnSaveToVenture;
		private System.Windows.Forms.Label lblSendToVentureMsg;
		private System.Windows.Forms.Button lblStartOver;
		private System.Windows.Forms.Button btnExit;
	}
}