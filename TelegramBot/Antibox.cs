using System;
using System.Diagnostics;
using System.Management;
using System.Windows.Forms;

namespace TelegramBot
{
	// Token: 0x02000005 RID: 5
	internal class Antibox
	{
		// Token: 0x06000010 RID: 16 RVA: 0x00003624 File Offset: 0x00001824
		private static bool GetDetectVirtualMachine()
		{
			using (ManagementObjectCollection managementObjectCollection = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem").Get())
			{
				foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
				{
					try
					{
						string text = managementBaseObject["Manufacturer"].ToString().ToLower();
						bool flag = managementBaseObject["Model"].ToString().ToUpperInvariant().Contains("VIRTUAL");
						if ((text.Equals("microsoft corporation") && flag) || text.Contains("vmware") || managementBaseObject["Model"].ToString().Equals("VirtualBox"))
						{
							return true;
						}
					}
					catch (ArgumentNullException)
					{
						return false;
					}
				}
			}
			return false;
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000011 RID: 17 RVA: 0x0000216C File Offset: 0x0000036C
		private static bool IsRdpAvailable
		{
			get
			{
				return SystemInformation.TerminalServerSession;
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00003720 File Offset: 0x00001920
		private static bool SBieDLL()
		{
			return Process.GetProcessesByName("wsnm").Length != 0 || DLLImport.GetModuleHandle("SbieDll.dll").ToInt32() != 0;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002178 File Offset: 0x00000378
		public static bool GetCheckVMBot()
		{
			return Antibox.SBieDLL() || Antibox.IsRdpAvailable || Antibox.GetDetectVirtualMachine();
		}
	}
}
