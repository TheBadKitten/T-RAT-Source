using System;
using System.Linq;
using Telegram.Bot.Types;

namespace TelegramBot
{
	// Token: 0x020000D9 RID: 217
	internal class FirstParser
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x060002A5 RID: 677 RVA: 0x00002F45 File Offset: 0x00001145
		// (set) Token: 0x060002A6 RID: 678 RVA: 0x00002F4D File Offset: 0x0000114D
		public string Command { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x060002A7 RID: 679 RVA: 0x00002F56 File Offset: 0x00001156
		// (set) Token: 0x060002A8 RID: 680 RVA: 0x00002F5E File Offset: 0x0000115E
		public string Example { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x060002A9 RID: 681 RVA: 0x00002F67 File Offset: 0x00001167
		// (set) Token: 0x060002AA RID: 682 RVA: 0x00002F6F File Offset: 0x0000116F
		public Action<FirstModel, Update> Execute { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x060002AB RID: 683 RVA: 0x00002F78 File Offset: 0x00001178
		// (set) Token: 0x060002AC RID: 684 RVA: 0x00002F80 File Offset: 0x00001180
		public Action<FirstModel, Update> OnError { get; set; }

		// Token: 0x060002AD RID: 685 RVA: 0x00020CE0 File Offset: 0x0001EEE0
		public static FirstModel Parse(string text)
		{
			if (text.StartsWith("/"))
			{
				string[] array = text.Split(new char[]
				{
					' '
				});
				string command = (array != null) ? array.FirstOrDefault<string>() : null;
				string[] args = array.Skip(1).Take(array.Count<string>()).ToArray<string>();
				return new FirstModel
				{
					Command = command,
					Args = args
				};
			}
			return null;
		}

		// Token: 0x04000507 RID: 1287
		public int CountArgs;
	}
}
