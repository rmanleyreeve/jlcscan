using System;
using System.Windows.Forms;

namespace REMedia.JlcScan {

	static class Program {
		[MTAThread]
		static void Main() {
			Application.Run( new UI() );
		}
	}
}