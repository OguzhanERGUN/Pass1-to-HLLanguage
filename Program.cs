using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pass1Algorithm
{
	internal class Program
	{
		//Label ve locctr içerir
		public static Dictionary<string, int> symtab = new Dictionary<string, int>();
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
		static bool founded;

		//Kod satırları burada tutulur.
		public static List<CodeLine> lines;
		static void Main(string[] args)
		{
			lines = new List<CodeLine>();
			StreamReader sr = new StreamReader("D:\\C#Console\\Pass1Algorithm\\CodeTXT\\source_code.txt");
			string txtline = "";


			while (txtline != null)
			{
				txtline = sr.ReadLine();
				string txtlabel = txtline.Substring(0, 9);
				string txtopcode = txtline.Substring(9, 6);
				string txtoperand = txtline.Substring(16, txtline.Length - 16);
				CodeLine codeLine = new CodeLine(txtlabel, txtopcode, txtoperand);
				lines.Add(codeLine);

			}

			foreach (CodeLine line in lines)
			{
				Console.WriteLine(line.Opcode);
			}
			Console.ReadLine();
			int locctr;

			if (lines[0].Opcode == "START")
			{
				locctr = int.Parse(lines[0].Operand);
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

					else
					{
						symtab.Add(line.Label, locctr);
					}
				}

				for (int i = 0; i < Optab.Length; i++)
				{
					if (Optab[i] == line.Opcode)
					{
						locctr += 3;
						founded = true;
						break;
					}
				}


				if (!founded)
				{
					switch (line.Opcode)
					{
						case "WORD":
							locctr += 3;
							break;

						case "RESW":
							locctr = locctr + (3 * int.Parse(line.Opcode));
							break;

						case "RESB":
							locctr += int.Parse(line.Opcode);
							break;
						case "BYTE":
							break;
					}
				}

			}



			Console.ReadKey();

		}



	}

}
