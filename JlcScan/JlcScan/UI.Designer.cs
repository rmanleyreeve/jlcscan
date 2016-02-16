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
			this.imgLogo = new System.Windows.Forms.PictureBox();
			this.loadPanel = new System.Windows.Forms.Panel();
			this.lblLoadFile = new System.Windows.Forms.Label();
			this.btnLoadFile = new System.Windows.Forms.Button();
			this.lblLoadFromVenture = new System.Windows.Forms.Label();
			this.menuEvents = new System.Windows.Forms.ComboBox();
			this.btnLoadFromVenture = new System.Windows.Forms.Button();
			this.optionsPanel = new System.Windows.Forms.Panel();
			this.lblOptions = new System.Windows.Forms.Label();
			this.lblScanRegOnly = new System.Windows.Forms.Label();
			this.btnScanRegOnly = new System.Windows.Forms.Button();
			this.lblScanSocialEvent = new System.Windows.Forms.Label();
			this.menuSocialEvents = new System.Windows.Forms.ComboBox();
			this.btnScanSocialEvent = new System.Windows.Forms.Button();
			this.scanPanel = new System.Windows.Forms.Panel();
			this.lblScanMode = new System.Windows.Forms.Label();
			this.btnScan = new System.Windows.Forms.Button();
			this.btnOptions = new System.Windows.Forms.Button();
			this.btnScanDone = new System.Windows.Forms.Button();
			this.resultPanel = new System.Windows.Forms.Panel();
			this.iconBoxOK = new System.Windows.Forms.PictureBox();
			this.iconBoxFail = new System.Windows.Forms.PictureBox();
			this.iconBoxNo = new System.Windows.Forms.PictureBox();
			this.lblScanResult = new System.Windows.Forms.Label();
			this.lblOverride = new System.Windows.Forms.Label();
			this.btnOverrideYes = new System.Windows.Forms.Button();
			this.btnOverrideNo = new System.Windows.Forms.Button();
			this.lblScanReady = new System.Windows.Forms.Label();
			this.imgScanReady = new System.Windows.Forms.PictureBox();
			this.lblTotalCount = new System.Windows.Forms.Label();
			this.lblValidCount = new System.Windows.Forms.Label();
			this.lblFailCount = new System.Windows.Forms.Label();
			this.savePanel = new System.Windows.Forms.Panel();
			this.lblScanComplete = new System.Windows.Forms.Label();
			this.lblNumScannedInfo = new System.Windows.Forms.Label();
			this.btnSaveToFile = new System.Windows.Forms.Button();
			this.btnSaveToVenture = new System.Windows.Forms.Button();
			this.lblSaveToVenture = new System.Windows.Forms.Label();
			this.btnStartOver = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.loadPanel.SuspendLayout();
			this.optionsPanel.SuspendLayout();
			this.scanPanel.SuspendLayout();
			this.resultPanel.SuspendLayout();
			this.savePanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblLogo
			// 
			this.lblLogo.BackColor = System.Drawing.Color.Lavender;
			this.lblLogo.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblLogo.Font = new System.Drawing.Font("HelveticaNeueLT Com 33 ThEx", 14F, System.Drawing.FontStyle.Regular);
			this.lblLogo.ForeColor = System.Drawing.Color.Black;
			this.lblLogo.Location = new System.Drawing.Point(0, 0);
			this.lblLogo.Name = "lblLogo";
			this.lblLogo.Size = new System.Drawing.Size(240, 22);
			this.lblLogo.Text = "JLC VentureSCAN";
			this.lblLogo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// imgLogo
			// 
			this.imgLogo.BackColor = System.Drawing.Color.Lavender;
			this.imgLogo.Image = ((System.Drawing.Image)(resources.GetObject("imgLogo.Image")));
			this.imgLogo.Location = new System.Drawing.Point(0, 22);
			this.imgLogo.Name = "imgLogo";
			this.imgLogo.Size = new System.Drawing.Size(240, 28);
			// 
			// loadPanel
			// 
			this.loadPanel.BackColor = System.Drawing.Color.DarkCyan;
			this.loadPanel.Controls.Add(this.lblLoadFile);
			this.loadPanel.Controls.Add(this.btnLoadFile);
			this.loadPanel.Controls.Add(this.lblLoadFromVenture);
			this.loadPanel.Controls.Add(this.menuEvents);
			this.loadPanel.Controls.Add(this.btnLoadFromVenture);
			this.loadPanel.Location = new System.Drawing.Point(0, 50);
			this.loadPanel.Name = "loadPanel";
			this.loadPanel.Size = new System.Drawing.Size(240, 244);
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
			this.btnLoadFile.Location = new System.Drawing.Point(56, 52);
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
			this.btnLoadFromVenture.Click += new System.EventHandler(this.btnLoadFromVenture_Click);
			// 
			// optionsPanel
			// 
			this.optionsPanel.BackColor = System.Drawing.Color.DarkCyan;
			this.optionsPanel.Controls.Add(this.lblOptions);
			this.optionsPanel.Controls.Add(this.lblScanRegOnly);
			this.optionsPanel.Controls.Add(this.btnScanRegOnly);
			this.optionsPanel.Controls.Add(this.lblScanSocialEvent);
			this.optionsPanel.Controls.Add(this.menuSocialEvents);
			this.optionsPanel.Controls.Add(this.btnScanSocialEvent);
			this.optionsPanel.Location = new System.Drawing.Point(0, 50);
			this.optionsPanel.Name = "optionsPanel";
			this.optionsPanel.Size = new System.Drawing.Size(240, 244);
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
			// lblScanRegOnly
			// 
			this.lblScanRegOnly.ForeColor = System.Drawing.Color.Black;
			this.lblScanRegOnly.Location = new System.Drawing.Point(0, 48);
			this.lblScanRegOnly.Name = "lblScanRegOnly";
			this.lblScanRegOnly.Size = new System.Drawing.Size(240, 24);
			this.lblScanRegOnly.Text = "Recording Event Registration access";
			this.lblScanRegOnly.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// btnScanRegOnly
			// 
			this.btnScanRegOnly.Location = new System.Drawing.Point(56, 76);
			this.btnScanRegOnly.Name = "btnScanRegOnly";
			this.btnScanRegOnly.Size = new System.Drawing.Size(124, 20);
			this.btnScanRegOnly.TabIndex = 2;
			this.btnScanRegOnly.Text = "Start Scanning";
			this.btnScanRegOnly.Click += new System.EventHandler(this.btnScanRegOnly_Click);
			// 
			// lblScanSocialEvent
			// 
			this.lblScanSocialEvent.ForeColor = System.Drawing.Color.Black;
			this.lblScanSocialEvent.Location = new System.Drawing.Point(0, 128);
			this.lblScanSocialEvent.Name = "lblScanSocialEvent";
			this.lblScanSocialEvent.Size = new System.Drawing.Size(240, 20);
			this.lblScanSocialEvent.Text = "Recording Social Event access";
			this.lblScanSocialEvent.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// menuSocialEvents
			// 
			this.menuSocialEvents.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
			this.menuSocialEvents.Location = new System.Drawing.Point(4, 152);
			this.menuSocialEvents.Name = "menuSocialEvents";
			this.menuSocialEvents.Size = new System.Drawing.Size(228, 19);
			this.menuSocialEvents.TabIndex = 5;
			// 
			// btnScanSocialEvent
			// 
			this.btnScanSocialEvent.Location = new System.Drawing.Point(52, 184);
			this.btnScanSocialEvent.Name = "btnScanSocialEvent";
			this.btnScanSocialEvent.Size = new System.Drawing.Size(124, 20);
			this.btnScanSocialEvent.TabIndex = 9;
			this.btnScanSocialEvent.Text = "Start Scanning";
			this.btnScanSocialEvent.Click += new System.EventHandler(this.btnScanSocialEvents_Click);
			// 
			// scanPanel
			// 
			this.scanPanel.BackColor = System.Drawing.Color.DarkCyan;
			this.scanPanel.Controls.Add(this.lblScanMode);
			this.scanPanel.Controls.Add(this.btnScan);
			this.scanPanel.Controls.Add(this.btnOptions);
			this.scanPanel.Controls.Add(this.btnScanDone);
			this.scanPanel.Controls.Add(this.resultPanel);
			this.scanPanel.Controls.Add(this.lblScanReady);
			this.scanPanel.Controls.Add(this.imgScanReady);
			this.scanPanel.Controls.Add(this.lblTotalCount);
			this.scanPanel.Controls.Add(this.lblValidCount);
			this.scanPanel.Controls.Add(this.lblFailCount);
			this.scanPanel.Location = new System.Drawing.Point(0, 50);
			this.scanPanel.Name = "scanPanel";
			this.scanPanel.Size = new System.Drawing.Size(240, 244);
			this.scanPanel.Visible = false;
			// 
			// lblScanMode
			// 
			this.lblScanMode.BackColor = System.Drawing.Color.DarkCyan;
			this.lblScanMode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
			this.lblScanMode.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lblScanMode.Location = new System.Drawing.Point(0, 4);
			this.lblScanMode.Name = "lblScanMode";
			this.lblScanMode.Size = new System.Drawing.Size(238, 24);
			this.lblScanMode.Text = "Scanning Mode";
			this.lblScanMode.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
			this.resultPanel.Controls.Add(this.btnOverrideYes);
			this.resultPanel.Controls.Add(this.btnOverrideNo);
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
			// btnOverrideYes
			// 
			this.btnOverrideYes.BackColor = System.Drawing.Color.LightSalmon;
			this.btnOverrideYes.Location = new System.Drawing.Point(72, 116);
			this.btnOverrideYes.Name = "btnOverrideYes";
			this.btnOverrideYes.Size = new System.Drawing.Size(40, 30);
			this.btnOverrideYes.TabIndex = 4;
			this.btnOverrideYes.Text = "Yes";
			this.btnOverrideYes.Visible = false;
			this.btnOverrideYes.Click += new System.EventHandler(this.btnOverrideYes_Click);
			// 
			// btnOverrideNo
			// 
			this.btnOverrideNo.BackColor = System.Drawing.Color.LightSkyBlue;
			this.btnOverrideNo.Location = new System.Drawing.Point(136, 116);
			this.btnOverrideNo.Name = "btnOverrideNo";
			this.btnOverrideNo.Size = new System.Drawing.Size(40, 30);
			this.btnOverrideNo.TabIndex = 6;
			this.btnOverrideNo.Text = "No";
			this.btnOverrideNo.Click += new System.EventHandler(this.btnOverrideNo_Click);
			// 
			// lblScanReady
			// 
			this.lblScanReady.BackColor = System.Drawing.Color.DarkCyan;
			this.lblScanReady.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
			this.lblScanReady.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lblScanReady.Location = new System.Drawing.Point(32, 72);
			this.lblScanReady.Name = "lblScanReady";
			this.lblScanReady.Size = new System.Drawing.Size(176, 32);
			this.lblScanReady.Text = "Scanner Ready...";
			this.lblScanReady.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// imgScanReady
			// 
			this.imgScanReady.Image = ((System.Drawing.Image)(resources.GetObject("imgScanReady.Image")));
			this.imgScanReady.Location = new System.Drawing.Point(78, 104);
			this.imgScanReady.Name = "imgScanReady";
			this.imgScanReady.Size = new System.Drawing.Size(75, 75);
			// 
			// lblTotalCount
			// 
			this.lblTotalCount.BackColor = System.Drawing.Color.Lavender;
			this.lblTotalCount.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
			this.lblTotalCount.ForeColor = System.Drawing.Color.Black;
			this.lblTotalCount.Location = new System.Drawing.Point(0, 224);
			this.lblTotalCount.Name = "lblTotalCount";
			this.lblTotalCount.Size = new System.Drawing.Size(92, 22);
			this.lblTotalCount.Text = "Scanned:";
			// 
			// lblValidCount
			// 
			this.lblValidCount.BackColor = System.Drawing.Color.Lavender;
			this.lblValidCount.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
			this.lblValidCount.ForeColor = System.Drawing.Color.Black;
			this.lblValidCount.Location = new System.Drawing.Point(92, 224);
			this.lblValidCount.Name = "lblValidCount";
			this.lblValidCount.Size = new System.Drawing.Size(76, 22);
			this.lblValidCount.Text = "Valid:";
			// 
			// lblFailCount
			// 
			this.lblFailCount.BackColor = System.Drawing.Color.Lavender;
			this.lblFailCount.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
			this.lblFailCount.ForeColor = System.Drawing.Color.Black;
			this.lblFailCount.Location = new System.Drawing.Point(168, 224);
			this.lblFailCount.Name = "lblFailCount";
			this.lblFailCount.Size = new System.Drawing.Size(72, 22);
			this.lblFailCount.Text = "Failed:";
			// 
			// savePanel
			// 
			this.savePanel.BackColor = System.Drawing.Color.DarkCyan;
			this.savePanel.Controls.Add(this.lblScanComplete);
			this.savePanel.Controls.Add(this.lblNumScannedInfo);
			this.savePanel.Controls.Add(this.btnSaveToFile);
			this.savePanel.Controls.Add(this.btnSaveToVenture);
			this.savePanel.Controls.Add(this.lblSaveToVenture);
			this.savePanel.Controls.Add(this.btnStartOver);
			this.savePanel.Controls.Add(this.btnExit);
			this.savePanel.Location = new System.Drawing.Point(0, 50);
			this.savePanel.Name = "savePanel";
			this.savePanel.Size = new System.Drawing.Size(240, 244);
			this.savePanel.Visible = false;
			// 
			// lblScanComplete
			// 
			this.lblScanComplete.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
			this.lblScanComplete.ForeColor = System.Drawing.Color.White;
			this.lblScanComplete.Location = new System.Drawing.Point(0, 4);
			this.lblScanComplete.Name = "lblScanComplete";
			this.lblScanComplete.Size = new System.Drawing.Size(240, 24);
			this.lblScanComplete.Text = "Scanning Complete!";
			this.lblScanComplete.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblNumScannedInfo
			// 
			this.lblNumScannedInfo.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
			this.lblNumScannedInfo.Location = new System.Drawing.Point(0, 32);
			this.lblNumScannedInfo.Name = "lblNumScannedInfo";
			this.lblNumScannedInfo.Size = new System.Drawing.Size(240, 22);
			this.lblNumScannedInfo.Text = "0 valid Registrations scanned";
			this.lblNumScannedInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// btnSaveToFile
			// 
			this.btnSaveToFile.Location = new System.Drawing.Point(44, 64);
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
			this.btnSaveToVenture.Click += new System.EventHandler(this.btnSaveToVenture_Click);
			// 
			// lblSaveToVenture
			// 
			this.lblSaveToVenture.BackColor = System.Drawing.Color.DarkCyan;
			this.lblSaveToVenture.Location = new System.Drawing.Point(0, 140);
			this.lblSaveToVenture.Name = "lblSaveToVenture";
			this.lblSaveToVenture.Size = new System.Drawing.Size(240, 72);
			this.lblSaveToVenture.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// btnStartOver
			// 
			this.btnStartOver.Location = new System.Drawing.Point(8, 220);
			this.btnStartOver.Name = "btnStartOver";
			this.btnStartOver.Size = new System.Drawing.Size(90, 20);
			this.btnStartOver.TabIndex = 8;
			this.btnStartOver.Text = "Start Again";
			this.btnStartOver.Click += new System.EventHandler(this.lblStartOver_Click);
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
			// UI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(240, 320);
			this.ControlBox = false;
			this.Controls.Add(this.lblLogo);
			this.Controls.Add(this.imgLogo);
			this.Controls.Add(this.loadPanel);
			this.Controls.Add(this.optionsPanel);
			this.Controls.Add(this.scanPanel);
			this.Controls.Add(this.savePanel);
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
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
			this.loadPanel.ResumeLayout(false);
			this.optionsPanel.ResumeLayout(false);
			this.scanPanel.ResumeLayout(false);
			this.resultPanel.ResumeLayout(false);
			this.savePanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblLogo;
		private System.Windows.Forms.Panel loadPanel;
		private System.Windows.Forms.Button btnLoadFile;
		private System.Windows.Forms.Label lblLoadFile;
		private System.Windows.Forms.Panel scanPanel;
		private System.Windows.Forms.Label lblScanMode;
		private System.Windows.Forms.Button btnScan;
		private System.Windows.Forms.Label lblTotalCount;
		private System.Windows.Forms.Button btnScanDone;
		private System.Windows.Forms.Button btnLoadFromVenture;
		private System.Windows.Forms.Label lblLoadFromVenture;
		private System.Windows.Forms.ComboBox menuEvents;
		private System.Windows.Forms.Button btnOptions;
		private System.Windows.Forms.Label lblValidCount;
		private System.Windows.Forms.Label lblFailCount;
		private System.Windows.Forms.Panel optionsPanel;
		private System.Windows.Forms.Label lblOptions;
		private System.Windows.Forms.Button btnScanRegOnly;
		private System.Windows.Forms.Label lblScanRegOnly;
		private System.Windows.Forms.Label lblScanSocialEvent;
		private System.Windows.Forms.ComboBox menuSocialEvents;
		private System.Windows.Forms.Button btnScanSocialEvent;
		private System.Windows.Forms.PictureBox imgLogo;
		private System.Windows.Forms.Panel resultPanel;
		private System.Windows.Forms.PictureBox iconBoxOK;
		private System.Windows.Forms.Label lblScanResult;
		private System.Windows.Forms.PictureBox iconBoxNo;
		private System.Windows.Forms.PictureBox iconBoxFail;
		private System.Windows.Forms.Label lblScanReady;
		private System.Windows.Forms.PictureBox imgScanReady;
		private System.Windows.Forms.Label lblOverride;
		private System.Windows.Forms.Button btnOverrideYes;
		private System.Windows.Forms.Button btnOverrideNo;
		private System.Windows.Forms.Panel savePanel;
		private System.Windows.Forms.Label lblScanComplete;
		private System.Windows.Forms.Label lblNumScannedInfo;
		private System.Windows.Forms.Button btnSaveToFile;
		private System.Windows.Forms.Button btnSaveToVenture;
		private System.Windows.Forms.Label lblSaveToVenture;
		private System.Windows.Forms.Button btnStartOver;
		private System.Windows.Forms.Button btnExit;
	}
}