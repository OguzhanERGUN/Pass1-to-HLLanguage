using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Pass1Algorithm
{
	public class CodeLine
	{
        public string Label { get { return Label; } set {}}
		public int? Locctr { get { return Locctr; } set { } }
        public string Opcode { get { return Opcode; } set { } }


		public CodeLine(string label, int locctr, string opcode)
        {
			Label = label;
			Locctr = locctr;
			Opcode = opcode;
		}

		public CodeLine(string label, string opcode)
		{
			Label = label;
			Locctr = null;
			Opcode = opcode;
		}

		public CodeLine(string opcode)
        {
			Label = "";
			Locctr = null;
			Opcode = opcode;
		}


    }

}
