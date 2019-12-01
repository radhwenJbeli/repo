using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PiProject.web.Models.Collaborator
{
	public class CollaboratorModel
	{
		public int C_ID { get; set; }
		public string C_Forname { get; set; }



		public string C_Lastname { get; set; }


		public int? C_Age { get; set; }


		public string C_email { get; set; }
		public ManagerModel superviser { get; set; }

		public string C_password { get; set; }
		public PerformanceModel performance { get; set; }

		public Boolean is_Manager { get; set; }
		public Boolean is_Developper { get; set; }
	}
}