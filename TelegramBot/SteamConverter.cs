using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace TelegramBot
{
	// Token: 0x020000F2 RID: 242
	public class SteamConverter
	{
		// Token: 0x06000336 RID: 822 RVA: 0x00003292 File Offset: 0x00001492
		public static long FromSteam2ToSteam64(string accountId)
		{
			if (Regex.IsMatch(accountId, "^STEAM_0:[0-1]:([0-9]{1,10})$"))
			{
				return SteamConverter.Num64 + Convert.ToInt64(accountId.Substring(10)) * 2L + Convert.ToInt64(accountId.Substring(8, 1));
			}
			return (long)SteamConverter.Number0;
		}

		// Token: 0x06000337 RID: 823 RVA: 0x000032CC File Offset: 0x000014CC
		public static long FromSteam32ToSteam64(long steam32)
		{
			if (steam32 >= 1L && Regex.IsMatch("U:1:" + steam32.ToString(CultureInfo.InvariantCulture), "^U:1:([0-9]{1,10})$"))
			{
				return steam32 + SteamConverter.Num64;
			}
			return (long)SteamConverter.Number0;
		}

		// Token: 0x06000338 RID: 824 RVA: 0x00003303 File Offset: 0x00001503
		public static long FromSteam64ToSteam32(long communityId)
		{
			if (communityId >= SteamConverter.Num32 && Regex.IsMatch(communityId.ToString(CultureInfo.InvariantCulture), "^7656119([0-9]{10})$"))
			{
				return communityId - SteamConverter.Num64;
			}
			return (long)SteamConverter.Number0;
		}

		// Token: 0x06000339 RID: 825 RVA: 0x000262C8 File Offset: 0x000244C8
		public static string FromSteam64ToSteam2(long communityId)
		{
			if (communityId < SteamConverter.Num32 || !Regex.IsMatch(communityId.ToString(CultureInfo.InvariantCulture), "^7656119([0-9]{10})$"))
			{
				return string.Empty;
			}
			communityId -= SteamConverter.Num64;
			communityId -= communityId % 2L;
			string text = string.Format("{0}{1}:{2}", "STEAM_0:", communityId % 2L, communityId / 2L);
			if (Regex.IsMatch(text, "^STEAM_0:[0-1]:([0-9]{1,10})$"))
			{
				return text;
			}
			return string.Empty;
		}

		// Token: 0x0400055F RID: 1375
		public const string STEAM2 = "^STEAM_0:[0-1]:([0-9]{1,10})$";

		// Token: 0x04000560 RID: 1376
		public const string STEAM32 = "^U:1:([0-9]{1,10})$";

		// Token: 0x04000561 RID: 1377
		public const string STEAM64 = "^7656119([0-9]{10})$";

		// Token: 0x04000562 RID: 1378
		public const string STEAMPREFIX = "U:1:";

		// Token: 0x04000563 RID: 1379
		public const string STEAMPREFIX2 = "STEAM_0:";

		// Token: 0x04000564 RID: 1380
		public const string HTTPS = "https://steamcommunity.com/profiles/";

		// Token: 0x04000565 RID: 1381
		private static readonly long Num64 = 76561197960265728L;

		// Token: 0x04000566 RID: 1382
		private static readonly long Num32 = 76561197960265729L;

		// Token: 0x04000567 RID: 1383
		private static readonly int Number0 = 0;
	}
}
