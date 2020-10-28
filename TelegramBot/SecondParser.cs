using System;
using System.Linq;
using Telegram.Bot.Types;

namespace TelegramBot
{
	// Token: 0x020000DC RID: 220
	internal class SecondParser
	{
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x060002B9 RID: 697 RVA: 0x00002FCD File Offset: 0x000011CD
		// (set) Token: 0x060002BA RID: 698 RVA: 0x00002FD5 File Offset: 0x000011D5
		public string Command { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x060002BB RID: 699 RVA: 0x00002FDE File Offset: 0x000011DE
		// (set) Token: 0x060002BC RID: 700 RVA: 0x00002FE6 File Offset: 0x000011E6
		public string Example { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060002BD RID: 701 RVA: 0x00002FEF File Offset: 0x000011EF
		// (set) Token: 0x060002BE RID: 702 RVA: 0x00002FF7 File Offset: 0x000011F7
		public Action<SecondModel, Update> Execute { get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060002BF RID: 703 RVA: 0x00003000 File Offset: 0x00001200
		// (set) Token: 0x060002C0 RID: 704 RVA: 0x00003008 File Offset: 0x00001208
		public Action<SecondModel, Update> OnError { get; set; }

		// Token: 0x060002C1 RID: 705 RVA: 0x00020D48 File Offset: 0x0001EF48
		public static SecondModel Parse(string text)
		{
			string[] array = text.Split(new char[]
			{
				' '
			});
			string text2 = (array != null) ? array.FirstOrDefault<string>() : null;
			string arg = text.Replace(text2 + " ", null);
			return new SecondModel
			{
				Command = text2,
				Arg = arg
			};
		}
	}
}
