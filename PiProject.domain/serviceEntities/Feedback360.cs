using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiProject.domain.serviceEntities
{
	public class Feedback360
	{
		public int idCollaboratorAffectedTo { get; set; }
		public int idEvaluationTestAffectedTo { get; set; }
		public string content { get; set; }
		public Boolean isBad { get; set; }
	}
}
