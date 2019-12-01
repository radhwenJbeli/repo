using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PiProject.web.Models.Collaborator
{
	public class Feedback
	{
		public string content { get; set; }
		public string title { get; set; }
		public Boolean isBad { get; set; }
	}
}