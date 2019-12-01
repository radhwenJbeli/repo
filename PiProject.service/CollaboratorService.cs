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
		private static AnswerWebService _wb;
		private static PiServices _pi;
		public  CollaboratorService()
		{
			init();
			_context.Database.Initialize(force: false);
		}
		public static void init()
		{
			_context = new PiContext();
			_wb = new AnswerWebService();
			_pi = new PiServices();
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
			//IEnumerable<t_evaluationguestaffectation> affecatations = collaborator.t_evaluationguestaffectation;

			IEnumerable<t_evaluationguestaffectation> affecatations = GetAllAff(collaborator.C_ID);
			List<t_evaluationtest> tests = new List<t_evaluationtest>();

			if (type.Equals("Auto"))
			{

				foreach (t_evaluationguestaffectation aff in affecatations)
				{
					if (aff.t_evaluationtest.ET_Type.Equals("AutoEvaluation") && aff.isAnswered==false)
					{
						tests.Add(aff.t_evaluationtest);
					}
				}
			}

			IEnumerable<t_evaluationguestaffectation> invitations = GetAllAff(collaborator.C_ID);
			
			if (type.Equals("360"))
			{

				foreach (t_evaluationguestaffectation aff in invitations)
				{
					if (aff.t_evaluationtest.ET_Type.Equals("PersonalEvaluation") && aff.isAnswered == false)
					{
						tests.Add(aff.t_evaluationtest);
					}
				}
			}

			return tests; 


		}

		public List<t_collaborator> GetTargetList(int idTest)
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("http://localhost:8080/PiProject-web/");
			client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
			HttpResponseMessage response = client.GetAsync("api/answer/"+idTest).Result;
			if (response.IsSuccessStatusCode)
			{
				Task<List<CollaboratorSr>> t = response.Content.ReadAsAsync<List<CollaboratorSr>>();
				List<CollaboratorSr> returnList = t.Result;
				List<t_collaborator> targetList = new List<t_collaborator>();
				t_collaborator collab;
				foreach (CollaboratorSr co in returnList)
				{
					//get the collaborator from the database
					 collab=   _pi.GetCollaborator(co.C_ID);
				//	t_collaborator collab = _context.t_collaborator.Where(c => c.C_ID == co.C_ID).FirstOrDefault();
					targetList.Add(collab);
				}
				var x = targetList.Count;

				//il manque les associations

				return targetList;
			}

			
			else
			{
				return null;
			}
			
		}

		public List<t_evaluationguestaffectation> GetAllAff(int idCollaborator)
		{
			List<t_evaluationguestaffectation> list = new List<t_evaluationguestaffectation>();
			t_collaborator c = _context.t_collaborator.Where<t_collaborator>(c0 => c0.C_ID == idCollaborator).FirstOrDefault();
			list = c.t_evaluationguestaffectation.ToList<t_evaluationguestaffectation>();
			return list; 
		}


		public void  IncrementBadFeedbackCountForCollaborator(int idcollab)
		{
			t_collaborator c0 = _context.t_collaborator.Where(c1 => c1.C_ID == idcollab).FirstOrDefault();
			c0.t_performancenote.ElementAt(0).NbreBadFeedbacks = c0.t_performancenote.ElementAt(0).NbreBadFeedbacks + 1;
			_context.SaveChanges();
			
		}




	}
}
