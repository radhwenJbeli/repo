
using PiProject.data;
using PiProject.domain.serviceEntities;
using PiProject.domain.utilities;
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

		private static PiContext _context;
		private static CollaboratorService _sr ;

		static AnswerWebService()
		{
			 _sr = new CollaboratorService();

		}
		public AnswerWebService()
		{
			
			init();
			
			
			_context.Database.Initialize(force: false);
		}
		public static void init()
		{
			
			_context = new PiContext();
		}

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

			//set the test answered state to true whenever it's answered 
			SetEvaluationAffectationStateToAnswered(idCollaborator, idEvaluationTest);

			

		}

		public void RecalculateGlobalNote(List<t_collaborator> list)
		{
			//get the list from database 
			List<t_collaborator> TargetList = new List<t_collaborator>();
			t_collaborator target; 
			foreach(t_collaborator collab in list)
			{
				target = _context.t_collaborator.Where(c => c.C_ID == collab.C_ID).FirstOrDefault();
				TargetList.Add(target);
			}

			//caluculate global Note
			foreach(t_collaborator c in TargetList)
			{

				float note360 = c.t_performancenote.ElementAt(0).global360Note;
				
				float noteAuto = c.t_performancenote.ElementAt(0).gloabalAutoNote;

				float AllNote = note360 * GlobalNoteCoefficients.GetCoeff360() + noteAuto * GlobalNoteCoefficients.GetCoeffAuto();
				float globalNoteCaluculated = AllNote / GlobalNoteCoefficients.GetAllCoeff();

				c.t_performancenote.ElementAt(0).globalPerformance = globalNoteCaluculated;
				_context.SaveChanges();
			}


			//recalculate rank
			RecalculateRank();
		}

		public void AddFeedbackToAnswer( Feedback360 feedback)
		{
			
			
			
			

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

		public String SetEvaluationAffectationStateToAnswered(int idCollaborator , int idEvaluationTest )
		{
			AnswerAffectation r = new AnswerAffectation();
			r.idCollaborator = idCollaborator;
			r.idEvaluationTest = idEvaluationTest;
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("http://localhost:8080/PiProject-web/");
			var response = client.PutAsJsonAsync<AnswerAffectation>("api/answer", r).ContinueWith((posttrack) => posttrack.Result.EnsureSuccessStatusCode()).Result;
			if (response.IsSuccessStatusCode)
			{
				return " update successefully";
			}
			else
				return "update not succesfully";
		}


		public void RecalculateRank()
		{
			// rank 360 ascendant
			List<t_performancenote> list = _context.t_performancenote.OrderByDescending(p => p.global360Note).ToList();
			int i = 1;
			foreach(t_performancenote p in list)
			{
				p.rank.Ranking360 = i;
				i++;
			}
			_context.SaveChanges();

			//rank auto ascendant
			List<t_performancenote> list1 = _context.t_performancenote.OrderByDescending(p => p.gloabalAutoNote).ToList();

			i = 1; 
				foreach (t_performancenote p in list1)
			{
				p.rank.RankingAuto = i;
				i++;
			}
			


			//rank global 
			List<t_performancenote> list2 = _context.t_performancenote.OrderByDescending(p => p.globalPerformance).ToList();
			i = 1;
			foreach (t_performancenote p in list2)
			{
				p.rank.globalRanking = i;
				i++;
			}
			_context.SaveChanges();

		}
	}
}
