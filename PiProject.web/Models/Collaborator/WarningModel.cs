using PiProject.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PiProject.web.Models.Collaborator
{
	public class WarningModel
	{
		public int WId { get; set; }
		public string Reason { get; set; }
		
		public string Content { get; set; }
		public int is_Confirmed { get; set; }
		public CollaboratorModel collabAffected { get; set; }

		public Gravity gravity { get; set; }
	}
}