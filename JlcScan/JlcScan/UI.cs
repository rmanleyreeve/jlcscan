using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SDK.English.JlcScan {

	public partial class UI : Form {

		[DllImport("DeviceAPI.dll", EntryPoint = "Barcode1D_init")]
		private static extern void Barcode1D_init();

		[DllImport("DeviceAPI.dll", EntryPoint = "Barcode1D_scan")]
		private static extern int Barcode1D_scan(byte[] pszData);

		[DllImport("DeviceAPI.dll", EntryPoint = "Barcode1D_free")]
		private static extern void Barcode1D_free();


		public UI() {
			InitializeComponent();
		}

		private void Ui_Load(object sender, EventArgs e) {
			System.Diagnostics.Debug.WriteLine("LOADED");
			Barcode1D_init();
			lblScanResult.Text = "";
			lblScanSum.Text = "0";
		}
		private void Ui_Closed(object sender, EventArgs e) {
			System.Diagnostics.Debug.WriteLine("CLOSED");
			Barcode1D_free();
			GC.Collect();
		}
		private void Ui_KeyDown(object sender, KeyEventArgs e) {
			System.Diagnostics.Debug.WriteLine("KEY DOWN");
			if (e.KeyValue == (int)ConstantKeyValue.Scan) {
				this.btnScan_Click(null, null);
			}
			if (e.KeyValue == (int)ConstantKeyValue.ESC) {
				this.Close();
			}
		}
		private void Ui_KeyUp(object sender, KeyEventArgs e) {
			System.Diagnostics.Debug.WriteLine("KEY UP");
			if (e.KeyValue == 118)
				this.Close();
		}
		private void Ui_KeyPress(object sender, KeyPressEventArgs e) {
			System.Diagnostics.Debug.WriteLine("KEY PRESS");
		}


		public List<Registration> registrations = new List<Registration>();
		public List<int> regIdList = new List<int>();
		public string eventID;
		public string eventTitle;

		private void btnLoadFile_Click(object sender, EventArgs e) {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "XML File|*.xml";
			ofd.InitialDirectory = "\\My Documents";
			if (DialogResult.OK == ofd.ShowDialog()) {

				System.Xml.Linq.XDocument xdoc = System.Xml.Linq.XDocument.Load(ofd.FileName);

				eventID = (String)xdoc.Element("event").Attribute("id");
				eventTitle = (String)xdoc.Element("event").Element("title");
				registrations = (
					from r in xdoc.Descendants("registration") select new Registration() {
						id = Convert.ToInt16(r.Attribute("id").Value),
						first_name = r.Element("first_name").Value,
						last_name = r.Element("last_name").Value
					}
						).ToList<Registration>();
				int numReg = registrations.Count();

				foreach (Registration r in registrations) {
					regIdList.Add(r.id);
					System.Diagnostics.Debug.WriteLine(r.id);
				}
				MessageBox.Show("Event Data Loaded for " + eventTitle.ToUpper() + "(" + numReg + " registrations)");
				this.loadPanel.Hide();
				this.scanPanel.Show();


			} else {
				MessageBox.Show("Please select an Event Data file");
			}
		}

		private void btnScan_Click(object sender, EventArgs e) {
			string barCode = Scan();
			int sum = Convert.ToInt16(lblScanSum.Text);
			lblScanSum.Text = Convert.ToString( sum + 1);
			if (!string.IsNullOrEmpty(barCode)) {
				//CommonClass.PlaySound(@"\windows\beep.wav");
				lblScanResult.Text = barCode;
				System.Diagnostics.Debug.WriteLine(barCode);
				String[] parts = barCode.Split(' ');
				System.Diagnostics.Debug.WriteLine(parts[0]);
				System.Diagnostics.Debug.WriteLine(parts[1]);
				string evID = parts[0];
				int regID = Convert.ToInt32(parts[1]);

				if (evID != eventID) {
					CommonClass.PlaySound(@"\windows\critical.wav");
					lblScanResult.Text = "ERROR - Wrong event";
				} else {

					//bool ok = registrations.Any(r => r.id == regID);
					Registration reg = registrations.FirstOrDefault(r => r.id == regID);
					if(reg != null) {
						// ok 
						CommonClass.PlaySound(@"\windows\beep.wav");
						lblScanResult.Text = reg.first_name + " " + reg.last_name + " IS ON THE LIST";
					} else {
						// not ok
						CommonClass.PlaySound(@"\windows\critical.wav");
						lblScanResult.Text = "NOT ON THE LIST";
					}
				}

			} else {

				CommonClass.PlaySound(@"\windows\critical.wav");
				lblScanResult.Text = "Failed to scan";

			}
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
				System.Diagnostics.Debug.Write(ex.Message);
				return String.Empty;
			}

		}

		private void labelScanInfo_ParentChanged(object sender, EventArgs e) {

		}


	}

	public class Registration {
		public int id { get; set; }
		public string first_name { get; set; }
		public string last_name { get; set; }
	}





}