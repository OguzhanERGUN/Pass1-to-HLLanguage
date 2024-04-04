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
		private string label;
		private string opcode;
		private string operand;

		public string Label
		{
			get { return label; }
			set { label = value; }
		}

		public string Opcode
		{
			get { return opcode; }
			set { opcode = value; }
		}

		public string Operand
		{
			get { return operand; }
			set { operand = value; }
		}

		public CodeLine(string label, string opcode, string operand)
		{
			if (label != null)
			{
				Label = label;
			}
			else
			{
				Label = "";
			}
			if (opcode != null)
			{
				Opcode = opcode;
			}
			else
			{
				opcode = "";
			}
			if (operand != null)
			{
				Operand = operand;

			}
			else
			{
				Operand = "";
			}
		}
	}

}
