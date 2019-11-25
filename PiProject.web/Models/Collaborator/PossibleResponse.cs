using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PiProject.web.Models
{
	public class PossibleResponse
	{
		public int ID { get; set; }
		public string Content { get; set; }
		public string Description { get; set; }

		public int? Score { get; set; }

		
	}
}