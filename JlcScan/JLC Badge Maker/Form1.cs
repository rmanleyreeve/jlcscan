using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace JLC_Badge_Maker {
	public partial class UI : Form {

		string _eventID = String.Empty;
		string _title = String.Empty;
		string _first_name = String.Empty;
		string _last_name = String.Empty;
		string _organisation = String.Empty;
		string _country = String.Empty;
		int style = 0;
		int position;
		public int count = 0;
		public List<Badge> BadgeList = new List<Badge>();
		string PDF_OK = "Temporary Badge PDF Created";
		string VALIDATION_FAIL_MSG = "You must complete the required fields.";
		bool drawGuides = true;

		public UI() {
			InitializeComponent();
			this.menuBadgeStyle.SelectedIndex = 0;
			this.menuPrintPosition.SelectedIndex = 0;
			//test();
		}
		
		private void IncrementCounter() {
			count++;
		}
		
		private int GetCount() {
			return count;
		}
		
		public static void Log(String msg) {
			System.Diagnostics.Debug.WriteLine(msg);
		}
		
		private bool validate() {
			bool ok = true;
			List<TextBox> fields = new List<TextBox>() { 
				this.eventID, 
				this.first_name, 
				this.last_name 
			};
			foreach (TextBox f in fields) {
				f.BackColor = Color.White;
				if (f.Text == String.Empty) {
					f.BackColor = Color.Pink;
					ok = false;
				}
			}
			if (menuBadgeStyle.SelectedIndex == 0) {
				menuBadgeStyle.BackColor = Color.Pink;
				ok = false;
			} else {
				menuBadgeStyle.BackColor = Color.White;
			}

			return ok;
		}
		
		private string sp(string s) {
			return (s == String.Empty) ? s : s + " ";
		}
		
		private void button1_Click(object sender, EventArgs e) {
			if (!validate()) {
				MessageBox.Show(VALIDATION_FAIL_MSG, "ATTENTION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			_eventID = eventID.Text;
			_title = title.Text;
			_first_name = first_name.Text;
			_last_name = last_name.Text;
			_organisation = organisation.Text;
			_country = country.Text;
			style = menuBadgeStyle.SelectedIndex;
			position = menuPrintPosition.SelectedIndex;

			IncrementCounter();

			string regID = "X00" + Convert.ToString(GetCount());
			Badge b = new Badge() {
				id = regID,
				event_id = _eventID,
				title = _title,
				first_name = _first_name,
				last_name = _last_name,
				organisation = _organisation,
				country = _country,
				timestamp = DateTime.Now.ToString("u")
			};

			BadgeList.Add(b);
			Log(b.ToString());
			Log("style: " + style);
			Log("pos: " + position);
			CreatePDF(b, style, position);
			MessageBox.Show(PDF_OK, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
			this.eventID.Text = _eventID;
			this.title.Text = String.Empty;
			this.first_name.Text = String.Empty;
			this.last_name.Text = String.Empty;
			this.organisation.Text = String.Empty;
			this.country.Text = String.Empty;
		}
		
		private void CreatePDF(Badge b, int style, int position) {
			string dir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			string path = dir + "/" + b.event_id + "_" + b.id + ".pdf";
			Document doc = new Document(PageSize.A4);
			int docH = (int)doc.PageSize.Height; //842
			int docW = (int)doc.PageSize.Width; //595
			int marginT = 94;
			int marginB = 94;
			int badgesH = (docH - (marginT + marginB));
			int badgeH = (badgesH / 3);
			int badgeW = (docW / 2);
			int badgeX = 0;
			int badgeY = 0;
			int logoH = (int)iTextSharp.text.Utilities.MillimetersToPoints(25);
			var output = new FileStream(path, FileMode.Create);
			var writer = PdfWriter.GetInstance(doc, output);
			doc.Open();
			PdfContentByte cb = writer.DirectContent;
			BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
			iTextSharp.text.Font font1 = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD);
			iTextSharp.text.Font font2 = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);
			iTextSharp.text.Font font3 = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.ITALIC);
			iTextSharp.text.Font font4 = new iTextSharp.text.Font(bf, 5, iTextSharp.text.Font.NORMAL);
			cb.SetColorFill(BaseColor.BLACK);
			cb.SetFontAndSize(bf, 30);
			if (drawGuides) {
				// GUIDES
				cb.MoveTo(0, docH - marginT);
				cb.LineTo(docW, docH - marginT);
				cb.Stroke(); // top margin
				cb.MoveTo(0, marginB);
				cb.LineTo(docW, marginB);
				cb.Stroke(); // bottom margin
				cb.MoveTo(badgeW, marginB);
				cb.LineTo(badgeW, docH - marginT);
				cb.Stroke(); // center line
				cb.MoveTo(0, (marginB + badgeH));
				cb.LineTo(docW, (marginB + badgeH));
				cb.Stroke(); // lower divider
				cb.MoveTo(0, (marginB + (badgeH * 2)));
				cb.LineTo(docW, (marginB + (badgeH * 2)));
				cb.Stroke(); // upper divider
			}
			// set position of badge
			switch (position) {
				case 0:
					badgeX = 0; badgeY = ((docH - marginT) - badgeH);
					break;
				case 1:
					badgeX = badgeW; badgeY = ((docH - marginT) - badgeH);
					break;
				case 2:
					badgeX = 0; badgeY = ((docH - marginT) - (badgeH * 2));
					break;
				case 3:
					badgeX = badgeW; badgeY = ((docH - marginT) - (badgeH * 2));
					break;
				case 4:
					badgeX = 0; badgeY = marginB;
					break;
				case 5:
					badgeX = badgeW; badgeY = marginB;
					break;
			}
			badgeY = (style == 1) ? (badgeY - logoH) : (badgeY - 0);
			// create barcode image
			string code = b.event_id + " " + b.id;
			System.Drawing.Image _img = BarcodeLib.Barcode.DoEncode(BarcodeLib.TYPE.CODE128, code, true, Color.Black, Color.White, 250, 50);
			iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(_img, System.Drawing.Imaging.ImageFormat.Png);
			// add text
			Paragraph p = new Paragraph();
			p.Add(new Chunk(sp(b.title) + sp(b.first_name) + b.last_name + "\n", font1));
			p.Add(new Chunk(b.organisation + "\n", font2));
			p.Add(new Chunk(b.country + "\n", font3));
			p.Add(new Chunk("\n", font4));
			p.Add(new Chunk(img, 0, 0, true));
			p.Alignment = 1;
			ColumnText col = new ColumnText(cb);
			col.SetSimpleColumn(badgeX, badgeY, (badgeX + badgeW), (badgeY + badgeH));
			col.Alignment = 1;
			col.SetLeading(0, 1.2f);
			col.AddText(p);
			col.Go();
			doc.Close();
		}

		// DEBUG ==================================================================
		private void test() {

			string dir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			string path = dir + "/TEST.pdf";
			Document doc = new Document(PageSize.A4);
			int docH = (int)doc.PageSize.Height; //842
			int docW = (int)doc.PageSize.Width; //595
			int marginT = 94;
			int marginB = 94;
			int badgesH = (docH - (marginT + marginB));
			int badgeH = (badgesH / 3);
			int badgeW = (docW / 2);
			int badgeX = 0;
			int badgeY = 0;
			int logoH = (int)iTextSharp.text.Utilities.MillimetersToPoints(25);
			Log("Doc H:" + docH);
			Log("Marg T:" + marginT);
			Log("Badges H:" + badgesH);
			Log("Badge H:" + badgeH);
			Log("Logo H:" + logoH);
			var output = new FileStream(path, FileMode.Create);
			var writer = PdfWriter.GetInstance(doc, output);
			doc.Open();
			PdfContentByte cb = writer.DirectContent;
			BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
			iTextSharp.text.Font font1 = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD);
			iTextSharp.text.Font font2 = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);
			iTextSharp.text.Font font3 = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.ITALIC);
			iTextSharp.text.Font font4 = new iTextSharp.text.Font(bf, 5, iTextSharp.text.Font.NORMAL);
			cb.SetColorFill(BaseColor.BLACK);
			cb.SetFontAndSize(bf, 30);
			// GUIDES
			cb.MoveTo(0, docH - marginT);
			cb.LineTo(docW, docH - marginT);
			cb.Stroke(); // top margin
			cb.MoveTo(0, marginB);
			cb.LineTo(docW, marginB);
			cb.Stroke(); // bottom margin
			cb.MoveTo(badgeW, marginB);
			cb.LineTo(badgeW, docH - marginT);
			cb.Stroke(); // center line
			cb.MoveTo(0, (marginB + badgeH));
			cb.LineTo(docW, (marginB + badgeH));
			cb.Stroke(); // lower divider
			cb.MoveTo(0, (marginB + (badgeH * 2)));
			cb.LineTo(docW, (marginB + (badgeH * 2)));
			cb.Stroke(); // upper divider
			for (int i = 0; i < 6; i++) {
				Badge b = new Badge() {
					id = "X99",
					event_id = "139",
					title = "Mr",
					first_name = "Richard",
					last_name = "Manley-Reeve",
					organisation = "RE Media",
					country = "United Kingdom",
					timestamp = DateTime.Now.ToString("u")
				};
				int style = 1;
				int position = i;
				switch (position) {
					case 0:
						badgeX = 0; badgeY = ((docH - marginT) - badgeH);
						break;
					case 1:
						badgeX = badgeW; badgeY = ((docH - marginT) - badgeH);
						break;
					case 2:
						badgeX = 0; badgeY = ((docH - marginT) - (badgeH * 2));
						break;
					case 3:
						badgeX = badgeW; badgeY = ((docH - marginT) - (badgeH * 2));
						break;
					case 4:
						badgeX = 0; badgeY = marginB;
						break;
					case 5:
						badgeX = badgeW; badgeY = marginB;
						break;
				}
				badgeY = (style == 1) ? (badgeY - logoH) : (badgeY - 0);
				// create barcode image
				string code = b.event_id + " " + b.id;
				System.Drawing.Image _img = BarcodeLib.Barcode.DoEncode(BarcodeLib.TYPE.CODE128, code, true, Color.Black, Color.White, 250, 50);
				iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(_img, System.Drawing.Imaging.ImageFormat.Png);
				// add text
				Paragraph p = new Paragraph();
				p.Add(new Chunk(sp(b.title) + sp(b.first_name) + b.last_name + "\n", font1));
				p.Add(new Chunk(b.organisation + "\n", font2));
				p.Add(new Chunk(b.country + "\n", font3));
				p.Add(new Chunk("\n", font4));
				p.Add(new Chunk(img, 0, 0, true));
				p.Alignment = 1;
				ColumnText col = new ColumnText(cb);
				Log("B:" + badgeY + ", T:" + (badgeY + badgeH));
				col.SetSimpleColumn(badgeX, badgeY, (badgeX + badgeW), (badgeY + badgeH));
				col.Alignment = 1;
				col.SetLeading(0, 1.2f);
				col.AddText(p);
				col.Go();
			}
			doc.Close();
			MessageBox.Show("TEST CREATED", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void menuBadgeStyle_SelectedIndexChanged(object sender, EventArgs e) {

		}

		private void menuPrintPosition_SelectedIndexChanged(object sender, EventArgs e) {

		}

	}


	public class Badge {
		public string id { get; set; }
		public string event_id { get; set; }
		public string title { get; set; }
		public string first_name { get; set; }
		public string last_name { get; set; }
		public string organisation { get; set; }
		public string country { get; set; }
		public string timestamp { get; set; }
	}


}
