using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
		int style = 0;
		int position;
		public int count = 0;


		public UI() {
			InitializeComponent();
			this.menuBadgeStyle.SelectedIndex = 0;
			this.menuPrintPosition.SelectedIndex = 0;
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
			Log("TXT " + menuPrintPosition.SelectedItem.ToString());
			if (!validate()) {
				MessageBox.Show("Badge Details missing","ATTENTION",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return; 
			}
			_eventID = eventID.Text;
			_title = title.Text;
			_first_name = first_name.Text;
			_last_name = last_name.Text;
			_organisation = organisation.Text;
			style = menuBadgeStyle.SelectedIndex;
			position = Convert.ToInt32(menuPrintPosition.SelectedItem.ToString());

			IncrementCounter();

			// create barcode image
			string regID = "X00" + Convert.ToString(GetCount());
			string BarcodeContent = _eventID + " " + regID;
			BarcodeLib.Barcode bc = new BarcodeLib.Barcode(BarcodeContent, BarcodeLib.TYPE.CODE128);
			bc.IncludeLabel = true;
			System.Drawing.Image img = bc.Encode(BarcodeLib.TYPE.CODE128, BarcodeContent,200,60);
			foo.Image = img; foo.Refresh(); // DEBUG		

			// create pdf
			Document doc = new Document(PageSize.A4);
			var output = new FileStream(Server.MapPath(regID + ".pdf"), FileMode.Create);
			var writer = PdfWriter.GetInstance(doc, output);
			doc.Open();

			var logo = iTextSharp.text.Image.GetInstance(img, System.Drawing.Imaging.ImageFormat.Png);
			logo.SetAbsolutePosition(430, 770);
			logo.ScaleAbsoluteHeight(30);
			logo.ScaleAbsoluteWidth(70);
			doc.Add(logo);


			doc.Close();

		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {

		}

		private void label7_Click(object sender, EventArgs e) {

		}

		private void menuPrintPosition_SelectedIndexChanged(object sender, EventArgs e) {

		}

		private void label6_Click(object sender, EventArgs e) {

		}
	}


	public class Badge {
		public string id { get; set; }
		public string title { get; set; }
		public string first_name { get; set; }
		public string last_name { get; set; }
		public string organisation { get; set; }
	}


}
