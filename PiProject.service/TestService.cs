using PiProject.data;
using PiProject.domain.entities;
using PiProject.domain.serviceEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PiProject.service
{
	public class TestService
	{
		private PiContext _picontext;
		public TestService()
		{
			_picontext = new PiContext();
			_picontext.Database.Initialize(force: false);
		}



		public void TestRelation()
		{
				t_collaborator collab = _picontext.t_collaborator
										.Include("superViser")
										.Include("t_answertestaffectation")
										.Include("t_answertestaffectation.t_feedback")
										.Include("superViser.t_collaborator")
										.Include("notifacations")
										.Include("notifacations.Relatedwarning")
									
										.Include("warnings")

										.Where<t_collaborator>(c => c.C_ID == 13)
										.FirstOrDefault();
		ICollection	<t_performancenote> notes = collab.t_performancenote
												
				
												.ToList();

			//obligatoire
			foreach(t_performancenote note in notes)
			{
				var e = note.rank;
			}
			//
			ICollection<Warning> warnings = collab.warnings.ToList();
			ICollection<t_notif> notif = collab.notifacations.ToList();

		
			
			 //ICollection<Warning> e = _picontext.t_warning.ToList<Warning>();

		/*	ICollection<t_performancenote> t = _picontext.t_performancenote
											.Include("t_collaborator")
										.ToList<t_performancenote>();
		*/	
		}

		public TestWrapper addTestAnswerAff()
		{
			/*t_answertestaffectation answeraff = new t_answertestaffectation();
		answeraff.idCollaborator = 15;
		answeraff.idEvaluationTest = 13;
		*/
			TestWrapper table = new TestWrapper();
			table.idCollaborator = 1; 

			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("http://localhost:8080/PiProject-web/");
			//client.PostAsJsonAsync("api/answer/15/13",answeraff);

			//client.PostAsJsonAsync<t_answertestaffectation>("api/answer/15/13", answeraff).ContinueWith((posttrack) => posttrack.Result.EnsureSuccessStatusCode());
			var res = client.PostAsJsonAsync<TestWrapper>("api/answer/15/13", table).ContinueWith((posttrack) => posttrack.Result.EnsureSuccessStatusCode()).Result;
			Task<TestWrapper> t = res.Content.ReadAsAsync<TestWrapper>();
			TestWrapper var = t.Result;



			return var; 

		}


		public void addAnswer(int idCollaborator , int idEvaluationTest, int idQuestion , int idResponse)
		{
			AnswerObject answer = new AnswerObject();
			answer.idCollaborator = idCollaborator;
			answer.idEvaluationTest = idEvaluationTest;
			answer.idQuestion = idQuestion;
			answer.idResponse = idResponse; 


			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("http://localhost:8080/PiProject-web/");
			//client.PostAsJsonAsync("api/answer/15/13",answeraff);

			//client.PostAsJsonAsync<t_answertestaffectation>("api/answer/15/13", answeraff).ContinueWith((posttrack) => posttrack.Result.EnsureSuccessStatusCode());
			var res = client.PostAsJsonAsync<AnswerObject>("api/answer/", answer).ContinueWith((posttrack) => posttrack.Result.EnsureSuccessStatusCode()).Result;
			/*Task<TestWrapper> t = res.Content.ReadAsAsync<TestWrapper>();
			TestWrapper var = t.Result;*/

		}


	}
}
