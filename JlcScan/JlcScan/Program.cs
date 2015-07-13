using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using SDK.English.UI;
using SDK.English;

namespace SDK.English.JlcScan {

	static class Program {
		/// <summary>
		/// The App Entry Point
		/// </summary>
		[MTAThread]
		static void Main() {
			SystemHelper.CurrentDeviceType = DeviceType.C2000;
			Application.Run(new UI());
		}
	}
}