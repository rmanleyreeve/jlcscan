using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Media;
using System.IO;
using Microsoft.Win32;
using System.Drawing;
using System.Runtime.InteropServices;

namespace SDK.English.JlcScan {

	public class CommonClass {
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
		private const string filePathX = @"\windows\Barcodebeep.wav";

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


		/// <summary>
		/// Read registry information, judge whether English OS
		/// </summary>
		public static bool isEnglish() {
			try {
				RegistryKey RegKey = Registry.CurrentUser.OpenSubKey(@"ControlPanel\Appearance");
				if ("Windows 标准" == RegKey.GetValue("Current").ToString())
					return false;
				else
					return true;
			} catch (Exception) {
				return true;
			}
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
