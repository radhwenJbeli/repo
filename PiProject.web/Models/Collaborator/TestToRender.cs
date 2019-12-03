using PiProject.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PiProject.web.Models.Collaborator
{
	public class TestToRender
	{
		public int ID { get; set; }
		public string Description { get; set; }
		public string Type { get; set; }
		public string tType { get; set; }
		public float globaloNoteSoFar { get; set; }
		public int NbreQuestions { get; set; }
		public int coefficient { get; set; }
		public int NbreParticipants { get; set; }

		//to use in case 360
		public List<CollaboratorModel> targetList { get; set; }
		public virtual ICollection<Question> questions { get; set; }
	}
}