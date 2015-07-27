namespace JLC_Badge_Maker {
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
			this.mainPanel = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.country = new System.Windows.Forms.TextBox();
			this.labelCountry = new System.Windows.Forms.Label();
			this.organisation = new System.Windows.Forms.TextBox();
			this.labelOrg = new System.Windows.Forms.Label();
			this.last_name = new System.Windows.Forms.TextBox();
			this.labelSurname = new System.Windows.Forms.Label();
			this.first_name = new System.Windows.Forms.TextBox();
			this.labelFirstname = new System.Windows.Forms.Label();
			this.title = new System.Windows.Forms.TextBox();
			this.labelTitle = new System.Windows.Forms.Label();
			this.eventID = new System.Windows.Forms.TextBox();
			this.labelID = new System.Windows.Forms.Label();
			this.labelPos = new System.Windows.Forms.Label();
			this.labelStyle = new System.Windows.Forms.Label();
			this.menuPrintPosition = new System.Windows.Forms.ComboBox();
			this.menuBadgeStyle = new System.Windows.Forms.ComboBox();
			this.buttonGo = new System.Windows.Forms.Button();
			this.lblLogo = new System.Windows.Forms.Label();
			this.imgLogo = new System.Windows.Forms.PictureBox();
			this.mainPanel.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.BackColor = System.Drawing.Color.DarkCyan;
			this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mainPanel.Controls.Add(this.groupBox1);
			this.mainPanel.Controls.Add(this.labelPos);
			this.mainPanel.Controls.Add(this.labelStyle);
			this.mainPanel.Controls.Add(this.menuPrintPosition);
			this.mainPanel.Controls.Add(this.menuBadgeStyle);
			this.mainPanel.Controls.Add(this.buttonGo);
			this.mainPanel.Location = new System.Drawing.Point(12, 54);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Size = new System.Drawing.Size(600, 375);
			this.mainPanel.TabIndex = 2;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.country);
			this.groupBox1.Controls.Add(this.labelCountry);
			this.groupBox1.Controls.Add(this.organisation);
			this.groupBox1.Controls.Add(this.labelOrg);
			this.groupBox1.Controls.Add(this.last_name);
			this.groupBox1.Controls.Add(this.labelSurname);
			this.groupBox1.Controls.Add(this.first_name);
			this.groupBox1.Controls.Add(this.labelFirstname);
			this.groupBox1.Controls.Add(this.title);
			this.groupBox1.Controls.Add(this.labelTitle);
			this.groupBox1.Controls.Add(this.eventID);
			this.groupBox1.Controls.Add(this.labelID);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(27, 36);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(544, 260);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// country
			// 
			this.country.Location = new System.Drawing.Point(128, 217);
			this.country.Name = "country";
			this.country.Size = new System.Drawing.Size(392, 24);
			this.country.TabIndex = 6;
			// 
			// labelCountry
			// 
			this.labelCountry.AutoSize = true;
			this.labelCountry.ForeColor = System.Drawing.Color.White;
			this.labelCountry.Location = new System.Drawing.Point(16, 220);
			this.labelCountry.Name = "labelCountry";
			this.labelCountry.Size = new System.Drawing.Size(64, 18);
			this.labelCountry.TabIndex = 9;
			this.labelCountry.Text = "Country:";
			// 
			// organisation
			// 
			this.organisation.Location = new System.Drawing.Point(128, 181);
			this.organisation.Name = "organisation";
			this.organisation.Size = new System.Drawing.Size(388, 24);
			this.organisation.TabIndex = 5;
			// 
			// labelOrg
			// 
			this.labelOrg.AutoSize = true;
			this.labelOrg.ForeColor = System.Drawing.Color.White;
			this.labelOrg.Location = new System.Drawing.Point(16, 184);
			this.labelOrg.Name = "labelOrg";
			this.labelOrg.Size = new System.Drawing.Size(96, 18);
			this.labelOrg.TabIndex = 8;
			this.labelOrg.Text = "Organisation:";
			// 
			// last_name
			// 
			this.last_name.Location = new System.Drawing.Point(128, 145);
			this.last_name.Name = "last_name";
			this.last_name.Size = new System.Drawing.Size(388, 24);
			this.last_name.TabIndex = 4;
			// 
			// labelSurname
			// 
			this.labelSurname.AutoSize = true;
			this.labelSurname.ForeColor = System.Drawing.Color.White;
			this.labelSurname.Location = new System.Drawing.Point(16, 148);
			this.labelSurname.Name = "labelSurname";
			this.labelSurname.Size = new System.Drawing.Size(84, 18);
			this.labelSurname.TabIndex = 6;
			this.labelSurname.Text = "Last Name:";
			// 
			// first_name
			// 
			this.first_name.Location = new System.Drawing.Point(128, 109);
			this.first_name.Name = "first_name";
			this.first_name.Size = new System.Drawing.Size(388, 24);
			this.first_name.TabIndex = 3;
			// 
			// labelFirstname
			// 
			this.labelFirstname.AutoSize = true;
			this.labelFirstname.ForeColor = System.Drawing.Color.White;
			this.labelFirstname.Location = new System.Drawing.Point(16, 112);
			this.labelFirstname.Name = "labelFirstname";
			this.labelFirstname.Size = new System.Drawing.Size(103, 18);
			this.labelFirstname.TabIndex = 4;
			this.labelFirstname.Text = "First Name(s):";
			// 
			// title
			// 
			this.title.Location = new System.Drawing.Point(128, 73);
			this.title.Name = "title";
			this.title.Size = new System.Drawing.Size(156, 24);
			this.title.TabIndex = 2;
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.ForeColor = System.Drawing.Color.White;
			this.labelTitle.Location = new System.Drawing.Point(16, 76);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(39, 18);
			this.labelTitle.TabIndex = 2;
			this.labelTitle.Text = "Title:";
			// 
			// eventID
			// 
			this.eventID.Location = new System.Drawing.Point(128, 24);
			this.eventID.Name = "eventID";
			this.eventID.Size = new System.Drawing.Size(64, 24);
			this.eventID.TabIndex = 1;
			// 
			// labelID
			// 
			this.labelID.AutoSize = true;
			this.labelID.ForeColor = System.Drawing.Color.White;
			this.labelID.Location = new System.Drawing.Point(16, 28);
			this.labelID.Name = "labelID";
			this.labelID.Size = new System.Drawing.Size(67, 18);
			this.labelID.TabIndex = 0;
			this.labelID.Text = "Event ID:";
			// 
			// labelPos
			// 
			this.labelPos.AutoSize = true;
			this.labelPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPos.ForeColor = System.Drawing.Color.White;
			this.labelPos.Location = new System.Drawing.Point(236, 320);
			this.labelPos.Name = "labelPos";
			this.labelPos.Size = new System.Drawing.Size(59, 16);
			this.labelPos.TabIndex = 14;
			this.labelPos.Text = "Position:";
			// 
			// labelStyle
			// 
			this.labelStyle.AutoSize = true;
			this.labelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelStyle.ForeColor = System.Drawing.Color.White;
			this.labelStyle.Location = new System.Drawing.Point(34, 320);
			this.labelStyle.Name = "labelStyle";
			this.labelStyle.Size = new System.Drawing.Size(41, 16);
			this.labelStyle.TabIndex = 13;
			this.labelStyle.Text = "Style:";
			// 
			// menuPrintPosition
			// 
			this.menuPrintPosition.FormattingEnabled = true;
			this.menuPrintPosition.Items.AddRange(new object[] {
            "Top Left",
            "Top Right",
            "Middle Left",
            "Middle Right",
            "Bottom Left",
            "Bottom Right"});
			this.menuPrintPosition.Location = new System.Drawing.Point(296, 318);
			this.menuPrintPosition.Name = "menuPrintPosition";
			this.menuPrintPosition.Size = new System.Drawing.Size(100, 21);
			this.menuPrintPosition.TabIndex = 11;
			this.menuPrintPosition.SelectedIndexChanged += new System.EventHandler(this.menuPrintPosition_SelectedIndexChanged);
			// 
			// menuBadgeStyle
			// 
			this.menuBadgeStyle.FormattingEnabled = true;
			this.menuBadgeStyle.Items.AddRange(new object[] {
            "Select Badge Style...",
            "6 per page, logo top",
            "6 per page, logo bottom"});
			this.menuBadgeStyle.Location = new System.Drawing.Point(75, 318);
			this.menuBadgeStyle.Name = "menuBadgeStyle";
			this.menuBadgeStyle.Size = new System.Drawing.Size(148, 21);
			this.menuBadgeStyle.TabIndex = 10;
			this.menuBadgeStyle.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// buttonGo
			// 
			this.buttonGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonGo.Location = new System.Drawing.Point(412, 315);
			this.buttonGo.Name = "buttonGo";
			this.buttonGo.Size = new System.Drawing.Size(152, 27);
			this.buttonGo.TabIndex = 99;
			this.buttonGo.Text = "Create Badge";
			this.buttonGo.UseVisualStyleBackColor = true;
			this.buttonGo.Click += new System.EventHandler(this.button1_Click);
			// 
			// lblLogo
			// 
			this.lblLogo.AutoSize = true;
			this.lblLogo.BackColor = System.Drawing.Color.DarkCyan;
			this.lblLogo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLogo.Location = new System.Drawing.Point(190, 56);
			this.lblLogo.Name = "lblLogo";
			this.lblLogo.Size = new System.Drawing.Size(246, 32);
			this.lblLogo.TabIndex = 3;
			this.lblLogo.Text = "JLC Badge Maker";
			// 
			// imgLogo
			// 
			this.imgLogo.Image = ((System.Drawing.Image)(resources.GetObject("imgLogo.Image")));
			this.imgLogo.Location = new System.Drawing.Point(12, 0);
			this.imgLogo.Name = "imgLogo";
			this.imgLogo.Size = new System.Drawing.Size(600, 50);
			this.imgLogo.TabIndex = 4;
			this.imgLogo.TabStop = false;
			// 
			// UI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Lavender;
			this.ClientSize = new System.Drawing.Size(624, 442);
			this.Controls.Add(this.lblLogo);
			this.Controls.Add(this.imgLogo);
			this.Controls.Add(this.mainPanel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(640, 480);
			this.MinimumSize = new System.Drawing.Size(640, 480);
			this.Name = "UI";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "JLC Badge Maker";
			this.mainPanel.ResumeLayout(false);
			this.mainPanel.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel mainPanel;
		private System.Windows.Forms.Label lblLogo;
		private System.Windows.Forms.PictureBox imgLogo;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label labelID;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.TextBox eventID;
		private System.Windows.Forms.TextBox title;
		private System.Windows.Forms.Label labelFirstname;
		private System.Windows.Forms.TextBox organisation;
		private System.Windows.Forms.Label labelOrg;
		private System.Windows.Forms.TextBox last_name;
		private System.Windows.Forms.Label labelSurname;
		private System.Windows.Forms.TextBox first_name;
		private System.Windows.Forms.Button buttonGo;
		private System.Windows.Forms.ComboBox menuPrintPosition;
		private System.Windows.Forms.ComboBox menuBadgeStyle;
		private System.Windows.Forms.Label labelPos;
		private System.Windows.Forms.Label labelStyle;
		private System.Windows.Forms.TextBox country;
		private System.Windows.Forms.Label labelCountry;
	}
}

