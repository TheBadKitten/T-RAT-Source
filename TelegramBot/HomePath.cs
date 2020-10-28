using System;
using System.IO;

namespace TelegramBot
{
	// Token: 0x020000E4 RID: 228
	public class HomePath
	{
		// Token: 0x0400051C RID: 1308
		public static readonly string DefaultPath = Environment.GetEnvironmentVariable("Temp");

		// Token: 0x0400051D RID: 1309
		public static readonly string User_Name = Path.Combine(HomePath.DefaultPath, Environment.UserName);
	}
}
