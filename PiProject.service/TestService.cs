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
