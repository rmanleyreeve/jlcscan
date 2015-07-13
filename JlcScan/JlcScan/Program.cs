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
			if (!SystemHelper.GetDeviceType()) {
				//set default device type is C5000
				SystemHelper.CurrentDeviceType = DeviceType.C5000;
			}
			Application.Run(new JlcScanUi());
		}
	}
}