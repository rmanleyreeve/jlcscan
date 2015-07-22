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
		private List<Registration> RegistrationsList = new List<Registration>();
		private List<Event> EventsList = new List<Event>();
		private List<SocialEventOption> SocialEventOptionsList = new List<SocialEventOption>();
		private string EventID;
		private string EventTitle;
		private int NumTotalScans;
		private int NumValidScans;
		private int NumFailedScans;
		private int NumEvents = 0;
		private static List<Registration> RegScanned_OnList = new List<Registration>();
		private static List<Registration> RegScanned_Overrides = new List<Registration>();
		private static List<string> RegScanned_NotOnList = new List<string>();
		public bool Online = false;
		public bool ScannerActive;
		private int SelectedSocialEventId;
		public string LastScannedId;
		public bool DataSaved = false;
		private int ResultsScreenDuration = 3;

		public UI() {
			InitializeComponent(); // set up ui layout from UI.Designer.cs
		}


		// UTILITY METHODS =======================================================================
		private void Ui_Load(object sender, EventArgs e) {
			Log("PROGRAM LOADED");
			if (SystemInfo.alreadyRun(this.Text, this.Handle.ToInt32())) {
				MessageBox.Show("FATAL ERROR\nProgram already running","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Hand,MessageBoxDefaultButton.Button1);
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
						this.DisplayOfflineText();
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
			RegScanned_OnList.Clear();
			RegScanned_NotOnList.Clear();
			RegScanned_Overrides.Clear();
			this.DataSaved = false;
			this.lblSendToVentureMsg.Text = "";
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
				this.btnOverride_Click(null, null);
			}
			if (this.lblOverride.Visible && e.KeyValue == (int)SystemHelper.ConstantKeyValue.BLUE) {
				this.btnNoOverride_Click(null, null);
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
			this.btnOverride.Hide();
			this.btnNoOverride.Hide();
			bool IsOverride = false;
			switch (str) {
				case "ok":
					this.iconBoxOK.Show();
					break;
				case "no":
					this.iconBoxNo.Show();
					IsOverride = true;
					this.lblOverride.Show();
					this.btnOverride.Show();
					this.btnNoOverride.Show();
					break;
				case "fail":
					this.iconBoxFail.Show();
					break;
			}
			// show result panel for 3 seconds
			this.ScannerActive = false;
			this.resultPanel.Show();
			if (!IsOverride) {
				int secs = 0;
				Timer timer = new Timer { Interval = 1000, Enabled = true };
				timer.Tick += delegate {
					secs++;
					if (secs < this.ResultsScreenDuration) { return; }
					timer.Enabled = false;
					this.resultPanel.Hide();
					this.ScannerActive = true;
				};
			}
		}
		private void PopulateEventsDropdown() {
			this.EventsList.Insert(0, new Event() { id = 139, display_name = "RE MEDIA TEST EVENT" }); // HACK
			this.EventsList.Insert(0, new Event() { id = 0, display_name = "Choose Event..." });
			this.menuEvents.DataSource = EventsList;
			this.menuEvents.ValueMember = "id";
			this.menuEvents.DisplayMember = "display_name";
		}
		private void PopulateSocialEventsOptionsDropdown() {
			this.SocialEventOptionsList.Insert(0, new SocialEventOption() { id = 0, display_name = "Choose Social Event..." });
			this.menuSocialEvents.DataSource = SocialEventOptionsList;
			menuSocialEvents.ValueMember = "id";
			this.menuSocialEvents.DisplayMember = "display_name";
		}
		private void DisplayOfflineText() {
			this.lblLoadFromVenture.Text = "No Internet Connection";
		}
		private void DrawBorder(object sender, PaintEventArgs e) {
			e.Graphics.DrawRectangle(
				new Pen(Color.Black), 0, 0,
				e.ClipRectangle.Width - 2,
				e.ClipRectangle.Height - 2
			);
		}
		private void UpdateSaveToVentureMsg(string msg) {
			this.lblSendToVentureMsg.Text = msg;
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
			RegScanned_OnList.Add(reg);
			C.PlaySound(@"\windows\beep.wav");
			this.ShowScanResult("ok");
			this.UpdateScanResultMsg(reg.first_name + " " + reg.last_name + "\n" + C.VALID_SE_REG_MSG);
			this.IncrementScanValid();
		}
		public void RegOk(Registration reg) {
			reg.timestamp = DateTime.Now.ToString("u");
			RegScanned_OnList.Add(reg);
			C.PlaySound(@"\windows\beep.wav");
			this.ShowScanResult("ok");
			this.UpdateScanResultMsg(reg.first_name + " " + reg.last_name + "\n" + C.VALID_REG_MSG);
			this.IncrementScanValid();
		}
		public void RegNotOk(string r) {
			RegScanned_NotOnList.Add(r);
			C.PlaySound(@"\windows\exclam.wav");
			this.ShowScanResult("no");
			this.UpdateScanResultMsg(C.INVALID_REG_MSG);
			this.IncrementScanFail();
		}
		public void SE_RegNotOk(string rid) {
			RegScanned_NotOnList.Add(rid);
			C.PlaySound(@"\windows\exclam.wav");
			this.ShowScanResult("no");
			this.UpdateScanResultMsg(C.INVALID_SE_REG_MSG);
			this.IncrementScanFail();
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
			ShowScanResult("fail");
			UpdateScanResultMsg(C.SCAN_FAIL_MSG);
			IncrementScanFail();
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
					this.RegistrationsList.Add(r);
				} catch (Exception ex) {
					Log(ex.StackTrace);
					Log(el.ToString());
				}
			}
			Log("XML count=" + count + ", read=" + RegistrationsList.Count()); // DEBUG

			// read in social EventsList
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
									Registration regBooked = RegistrationsList.FirstOrDefault(r => r.id == booked_reg);
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
			return this.RegistrationsList.Count();
		}
		private int ReadXMLEvents(XDocument xdoc) {
			foreach (XElement el in xdoc.Descendants("event")) {
				try {
					Event ev = new Event() {
						id = Convert.ToInt32(el.Attribute("id").Value),
						name = FixNullString(el.Attribute("name").Value),
						city = FixNullString(el.Attribute("city").Value),
						event_code = FixNullString(el.Attribute("event_code").Value),
						display_name = FixNullString(el.Attribute("name").Value) + " " + FixNullString(el.Attribute("city").Value)
					};
					this.EventsList.Add(ev);
				} catch (Exception ex) {
					Log(ex.StackTrace);
					Log(el.ToString());
				}
			}
			return this.EventsList.Count();
		}
		private void SaveCsvFile() {
			Log("On List:"); // DEBUG
			RegScanned_OnList.ForEach(x => Log(Convert.ToString(x.id) + "," + x.timestamp)); // DEBUG
			Log("Overrides:"); // DEBUG
			RegScanned_Overrides.ForEach(x => Log(Convert.ToString(x.id) + "," + x.timestamp)); // DEBUG
			string filePath = "";
			if (this.GetSelectedSocialEventId() > 0) {
				filePath = String.Format("{0}\\SocialEvent_{1}.csv", C.INITIAL_DIR, this.GetSelectedSocialEventId());
			} else {
				filePath = String.Format("{0}\\Event_{1}.csv", C.INITIAL_DIR, EventID);
			}
			File.Create(filePath).Close();
			using (TextWriter writer = File.CreateText(filePath)) {
				writer.WriteLine("#File Saved At: " + DateTime.Now.ToString());
				RegScanned_OnList.ForEach(x => writer.WriteLine("\"" + Convert.ToString(x.id) + "\",\"" + x.timestamp + "\",0"));
				RegScanned_Overrides.ForEach(x => writer.WriteLine("\"" + Convert.ToString(x.id) + "\",\"" + x.timestamp + "\",1"));
				this.DataSaved = true;
				MessageBox.Show(String.Format(C.REG_SAVED_MSG, NumValidScans));
				this.btnSaveToFile.Enabled = false;
			}
		}
		private XDocument BuildXmlDataFile_Registrations() {
			XDocument xdoc = new XDocument();
			try {
				xdoc = new XDocument(
					new XElement("event", new XAttribute("id", EventID), new XAttribute("type", "registration"), new XAttribute("created", DateTime.Now.ToString("u")),
						new XElement("valid", new XAttribute("count",NumValidScans),RegScanned_OnList.Select(x => new XElement("registration", new XAttribute("id", x.id),new XAttribute("timestamp",x.timestamp)))
						),
						new XElement("overrides", new XAttribute("count",RegScanned_Overrides.Count),RegScanned_Overrides.Select(x => new XElement("registration", new XAttribute("id", x.id),new XAttribute("timestamp",x.timestamp)))
						)
					)
				);
			} catch (Exception ex) {
				Log(ex.Message);
			}
			Log("Built Saved Registration XML:\n"+xdoc.ToString()); // DEBUG
			return xdoc;
		}
		private XDocument BuildXmlDataFile_SocialEvents() {
			XDocument xdoc = new XDocument();
			try {
				xdoc = new XDocument(
					new XElement("socialevent", new XAttribute("id", this.EventID), new XAttribute("type", "socialevent"), new XAttribute("social_event_option_id", this.GetSelectedSocialEventId()), new XAttribute("created", DateTime.Now.ToString("u")),
						new XElement("valid", new XAttribute("count", NumValidScans), RegScanned_OnList.Select(x => new XElement("registration", new XAttribute("id", x.id), new XAttribute("timestamp", x.timestamp)))
						),
						new XElement("overrides", new XAttribute("count", RegScanned_Overrides.Count), RegScanned_Overrides.Select(x => new XElement("registration", new XAttribute("id", x.id), new XAttribute("timestamp", x.timestamp)))
						)
					)
				);
			} catch (Exception ex) {
				Log(ex.Message);
			}
			Log("Built Saved Registration XML:\n" + xdoc.ToString()); // DEBUG
			return xdoc;
		}


		// NETWORK METHODS ========================================================================
		private bool IsServerAvailable() {
			bool ok = false;
			try {
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(C.CHECK_URL);
				request.Timeout = 10000;
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				if (response.StatusCode == HttpStatusCode.OK) {
					ok = true;
					Log("IsServerAvailable: " + response.StatusCode);
					response.Close();
				} else {
					response.Close();
				}
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
			req.ReadWriteTimeout = 30000;
			req.Timeout = 30000;
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
		private void GotoOptionsScreen() {
			this.ScannerActive = false;
			this.ClearData();
			this.loadPanel.Hide();
			this.scanPanel.Hide();
			this.savePanel.Hide();
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
			this.scanPanel.Show();
		}
		private void GotoSaveScreen() {
			this.ScannerActive = false;
			this.loadPanel.Hide();
			this.optionsPanel.Hide();
			this.scanPanel.Hide();
			this.resultPanel.Hide();
			this.btnSaveToVenture.Enabled = true;
			this.btnSaveToFile.Enabled = true;
			this.lblNumScannedInfo.Text = String.Format(C.REG_SCANNED_MSG, RegScanned_OnList.Count);
			this.savePanel.Show();
			if (IsServerAvailable()) {
				this.btnSaveToVenture.Show();
			}
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
				MessageBox.Show(C.SELECT_FILE_MSG,"ALERT");
			}
		}
		private void btnLoadFromWeb_Click(object sender, EventArgs e) {
			this.RegistrationsList.Clear();
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
					Log("Event Code: " + parts[0]); // DEBUG
					Log("Reg ID: " + parts[1]); // DEBUG
					evID = parts[0];
					regID = parts[1];
					// check event code matches
					if (evID != EventID) {
						BadEventCode();
					} else {
						// event ok, check reg id against list
						this.LastScannedId = regID;
						Registration reg = this.RegistrationsList.FirstOrDefault(r => r.id == regID);
						if (reg != null) {
							// on the list
							if (RegScanned_OnList.Contains(reg)) {
								this.RegAlreadyScanned();
							} else {
								if (GetSelectedSocialEventId() != 0) {
									this.CheckSEAccess(reg);
								} else {
									this.RegOk(reg);
								}
							}
						} else {
							if (RegScanned_Overrides.Contains(reg)) {
								// was overridden and allowed in
								this.RegAlreadyScanned();
							} else {
								// not on the list
								this.RegNotOk(regID);
							}
						}
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
			if (RegScanned_OnList.Count > 0) {
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
		private void btnOverride_Click(object sender, EventArgs e) {
			if (MessageBox.Show(C.OVERRIDE_CONFIRM, "ATTENTION", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1) == DialogResult.Yes) {
			C.PlaySound(@"\windows\beep.wav");
			RegScanned_Overrides.Add(new Registration() { id = GetLastScannedId(), timestamp = DateTime.Now.ToString("u") });
			RegScanned_OnList.Add(new Registration() { id = GetLastScannedId(), timestamp = DateTime.Now.ToString("u") });
			this.IncrementScanValid();
			this.resultPanel.Hide();
			this.ScannerActive = true;
			} else {
			this.resultPanel.Hide();
			this.ScannerActive = true;
			}
		}
		private void btnNoOverride_Click(object sender, EventArgs e) {
			this.resultPanel.Hide();
			this.ScannerActive = true;
		}
		private void btnSaveToFile_Click(object sender, EventArgs e) {
			this.SaveCsvFile();
		}
		private void btnSaveToVenture_Click(object sender, EventArgs e) {
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
				if(response == "OK") {
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
		private void lblStartOver_Click(object sender, EventArgs e) {
			this.GotoOptionsScreen();
		}
		private void btnExit_Click(object sender, EventArgs e) {
			if (!this.GetDataSaved()) {
				if (MessageBox.Show(C.EXIT_DATA_NOT_SAVED_MSG, "ATTENTION", MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1) == DialogResult.Yes) {
					this.Close();
				}
			} else {
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

	// EventsList class populated from Venture
	public class Event {
		public int id { get; set; }
		public string name { get; set; }
		public string city { get; set; }
		public string event_code { get; set; }
		public string display_name { get; set; }
	}

	// social EventsList class populated from Venture
	public class SocialEventOption {
		public int id { get; set; }
		public string name { get; set; }
		public int social_event_id { get; set; }
		public string social_event_name { get; set; }
		public string display_name { get; set; }
	}



}
