

using PiProject.data;
using PiProject.domain.serviceEntities;
using PiProject.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PiProject.console
{
	public class Program
	{
		static void Main(string[] args)
		{
			/*	TestService ser = new TestService();
				TestWrapper testVar = ser.addTestAnswerAff();
				Console.WriteLine(testVar.idCollaborator);
				Console.ReadLine();

			*/

			/*CollaboratorService sr = new CollaboratorService();
			sr.VerfyCredentials("zz", "zz");
		*/

			// 1 ) test service add testanswer affectation

			/*	AnswerAffectation r = new AnswerAffectation();
				r.idCollaborator = 15;
				r.idEvaluationTest = 13;

				HttpClient client = new HttpClient();
				client.BaseAddress = new Uri("http://localhost:8080/PiProject-web/");

				var res = client.PostAsJsonAsync<AnswerAffectation>("api/answer/AddAnswerAff", r).ContinueWith((posttrack) => posttrack.Result.EnsureSuccessStatusCode()).Result;

				var resy = res.Content;
	*/
			// 2) test service add answers to the affectation 
			/*	AnswerObject answer = new AnswerObject();
				answer.idCollaborator = 15;
				answer.idEvaluationTest = 13;
				answer.idQuestion = 2;
				answer.idResponse = 3;

				HttpClient client = new HttpClient();
				client.BaseAddress = new Uri("http://localhost:8080/PiProject-web/");

				var res = client.PostAsJsonAsync<AnswerObject>("api/answer/AddAnswer",answer ).ContinueWith((posttrack) => posttrack.Result.EnsureSuccessStatusCode()).Result;
				var resy = res.Content;
	*/

			// 3 ) add feedback

			/*Feedback360 feedback = new Feedback360();
			feedback.idCollaboratorAffectedTo = 15;
			feedback.idEvaluationTestAffectedTo = 13;
			feedback.content = "content";

			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("http://localhost:8080/PiProject-web/");

			var res = client.PostAsJsonAsync<Feedback360>("api/answer/AddFeedback", feedback).ContinueWith((posttrack) => posttrack.Result.EnsureSuccessStatusCode()).Result;
			var resy = res.Content;
			*/

			// 3 ) test new relations 
			//TestService t = new TestService();
			//t.TestRelation();


			// ) test feedback 
			/*	List<String> BadWordsDictionnary = new List<string>();
				BadWordsDictionnary.Add("bonne");
				BadWordsDictionnary.Add("chose");

				t_feedback fe = new t_feedback();
				fe.F_content = "crest une bonne chose";
				PiServices ser = new PiServices();
				var res = ser.VerifyNegativityOfFeedback(fe,BadWordsDictionnary);
			*/

			//test SetEvaluationAffectationStateToAnswered web method 
			//AnswerWebService sr = new AnswerWebService();
			//sr.SetEvaluationAffectationStateToAnswered(11, 19);

			/*	HttpClient client = new HttpClient();
				client.BaseAddress = new Uri("http://localhost:8080/PiProject-web/");
				client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
				HttpResponseMessage response = client.GetAsync("api/answer/24").Result;
				if (response.IsSuccessStatusCode)
				{
					Task<List<CollaboratorSr>> t = response.Content.ReadAsAsync<List<CollaboratorSr>>();
					var a = t.Result;
				}
				else
				{

				}

			*/
			//CollaboratorService sr = new CollaboratorService();
			//sr.IncrementBadFeedbackCountForCollaborator(16);

			//AnswerWebService wb = new AnswerWebService();
			//wb.RecalculateRank();
			PiServices sr = new PiServices();
			sr.VerifyRank360(16);

		}
	}
}
