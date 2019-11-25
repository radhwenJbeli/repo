using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PiProject.web.Models
{
	public class RenderTestList
	{
		public IEnumerable<TestToRender> TestsList { get; set; }
	}
}