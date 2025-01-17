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

	// main UI form class =======================================================================
	public partial class UI : Form {

		// import barcode functionality from device library
		[DllImport("DeviceAPI.dll", EntryPoint = "Barcode1D_init")]
		private static extern void Barcode1D_init();
		[DllImport("DeviceAPI.dll", EntryPoint = "Barcode1D_scan")]
		private static extern int Barcode1D_scan(byte[] pszData);
		[DllImport("DeviceAPI.dll", EntryPoint = "Barcode1D_free")]
		private static extern void Barcode1D_free();

		// properties
		private List<Registration> RegistrationsLoaded = new List<Registration>();
		private List<Event> EventsLoaded = new List<Event>();
		private List<SocialEventOption> SocialEventOptionsList = new List<SocialEventOption>();
		private string EventID;
		private string EventTitle;
		private int NumTotalScans;
		private int NumValidScans;
		private int NumFailedScans;
		private int NumEvents = 0;
		private List<string> RegScannedTally = new List<string>();

		private List<Registration> RegScanned_OK = new List<Registration>();
		private List<Registration> RegScanned_Overrides = new List<Registration>();
		private List<Registration> RegScanned_Rejected = new List<Registration>();
		private List<Registration> RegScanned_Temp = new List<Registration>();
		private List<string> idRegScanned_Quick = new List<string>();
		private List<string> idRegScanned_NotOnList = new List<string>();

		public bool Online = false;
		public bool ScannerActive;
		private int SelectedSocialEventId;
		public string LastScannedId;
		public bool DataSaved = false;
		private int ResultsScreenDuration = 2;
		private int SocketTimeout = 15000;

		public UI() {
			System.IO.Directory.CreateDirectory(C.LOG_DIR);
			InitializeComponent(); // set up ui layout from UI.Designer.cs
		}

		// UTILITY METHODS =======================================================================
		private void Ui_Load(object sender, EventArgs e) {
			Log("PROGRAM LOADED");
			if (SystemInfo.alreadyRun(this.Text, this.Handle.ToInt32())) {
				MessageBox.Show("FATAL ERROR\nProgram already running", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
				this.Close();
			} else {
				// set up UI
				this.Menu = null;
				this.ControlBox = false;
				this.FormBorderStyle = FormBorderStyle.None;
				this.WindowState = FormWindowState.Maximized;
				this.Text = string.Empty;
				// initialise
				this.ClearData();
				this.ScannerActive = false;
				// check if web services available
				Online = this.IsServerAvailable();
				if (Online) {
					this.GetEventListFromServer();
					if (NumEvents > 0) {
						this.PopulateEventsDropdown();
						this.menuEvents.Show();
						this.btnLoadFromVenture.Show();
					} else {
						this.lblLoadFromVenture.Text = C.NO_EVENTS_MSG;
					}
				} else {
					this.DisplayOfflineText();
				}
				Barcode1D_init();
			}
		}
		private void ClearData() {
			this.UpdateScanResultMsg(String.Empty);
			this.NumTotalScans = 0;
			this.NumValidScans = 0;
			this.NumFailedScans = 0;
			this.UpdateScanCounts();
			this.SelectedSocialEventId = 0;
			this.LastScannedId = String.Empty;
			this.RegScanned_OK.Clear();
			this.idRegScanned_NotOnList.Clear();
			this.RegScanned_Overrides.Clear();
			this.RegScanned_Rejected.Clear();
			this.RegScanned_Temp.Clear();
			this.RegScannedTally.Clear();
			this.DataSaved = false;
			this.lblSaveToVenture.Text = "";
		}
		private void Ui_Closed(object sender, EventArgs e) {
			Log("PROGRAM CLOSED");
			Barcode1D_free();
			GC.Collect();
		}
		private void Ui_KeyDown(object sender, KeyEventArgs e) {
			//Log("KEY DOWN: " + e.KeyValue);
			if (GetScannerActive() && e.KeyValue == (int)SystemHelper.ConstantKeyValue.Scan) {
				this.btnScan_Click(null, null);
			}
			if (this.lblOverride.Visible && e.KeyValue == (int)SystemHelper.ConstantKeyValue.RED) {
				this.btnOverrideYes_Click(null, null);
			}
			if (this.lblOverride.Visible && e.KeyValue == (int)SystemHelper.ConstantKeyValue.BLUE) {
				this.btnOverrideNo_Click(null, null);
			}
			if (e.KeyValue == (int)SystemHelper.ConstantKeyValue.ESC) {
				//this.Close();
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
			//Console.WriteLine(msg);
		}
		public string FixNullString(string s) {
			return (s != null) ? s : String.Empty;
		}
		// getters
		public bool GetScannerActive() {
			return this.ScannerActive;
		}
		public int GetSelectedSocialEventId() {
			return this.SelectedSocialEventId;
		}
		public string GetLastScannedId() {
			return this.LastScannedId;
		}
		public bool GetDataSaved() {
			return this.DataSaved;
		}


		// UI METHODS ============================================================================
		private void UpdateScanResultMsg(string txt) {
			this.lblScanResult.Text = txt;
		}
		private void UpdateScanCounts() {
			this.lblTotalCount.Text = "Scanned: " + Convert.ToString(NumTotalScans);
			this.lblValidCount.Text = "Valid: " + Convert.ToString(NumValidScans);
			this.lblFailCount.Text = "Failed: " + Convert.ToString(NumFailedScans);
		}
		private void IncrementScanValid() {
			this.NumTotalScans++;
			this.NumValidScans++;
			this.UpdateScanCounts();
		}
		private void IncrementScanFail() {
			this.NumTotalScans++;
			this.NumFailedScans++;
			this.UpdateScanCounts();
		}
		private void ShowScanResult(string str) {
			this.iconBoxFail.Hide();
			this.iconBoxNo.Hide();
			this.iconBoxOK.Hide();
			this.lblOverride.Hide();
			this.btnOverrideYes.Hide();
			this.btnOverrideNo.Hide();
			bool IsOverride = false;
			switch (str) {
				case "ok":
					this.iconBoxOK.Show();
					break;
				case "no":
					this.iconBoxNo.Show();
					IsOverride = true;
					this.lblOverride.Show();
					this.btnOverrideYes.Show();
					this.btnOverrideNo.Show();
					break;
				case "fail":
					this.iconBoxFail.Show();
					break;
			}
			// show result panel for specified time
			this.ScannerActive = false;
			this.btnScan.Enabled = false;
			this.resultPanel.Show();
			if (!IsOverride) {
				int secs = 0;
				Timer timer = new Timer { Interval = 1000, Enabled = true };
				timer.Tick += delegate {
					secs++;
					if (secs < this.ResultsScreenDuration) { return; }
					timer.Enabled = false;
					this.resultPanel.Hide();
					this.btnScan.Enabled = true;
					this.ScannerActive = true;
				};
			}
		}
		private void PopulateEventsDropdown() {
			this.EventsLoaded.Insert(0, new Event() { id = 0, display_name = "Choose Event..." });
			this.menuEvents.DataSource = EventsLoaded;
			this.menuEvents.ValueMember = "id";
			this.menuEvents.DisplayMember = "display_name";
			this.btnLoadFromVenture.Focus();
		}
		private void PopulateSocialEventsOptionsDropdown() {
			this.SocialEventOptionsList.Insert(0, new SocialEventOption() { id = 0, display_name = "Choose Social Event..." });
			this.menuSocialEvents.DataSource = SocialEventOptionsList;
			this.menuSocialEvents.ValueMember = "id";
			this.menuSocialEvents.DisplayMember = "display_name";
		}
		private void DisplayOfflineText() {
			this.lblLoadFromVenture.Text = C.OFFLINE_MSG;
		}
		private void DrawBorder(object sender, PaintEventArgs e) {
			e.Graphics.DrawRectangle(
				new Pen(Color.Black), 0, 0,
				e.ClipRectangle.Width - 1,
				e.ClipRectangle.Height - 1
			);
		}
		private void UpdateSaveToVentureMsg(string msg) {
			this.lblSaveToVenture.Text = msg;
		}


		// SCANNING RELATED METHODS ===============================================================
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
			Log("Selected SE: " + seoId); // DEBUG
			if (reg.social_events_booked.Contains(seoId)) {
				this.SE_RegOk(reg);
			} else {
				this.SE_RegNotOk(reg.id);
			}
		}
		public void SE_RegOk(Registration reg) {
			reg.timestamp = "" + DateTime.Now.ToString("u");
			this.RegScanned_OK.Add(reg);
			this.RegScannedTally.Add(reg.id);
			C.PlaySound(@"\windows\beep.wav");
			this.ShowScanResult("ok");
			this.UpdateScanResultMsg(reg.first_name + " " + reg.last_name + "\n" + C.VALID_SE_REG_MSG);
			this.IncrementScanValid();
		}
		public void RegOk(Registration reg) {
			reg.timestamp = DateTime.Now.ToString("u");
			this.RegScanned_OK.Add(reg);
			this.RegScannedTally.Add(reg.id);
			C.PlaySound(@"\windows\beep.wav");
			this.ShowScanResult("ok");
			this.UpdateScanResultMsg(reg.first_name + " " + reg.last_name + "\n" + C.VALID_REG_MSG);
			this.IncrementScanValid();
		}
		public void RegNotOk(string rid) {
			this.idRegScanned_NotOnList.Add(rid);
			this.RegScannedTally.Add(rid);
			C.PlaySound(@"\windows\exclam.wav");
			this.ShowScanResult("no");
			this.UpdateScanResultMsg(C.INVALID_REG_MSG);
			this.IncrementScanFail();
		}
		public void SE_RegNotOk(string rid) {
			this.idRegScanned_NotOnList.Add(rid);
			this.RegScannedTally.Add(rid);
			C.PlaySound(@"\windows\exclam.wav");
			this.ShowScanResult("no");
			this.UpdateScanResultMsg(C.INVALID_SE_REG_MSG);
			this.IncrementScanFail();
		}
		public void ProcessTempReg(string rid) {
			// check if already scanned
			if (this.RegScannedTally.Contains(rid)) {
				this.RegAlreadyScanned();
			} else {
				Registration r = new Registration() { id = rid, timestamp = DateTime.Now.ToString("u") };
				this.RegScanned_OK.Add(r);
				this.RegScanned_Temp.Add(r);
				this.RegScannedTally.Add(rid);
				C.PlaySound(@"\windows\beep.wav");
				this.ShowScanResult("ok");
				this.UpdateScanResultMsg(C.VALID_TEMP_REG_MSG);
				this.IncrementScanValid();
			}
		}
		public void RegAlreadyScanned() {
			C.PlaySound(@"\windows\critical.wav");
			this.ShowScanResult("fail");
			this.UpdateScanResultMsg(C.DUPLICATE_SCAN_MSG);
			this.IncrementScanFail();
		}
		public void BadEventCode() {
			C.PlaySound(@"\windows\critical.wav");
			this.ShowScanResult("fail");
			this.UpdateScanResultMsg(C.BAD_EVENT_MSG);
			this.IncrementScanFail();
		}
		public void BadFormat() {
			C.PlaySound(@"\windows\critical.wav");
			this.ShowScanResult("fail");
			this.UpdateScanResultMsg(C.BAD_FORMAT_MSG);
			this.IncrementScanFail();
		}
		public void ScanFail() {
			C.PlaySound(@"\windows\critical.wav");
			this.ShowScanResult("fail");
			this.UpdateScanResultMsg(C.SCAN_FAIL_MSG);
			this.IncrementScanFail();
		}


		// DATA FILE METHODS ======================================================================
		private int ReadXMLRegistrations(XDocument xdoc) {
			int count = (int)xdoc.Element("event").Element("registrations").Attribute("count");
			this.EventID = (String)xdoc.Element("event").Attribute("id");
			this.EventTitle = (String)xdoc.Element("event").Element("title");
			foreach (XElement el in xdoc.Descendants("registration")) {
				try {
					Log(String.Format("Added registration #{0}->{1}", el.Attribute("num").Value, el.Attribute("id").Value)); // DEBUG
					Registration r = new Registration() {
						id = FixNullString(el.Attribute("id").Value),
						first_name = FixNullString(el.Element("first_name").Value),
						last_name = FixNullString(el.Element("last_name").Value),
						social_events_booked = new List<int>()
					};
					this.RegistrationsLoaded.Add(r);
				} catch (Exception ex) {
					Log(ex.StackTrace);
					Log(el.ToString());
				}
			}
			Log("XML count=" + count + ", read=" + RegistrationsLoaded.Count()); // DEBUG

			// read in social EventsLoaded
			foreach (XElement el_se in xdoc.Descendants("socialevent")) {
				try {
					Log("SE: #" + el_se.Attribute("id").Value + " " + el_se.Attribute("name").Value); // DEBUG
					foreach (XElement el_seo in el_se.Descendants("option")) {
						try {
							Log("SEO: #" + el_seo.Attribute("id").Value + " " + el_seo.Attribute("name").Value); // DEBUG
							SocialEventOption seo = new SocialEventOption() {
								id = Convert.ToInt32(el_seo.Attribute("id").Value),
								name = FixNullString(el_seo.Attribute("name").Value),
								social_event_id = Convert.ToInt32(el_se.Attribute("id").Value),
								social_event_name = FixNullString(el_se.Attribute("name").Value),
								display_name = FixNullString(el_se.Attribute("name").Value) + ": " + FixNullString(el_seo.Attribute("name").Value)
							};
							this.SocialEventOptionsList.Add(seo);
							foreach (XElement el_seb in el_seo.Descendants("booking")) {
								try {
									string booked_reg = el_seb.Value;
									Log("Booked: " + booked_reg); // DEBUG
									Registration regBooked = RegistrationsLoaded.FirstOrDefault(r => r.id == booked_reg);
									if (regBooked != null) {
										regBooked.social_events_booked.Add(Convert.ToInt32(el_seo.Attribute("id").Value));
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
			return this.RegistrationsLoaded.Count();
		}
		private int ReadXMLEvents(XDocument xdoc) {
			foreach (XElement el in xdoc.Descendants("event")) {
				try {
					Event ev = new Event() {
						id = Convert.ToInt32(el.Attribute("id").Value),
						name = FixNullString(el.Attribute("name").Value),
						city = FixNullString(el.Attribute("city").Value),
						event_code = FixNullString(el.Attribute("event_code").Value),
						display_name = (FixNullString(el.Attribute("event_code").Value) + " " +
							FixNullString(el.Attribute("name").Value) + " " +
							FixNullString(el.Attribute("city").Value)).Trim()
					};
					this.EventsLoaded.Add(ev);
				} catch (Exception ex) {
					Log(ex.StackTrace);
					Log(el.ToString());
				}
			}
			return this.EventsLoaded.Count();
		}
		private void SaveCsvFile() {
			this.LogResults();
			string filePath = "";
			if (this.GetSelectedSocialEventId() > 0) {
				filePath = String.Format("{0}\\SocialEvent_{1}.csv", C.INITIAL_DIR, this.GetSelectedSocialEventId());
			} else {
				filePath = String.Format("{0}\\Event_{1}.csv", C.INITIAL_DIR, EventID);
			}
			File.Create(filePath).Close();
			using (TextWriter writer = File.CreateText(filePath)) {
				writer.WriteLine("#File Saved At: " + DateTime.Now.ToString());
				this.RegScanned_OK.ForEach(x => writer.WriteLine("\"" + x.id + "\",\"" + x.timestamp + "\",\"" + ((x.id.StartsWith("X")) ? "TEMP" : "OK") + "\""));
				this.RegScanned_Overrides.ForEach(x => writer.WriteLine("\"" + x.id + "\",\"" + x.timestamp + "\",\"OVERRIDE\""));
				this.RegScanned_Rejected.ForEach(x => writer.WriteLine("\"" + x.id + "\",\"" + x.timestamp + "\",\"REJECTED\""));
				this.DataSaved = true;
				C.PlaySound(@"\windows\beep.wav");
				MessageBox.Show(String.Format(C.REG_SAVED_MSG, NumValidScans));
				this.btnSaveToFile.Enabled = false;
			}
		}
		private void SaveToVenture() {
			this.LogResults();
			XDocument xdoc;
			if (this.GetSelectedSocialEventId() > 0) {
				xdoc = BuildXmlDataFile_SocialEvents();
			} else {
				xdoc = BuildXmlDataFile_Registrations();
			}
			string response = "";
			try {
				response = SendDataToServer(xdoc.ToString(), C.WEBSVC_SAVE_ENDPOINT);
				Log("Server Response:\n" + response);
				if (response == "OK") {
					C.PlaySound(@"\windows\beep.wav");
					this.UpdateSaveToVentureMsg(C.VENTURE_UPLOAD_OK_MSG);
					this.DataSaved = true;
					this.btnSaveToVenture.Enabled = false;
				} else {
					C.PlaySound(@"\windows\critical.wav");
					this.UpdateSaveToVentureMsg(C.VENTURE_UPLOAD_FAIL_MSG);
				}

			} catch (Exception ex) {
				Log(ex.Message);
			}
		}
		private XDocument BuildXmlDataFile_Registrations() {
			XDocument xdoc = new XDocument();
			try {
				xdoc = new XDocument(
					new XElement("event", new XAttribute("id", EventID), new XAttribute("type", "registration"), new XAttribute("created", DateTime.Now.ToString("u")),
						new XElement("valid", new XAttribute("count", NumValidScans), RegScanned_OK.Select(x => new XElement("registration", new XAttribute("id", x.id), new XAttribute("timestamp", x.timestamp)))
						),
						new XElement("overrides", new XAttribute("count", RegScanned_Overrides.Count), RegScanned_Overrides.Select(x => new XElement("registration", new XAttribute("id", x.id), new XAttribute("timestamp", x.timestamp)))
							),
						new XElement("rejected", new XAttribute("count", RegScanned_Rejected.Count), RegScanned_Rejected.Select(x => new XElement("registration", new XAttribute("id", x.id), new XAttribute("timestamp", x.timestamp)))
						)
					)
				);
			} catch (Exception ex) {
				Log(ex.Message);
			}
			Log("Built Saved Registration XML:\n" + xdoc.ToString()); // DEBUG
			return xdoc;
		}
		private XDocument BuildXmlDataFile_SocialEvents() {
			XDocument xdoc = new XDocument();
			try {
				xdoc = new XDocument(
					new XElement("socialevent", new XAttribute("id", this.EventID), new XAttribute("type", "socialevent"), new XAttribute("social_event_option_id", this.GetSelectedSocialEventId()), new XAttribute("created", DateTime.Now.ToString("u")),
						new XElement("valid", new XAttribute("count", NumValidScans), RegScanned_OK.Select(x => new XElement("registration", new XAttribute("id", x.id), new XAttribute("timestamp", x.timestamp)))
						),
						new XElement("overrides", new XAttribute("count", RegScanned_Overrides.Count), RegScanned_Overrides.Select(x => new XElement("registration", new XAttribute("id", x.id), new XAttribute("timestamp", x.timestamp)))
						),
						new XElement("rejected", new XAttribute("count", RegScanned_Rejected.Count), RegScanned_Rejected.Select(x => new XElement("registration", new XAttribute("id", x.id), new XAttribute("timestamp", x.timestamp)))
						)
					)
				);
			} catch (Exception ex) {
				Log(ex.Message);
			}
			Log("Built Saved Social Event XML:\n" + xdoc.ToString()); // DEBUG
			return xdoc;
		}
		private void LogResults() { // DEBUG
			Log("OK:");
			this.RegScanned_OK.ForEach(x => Log(Convert.ToString(x.id) + "," + x.timestamp));
			Log("Temp:");
			this.RegScanned_Temp.ForEach(x => Log(Convert.ToString(x.id) + "," + x.timestamp));
			Log("Overrides:");
			this.RegScanned_Overrides.ForEach(x => Log(Convert.ToString(x.id) + "," + x.timestamp));
			Log("Rejected:");
			this.RegScanned_Rejected.ForEach(x => Log(Convert.ToString(x.id) + "," + x.timestamp));
			Log("Quick Registrations:");
			this.idRegScanned_Quick.Distinct().ToList().ForEach(x => Log(x));
			Log("Not on list:");
			this.idRegScanned_NotOnList.Distinct().ToList().ForEach(x => Log(x));
		}
		private void LogResultsToFile() {
			long ts = (DateTime.UtcNow.Ticks/10000000);
			string filePath = String.Format("{0}\\Event_{1}_{2}.log", C.LOG_DIR, EventID, ts);
			File.Create(filePath).Close();
			using (TextWriter writer = File.CreateText(filePath)) {
				writer.WriteLine("#File Saved At: " + DateTime.Now.ToString());
				writer.WriteLine("OK:");
				this.RegScanned_OK.ForEach(x => writer.WriteLine(x.id + "," + x.timestamp));
				writer.WriteLine("TEMP:");
				this.RegScanned_Temp.ForEach(x => writer.WriteLine(x.id + "," + x.timestamp));
				writer.WriteLine("OVERRIDE:");
				this.RegScanned_Overrides.ForEach(x => writer.WriteLine(x.id + "," + x.timestamp));
				writer.WriteLine("REJECTED:");
				this.RegScanned_Rejected.ForEach(x => writer.WriteLine(x.id + "," + x.timestamp));
				writer.WriteLine("QUICK REG:");
				this.idRegScanned_Quick.Distinct().ToList().ForEach(x => writer.WriteLine(x));
				writer.WriteLine("NOT ON LIST:");
				this.idRegScanned_NotOnList.Distinct().ToList().ForEach(x => writer.WriteLine(x));
			}
		}

		// NETWORK METHODS ========================================================================
		private bool IsServerAvailable() {
			bool ok = false;
			try {
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(C.CHECK_URL);
				request.Timeout = this.SocketTimeout;
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				if (response.StatusCode == HttpStatusCode.OK) {
					ok = true;
					Log("IsServerAvailable: " + response.StatusCode);
				}
				response.Close();
			} catch (Exception ex) {
				Log("Network error: " + ex.Message);
			}
			return ok;
		}
		private string GetDataFromServer(string url) {
			Log("Getting data from: " + url);
			Cursor.Current = Cursors.WaitCursor;
			StringBuilder sb = new StringBuilder();
			HttpWebRequest request;
			HttpWebResponse response;
			Stream resStream;
			try {
				byte[] buf = new byte[8192];
				request = (HttpWebRequest)WebRequest.Create(url);
				request.Timeout = this.SocketTimeout;
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
				this.NumEvents = ReadXMLEvents(xdoc);
			} catch (Exception ex) {
				Log(ex.StackTrace);
				this.NumEvents = 0;
			}
		}
		private string SendDataToServer(string data, string url) {
			Log("Sending data to: " + url); // DEBUG
			//Log("Data:\n" + data); // DEBUG
			Cursor.Current = Cursors.WaitCursor;
			HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
			req.KeepAlive = false;
			req.ProtocolVersion = HttpVersion.Version10;
			req.ContentType = "text/xml;charset=utf-8";
			req.Method = "POST";
			req.ReadWriteTimeout = this.SocketTimeout;
			req.Timeout = this.SocketTimeout;
			byte[] postBytes = Encoding.UTF8.GetBytes(data);
			req.ContentLength = postBytes.Length;
			try {
				Stream reqStream = req.GetRequestStream();
				reqStream.Write(postBytes, 0, postBytes.Length);
				reqStream.Close();
				using (var res = (HttpWebResponse)req.GetResponse()) {
					StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.Default);
					Cursor.Current = Cursors.Default;
					return sr.ReadToEnd();
				}
			} catch (Exception ex) {
				Log(ex.Message);
				req.Abort();
				return string.Empty;
			} finally {
				Cursor.Current = Cursors.Default;
			}

		}


		// NAVIGATION =============================================================================
		private void LoadComplete() {
			if (this.SocialEventOptionsList.Count > 0) {
				this.PopulateSocialEventsOptionsDropdown();
				this.GotoOptionsScreen();
			} else {
				this.GotoScanScreen();
			}
		}
		private void GotoLoadScreen() {
			this.ScannerActive = false;
			this.ClearData();
			this.optionsPanel.Hide();
			this.scanPanel.Hide();
			this.savePanel.Hide();
			this.loadPanel.Show();
		}
		private void GotoOptionsScreen() {
			this.ScannerActive = false;
			this.ClearData();
			this.loadPanel.Hide();
			this.scanPanel.Hide();
			this.savePanel.Hide();
			if (this.SocialEventOptionsList.Count > 0) {
				try {
					this.menuSocialEvents.Show();
					this.lblScanSocialEvent.Show();
					this.btnScanSocialEvent.Show();
				} catch (Exception ex) { }
			} else {
				try {
					this.menuSocialEvents.Hide();
					this.lblScanSocialEvent.Hide();
					this.btnScanSocialEvent.Hide();
				} catch (Exception ex) { }
			}
			try {
				this.menuSocialEvents.SelectedIndex = 0;
			} catch (Exception ex) { }
			this.optionsPanel.Show();
		}
		private void GotoScanScreen() {
			this.ScannerActive = true;
			this.loadPanel.Hide();
			this.optionsPanel.Hide();
			this.savePanel.Hide();
			this.resultPanel.Hide();
			if (GetSelectedSocialEventId() == 0) {
				this.lblScanMode.Text = "Scan Mode: Registration";
			} else {
				this.lblScanMode.Text = "Scan Mode: Social Event";
			}
			this.btnOptions.Enabled = (this.SocialEventOptionsList.Count > 0);
			this.scanPanel.Show();
		}
		private void GotoSaveScreen() {
			this.ScannerActive = false;
			this.loadPanel.Hide();
			this.optionsPanel.Hide();
			this.scanPanel.Hide();
			this.resultPanel.Hide();
			this.btnSaveToFile.Enabled = true;
			this.btnSaveToVenture.Enabled = (IsServerAvailable());
			this.lblNumScannedInfo.Text = String.Format(C.REG_SCANNED_MSG, RegScanned_OK.Count);
			this.btnStartOver.Enabled = (this.SocialEventOptionsList.Count > 0);
			this.savePanel.Show();
		}


		// BUTTON CLICK HANDLERS ==================================================================
		private void btnLoadFile_Click(object sender, EventArgs e) {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "XML File|*.xml";
			ofd.InitialDirectory = C.INITIAL_DIR;
			if (DialogResult.OK == ofd.ShowDialog()) {
				// load xml file
				XDocument xdoc = XDocument.Load(ofd.FileName);
				int numReg = ReadXMLRegistrations(xdoc);
				MessageBox.Show(String.Format(C.DATA_LOADED_MSG, EventTitle.ToUpper(), numReg), "INFO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
				this.LoadComplete();
			} else {
				MessageBox.Show(C.SELECT_FILE_MSG, "ALERT");
			}
		}
		private void btnLoadFromVenture_Click(object sender, EventArgs e) {
			this.RegistrationsLoaded.Clear();
			if (this.Online) {
				try {
					int id = (int)menuEvents.SelectedValue;
					if (id > 0) {
						string url = C.WEBSVC_EVENTS_ENDPOINT + "?id=" + id;
						string data = GetDataFromServer(url);
						//Log(data); // DEBUG
						XDocument xdoc = XDocument.Parse(data.ToString());
						int numReg = ReadXMLRegistrations(xdoc);
						MessageBox.Show(String.Format(C.DATA_LOADED_MSG, EventTitle.ToUpper(), numReg), "INFO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
						this.LoadComplete();
					} else {
						MessageBox.Show(C.NO_EVENT_SELECTED, "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
					}
				} catch (Exception ex) {
					Log(ex.StackTrace);
					MessageBox.Show(C.WEBSVC_FAIL_MSG, "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
				}
			} else {
				MessageBox.Show(C.NO_CONNECTION_MSG, "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			}
		}
		private void btnScan_Click(object sender, EventArgs e) {
			string barCode = Scan();
			if (!string.IsNullOrEmpty(barCode)) {
				Log("Scanned: " + barCode); // DEBUG
				string evID = String.Empty;
				string regID = String.Empty;
				try {
					String[] parts = barCode.Split(' ');
					evID = parts[0].Trim();
					regID = parts[1].Trim();
					Log("Event Code: " + evID + "."); // DEBUG
					Log("Reg ID: " + regID + "."); // DEBUG
					// check event code matches
					if (evID != EventID) {
						BadEventCode();
						return;
					}
					// check for temp badges
					if(regID.StartsWith("X")) {
						ProcessTempReg(regID);
						return;
					}
					// check for quick reg badges
					if (regID.StartsWith("Q")) {
						regID = regID.Remove(0, 1);
						this.idRegScanned_Quick.Add(regID);
						// quick reg will be in venture, so add to list and proceed
						Registration qreg = this.RegistrationsLoaded.FirstOrDefault(r => r.id == regID);
						if (qreg == null) {
							Registration r = new Registration() {
								id = regID,
								first_name = "Quick",
								last_name = "Registration",
								social_events_booked = new List<int>()
							};
							this.RegistrationsLoaded.Add(r);
						}
					}
					// check already scanned
					if(this.RegScannedTally.Contains(regID)){
						this.RegAlreadyScanned();
						return;
					}
					// event ok, check reg id against list
					this.LastScannedId = regID;
					Registration reg = this.RegistrationsLoaded.FirstOrDefault(r => r.id == regID);
					if (reg != null) {
						// reg exists on the loaded list
						if (GetSelectedSocialEventId() != 0) {
							this.CheckSEAccess(reg);
						} else {
							this.RegOk(reg);
						}
					} else {
						// not on the list
						this.RegNotOk(regID);
					}
				} catch (Exception ex) {
					Log(ex.Message);
					this.BadFormat();
				}
			} else {
				this.ScanFail();
			}
		}
		private void btnScanDone_Click(object sender, EventArgs e) {
			if (RegScanned_OK.Count > 0) {
				this.GotoSaveScreen();
			} else {
				if (MessageBox.Show(C.NO_REG_SAVED_MSG, "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes) {
					this.Close();
				}
			}
		}
		private void btnSelect_Click(object sender, EventArgs e) {
			this.GotoOptionsScreen();
		}
		private void btnScanRegOnly_Click(object sender, EventArgs e) {
			this.GotoScanScreen();
		}
		private void btnScanSocialEvents_Click(object sender, EventArgs e) {
			int id = (int)menuSocialEvents.SelectedValue;
			if (id > 0) {
				this.SelectedSocialEventId = id;
				this.GotoScanScreen();
			} else {
				MessageBox.Show(C.NO_SOCIAL_EVENT_SELECTED, "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			}
		}
		private void btnOverrideYes_Click(object sender, EventArgs e) {
			if (MessageBox.Show(C.OVERRIDE_CONFIRM, "ATTENTION", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1) == DialogResult.Yes) {
				C.PlaySound(@"\windows\beep.wav");
				this.RegScannedTally.Add(GetLastScannedId());
				Registration r = new Registration() { id = GetLastScannedId(), timestamp = DateTime.Now.ToString("u") };
				RegScanned_Overrides.Add(r);
				RegScanned_OK.Add(r);
				this.IncrementScanValid();
			}
			this.resultPanel.Hide();
			this.btnScan.Enabled = true;
			this.ScannerActive = true;
		}
		private void btnOverrideNo_Click(object sender, EventArgs e) {
			RegScanned_Rejected.Add(new Registration() { id = GetLastScannedId(), timestamp = DateTime.Now.ToString("u") });
			this.resultPanel.Hide();
			this.btnScan.Enabled = true;
			this.ScannerActive = true;
		}
		private void btnSaveToFile_Click(object sender, EventArgs e) {
			this.SaveCsvFile();
		}
		private void btnSaveToVenture_Click(object sender, EventArgs e) {
			this.SaveToVenture();
		}
		private void lblStartOver_Click(object sender, EventArgs e) {
			this.GotoOptionsScreen();
		}
		private void btnExit_Click(object sender, EventArgs e) {
			if (!this.GetDataSaved()) {
				if (MessageBox.Show(C.EXIT_DATA_NOT_SAVED_MSG, "ATTENTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes) {
					this.LogResultsToFile();
					this.Close();
				}
			} else {
				this.LogResultsToFile();
				this.Close();
			}
		}









	}
	// end main UI class ========================================================================

	// registration class for each registered delegate
	public class Registration {
		public string id { get; set; }
		public string title { get; set; }
		public string first_name { get; set; }
		public string last_name { get; set; }
		public string suffix { get; set; }
		public List<int> social_events_booked { get; set; }
		public string timestamp { get; set; }
	}

	// EventsLoaded class populated from Venture
	public class Event {
		public int id { get; set; }
		public string name { get; set; }
		public string city { get; set; }
		public string event_code { get; set; }
		public string display_name { get; set; }
	}

	// social EventsLoaded class populated from Venture
	public class SocialEventOption {
		public int id { get; set; }
		public string name { get; set; }
		public int social_event_id { get; set; }
		public string social_event_name { get; set; }
		public string display_name { get; set; }
	}



}
