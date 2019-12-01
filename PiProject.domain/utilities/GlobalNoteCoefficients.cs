using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiProject.domain.utilities
{
	public static class GlobalNoteCoefficients
	{
		private  static  int coeff360 = 6;
		private static int coeffAuto = 4;
		private static int AllCoeff;
		
		public static int GetCoeff360()
		{
			return coeff360;
		}

		public static int GetCoeffAuto()
		{
			return coeffAuto;
		}

		public static int GetAllCoeff()
		{
			AllCoeff = coeff360 + coeffAuto;
			return AllCoeff;
		}

	}
}
