using System;
using System.Runtime.InteropServices;

namespace TelegramBot
{
	// Token: 0x020000F5 RID: 245
	public class Taskbar
	{
		// Token: 0x06000342 RID: 834
		[DllImport("user32.dll")]
		private static extern int FindWindow(string className, string windowText);

		// Token: 0x06000343 RID: 835
		[DllImport("user32.dll")]
		private static extern int ShowWindow(int hwnd, int command);

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000344 RID: 836 RVA: 0x000033A3 File Offset: 0x000015A3
		protected static int Handle
		{
			get
			{
				return Taskbar.FindWindow("Shell_TrayWnd", "");
			}
		}

		// Token: 0x06000345 RID: 837 RVA: 0x00002064 File Offset: 0x00000264
		private Taskbar()
		{
		}

		// Token: 0x06000346 RID: 838 RVA: 0x000033B4 File Offset: 0x000015B4
		public static void Show()
		{
			Taskbar.ShowWindow(Taskbar.Handle, 1);
		}

		// Token: 0x06000347 RID: 839 RVA: 0x000033C2 File Offset: 0x000015C2
		public static void Hide()
		{
			Taskbar.ShowWindow(Taskbar.Handle, 0);
		}

		// Token: 0x0400056E RID: 1390
		private const int SW_HIDE = 0;

		// Token: 0x0400056F RID: 1391
		private const int SW_SHOW = 1;
	}
}
