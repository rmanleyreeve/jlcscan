﻿namespace REMedia.JlcScan {

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
			this.loadPanel = new System.Windows.Forms.Panel();
			this.lblLoadFile = new System.Windows.Forms.Label();
			this.btnLoadFile = new System.Windows.Forms.Button();
			this.labelLoadWeb = new System.Windows.Forms.Label();
			this.menuEvents = new System.Windows.Forms.ComboBox();
			this.btnLoadFromWeb = new System.Windows.Forms.Button();
			this.scanPanel = new System.Windows.Forms.Panel();
			this.labelScanInfo = new System.Windows.Forms.Label();
			this.btnScan = new System.Windows.Forms.Button();
			this.lblScanResult = new System.Windows.Forms.Label();
			this.iconBox = new System.Windows.Forms.PictureBox();
			this.lblScanSum = new System.Windows.Forms.Label();
			this.btnScanDone = new System.Windows.Forms.Button();
			this.btnSelect = new System.Windows.Forms.Button();
			this.lblValid = new System.Windows.Forms.Label();
			this.lblScanFail = new System.Windows.Forms.Label();
			this.containerPanel.SuspendLayout();
			this.loadPanel.SuspendLayout();
			this.scanPanel.SuspendLayout();
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
			this.containerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.containerPanel.Location = new System.Drawing.Point(0, 0);
			this.containerPanel.Name = "containerPanel";
			this.containerPanel.Size = new System.Drawing.Size(238, 295);
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
			// btnScan
			// 
			this.btnScan.Location = new System.Drawing.Point(4, 32);
			this.btnScan.Name = "btnScan";
			this.btnScan.Size = new System.Drawing.Size(72, 20);
			this.btnScan.TabIndex = 2;
			this.btnScan.Text = "Scan";
			this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
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
			// iconBox
			// 
			this.iconBox.Location = new System.Drawing.Point(96, 68);
			this.iconBox.Name = "iconBox";
			this.iconBox.Size = new System.Drawing.Size(48, 48);
			// 
			// lblScanSum
			// 
			this.lblScanSum.BackColor = System.Drawing.Color.DarkCyan;
			this.lblScanSum.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
			this.lblScanSum.Location = new System.Drawing.Point(0, 224);
			this.lblScanSum.Name = "lblScanSum";
			this.lblScanSum.Size = new System.Drawing.Size(76, 20);
			this.lblScanSum.Text = "Scanned: 0";
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
			// btnSelect
			// 
			this.btnSelect.Location = new System.Drawing.Point(82, 32);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(72, 20);
			this.btnSelect.TabIndex = 6;
			this.btnSelect.Text = "Options";
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			// 
			// lblValid
			// 
			this.lblValid.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
			this.lblValid.Location = new System.Drawing.Point(92, 224);
			this.lblValid.Name = "lblValid";
			this.lblValid.Size = new System.Drawing.Size(60, 20);
			this.lblValid.Text = "Valid:";
			// 
			// lblScanFail
			// 
			this.lblScanFail.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
			this.lblScanFail.Location = new System.Drawing.Point(168, 224);
			this.lblScanFail.Name = "lblScanFail";
			this.lblScanFail.Size = new System.Drawing.Size(68, 20);
			this.lblScanFail.Text = "Failed:";
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
			this.loadPanel.ResumeLayout(false);
			this.scanPanel.ResumeLayout(false);
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
	}
}