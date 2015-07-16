﻿using System;
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
		private List<SocialEventOption> se_options = new List<SocialEventOption>();
		private string eventID;
		private string eventTitle;
		private int numTotalScans;
		private int numValidScans;
		private int numFailedScans;
		private int numEvents = 0;
		private static List<int> regScanned_OnList = new List<int>();
		private static List<int> regScanned_NotOnList = new List<int>();
		public bool Online = false;
		public bool ScannerActive;
		private int SelectedSocialEventId;

		public UI() {
			InitializeComponent();
		}

		// UTILITY METHODS =====================================================================
		private void Ui_Load(object sender, EventArgs e) {
			//Log("PROGRAM LOADED");
			if (SystemInfo.alreadyRun(this.Text, this.Handle.ToInt32())) {
				MessageBox.Show("repeated start");
				this.Close();
			} else {
				// set up UI
				UpdateScanResult(String.Empty);
				numTotalScans = 0;
				numValidScans = 0;
				numFailedScans = 0;
				UpdateScanCounts();
				iconBox.Invalidate();
				SelectedSocialEventId = 0;
				ScannerActive = false;
				// check if web services available
				Online = IsServerAvailable();
				if (Online) {
					GetEventListFromServer();
					if (numEvents > 0) {
						menuEvents.Show();
						PopulateEventsDropdown();
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
			if (IsScannerActive() && e.KeyValue == (int)ConstantKeyValue.Scan) {
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
		public bool IsScannerActive() {
			return ScannerActive;
		}
		public int GetSelectedSocialEventId() {
			return SelectedSocialEventId;
		}

		// UI METHODS ============================================================================
		private void UpdateScanResult(string txt) {
			lblScanResult.Text = txt;
		}
		private void UpdateScanCounts() {
			lblScanSum.Text = "Scanned: " + Convert.ToString(numTotalScans);
			lblValid.Text = "Valid: " + Convert.ToString(numValidScans);
			lblScanFail.Text = "Failed: " + Convert.ToString(numFailedScans);
		}
		private void ScanIncrementValid() {
			numTotalScans++;
			numValidScans++;
			UpdateScanCounts();
		}
		private void ScanIncrementFail() {
			numTotalScans++;
			numFailedScans++;
			UpdateScanCounts();
		}
		private void UpdateIcon(string str) {
			iconBox.Invalidate();
			iconBox.Image = (Image)new System.ComponentModel.ComponentResourceManager(typeof(UI)).GetObject(str);
			iconBox.Refresh();
		}
		private void PopulateEventsDropdown() {
			events.Insert(0, new Event() { id = 139, display_name = "RE MEDIA TEST EVENT" }); // HACK
			events.Insert(0, new Event() { id = 0, display_name = "Choose Event..." });
			menuEvents.DataSource = events;
			menuEvents.ValueMember = "id";
			menuEvents.DisplayMember = "display_name";
		}
		private void PopulateSocialEventsOptionsDropdown() {
			se_options.Insert (0, new SocialEventOption() {id = 0, display_name = "Choose Social Event..."});
			menuSocialEvents.DataSource = se_options;
			menuSocialEvents.ValueMember = "id";
			menuSocialEvents.DisplayMember = "display_name";
		}
		private void DisplayOfflineText() {
			labelLoadWeb.Text = "No Internet Connection";
		}

		// SCANNING RELATED METHODS ================================================================
		public static string Scan() {
			int barLen = 0;
			byte[] bcData = new byte[2048];
			string barcode = string.Empty;
			try {
				barLen = Barcode1D_scan(bcData);
				if (barLen > 0) {
					barcode = Encoding.ASCII.GetString(bcData, 0, barLen).Trim();
				}
				return barcode;
			} catch (System.Exception ex) {
				Log(ex.Message);
				return String.Empty;
			}
		}
		public void CheckSEAccess(Registration reg) {
			int seoId = GetSelectedSocialEventId();
			Log("Selected SE: "+seoId); // DEBUG
			if (reg.social_events_booked.Contains(seoId)) {
				SE_RegOk(reg);
			} else {
				SE_RegNotOk(reg.id);
			}
		}
		public void SE_RegOk(Registration reg) {
			regScanned_OnList.Add(reg.id);
			C.PlaySound(@"\windows\beep.wav");
			UpdateIcon("ok");
			UpdateScanResult(reg.first_name + " " + reg.last_name + "\n" + C.VALID_SE_REG_MSG);
			ScanIncrementValid();
		}
		public void RegOk(Registration reg) {
			regScanned_OnList.Add(reg.id);
			C.PlaySound(@"\windows\beep.wav");
			UpdateIcon("ok");
			UpdateScanResult(reg.first_name + " " + reg.last_name + "\n" + C.VALID_REG_MSG);
			ScanIncrementValid();
		}
		public void RegNotOk(int r) {
			regScanned_NotOnList.Add(r);
			C.PlaySound(@"\windows\critical.wav");
			UpdateIcon("no");
			UpdateScanResult(C.INVALID_REG_MSG);
			ScanIncrementFail();
			// TODO show override screen here
		}
		public void SE_RegNotOk(int r) {
			regScanned_NotOnList.Add(r);
			C.PlaySound(@"\windows\critical.wav");
			UpdateIcon("no");
			UpdateScanResult(C.INVALID_SE_REG_MSG);
			ScanIncrementFail();
			// TODO show Social Events override screen here
		}
		public void RegAlreadyScanned() {
			C.PlaySound(@"\windows\critical.wav");
			UpdateIcon("fail");
			UpdateScanResult(C.DUPLICATE_SCAN_MSG);
			ScanIncrementFail();
		}
		public void BadEventCode() {
			C.PlaySound(@"\windows\critical.wav");
			UpdateIcon("fail");
			UpdateScanResult(C.BAD_EVENT_MSG);
			ScanIncrementFail();
		}
		public void BadFormat() {
			C.PlaySound(@"\windows\critical.wav");
			UpdateIcon("fail");
			UpdateScanResult(C.BAD_FORMAT_MSG);
			ScanIncrementFail();
		}
		public void ScanFail() {
			C.PlaySound(@"\windows\critical.wav");
			UpdateIcon("fail");
			UpdateScanResult(C.SCAN_FAIL_MSG);
			ScanIncrementFail();
		}

		// DATA FILE METHODS ============================================================================
		private int ReadXMLRegistrations(XDocument xdoc) {
			int count = (int)xdoc.Element("event").Element("registrations").Attribute("count");
			eventID = (String)xdoc.Element("event").Attribute("id");
			eventTitle = (String)xdoc.Element("event").Element("title");
			foreach (XElement el in xdoc.Descendants("registration")) {
				try {
					Log(String.Format("Added Registration #{0}->{1}", el.Attribute("num").Value, el.Attribute("id").Value)); // DEBUG
					Registration r = new Registration() {
						id = Convert.ToInt32(el.Attribute("id").Value),
						first_name = FixNull(el.Element("first_name").Value),
						last_name = FixNull(el.Element("last_name").Value),
						social_events_booked = new List<int>()
					};
					registrations.Add(r);
				} catch (Exception ex) {
					Log(ex.StackTrace);
					Log(el.ToString());
				}
			}
			Log("XML count=" + count + ", read=" + registrations.Count()); // DEBUG
			
			// read in social events
			foreach (XElement el_se in xdoc.Descendants("socialevent")) {
				try {
					Log("SE: " + el_se.Attribute("id").Value + el_se.Attribute("name").Value); // DEBUG
					foreach (XElement el_seo in el_se.Descendants("option")) {
						try {
							Log("SEO: " + el_seo.Attribute("id").Value + el_seo.Attribute("name").Value); // DEBUG
							SocialEventOption seo = new SocialEventOption() {
								id = Convert.ToInt32(el_seo.Attribute("id").Value),
								name = FixNull(el_seo.Attribute("name").Value),
								social_event_id = Convert.ToInt32(el_se.Attribute("id").Value),
								social_event_name = FixNull(el_se.Attribute("name").Value),
								display_name = FixNull(el_se.Attribute("name").Value) + ": " + FixNull(el_seo.Attribute("name").Value)
							};
							se_options.Add(seo);
							foreach (XElement el_seb in el_seo.Descendants("reg")) {
								try {
									int booked_reg = Convert.ToInt32(el_seb.Attribute("id").Value);
									Log("Booked: " + booked_reg); // DEBUG
									Registration regBooked = registrations.FirstOrDefault(r => r.id == booked_reg);
									if (regBooked != null) {
										regBooked.social_events_booked.Add(Convert.ToInt32(el_seo.Attribute("id").Value) );
									}
								} catch (Exception ex) {
									Log(ex.StackTrace);
									Log(el_seb.ToString());
								}
							}
						} catch (Exception ex) {
							Log(ex.StackTrace);
							Log(el_seo.ToString());
						}
					}
				} catch (Exception ex) {
					Log(ex.StackTrace);
					Log(el_se.ToString());
				}
			}
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
				string data = GetDataFromServer(C.WEBSVC_EVENT_ENDPOINT);
				XDocument xdoc = XDocument.Parse(data.ToString());
				numEvents = ReadXMLEvents(xdoc);
			} catch (Exception ex) {
				Log(ex.StackTrace);
				numEvents = 0;
			}
		}

		// NAVIGATION ==================================================================================
		private void LoadComplete() {
			if (se_options.Count > 0) {
				PopulateSocialEventsOptionsDropdown();
				GotoOptionsScreen();
			} else {
				GotoScanScreen();
			}
		}
		private void GotoOptionsScreen() {
			ScannerActive = false;
			this.loadPanel.Hide();
			this.scanPanel.Hide();
			this.optionsPanel.Show();
		}
		private void GotoScanScreen() {
			ScannerActive = true;
			this.loadPanel.Hide();
			this.optionsPanel.Hide();
			this.scanPanel.Show();
		}
		private void GotoSaveScreen() {
			// TODO show data file export options here
			ScannerActive = false;
			this.loadPanel.Hide();
			this.optionsPanel.Hide();
			this.scanPanel.Hide();
			MessageBox.Show(String.Format(C.REG_SAVED_MSG, regScanned_OnList.Count));
			SaveCsvFile();
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
				LoadComplete();
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
						string url = C.WEBSVC_EVENTS_ENDPOINT + "?id=" + id;
						string data = GetDataFromServer(url);
						XDocument xdoc = XDocument.Parse(data.ToString());
						int numReg = ReadXMLRegistrations(xdoc);
						MessageBox.Show(String.Format(C.DATA_LOADED_MSG, eventTitle.ToUpper(), numReg));
						LoadComplete();
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
				Log("Scanned: " + barCode);
				string evID = "";
				int regID = 0;
				try {
					String[] parts = barCode.Split(' ');
					Log("Event Code: " + parts[0]);
					Log("Reg ID: " + parts[1]);
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
								if (GetSelectedSocialEventId() != 0) {
									CheckSEAccess(reg);
								} else {
									RegOk(reg);
								}
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
				GotoSaveScreen();
			} else {
				MessageBox.Show(C.NO_REG_SAVED_MSG);
			}
			this.Close();
		}
		private void btnSelect_Click(object sender, EventArgs e) {
			// TODO show choose option screen here
		}
		private void btnScanRegOnly_Click(object sender, EventArgs e) {
			GotoScanScreen();
		}
		private void btnScanSocialEvents_Click(object sender, EventArgs e) {
			int id = (int)menuSocialEvents.SelectedValue;
			if (id > 0) {
				SelectedSocialEventId = id;
				GotoScanScreen();
			} else {
				MessageBox.Show("No event selected!");
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
		public List<int> social_events_booked { get; set; }
	}

	// events class populated from Venture
	public class Event {
		public int id { get; set; }
		public string name { get; set; }
		public string city { get; set; }
		public string event_code { get; set; }
		public string display_name { get; set; }
	}

	public class SocialEventOption {
		public int id { get; set; }
		public string name { get; set; }
		public int social_event_id { get; set; }
		public string social_event_name { get; set; }
		public string display_name { get; set; }
	}

}