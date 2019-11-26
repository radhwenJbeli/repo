using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiProject.data;
using System.Net.Http;
using System.Net.Http.Headers;
using PiProject.domain.serviceEntities;

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


	
		

		//!!!!!!!!! il manque les include des associations du manager, developper , criteria, response , affectations ....

		public t_collaborator VerfyCredentials(string email , string password)
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("http://localhost:8080/PiProject-web/");
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			HttpResponseMessage response = client.GetAsync("api/login/" + email + "/" + password).Result;
			if (response.IsSuccessStatusCode)
			{
				CollaboratorSr res = response.Content.ReadAsAsync<CollaboratorSr>().Result;
				t_collaborator logger;
				//check if manager or developper
				if (res.is_Manager)
				{
					logger = _context.t_collaborator
						//.Include("t_manager")
						//.Include("t_manager.t_evaluationtest")
						.FirstOrDefault(m => m.C_ID == res.C_ID);
					return logger;
					
				}
				if (res.is_Developper)
				{
					 
					 logger = _context.t_collaborator.Include("t_developper")
						//	.Include("t_evaluationtargetaffectation")
						//	.Include("t_evaluationtargetaffectation.t_evaluationtest")
						//	.Include("t_evaluationtargetaffectation.t_evaluationtest.t_criteria")
						//	.Include("t_evaluationtargetaffectation.t_evaluationtest.t_criteria.t_possibleresponse")

						//	.Include("t_evaluationguestaffectation")
						//	.Include("t_evaluationguestaffectation.t_evaluationtest")
						//	.Include("t_evaluationguestaffectation.t_evaluationtest.t_criteria")
						//	.Include("t_evaluationguestaffectation.t_evaluationtest.t_criteria.t_possibleresponse")

						//	.Include("t_performancenote")
							.FirstOrDefault(d => d.C_ID == res.C_ID);
					return logger;
					
				}

				return null;
			}
			return null; 
			
		}


		public IEnumerable<t_evaluationtest> DisplayTests(t_collaborator collaborator , string type)
		{
		/*	t_collaborator collab = _context.t_collaborator
							.Include("t_evaluationtargetaffectation")
							.Include("t_evaluationtargetaffectation.t_evaluationtest")
							.Include("t_evaluationtargetaffectation.t_evaluationtest.t_criteria")
							.Include("t_evaluationtargetaffectation.t_evaluationtest.t_criteria.t_possibleresponse")
							.Where<t_collaborator>(c => c.C_ID == idcollaborator).FirstOrDefault();
*/
			IEnumerable<t_evaluationguestaffectation> affecatations = collaborator.t_evaluationguestaffectation;

			List<t_evaluationtest> tests = new List<t_evaluationtest>();

			if (type.Equals("Auto"))
			{

				foreach (t_evaluationguestaffectation aff in affecatations)
				{
					if (aff.t_evaluationtest.ET_Type.Equals("AutoEvaluation"))
					{
						tests.Add(aff.t_evaluationtest);
					}
				}
			}

			IEnumerable<t_evaluationguestaffectation> invitations = collaborator.t_evaluationguestaffectation; 
			if (type.Equals("360"))
			{

				foreach (t_evaluationguestaffectation aff in invitations)
				{
					if (aff.t_evaluationtest.ET_Type.Equals("PersonalEvaluation"))
					{
						tests.Add(aff.t_evaluationtest);
					}
				}
			}

			return tests; 


		}







	}
}
