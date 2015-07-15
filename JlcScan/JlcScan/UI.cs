using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

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
		private List<Event> events = new List<Event>();
		private string eventID;
		private string eventTitle;
		private int numTotalScans;
		private int numEvents = 0;
		private static List<int> regScanned_OnList = new List<int>();
		private static List<int> regScanned_NotOnList = new List<int>();
		public bool Online = false;

		public UI() {
			InitializeComponent();
		}

		// UTILITY METHODS =====================================================================
		private void Ui_Load(object sender, EventArgs e) {
			//Log("PROGRAM LOADED");
			if (SystemInco.alreadyRun(this.Text, this.Handle.ToInt32())) {
				MessageBox.Show("repeated start");
				this.Close();
			} else {
				// set up UI
				UpdateScanResult(String.Empty);
				numTotalScans = 0;
				UpdateTotalScanCount();
				iconBox.Invalidate();
				// check if web services available
				Online = IsServerAvailable();
				if (Online) {
					GetEventListFromServer();
					if (numEvents > 0) {
						menuEvents.Show();
						populateDropdown();
						btnLoadFromWeb.Show();
					} else {
						DisplayOfflineText();
					}
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
		public static void Log(String msg) {
			System.Diagnostics.Debug.WriteLine(msg);
		}
		public string FixNull(string s) {
			return (s != null) ? s : String.Empty;
		}

		// UI METHODS ============================================================================
		private void UpdateScanResult(string txt) {
			lblScanResult.Text = txt;
		}
		private void UpdateTotalScanCount() {
			lblScanSum.Text = "Scanned: " + Convert.ToString(numTotalScans);
		}
		private void ScanIncrement() {
			numTotalScans++;
			UpdateTotalScanCount();
		}
		private void UpdateIcon(string str) {
			iconBox.Invalidate();
			iconBox.Image = (Image)new System.ComponentModel.ComponentResourceManager(typeof(UI)).GetObject(str);
			iconBox.Refresh();
		}
		private void populateDropdown() {
			events.Insert(0, new Event() { id = 139, display_name = "TEST" }); // HACK
			events.Insert(0, new Event() { id = 0, display_name = "Select..." });
			menuEvents.DataSource = events;
			menuEvents.ValueMember = "id";
			menuEvents.DisplayMember = "display_name";
		}
		private void DisplayOfflineText() {
			labelLoadWeb.Text = "No Internet Connection";
		}

		// SCANNING RELATED METHODS ================================================================
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
			// TODO show override screen here


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

		// DATA FILE METHODS ============================================================================
		private int ReadXMLRegistrations(XDocument xdoc) {
			int count = (int)xdoc.Element("event").Element("registrations").Attribute("count");
			eventID = (String)xdoc.Element("event").Attribute("id");
			eventTitle = (String)xdoc.Element("event").Element("title");
			foreach (XElement el in xdoc.Descendants("registration")) {
				try {
					Log(String.Format("Added #{0}->{1}",Convert.ToInt32(el.Attribute("num").Value), Convert.ToInt32(el.Attribute("id").Value))); // DEBUG
					Registration r = new Registration() {
						id = Convert.ToInt32(el.Attribute("id").Value),
						first_name = FixNull(el.Element("first_name").Value),
						last_name = FixNull(el.Element("last_name").Value)
					};
					registrations.Add(r);
				} catch (Exception ex) {
					Log(ex.StackTrace);
					Log(el.ToString());
				}
			}
			Log("XML count=" + count + ", read=" + registrations.Count()); // DEBUG
			return registrations.Count();
		}
		private int ReadXMLEvents(XDocument xdoc) {
			foreach (XElement el in xdoc.Descendants("event")) {
				try {
					Event ev = new Event() {
						id = Convert.ToInt32(el.Attribute("id").Value),
						name = FixNull(el.Attribute("name").Value),
						city = FixNull(el.Attribute("city").Value),
						event_code = FixNull(el.Attribute("event_code").Value),
						display_name = FixNull(el.Attribute("name").Value) + " " + FixNull(el.Attribute("city").Value)
					};
					events.Add(ev);
				} catch (Exception ex) {
					Log(ex.StackTrace);
					Log(el.ToString());
				}
			}
			return events.Count();
		}
		private void SaveCsvFile() {
			string filePath = String.Format("{0}\\{1}.csv", C.INITIAL_DIR, eventID);
			File.Create(filePath).Close();
			using (TextWriter writer = File.CreateText(filePath)) {
				writer.WriteLine("File Saved: " + DateTime.Now.ToString());
				regScanned_OnList.ForEach(x => writer.WriteLine(Convert.ToString(x)));
			}
		}

		// NETWORK METHODS ===========================================================================
		private bool IsServerAvailable() {
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(C.CHECK_URL);
			request.Timeout = 10000;
			//request.Credentials = CredentialCache.DefaultNetworkCredentials;
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			if (response.StatusCode == HttpStatusCode.OK) {
				Log("IsServerAvailable: " + response.StatusCode);
				response.Close();
				return true;
			} else {
				response.Close();
				return false;
			}
		}
		private string GetDataFromServer(string url) {
			Log("URL: " + url);
			Cursor.Current = Cursors.WaitCursor;
			StringBuilder sb = new StringBuilder();
			HttpWebRequest request;
			HttpWebResponse response;
			Stream resStream;
			try {
				byte[] buf = new byte[8192];
				request = (HttpWebRequest)WebRequest.Create(url);
				request.Timeout = 30000;
				request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.01; Windows NT 5.0)";
				response = (HttpWebResponse)request.GetResponse();
				Log("Got " + response.ContentLength.ToString() + " bytes"); // DEBUG
				resStream = response.GetResponseStream();
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
				resStream.Close();
				response.Close();
				Cursor.Current = Cursors.Default;
			} catch (WebException ex) {
				Log(ex.Response.ToString());
				Log(ex.Status.ToString());
				Log(ex.StackTrace);
			} finally {
				Cursor.Current = Cursors.Default;
			}
			return (sb.ToString());
		}
		private void GetEventListFromServer() {
			try {
				string data = GetDataFromServer(C.WEBSVC_EVENTS);
				XDocument xdoc = XDocument.Parse(data.ToString());
				numEvents = ReadXMLEvents(xdoc);
			} catch (Exception ex) {
				Log(ex.StackTrace);
				numEvents = 0;
			}
		}

		// BUTTON CLICK HANDLERS ====================================================================
		private void btnLoadFile_Click(object sender, EventArgs e) {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "XML File|*.xml";
			ofd.InitialDirectory = C.INITIAL_DIR;
			if (DialogResult.OK == ofd.ShowDialog()) {
				// load xml file
				XDocument xdoc = XDocument.Load(ofd.FileName);
				int numReg = ReadXMLRegistrations(xdoc);
				MessageBox.Show(String.Format(C.DATA_LOADED_MSG, eventTitle.ToUpper(), numReg));
				this.loadPanel.Hide();
				this.scanPanel.Show();
			} else {
				MessageBox.Show(C.SELECT_FILE_MSG);
			}
		}
		private void btnLoadFromWeb_Click(object sender, EventArgs e) {
			registrations.Clear();
			if (Online) {
				try {
					int id = (int)menuEvents.SelectedValue;
					if (id > 0) {
						string url = C.WEBSVC_ENDPOINT + "?id=" + id;
						string data = GetDataFromServer(url);
						XDocument xdoc = XDocument.Parse(data.ToString());
						int numReg = ReadXMLRegistrations(xdoc);
						MessageBox.Show(String.Format(C.DATA_LOADED_MSG, eventTitle.ToUpper(), numReg));
						this.loadPanel.Hide();
						this.scanPanel.Show();
					} else {
						MessageBox.Show("No event selected!");
					}
				} catch (Exception ex) {
					Log(ex.StackTrace);
					MessageBox.Show(C.WEBSVC_FAIL_MSG);
				}
			} else {
				MessageBox.Show(C.NO_CONNECTION_MSG);
			}
		}
		private void btnScan_Click(object sender, EventArgs e) {
			string barCode = Scan();
			if (!string.IsNullOrEmpty(barCode)) {
				ScanIncrement();
				Log("Scanned: " + barCode);
				string evID = "";
				int regID = 0;
				try {
					String[] parts = barCode.Split(' ');
					Log("Event Code: "+parts[0]);
					Log("Reg ID: "+parts[1]);
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
					Log(ex.Message);
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


	}

	// registration class for each registered delegate
	public class Registration {
		public int id { get; set; }
		public string title { get; set; }
		public string first_name { get; set; }
		public string last_name { get; set; }
		public string suffix { get; set; }
	}

	// events class populated from Venture
	public class Event {
		public int id { get; set; }
		public string name { get; set; }
		public string city { get; set; }
		public string event_code { get; set; }
		public string display_name { get; set; }
	}



}