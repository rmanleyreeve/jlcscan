using System;
using System.Windows.Forms;
using SDK.English.JlcScan;
using CeReader;
using System.Runtime.InteropServices;
using System.Text;
using SDK.English;

namespace SDK.English.UI {

	public partial class JlcScanUi : Form {
		[DllImport("DeviceAPI.dll", EntryPoint = "Barcode1D_init")]
		private static extern void Barcode1D_init();

		[DllImport("DeviceAPI.dll", EntryPoint = "Barcode1D_scan")]
		private static extern int Barcode1D_scan(byte[] pszData);

		[DllImport("DeviceAPI.dll", EntryPoint = "Barcode1D_free")]
		private static extern void Barcode1D_free();


		private delegate void myThread();

		public JlcScanUi() {
			InitializeComponent();

		}

		private void Barcode1DDemo_Load(object sender, EventArgs e) {

			if (SystemInco.alreadyRun(this.Text, this.Handle.ToInt32())) {
				MessageBox.Show("repeated start");
				this.Close();
			} else {
				checkBox1.Checked = false;

				labelScanSum.Text = "0";
				labelSuccess.Text = "0";
				Barcode1D_init();
			}
		}

		private void Barcode1DDemo_Closed(object sender, EventArgs e) {
			timerScan.Enabled = false;
			timerScan.Dispose();
			Barcode1D_free();
			GC.Collect();
		}

		private void btnScan_Click(object sender, EventArgs e) {
			//Scan Barcode

			string nCode = Scan();
			labelScanSum.Text = Convert.ToString(Convert.ToInt16(labelScanSum.Text) + 1);
			if (!string.IsNullOrEmpty(nCode)) {
				CommonClass.PlaySound();
				textBox1.Text = nCode + "\r\n" + textBox1.Text;
				labelSuccess.Text = Convert.ToString(Convert.ToInt16(labelSuccess.Text) + 1);
			} else {
				textBox1.Text = "Failed to scan\r\n" + textBox1.Text;
			}
		}

		private void UpdateTextBox(string nCode) {
			string note = nCode;
			if (checkBox2.Checked) {
				if (code_temp == string.Empty) {
					code_temp = nCode;
				}
				if (code_temp == nCode) {
					labelSuccess.Text = Convert.ToString(Convert.ToInt16(labelSuccess.Text) + 1);
				} else {
					code_temp = nCode;
					note = note + "Does not match with the last scan results";
				}
			} else {
				labelSuccess.Text = Convert.ToString(Convert.ToInt16(labelSuccess.Text) + 1);
			}
			textBox1.Text = note + "\r\n" + textBox1.Text;


		}
		public string code_temp = string.Empty;
		private void checkBox1_Click(object sender, EventArgs e) {
			if (checkBox1.Checked) {
				checkBox2.Visible = true;

				if (MessageBox.Show("Open Uninterrupted scanning？", "Prompt", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.OK) {
					checkBox1.Checked = false;
					return;
				}
				labelScanSum.Text = "0";
				labelSuccess.Text = "0";

				btnScan.Enabled = false;

				timerScan.Interval = (int)numericUpDown1.Value;
				timerScan.Enabled = true;
			} else {
				timerScan.Enabled = false;

				checkBox2.Visible = false;
				btnScan.Enabled = true;
				btnScan.Focus();
				labelScanSum.Text = "0";
				labelSuccess.Text = "0";
			}
		}

		private void Barcode1DDemo_KeyUp(object sender, KeyEventArgs e) {
			if (e.KeyValue == 118)
				this.Close();
		}

		private void pictureBox1_Click(object sender, EventArgs e) {
			this.Close();
		}
		public static string Scan() {
			int ibarLen = 0;
			byte[] pszData = new byte[2048];
			string barcode = string.Empty;

			try {
				ibarLen = Barcode1D_scan(pszData);

				if (ibarLen > 0) {
					barcode = Encoding.ASCII.GetString(pszData, 0, ibarLen).Trim();
				}
				return barcode;
			} catch (System.Exception ex) {
				//return string.Empty;
				return ex.Message;
			}

		}


		private void timerScan_Tick(object sender, EventArgs e) {
			string nCode = Scan();
			labelScanSum.Text = Convert.ToString(Convert.ToInt16(labelScanSum.Text) + 1);

			if (string.IsNullOrEmpty(nCode)) {
				textBox1.Text = "Failed to scan\r\n" + textBox1.Text;
			} else {
				UpdateTextBox(nCode);
				CommonClass.PlaySound();
			}
		}

		private void checkBox2_Click(object sender, EventArgs e) {
			if (checkBox2.Checked) {
				code_temp = string.Empty;
			}
		}

		private void Barcode1DDemo_KeyDown(object sender, KeyEventArgs e) {
			//if the device type is C2000,and press the Scan
			if (e.KeyValue == (int)ConstantKeyValue.Scan && SystemHelper.CurrentDeviceType == DeviceType.C2000) {
				this.btnScan_Click(null, null);
			}
			//if the device type is C2000,and press the ESC
			if (e.KeyValue == (int)ConstantKeyValue.ESC && SystemHelper.CurrentDeviceType == DeviceType.C2000) {
				this.Close();
			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e) {

		}
	}
}