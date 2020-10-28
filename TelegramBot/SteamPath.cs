using System;
using Microsoft.Win32;

namespace TelegramBot
{
	// Token: 0x020000F3 RID: 243
	public class SteamPath
	{
		// Token: 0x0600033C RID: 828 RVA: 0x00026344 File Offset: 0x00024544
		public static string GetLocationSteam(string Inst = "InstallPath", string Source = "SourceModInstallPath")
		{
			string result;
			using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32))
			{
				using (RegistryKey registryKey2 = registryKey.OpenSubKey(SteamPath.SteamPath_x64, Environment.Is64BitOperatingSystem ? SteamPath.True : SteamPath.False))
				{
					using (RegistryKey registryKey3 = registryKey.OpenSubKey(SteamPath.SteamPath_x32, Environment.Is64BitOperatingSystem ? SteamPath.True : SteamPath.False))
					{
						object obj;
						if (registryKey2 == null)
						{
							obj = null;
						}
						else
						{
							object value = registryKey2.GetValue(Inst);
							obj = ((value != null) ? value.ToString() : null);
						}
						object obj2;
						if ((obj2 = obj) == null)
						{
							if (registryKey3 == null)
							{
								obj2 = null;
							}
							else
							{
								object value2 = registryKey3.GetValue(Source);
								obj2 = ((value2 != null) ? value2.ToString() : null);
							}
						}
						result = obj2;
					}
				}
			}
			return result;
		}

		// Token: 0x04000568 RID: 1384
		private static readonly string SteamPath_x64 = "SOFTWARE\\Wow6432Node\\Valve\\Steam";

		// Token: 0x04000569 RID: 1385
		private static readonly string SteamPath_x32 = "Software\\Valve\\Steam";

		// Token: 0x0400056A RID: 1386
		private static readonly bool True = true;

		// Token: 0x0400056B RID: 1387
		private static readonly bool False = false;
	}
}
