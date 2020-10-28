using System;
using System.IO.Compression;
using System.Threading.Tasks;

namespace TelegramBot.Session
{
	// Token: 0x020000F9 RID: 249
	internal class Archive
	{
		// Token: 0x06000356 RID: 854 RVA: 0x000269A8 File Offset: 0x00024BA8
		public static async Task Zip(string zipname, string foldername)
		{
			try
			{
				ZipFile.CreateFromDirectory(foldername, zipname);
			}
			catch
			{
			}
		}
	}
}
