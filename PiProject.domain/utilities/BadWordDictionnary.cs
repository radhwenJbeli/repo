using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiProject.domain.utilities
{
	public static class BadWordDictionnary
	{

		private static List<String> BadWords;



		public static List<String> GetDictionnary()
		{
			BadWords = new List<string>();
			BadWords.Add("bad");
			BadWords.Add("mauvais");
			BadWords.Add("méchant");
			return BadWords;
		}
	}
}
