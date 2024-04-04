using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pass1Algorithm
{
	internal class Program
	{
		//Label ve locctr içerir
		private static Dictionary<string, string> symtab = new Dictionary<string, string>();
		static string[] Optab = {
	"ADD",
	"ADDF",
	"ADDR",
	"AND",
	"CLEAR",
	"COMP",
	"COMPF",
	"COMPR",
	"DIV",
	"DIVF",
	"DIVR",
	"FIX",
	"FLOAT",
	"HIO",
	"J",
	"JEQ",
	"JGT",
	"JLT",
	"JSUB",
	"LDA",
	"LDB",
	"LDCH",
	"LDF",
	"LDL",
	"LDS",
	"LDT",
	"LDX",
	"LPS",
	"MUL",
	"MULF",
	"MULR",
	"NORM",
	"OR",
	"RD",
	"RMO",
	"RSUB",
	"SHIFTL",
	"SHIFTR",
	"SIO",
	"SSK",
	"STA",
	"STB",
	"STCH",
	"STF",
	"STI",
	"STL",
	"STS",
	"STSW",
	"STT",
	"STX",
	"SUB",
	"SUBF",
	"SUBR",
	"SVC",
	"TD",
	"TIO",
	"TIX",
	"TIXR",
	"WD"
};

		//Kod satırları burada tutulur.
		public static List<CodeLine> lines;

		static void Main(string[] args)
		{
			int locctr;
			lines = ExampleCodeGenerator.CreateExampleCodeLines();

			if (lines[0].Opcode == "START")
			{
				if (lines[0].Locctr == null)
				{
					Console.WriteLine("Start ile başlamak için loctr adresi " +
						"vermeniz gerekir lütfen kodu inceleyin veya Start direktifini değiştirin. başlangıç adresi 0 olarak devam edecektir...");
					Console.ReadKey();
					locctr = 0;
				}
				else
				{
					locctr = (int)lines[0].Locctr;
				}
			}
			else
			{
				locctr = 0;
			}
			foreach (CodeLine line in lines)
			{
				if (line.Opcode == "END")
				{
					break;
				}

				if (line.Label == ".")
				{
					continue;
				}

				if (line.Label != "")
				{
					if (symtab.ContainsKey(line.Label))
					{
						throw new Exception("Aynı sembol iki defa kullanılamaz...");
					}
				}

			}



			Console.ReadKey();

		}



	}

	public static class ExampleCodeGenerator
	{
		public static List<CodeLine> CreateExampleCodeLines()
		{
			List<CodeLine> exampleCode = new List<CodeLine>();
			// Örnek kod satırlarını oluştur ve ekle
			exampleCode.Add(new CodeLine("COPY", 1000, "START"));
			exampleCode.Add(new CodeLine("FIRST", "STL"));
			exampleCode.Add(new CodeLine("CLOOP", "JSUB"));
			exampleCode.Add(new CodeLine("LDA"));
			exampleCode.Add(new CodeLine("COMP"));
			exampleCode.Add(new CodeLine("JEQ"));
			exampleCode.Add(new CodeLine("JSUB"));
			exampleCode.Add(new CodeLine("J"));
			exampleCode.Add(new CodeLine("ENDFILL", "LDA"));
			exampleCode.Add(new CodeLine("STA"));



			return exampleCode;
		}
	}

}
