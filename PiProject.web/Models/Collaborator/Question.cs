using PiProject.data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace PiProject.web.Models.Collaborator
{
	public class Question 
	{
		public int ID { get; set; }

		public int? coefficient { get; set; }
		public string Content { get; set; }
		public string Description { get; set; }
		public virtual ICollection<PossibleResponse> PossibleResponses { get; set; }

		
		[Required]
		public int chosenRep { get; set; }
	}
}