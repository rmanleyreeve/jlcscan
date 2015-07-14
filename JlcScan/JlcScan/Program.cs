using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using REMedia;

namespace REMedia.JlcScan {

	static class Program {
		[MTAThread]
		static void Main() {
			Application.Run( new UI() );
		}
	}
}