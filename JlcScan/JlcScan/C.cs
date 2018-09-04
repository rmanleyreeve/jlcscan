using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace REMedia.JlcScan {

	public class C {

		//UI messages
		public const string VALID_REG_MSG = "VALID REGISTRATION";
		public const string VALID_TEMP_REG_MSG = "VALID TEMP REGISTRATION";
		public const string INVALID_REG_MSG = "ERROR\nNOT REGISTERED FOR THIS EVENT";
		public const string VALID_SE_REG_MSG = "VALID SOCIAL EVENT BOOKING";
		public const string INVALID_SE_REG_MSG = "ERROR\nNOT BOOKED FOR THIS SOCIAL EVENT";
		public const string BAD_FORMAT_MSG = "ERROR\nWRONG BARCODE FORMAT";
		public const string SCAN_FAIL_MSG = "ERROR\nFAILED TO SCAN\nTRY AGAIN";
		public const string DUPLICATE_SCAN_MSG = "ERROR\nBADGE WAS ALREADY SCANNED";
		public const string BAD_EVENT_MSG = "ERROR\nWRONG EVENT CODE";

		public const string NO_EVENT_SELECTED = "No event selected!";
		public const string NO_SOCIAL_EVENT_SELECTED = "No social event selected!";
		public const string OVERRIDE_CONFIRM = "Allow Event Access for this Registration?\nPress ENT key to confirm.";
		public const string OFFLINE_MSG = "No Internet Connection!";
		public const string NO_EVENTS_MSG = "No barcode events found in Venture.";
		public const string NO_CONNECTION_MSG = "No Internet connection.\nPlease load data file from PDA.";
		public const string WEBSVC_FAIL_MSG = "Cannot get data from Venture server.\nPlease load data file from PDA.";
		public const string SELECT_FILE_MSG = "Please select an Event Data file!";
		public const string DATA_LOADED_MSG = "Event Data loaded for {0}\n({1} Registrations)";
		public const string NO_REG_SAVED_MSG = "No Registrations to save!\nExit the program?";
		public const string REG_SCANNED_MSG = "{0} Registrations scanned.";
		public const string REG_SAVED_MSG = "{0} Registrations saved to PDA.";
		public const string VENTURE_UPLOAD_OK_MSG = "The data has been uploaded to Venture.";
		public const string VENTURE_UPLOAD_FAIL_MSG = "The data could not be uploaded to Venture.\nPlease try again or save the data file to the PDA.";
		public const string EXIT_DATA_NOT_SAVED_MSG = "DATA NOT SAVED!\nAre you sure you want to exit?";
		public const string CONTACTING_VENTURE_MSG = "Contacting Venture Server...";

		// constants
		public const string INITIAL_DIR = "\\My Documents";
		public const string LOG_DIR = INITIAL_DIR + "\\VentureScan Logs";
		public const string CHECK_URL = "http://jlcventure.com/websvc/check.html";
		public const string WEBSVC_EVENTS_ENDPOINT = "http://jlcventure.com/websvc/pda_event.php";
		public const string WEBSVC_EVENT_ENDPOINT = "http://jlcventure.com/websvc/pda_events.php";
		public const string WEBSVC_SAVE_ENDPOINT = "http://jlcventure.com/websvc/save.php";




		#region SerialPort Switch
		#region
		/************************************************************************
        * SerialPortControl_Ex(UINT8 uPortID, UINT8 uValue);                 
        ************************************************************************/
		[DllImport("DeviceAPI.dll", EntryPoint = "SerialPortControl_Ex")]
		public static extern int SerialPortControl_Ex(byte port, byte s);


		/************************************************************************
		* SerialPortSwitch_Ex(int iPort);                         
		* iPort port id  0:RFID；1 :serial port；2:Barcode；3:GPS；                    
		************************************************************************/
		[DllImport("DeviceAPI.dll", EntryPoint = "SerialPortSwitch_Ex")]
		public static extern void SerialPortSwitch_Ex(int iPort);
		#endregion
		#endregion


		public static Icon GetIcon(string fileName, bool isLargeIcon) {
			SHFILEINFO shfi = new SHFILEINFO();
			IntPtr hI;

			if (isLargeIcon) {
				hI = SHGetFileInfo(fileName, 0, ref shfi, (uint)Marshal.SizeOf(shfi), SHGFI_ICON | SHGFI_USEFILEATTRIBUTES | SHGFI_LARGEICON);
			} else {
				hI = SHGetFileInfo(fileName, 0, ref shfi, (uint)Marshal.SizeOf(shfi), SHGFI_ICON | SHGFI_USEFILEATTRIBUTES | SHGFI_SMALLICON);
			}

			Icon icon = Icon.FromHandle(shfi.hIcon).Clone() as Icon;

			DestroyIcon(shfi.hIcon);
			return icon;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		struct SHFILEINFO {
			public IntPtr hIcon;
			public int iIcon;
			public uint dwAttributes;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			public string szDisplayName;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
			public string szTypeName;
		}

		[DllImport("coredll.dll", EntryPoint = "SHGetFileInfo", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);

		[DllImport("coredll.dll", EntryPoint = "DestroyIcon")]
		public static extern int DestroyIcon(IntPtr hIcon);

		#region API Const Value

		public const uint SHGFI_ICON = 0x100;
		public const uint SHGFI_LARGEICON = 0x0; // 32×32
		public const uint SHGFI_SMALLICON = 0x1; // 16×16
		public const uint SHGFI_USEFILEATTRIBUTES = 0x10;

		#endregion


		[DllImport("CoreDLL.dll")]
		public static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);


		#region coredll
		[DllImport("coredll.dll")]
		public static extern void GwesPowerOffSystem();

		[DllImport("coredll.dll")]
		public static extern void TouchCalibrate();


		#endregion


		private const string filePath = @"\windows\Barcodebeep.wav";

		public static bool PlaySound() {
			try {
				if (File.Exists(filePath)) {
					SoundPlayer player = new SoundPlayer(filePath);
					player.Play();
				}
				return true;
			} catch (System.Exception) {
				return false;
			}

		}


		public static bool PlaySound(string wavPath) {
			try {
				if (File.Exists(wavPath)) {
					SoundPlayer player = new SoundPlayer(wavPath);
					player.Play();
				}
				return true;
			} catch (System.Exception) {
				return false;
			}
		}

		public static string OS_Version {
			get {
				try {
					RegistryKey RegKey = Registry.LocalMachine.OpenSubKey(@"ControlPanel\BUILDTIME");
					//RegistryKey RegKey = Registry.CurrentUser.OpenSubKey(@"ControlPanel\Appearance");       
					string str = RegKey.GetValue("BUILDTIME").ToString();
					RegKey.Close();
					return str;
				} catch (Exception) {
					return string.Empty;
				}
			}

		}
		public static void TouchTest() {
			TouchCalibrate();
		}
		public static void PowerOffSystem() {
			GwesPowerOffSystem();
		}

		public static int ByteArrayToInt(byte[] bRefArr) {
			int iOutcome = 0;
			byte bLoop;

			for (int i = 0; i < 4; i++) {
				bLoop = bRefArr[i + 1];
				iOutcome += (bLoop & 0xFF) << (8 * i);
			}
			return iOutcome;
		}
	}
}
