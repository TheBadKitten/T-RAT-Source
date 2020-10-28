using System;
using System.IO;

namespace TelegramBot
{
	// Token: 0x020000DD RID: 221
	internal class Folders
	{
		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060002C3 RID: 707 RVA: 0x00020D9C File Offset: 0x0001EF9C
		public static string hidenfolder
		{
			get
			{
				string text = Path.GetTempPath() + "winsys";
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text).Attributes = (FileAttributes.Hidden | FileAttributes.Directory);
					return text;
				}
				return text;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060002C4 RID: 708 RVA: 0x00020DD4 File Offset: 0x0001EFD4
		public static string functionsfolder
		{
			get
			{
				string text = Path.GetTempPath() + "winsys\\functions";
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text).Attributes = (FileAttributes.Hidden | FileAttributes.Directory);
					return text;
				}
				return text;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060002C5 RID: 709 RVA: 0x00020E0C File Offset: 0x0001F00C
		public static string screenfolder
		{
			get
			{
				string text = Path.GetTempPath() + "winsys\\Scrl";
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text).Attributes = (FileAttributes.Hidden | FileAttributes.Directory);
					return text;
				}
				return text;
			}
		}
	}
}
