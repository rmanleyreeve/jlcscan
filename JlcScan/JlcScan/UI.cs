using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using CeReader;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using REMedia;

namespace REMedia.JlcScan {

	public partial class UI : Form {

		[DllImport("DeviceAPI.dll", EntryPoint = "Barcode1D_init")]
		private static extern void Barcode1D_init();

		[DllImport("DeviceAPI.dll", EntryPoint = "Barcode1D_scan")]
		private static extern int Barcode1D_scan(byte[] pszData);

		[DllImport("DeviceAPI.dll", EntryPoint = "Barcode1D_free")]
		private static extern void Barcode1D_free();

		private List<Registration> registrations = new List<Registration>();
		private string eventID;
		private string eventTitle;
		private int numScans;

		public UI() {
			InitializeComponent();
		}

		private void Ui_Load(object sender, EventArgs e) {
			//logLine("LOADED");
			if (SystemInco.alreadyRun(this.Text, this.Handle.ToInt32())) {
				MessageBox.Show("repeated start");
				this.Close();
			} else {
				UpdateText("");
				numScans = -1;
				ScanIncrement();
				Barcode1D_init();
			}
		}
		private void Ui_Closed(object sender, EventArgs e) {
			//logLine("CLOSED");
			Barcode1D_free();
			GC.Collect();
		}
		private void Ui_KeyDown(object sender, KeyEventArgs e) {
			//logLine("KEY DOWN");
			if (e.KeyValue == (int)ConstantKeyValue.Scan) {
				this.btnScan_Click(null, null);
			}
			if (e.KeyValue == (int)ConstantKeyValue.ESC) {
				this.Close();
			}
		}
		private void Ui_KeyUp(object sender, KeyEventArgs e) {
			//logLine("KEY UP");
			if (e.KeyValue == 118)
				this.Close();
		}
		private void Ui_KeyPress(object sender, KeyPressEventArgs e) {
			//logLine("KEY PRESS");
		}


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

				MessageBox.Show("Event Data Loaded for " + eventTitle.ToUpper() + "(" + numReg + " registrations)");
				this.loadPanel.Hide();
				this.scanPanel.Show();

			} else {
				MessageBox.Show("Please select an Event Data file");
			}
		}

		private void btnScan_Click(object sender, EventArgs e) {
			string barCode = Scan();
			if (!string.IsNullOrEmpty(barCode)) {
				ScanIncrement();
				//CommonClass.PlaySound(@"\windows\beep.wav");
				lblScanResult.Text = barCode;
				log(barCode);
				string evID = "";
				int regID = 0;
				try {
					String[] parts = barCode.Split(' ');
					log(parts[0]);
					log(parts[1]);
					evID = parts[0];
					regID = Convert.ToInt32(parts[1]);
					// check event code matches
					if (evID != eventID) {
						CommonClass.PlaySound(@"\windows\critical.wav");
						UpdateText("ERROR - WRONG EVENT");
					} else {
						// event ok, check reg id against list
						Registration reg = registrations.FirstOrDefault(r => r.id == regID);
						if (reg != null) {
							// on the list 
							CommonClass.PlaySound(@"\windows\beep.wav");
							UpdateText(reg.first_name + " " + reg.last_name + " ON THE LIST");
						} else {
							// not on the list
							CommonClass.PlaySound(@"\windows\critical.wav");
							UpdateText("NOT ON THE LIST");
						}
					}
				} catch (Exception ex) {
					CommonClass.PlaySound(@"\windows\critical.wav");
					UpdateText("ERROR - WRONG BARCODE FORMAT");
				}

			} else {

				CommonClass.PlaySound(@"\windows\critical.wav");
				UpdateText("Failed to scan");

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
				log(ex.Message);
				return String.Empty;
			}
		}

		private void UpdateText(string txt) {
			lblScanResult.Text = txt;
		}
		private void ScanIncrement() {
			numScans++;
			lblScanSum.Text = "Scanned: " + Convert.ToString(numScans);
		}
		public static void log(string msg) {
			System.Diagnostics.Debug.Write(msg);
		}

	}

	public class Registration {
		public int id { get; set; }
		public string first_name { get; set; }
		public string last_name { get; set; }
	}





}