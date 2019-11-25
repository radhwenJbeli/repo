using PiProject.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PiProject.web.Models
{
	public class TestToRender
	{
		public int ID { get; set; }
		public string Description { get; set; }
		public string Type { get; set; }
		public string tType { get; set; }
		public float globaloNoteSoFar { get; set; }
		public virtual ICollection<Question> questions { get; set; }
	}
}