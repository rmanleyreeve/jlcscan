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

		public UI() {
			InitializeComponent();
			this.menuBadgeStyle.SelectedIndex = 0;
			this.menuPrintPosition.SelectedIndex = 0;
			test();
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
			if (
				eventID.Text == String.Empty ||
				first_name.Text == String.Empty ||
				last_name.Text == String.Empty ||
				menuBadgeStyle.SelectedIndex == 0
			) {
				ok = false;
			}
			return ok;
		}

		private void button1_Click(object sender, EventArgs e) {
			if (!validate()) {
				MessageBox.Show("Badge Details missing", "ATTENTION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			_eventID = eventID.Text;
			_title = title.Text;
			_first_name = first_name.Text;
			_last_name = last_name.Text;
			_organisation = organisation.Text;
			_country = country.Text;
			style = menuBadgeStyle.SelectedIndex;
			position = Convert.ToInt32(menuPrintPosition.SelectedItem.ToString());

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

			MessageBox.Show("Badge PDF Created", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
			this.eventID.Text = _eventID;
			this.title.Text = String.Empty;
			this.first_name.Text = String.Empty;
			this.last_name.Text = String.Empty;
			this.organisation.Text = String.Empty;
			this.country.Text = String.Empty;
		}

		private void CreatePDF(Badge b, int style, int position) {
			Document doc = new Document(PageSize.A4);
			int docH = (int)doc.PageSize.Height; //842
			int docW = (int)doc.PageSize.Width; //595
			int badgeH = (docH / 3);
			int badgeW = (docW / 2);
			int badgeX = 0;
			int badgeY = 0;
			string dir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			string path = dir + "/" + b.id + ".pdf";
			var output = new FileStream(path, FileMode.Create);
			var writer = PdfWriter.GetInstance(doc, output);
			doc.Open();
			PdfContentByte cb = writer.DirectContent;
			BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
			iTextSharp.text.Font font1 = new iTextSharp.text.Font(bf, 20, iTextSharp.text.Font.BOLD);
			iTextSharp.text.Font font2 = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.NORMAL);
			iTextSharp.text.Font font3 = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.ITALIC);
			iTextSharp.text.Font font4 = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);
			cb.SetColorFill(BaseColor.BLACK);
			cb.SetFontAndSize(bf, 30);

			// GUIDES
			cb.MoveTo(doc.PageSize.Width / 2, 0);
			cb.LineTo(doc.PageSize.Width / 2, doc.PageSize.Height);
			cb.Stroke();
			cb.MoveTo(0, doc.PageSize.Height / 3);
			cb.LineTo(doc.PageSize.Width, doc.PageSize.Height / 3);
			cb.Stroke();
			cb.MoveTo(0, 2 * (doc.PageSize.Height / 3));
			cb.LineTo(doc.PageSize.Width, 2 * (doc.PageSize.Height / 3));
			cb.Stroke();

			switch (position) {
				case 1:
					badgeX = 0; badgeY = (docH - badgeH);
					break;
				case 2:
					badgeX = badgeW; badgeY = (docH - badgeH);
					break;
				case 3:
					badgeX = 0; badgeY = badgeH;
					break;
				case 4:
					badgeX = badgeW; badgeY = badgeH;
					break;
				case 5:
					badgeX = 0; badgeY = 0;
					break;
				case 6:
					badgeX = badgeW; badgeY = 0;
					break;
			}
			badgeY = (style == 1) ? (badgeY - 90) : (badgeY - 10);

			string code = b.event_id + " " + b.id;
			// create barcode image
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
			Log(badgeX + ", " + badgeY + ", " + (badgeX + badgeW) + ", " + (badgeY + badgeH));
			col.SetSimpleColumn(badgeX, badgeY, (badgeX + badgeW), (badgeY + badgeH));
			col.Alignment = 1;
			col.SetLeading(0, 1.2f);
			col.AddText(p);
			col.Go();
			doc.Close();
		}

		private void test() {
			Badge b = new Badge() {
				id = "X111",
				event_id = "139",
				title = "Mr.",
				first_name = "Frederick Augustus",
				last_name = "Blenkinsopp",
				organisation = "RE Media Enterprises Limited",
				country = "The Independent Federation of Gateshead",
				timestamp = DateTime.Now.ToString("u")
			};
			CreatePDF(b, 1, 1);
			MessageBox.Show("Badge PDF Created", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private string sp(string s) {
			return (s == String.Empty) ? s : s + " ";
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {

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
