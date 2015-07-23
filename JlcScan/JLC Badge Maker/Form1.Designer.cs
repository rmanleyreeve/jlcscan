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
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.menuPrintPosition = new System.Windows.Forms.ComboBox();
			this.menuBadgeStyle = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.foo = new System.Windows.Forms.PictureBox();
			this.organisation = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.last_name = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.first_name = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.title = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.eventID = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lblLogo = new System.Windows.Forms.Label();
			this.imgLogo = new System.Windows.Forms.PictureBox();
			this.mainPanel.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.foo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.BackColor = System.Drawing.Color.DarkCyan;
			this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mainPanel.Controls.Add(this.label7);
			this.mainPanel.Controls.Add(this.label6);
			this.mainPanel.Controls.Add(this.menuPrintPosition);
			this.mainPanel.Controls.Add(this.menuBadgeStyle);
			this.mainPanel.Controls.Add(this.button1);
			this.mainPanel.Controls.Add(this.groupBox1);
			this.mainPanel.Location = new System.Drawing.Point(12, 88);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Size = new System.Drawing.Size(600, 338);
			this.mainPanel.TabIndex = 2;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.ForeColor = System.Drawing.Color.White;
			this.label7.Location = new System.Drawing.Point(246, 284);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(58, 16);
			this.label7.TabIndex = 14;
			this.label7.Text = "Position:";
			this.label7.Click += new System.EventHandler(this.label7_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.White;
			this.label6.Location = new System.Drawing.Point(34, 284);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(40, 16);
			this.label6.TabIndex = 13;
			this.label6.Text = "Style:";
			this.label6.Click += new System.EventHandler(this.label6_Click);
			// 
			// menuPrintPosition
			// 
			this.menuPrintPosition.FormattingEnabled = true;
			this.menuPrintPosition.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
			this.menuPrintPosition.Location = new System.Drawing.Point(306, 282);
			this.menuPrintPosition.Name = "menuPrintPosition";
			this.menuPrintPosition.Size = new System.Drawing.Size(57, 21);
			this.menuPrintPosition.TabIndex = 12;
			this.menuPrintPosition.SelectedIndexChanged += new System.EventHandler(this.menuPrintPosition_SelectedIndexChanged);
			// 
			// menuBadgeStyle
			// 
			this.menuBadgeStyle.FormattingEnabled = true;
			this.menuBadgeStyle.Items.AddRange(new object[] {
            "Select Badge Style...",
            "6 per page",
            "GLS",
            "ACC"});
			this.menuBadgeStyle.Location = new System.Drawing.Point(75, 282);
			this.menuBadgeStyle.Name = "menuBadgeStyle";
			this.menuBadgeStyle.Size = new System.Drawing.Size(148, 21);
			this.menuBadgeStyle.TabIndex = 11;
			this.menuBadgeStyle.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(412, 279);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(152, 27);
			this.button1.TabIndex = 10;
			this.button1.Text = "Create Badge";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.foo);
			this.groupBox1.Controls.Add(this.organisation);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.last_name);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.first_name);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.title);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.eventID);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(28, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(544, 232);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// foo
			// 
			this.foo.BackColor = System.Drawing.Color.Transparent;
			this.foo.Location = new System.Drawing.Point(332, 32);
			this.foo.Name = "foo";
			this.foo.Size = new System.Drawing.Size(200, 60);
			this.foo.TabIndex = 5;
			this.foo.TabStop = false;
			// 
			// organisation
			// 
			this.organisation.Location = new System.Drawing.Point(128, 188);
			this.organisation.Name = "organisation";
			this.organisation.Size = new System.Drawing.Size(388, 26);
			this.organisation.TabIndex = 5;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.ForeColor = System.Drawing.Color.White;
			this.label5.Location = new System.Drawing.Point(16, 192);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(103, 20);
			this.label5.TabIndex = 8;
			this.label5.Text = "Organisation:";
			// 
			// last_name
			// 
			this.last_name.Location = new System.Drawing.Point(128, 148);
			this.last_name.Name = "last_name";
			this.last_name.Size = new System.Drawing.Size(388, 26);
			this.last_name.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ForeColor = System.Drawing.Color.White;
			this.label4.Location = new System.Drawing.Point(16, 152);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(90, 20);
			this.label4.TabIndex = 6;
			this.label4.Text = "Last Name:";
			// 
			// first_name
			// 
			this.first_name.Location = new System.Drawing.Point(128, 108);
			this.first_name.Name = "first_name";
			this.first_name.Size = new System.Drawing.Size(388, 26);
			this.first_name.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(16, 112);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(108, 20);
			this.label3.TabIndex = 4;
			this.label3.Text = "First Name(s):";
			// 
			// title
			// 
			this.title.Location = new System.Drawing.Point(128, 72);
			this.title.Name = "title";
			this.title.Size = new System.Drawing.Size(156, 26);
			this.title.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(16, 76);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(42, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "Title:";
			// 
			// eventID
			// 
			this.eventID.Location = new System.Drawing.Point(128, 24);
			this.eventID.Name = "eventID";
			this.eventID.Size = new System.Drawing.Size(64, 26);
			this.eventID.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(16, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(75, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Event ID:";
			// 
			// lblLogo
			// 
			this.lblLogo.AutoSize = true;
			this.lblLogo.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLogo.Location = new System.Drawing.Point(217, 60);
			this.lblLogo.Name = "lblLogo";
			this.lblLogo.Size = new System.Drawing.Size(191, 24);
			this.lblLogo.TabIndex = 3;
			this.lblLogo.Text = "JLC Badge Creator";
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
			((System.ComponentModel.ISupportInitialize)(this.foo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel mainPanel;
		private System.Windows.Forms.Label lblLogo;
		private System.Windows.Forms.PictureBox imgLogo;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox eventID;
		private System.Windows.Forms.TextBox title;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox organisation;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox last_name;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox first_name;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox menuPrintPosition;
		private System.Windows.Forms.ComboBox menuBadgeStyle;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.PictureBox foo;
	}
}

