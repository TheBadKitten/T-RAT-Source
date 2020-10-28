using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace svchost.Properties
{
	// Token: 0x02000003 RID: 3
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	public class Resources
	{
		// Token: 0x06000006 RID: 6 RVA: 0x00002064 File Offset: 0x00000264
		internal Resources()
		{
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000007 RID: 7 RVA: 0x00002082 File Offset: 0x00000282
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("svchost.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000008 RID: 8 RVA: 0x000020AE File Offset: 0x000002AE
		// (set) Token: 0x06000009 RID: 9 RVA: 0x000020B5 File Offset: 0x000002B5
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000A RID: 10 RVA: 0x000020BD File Offset: 0x000002BD
		public static string CFLcode
		{
			get
			{
				return Resources.ResourceManager.GetString("CFLcode", Resources.resourceCulture);
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000B RID: 11 RVA: 0x000020D3 File Offset: 0x000002D3
		public static string Run1
		{
			get
			{
				return Resources.ResourceManager.GetString("Run1", Resources.resourceCulture);
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000C RID: 12 RVA: 0x000020E9 File Offset: 0x000002E9
		public static string Run2
		{
			get
			{
				return Resources.ResourceManager.GetString("Run2", Resources.resourceCulture);
			}
		}

		// Token: 0x04000003 RID: 3
		private static ResourceManager resourceMan;

		// Token: 0x04000004 RID: 4
		private static CultureInfo resourceCulture;
	}
}
