using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
namespace REMedia.JlcScan
{
    public class SystemInfo
    {
        private const int GW_HWNDFIRST = 0;
        private const int GW_HWNDNEXT = 2;
        private const int GWL_STYLE = (-16);
        private const int WS_VISIBLE = 268435456;
        private const int WS_BORDER = 8388608;

        #region find all app title
        /// <summary>
        /// find all app title
        /// </summary>
        /// <returns></returns>
        private static List<string> FindAllApps(int Handle)
        {
            List<string> Apps = new List<string>();

            int hwCurr;
            hwCurr = GetWindow(Handle, GW_HWNDFIRST);

            while (hwCurr > 0)
            {
                int IsTask = (WS_VISIBLE | WS_BORDER);
                int lngStyle = GetWindowLongW(hwCurr, GWL_STYLE);
                bool TaskWindow = ((lngStyle & IsTask) == IsTask);
                if (TaskWindow)
                {
                    int length = GetWindowTextLengthW(new IntPtr(hwCurr));
                    StringBuilder sb = new StringBuilder(2 * length + 1);
                    GetWindowText(hwCurr, sb, sb.Capacity);
                    string strTitle = sb.ToString();
                    if (!string.IsNullOrEmpty(strTitle))
                    {
                        Apps.Add(strTitle);
                    }
                }
                hwCurr = GetWindow(hwCurr, GW_HWNDNEXT);
            }

            return Apps;
        }
        #endregion



        /// <summary>
        /// has run the same window
        /// </summary>
        /// <param name="formName"></param>
        /// <param name="handle"></param>
        /// <returns></returns>
        public  static bool alreadyRun(string formName,int handle)
        {
  
            int sum = 0;
            List<string> gg = FindAllApps(handle);
            foreach (string a in gg)
            {
                if (a == formName)
                {
                    sum += 1;               
                }
            }
            if (sum > 0)
                return true;
            else
                return false;
   
        }

        #region Win32 API Describle
        [DllImport("coredll.dll")]
        private extern static int GetWindow(int hWnd, int wCmd);

        [DllImport("coredll.dll")]
        private extern static int GetWindowLongW(int hWnd, int wIndx);

        [DllImport("coredll.dll")]
        private static extern bool GetWindowText(int hWnd, StringBuilder title, int maxBufSize);

        [DllImport("coredll.dll", CharSet = CharSet.Auto)]
        private extern static int GetWindowTextLengthW(IntPtr hWnd);
#endregion
    }
}
