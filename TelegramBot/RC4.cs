using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelegramBot
{
	// Token: 0x02000014 RID: 20
	public static class RC4
	{
		// Token: 0x06000053 RID: 83 RVA: 0x00004DF0 File Offset: 0x00002FF0
		public static string Encrypt(string data, string key)
		{
			Encoding unicode = Encoding.Unicode;
			return Convert.ToBase64String(RC4.Encrypt(unicode.GetBytes(key), unicode.GetBytes(data)));
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002455 File Offset: 0x00000655
		public static string Decrypt(string data, string key)
		{
			Encoding unicode = Encoding.Unicode;
			return unicode.GetString(RC4.Encrypt(unicode.GetBytes(key), Convert.FromBase64String(data)));
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00002473 File Offset: 0x00000673
		public static byte[] Encrypt(byte[] key, byte[] data)
		{
			return RC4.EncryptOutput(key, data).ToArray<byte>();
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00002473 File Offset: 0x00000673
		public static byte[] Decrypt(byte[] key, byte[] data)
		{
			return RC4.EncryptOutput(key, data).ToArray<byte>();
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00004E1C File Offset: 0x0000301C
		private static byte[] EncryptInitalize(byte[] key)
		{
			byte[] array = (from i in Enumerable.Range(0, 256)
			select (byte)i).ToArray<byte>();
			int j = 0;
			int num = 0;
			while (j < 256)
			{
				num = (num + (int)key[j % key.Length] + (int)array[j] & 255);
				RC4.Swap(array, j, num);
				j++;
			}
			return array;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00004E90 File Offset: 0x00003090
		private static IEnumerable<byte> EncryptOutput(byte[] key, IEnumerable<byte> data)
		{
			byte[] s = RC4.EncryptInitalize(key);
			int i = 0;
			int j = 0;
			return data.Select(delegate(byte b)
			{
				i = (i + 1 & 255);
				j = (j + (int)s[i] & 255);
				RC4.Swap(s, i, j);
				return b ^ s[(int)(s[i] + s[j] & byte.MaxValue)];
			});
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00004ED0 File Offset: 0x000030D0
		private static void Swap(byte[] s, int i, int j)
		{
			byte b = s[i];
			s[i] = s[j];
			s[j] = b;
		}
	}
}
