using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace REMedia.JlcScan {

	// main interface form
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
		private static List<int> regScanned_OnList = new List<int>();
		private static List<int> regScanned_NotOnList = new List<int>();

		public UI() {
			InitializeComponent();
		}

		private void Ui_Load(object sender, EventArgs e) {
			//Log("PROGRAM LOADED");
			if (SystemInco.alreadyRun(this.Text, this.Handle.ToInt32())) {
				MessageBox.Show("repeated start");
				this.Close();
			} else {
				// set up UI
				UpdateScanResult(String.Empty);
				numScans = -1;
				ScanIncrement();
				iconBox.Invalidate();
				if(IsServerAvailable()) {
					btnLoadFromWeb.Show();
				}
				Barcode1D_init();
			}
		}
		private void Ui_Closed(object sender, EventArgs e) {
			//Log("PROGRAM CLOSED");
			Barcode1D_free();
			GC.Collect();
		}
		private void Ui_KeyDown(object sender, KeyEventArgs e) {
			//Log("KEY DOWN");
			if (e.KeyValue == (int)ConstantKeyValue.Scan) {
				this.btnScan_Click(null, null);
			}
			if (e.KeyValue == (int)ConstantKeyValue.ESC) {
				this.Close();
			}
		}
		private void Ui_KeyUp(object sender, KeyEventArgs e) {
			//Log("KEY UP");
			if (e.KeyValue == 118) { // F7 ??
				this.Close();
			}
		}

		// UI METHODS =====================================================
		private void UpdateScanResult(string txt) {
			lblScanResult.Text = txt;
		}
		private void UpdateTotalScanCount() {
			lblScanSum.Text = "Scanned: " + Convert.ToString(numScans);
		}
		private void ScanIncrement() {
			numScans++;
			UpdateTotalScanCount();
		}
		private void UpdateIcon(string str) {
			iconBox.Invalidate();
			iconBox.Image = (Image)new System.ComponentModel.ComponentResourceManager(typeof(UI)).GetObject(str);
			iconBox.Refresh();
		}
		public static void Log(String msg) {
			System.Diagnostics.Debug.WriteLine(msg);
		}
		// SCANNING RELATED METHODS ============================================
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
				Log(ex.Message);
				return String.Empty;
			}
		}
		public void RegOk(Registration reg) {
			regScanned_OnList.Add(reg.id);
			C.PlaySound(@"\windows\beep.wav");
			UpdateIcon("ok");
			UpdateScanResult(reg.first_name + " " + reg.last_name + "\n" + C.VALID_REG_MSG);
		}
		public void RegNotOk(int r) {
			regScanned_NotOnList.Add(r);
			C.PlaySound(@"\windows\critical.wav");
			UpdateIcon("no");
			UpdateScanResult(C.INVALID_REG_MSG);
			// TODO show override screen
		}
		public void RegAlreadyScanned() {
			C.PlaySound(@"\windows\critical.wav");
			UpdateIcon("fail");
			UpdateScanResult(C.DUPLICATE_SCAN_MSG);
		}
		public void BadEventCode() {
			C.PlaySound(@"\windows\critical.wav");
			UpdateIcon("fail");
			UpdateScanResult(C.BAD_EVENT_MSG);
		}
		public void BadFormat() {
			C.PlaySound(@"\windows\critical.wav");
			UpdateIcon("fail");
			UpdateScanResult(C.BAD_FORMAT_MSG);
		}
		public void ScanFail() {
			C.PlaySound(@"\windows\critical.wav");
			UpdateIcon("fail");
			UpdateScanResult(C.SCAN_FAIL_MSG);
		}
		// DATA FILE METHODS ======================================
		private int ReadXML(System.Xml.Linq.XDocument xdoc) {
			eventID = (String)xdoc.Element("event").Attribute("id");
			eventTitle = (String)xdoc.Element("event").Element("title");
			registrations = (
				from r in xdoc.Descendants("registration") select new Registration() {
					id = Convert.ToInt16(r.Attribute("id").Value),
					first_name = r.Element("first_name").Value,
					last_name = r.Element("last_name").Value
				}
			).ToList<Registration>();
			return registrations.Count();
		}
		private void SaveCsvFile() {
			string filePath = String.Format("{0}\\{1}.csv",C.INITIAL_DIR,eventID);
			File.Create(filePath).Close();
			using (TextWriter writer = File.CreateText(filePath)) {
				writer.WriteLine("File Saved: " + DateTime.Now.ToString());
				regScanned_OnList.ForEach(x => writer.WriteLine(Convert.ToString(x)));
			}
		}

		// NETWORK METHODS ========================================================================
		private bool IsServerAvailable() {
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(C.CHECK_URL);
			request.Timeout = 5000;
			//request.Credentials = CredentialCache.DefaultNetworkCredentials;
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			if (response.StatusCode == HttpStatusCode.OK) {
				Log("IsServerAvailable: " + response.StatusCode);
				return true;
			} else {
				return false;
			}
		}
		private string GetDataFromServer() {
			StringBuilder sb = new StringBuilder();
			try {
				byte[] buf = new byte[8192];
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(C.WEBSVC_ENDPOINT);
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				Stream resStream = response.GetResponseStream();
				string tempString = null;
				int count = 0;
				do {
					count = resStream.Read(buf, 0, buf.Length);
					if (count != 0) {
						tempString = Encoding.UTF8.GetString(buf, 0, count);
						sb.Append(tempString);
					}
				}
				while (count > 0);
			} catch (Exception ex) { }
			return (sb.ToString());
		}
		private Dictionary<int, string> GetEventListFromServer() {
			Dictionary<int, string> eventList = new Dictionary<int, string>();
			// TODO - connect to server & get data of IDs & event titles
			return eventList;
		}

		// BUTTON CLICK HANDLERS ====================================================================
		private void btnLoadFile_Click(object sender, EventArgs e) {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "XML File|*.xml";
			ofd.InitialDirectory = C.INITIAL_DIR;
			if (DialogResult.OK == ofd.ShowDialog()) {
				// load xml file
				System.Xml.Linq.XDocument xdoc = System.Xml.Linq.XDocument.Load(ofd.FileName);
				int numReg = ReadXML(xdoc);
				MessageBox.Show(String.Format(C.DATA_LOADED_MSG, eventTitle.ToUpper(), numReg));
				this.loadPanel.Hide();
				this.scanPanel.Show();
			} else {
				MessageBox.Show(C.SELECT_FILE_MSG);
			}
		}
		private void btnScan_Click(object sender, EventArgs e) {
			string barCode = Scan();
			if (!string.IsNullOrEmpty(barCode)) {
				ScanIncrement();
				Log("Scanned "+barCode);
				string evID = "";
				int regID = 0;
				try {
					String[] parts = barCode.Split(' ');
					Log(parts[0]);
					Log(parts[1]);
					evID = parts[0];
					regID = Convert.ToInt32(parts[1]);
					// check event code matches
					if (evID != eventID) {
						BadEventCode();
					} else {
						// event ok, check reg id against list
						Registration reg = registrations.FirstOrDefault(r => r.id == regID);
						if (reg != null) {
							// on the list 
							if (regScanned_OnList.Contains(regID)) {
								RegAlreadyScanned();
							} else {
								RegOk(reg);
							}
						} else {
							// not on the list
							RegNotOk(regID);
						}
					}
				} catch (Exception ex) {
					BadFormat();
				}
			} else {
				ScanFail();
			}
		}
		private void btnScanDone_Click(object sender, EventArgs e) {
			if (regScanned_OnList.Count > 0) {
				MessageBox.Show(String.Format(C.REG_SAVED_MSG, regScanned_OnList.Count));
				SaveCsvFile();
			} else {
				MessageBox.Show(C.NO_REG_SAVED_MSG);
			}
			this.Close();
		}
		private void btnLoadFromWeb_Click(object sender, EventArgs e) {
			if (IsServerAvailable()) {
				try {
					string data = GetDataFromServer();
					System.Xml.Linq.XDocument xdoc = System.Xml.Linq.XDocument.Parse(data.ToString());
					int numReg = ReadXML(xdoc);
					MessageBox.Show( String.Format(C.DATA_LOADED_MSG, eventTitle.ToUpper(),numReg) );
					this.loadPanel.Hide();
					this.scanPanel.Show();
				} catch (Exception ex) {
					Log(ex.StackTrace);
					MessageBox.Show(C.NO_CONNECTION_MSG);
				}
			} else {
				MessageBox.Show(C.NO_CONNECTION_MSG);
			}
		}


	}

	// registration class for each registered delegate
	public class Registration {
		public int id { get; set; }
		public string title { get; set; }
		public string first_name { get; set; }
		public string last_name { get; set; }
		public string suffix { get; set; }
	}





}