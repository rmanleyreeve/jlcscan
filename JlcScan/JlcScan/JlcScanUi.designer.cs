namespace SDK.English.UI {
	partial class JlcScanUi {
		/// <summary>
		/// Clean up all the resources being used.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="disposing">If managed resources should be released, it is true; otherwise false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// Required method for Designer support - do not
		/// use the code editor to modify the contents of this method.
		/// </summary>
		private void InitializeComponent() {

			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JlcScanUi));
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.btnScan = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.labelScanSum = new System.Windows.Forms.Label();
			this.labelSuccess = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.imageList1 = new System.Windows.Forms.ImageList();
			this.timerScan = new System.Windows.Forms.Timer();
			this.SuspendLayout();
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(3, 4);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(111, 20);
			this.checkBox1.TabIndex = 0;
			this.checkBox1.Text = "Uninterrupted";
			this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(3, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 20);
			this.label1.Text = "Scan interval";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.numericUpDown1.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.numericUpDown1.Location = new System.Drawing.Point(95, 23);
			this.numericUpDown1.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.ReadOnly = true;
			this.numericUpDown1.Size = new System.Drawing.Size(67, 24);
			this.numericUpDown1.TabIndex = 2;
			this.numericUpDown1.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(163, 26);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 20);
			this.label2.Text = "Millisecond";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// checkBox2
			// 
			this.checkBox2.Location = new System.Drawing.Point(138, 3);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(100, 20);
			this.checkBox2.TabIndex = 4;
			this.checkBox2.Text = "Compare";
			this.checkBox2.Visible = false;
			this.checkBox2.Click += new System.EventHandler(this.checkBox2_Click);
			// 
			// btnScan
			// 
			this.btnScan.BackColor = System.Drawing.Color.Transparent;
			this.btnScan.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
			this.btnScan.Location = new System.Drawing.Point(74, 235);
			this.btnScan.Name = "btnScan";
			this.btnScan.Size = new System.Drawing.Size(92, 31);
			this.btnScan.TabIndex = 0;
			this.btnScan.Text = "Scan 123";
			this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
			// 
			// textBox1
			// 
			this.textBox1.AcceptsTab = true;
			this.textBox1.Location = new System.Drawing.Point(5, 50);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size(230, 163);
			this.textBox1.TabIndex = 0;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// label4
			// 
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(-2, 216);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(75, 20);
			this.label4.Text = "Total Scan:";
			// 
			// label5
			// 
			this.label5.ForeColor = System.Drawing.Color.Black;
			this.label5.Location = new System.Drawing.Point(112, 216);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(61, 20);
			this.label5.Text = "Success:";
			// 
			// labelScanSum
			// 
			this.labelScanSum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.labelScanSum.Location = new System.Drawing.Point(65, 216);
			this.labelScanSum.Name = "labelScanSum";
			this.labelScanSum.Size = new System.Drawing.Size(56, 20);
			this.labelScanSum.Text = "label7";
			// 
			// labelSuccess
			// 
			this.labelSuccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.labelSuccess.Location = new System.Drawing.Point(173, 216);
			this.labelSuccess.Name = "labelSuccess";
			this.labelSuccess.Size = new System.Drawing.Size(61, 20);
			this.labelSuccess.Text = "label8";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(199, 248);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(38, 20);
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(38, 20);
			this.imageList1.Images.Clear();
			this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
			this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
			// 
			// timerScan
			// 
			this.timerScan.Tick += new System.EventHandler(this.timerScan_Tick);
			// 
			// FrmBarcode1D
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(265, 270);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnScan);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.labelSuccess);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.labelScanSum);
			this.Controls.Add(this.label4);
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmBarcode1D";
			this.Text = "Barcode_1D Test";
			this.Load += new System.EventHandler(this.Barcode1DDemo_Load);
			this.Closed += new System.EventHandler(this.Barcode1DDemo_Closed);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Barcode1DDemo_KeyUp);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Barcode1DDemo_KeyDown);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.Button btnScan;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label labelScanSum;
		private System.Windows.Forms.Label labelSuccess;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Timer timerScan;
	}
}