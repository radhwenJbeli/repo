
using PiProject.domain.serviceEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PiProject.service
{
	public class AnswerWebService : IAnswerWebService
	{
		public void AddAnswerToAff(int idCollaborator, int idEvaluationTest, int idQuestion, int idResponse)
		{
			AnswerObject answer = new AnswerObject();
			answer.idCollaborator = idCollaborator;
			answer.idEvaluationTest = idEvaluationTest;
			answer.idQuestion = idQuestion;
			answer.idResponse = idResponse;

			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("http://localhost:8080/PiProject-web/");

			var res = client.PostAsJsonAsync<AnswerObject>("api/answer/AddAnswer", answer).ContinueWith((posttrack) => posttrack.Result.EnsureSuccessStatusCode()).Result;
			var resy = res.Content;

		}

		public void AddFeedbackToAnswer(int idCollaborator, int idEvaluationTest)
		{
			Feedback360 feedback = new Feedback360();
			feedback.idCollaboratorAffectedTo = idCollaborator;
			feedback.idEvaluationTestAffectedTo = idEvaluationTest;
			feedback.content = "content";
			feedback.isBad = true;

			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("http://localhost:8080/PiProject-web/");

			var res = client.PostAsJsonAsync<Feedback360>("api/answer/AddFeedback", feedback).ContinueWith((posttrack) => posttrack.Result.EnsureSuccessStatusCode()).Result;
			var resy = res.Content;
		}

		public void AddTestAnswerAff(int idCollaborator, int idEvaluationTest)
		{
			AnswerAffectation r = new AnswerAffectation();
			r.idCollaborator = idCollaborator;
			r.idEvaluationTest = idEvaluationTest;

			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("http://localhost:8080/PiProject-web/");

			var res = client.PostAsJsonAsync<AnswerAffectation>("api/answer/AddAnswerAff", r).ContinueWith((posttrack) => posttrack.Result.EnsureSuccessStatusCode()).Result;
		}
	}
}
