using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiProject.data;
using System.Net.Http;

namespace PiProject.service
{
	public class CollaboratorService : ICollaboratorService
	{

		private static  PiContext _context;
		public  CollaboratorService()
		{
			init();
			_context.Database.Initialize(force: false);
		}
		public static void init()
		{
			_context = new PiContext();
		}


	
		




		public IEnumerable<t_evaluationtest> DisplayTests(int idcollaborator , string type)
		{
			t_collaborator collab = _context.t_collaborator
							.Include("t_evaluationtargetaffectation")
							.Include("t_evaluationtargetaffectation.t_evaluationtest")
							.Include("t_evaluationtargetaffectation.t_evaluationtest.t_criteria")
							.Include("t_evaluationtargetaffectation.t_evaluationtest.t_criteria.t_possibleresponse")
							.Where<t_collaborator>(c => c.C_ID == idcollaborator).FirstOrDefault();

			IEnumerable<t_evaluationtargetaffectation> affecatations = collab.t_evaluationtargetaffectation;

			List<t_evaluationtest> tests = new List<t_evaluationtest>();

			if (type.Equals("Auto"))
			{

				foreach (t_evaluationtargetaffectation aff in affecatations)
				{
					if (aff.t_evaluationtest.ET_Type.Equals("AutoEvaluation"))
					{
						tests.Add(aff.t_evaluationtest);
					}
				}
			}
			if (type.Equals("360"))
			{

				foreach (t_evaluationtargetaffectation aff in affecatations)
				{
					if (aff.t_evaluationtest.ET_Type.Equals("AutoEvaluation"))
					{
						tests.Add(aff.t_evaluationtest);
					}
				}
			}

			return tests; 


		}







	}
}
