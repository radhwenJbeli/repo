using PiProject.data;
using PiProject.domain.serviceEntities;
using PiProject.domain.utilities;
using PiProject.service;
using PiProject.web.Models.Collaborator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PiProject.web.Controllers.collaborator
{
	//collaborator dashboard
    public class CollaboratorController : Controller
    {
		private CollaboratorService _sr;
		private AnswerWebService _an;
		private PiServices _pi;


		//logger 
		private static t_collaborator logger; 

		//data for preparing the questions and responses of a test 
		private static int IndexQuestion = 0;
		private static List<TestToRender> RenderList ;
		
		private static Question question;

		//data to use when persisting the answers 
		private static TestToRender TestToAnswer;
		private static Dictionary<Question, PossibleResponse> mapAnswers;

		public CollaboratorController()
		{
			this._sr = new CollaboratorService();
			this._an = new AnswerWebService();
			this._pi = new PiServices();
		}


        // GET: Collaborator
        public ActionResult Index()
        {
			

            return View();
        }

		public ActionResult Deconnect()
		{
			return RedirectToAction("Index", "Login", null);
		}


		public ActionResult Dashboard()
		{

			Getlogger();

			CollaboratorModel model;
			if (logger.t_developper != null)
			{
				 model = initCollaborator(); 
			}
			else {
				model = initCollaborator();
				//ajouter ici les features du manager 
			}



				//var model = collab;
				return View(model);
		}


		[NonAction]
		public CollaboratorModel initCollaborator()
		{
			CollaboratorModel collab;
			
			
				collab = new DevelopperModel();

				////////////////////superviser//////////////// 
				ManagerModel superviser = new ManagerModel();
				superviser.C_Forname = logger.superViser.t_collaborator.C_Forname;
				superviser.C_Lastname = logger.superViser.t_collaborator.C_Lastname;
				collab.superviser = superviser;
				/////////////////////////////////////////////////////


				collab.C_Age = logger.C_Age;
				collab.C_email = logger.C_email;
				collab.C_Forname = logger.C_Forname;
				collab.C_Lastname = logger.C_Lastname;

				//performance notes //////////////////////
				PerformanceModel perf = new PerformanceModel();
				perf.gloabalAutoNote = logger.t_performancenote.ElementAt(0).gloabalAutoNote;
				perf.global360Note = logger.t_performancenote.ElementAt(0).global360Note;
				perf.globalPerformance = logger.t_performancenote.ElementAt(0).globalPerformance;
				//rankkkkkkkkkkkkkkkk/////////////////
				perf.RankingAuto = logger.t_performancenote.ElementAt(0).rank.RankingAuto;
				perf.Ranking360 = logger.t_performancenote.ElementAt(0).rank.Ranking360;
				perf.globalRanking = logger.t_performancenote.ElementAt(0).rank.globalRanking;

				collab.performance = perf;
				//////////////////////////////////////////////////////
			
			
			return collab;
		}


		public ActionResult DisplayWarnings()
		{
			return View("Warnings"); 
		}
		public ActionResult ConfirmAnswers()
		{
			// verify if a feedback is exisisting  , and if its a bad one 

			// get the answers from the map 

			// get the test the subject of answer 
			// persist in the database 
			_an.AddTestAnswerAff(logger.C_ID, TestToAnswer.ID);
			foreach (var e in mapAnswers)
			{
				_an.AddAnswerToAff(logger.C_ID, TestToAnswer.ID, e.Key.ID, e.Value.ID);
			}





			// get the target of this test 

			//the 360 ,  auto note are calculated in JEE, the global note is calculated in here
			List<t_collaborator> targets = _sr.GetTargetList(TestToAnswer.ID);
			_an.RecalculateGlobalNote(targets);

			// verfiy for possible warnings

			return RedirectToAction("Dashboard", "Collaborator", null);

		}

		public ActionResult ConfirmAnswerWithFeedback(Feedback model)
		{
			var m = model;
			var x = model.isBad;
			_an.AddTestAnswerAff(logger.C_ID, TestToAnswer.ID);
			foreach (var e in mapAnswers)
			{
				_an.AddAnswerToAff(logger.C_ID, TestToAnswer.ID, e.Key.ID, e.Value.ID);
			}


			//the 360 ,  auto note are calculated in JEE, the global note is calculated in here
			List<t_collaborator> targets = _sr.GetTargetList(TestToAnswer.ID);
			_an.RecalculateGlobalNote(targets);


			//add feedback 
			Feedback360 feedback = new Feedback360();
			feedback.content = model.content;
			feedback.isBad = model.isBad;
			feedback.idCollaboratorAffectedTo = logger.C_ID;
			feedback.idEvaluationTestAffectedTo = TestToAnswer.ID;

			_an.AddFeedbackToAnswer(feedback);
			if (feedback.isBad)
			{
				List<t_collaborator> targetList = _sr.GetTargetList(TestToAnswer.ID);
				foreach(t_collaborator collab in targetList)
				{
					_sr.IncrementBadFeedbackCountForCollaborator(collab.C_ID);
				}
			}

			return RedirectToAction("Dashboard", "Collaborator", null);
		}

		[HttpPost]
		public ActionResult AnswerWithFeedback(Feedback model)
		{
			//instanciation d'une instance Feedback360 
			String e = model.content;
			Feedback360 feed = new Feedback360();
			feed.content = e;
			
			List<String> dictionnary = BadWordDictionnary.GetDictionnary();
			var res = _pi.VerifyNegativityOfFeedback(feed, dictionnary);

			if (res)
			{
				model.isBad = true;
				return View("AddFeedback", model);
			}
			else
			{
				return RedirectToAction("ConfirmAnswerWithFeedback", "Collaborator", model);
				//cofirm feedback with asnwers in herer
				//return RedirectToAction("Dashboard", "Collaborator", null);
			}
			//take the content of the feedback here  and store it to get it afterwards in the confirmAnswer action

			
		}

		public ActionResult AddFeedback()
		{
			Feedback feedback = new Feedback();
			feedback.isBad = false;
			Feedback model = feedback;
			return View(model);
		}

		[NonAction]
		public void Getlogger()
		{
			 logger = (t_collaborator)Session["logger"];
		}


		public ActionResult AutoTests()
		{
			IEnumerable<t_evaluationtest> list =  _sr.DisplayTests(logger, "Auto");
			 RenderList = new List<TestToRender>();

			TestToRender render;
			Question question;
			PossibleResponse response;

			foreach( t_evaluationtest test in list)
			{
				render = new TestToRender();
				render.ID = test.ET_ID;
				render.Type = test.ET_Type;
				render.tType = test.Et_tType;
				render.globaloNoteSoFar = test.globaloNoteSoFar;

				render.questions = new List<Question>();

				//add the questions 
				foreach (t_criteria c in test.t_criteria)
				{
					question = new Question();
					question.ID = c.Cr_ID;
					question.coefficient = c.Cr_coefficient;
					question.Content = c.Cr_Content;

					question.PossibleResponses = new List<PossibleResponse>();

					//add the responses of each question
					foreach (t_possibleresponse rep in c.t_possibleresponse)
					{
						

						response = new PossibleResponse();
						response.ID = rep.Pr_ID;
						response.Content = rep.Pr_Content;
						response.Score = rep.Pr_score;

						question.PossibleResponses.Add(response);
					}


					render.questions.Add(question);

				}
				RenderList.Add(render);
			}
			RenderTestList model = new RenderTestList();
			model.TestsList = RenderList; 
			
			return View(model); 
		}


		public ActionResult Tests360()
		{
			IEnumerable<t_evaluationtest> list = _sr.DisplayTests(logger, "360");
			RenderList = new List<TestToRender>();


			TestToRender render;
			Question question;
			PossibleResponse response;

			foreach (t_evaluationtest test in list)
			{
				render = new TestToRender();
				render.ID = test.ET_ID;
				render.Type = test.ET_Type;
				render.tType = test.Et_tType;
				render.globaloNoteSoFar = test.globaloNoteSoFar;

				render.questions = new List<Question>();

				//add the questions 
				foreach (t_criteria c in test.t_criteria)
				{
					question = new Question();
					question.ID = c.Cr_ID;
					question.coefficient = c.Cr_coefficient;
					question.Content = c.Cr_Content;

					question.PossibleResponses = new List<PossibleResponse>();

					//add the responses of each question
					foreach (t_possibleresponse rep in c.t_possibleresponse)
					{


						response = new PossibleResponse();
						response.ID = rep.Pr_ID;
						response.Content = rep.Pr_Content;
						response.Score = rep.Pr_score;

						question.PossibleResponses.Add(response);
					}


					render.questions.Add(question);

				}
				RenderList.Add(render);
			}
			RenderTestList model = new RenderTestList();
			model.TestsList = RenderList;

			return View(model);

			
		}



		public ActionResult AnswerTest( int id )
		{
			//inititalize the index of the questions
			IndexQuestion = 0;
			//get the test chosen
			TestToAnswer = new TestToRender();
			foreach (TestToRender test in RenderList)
			{
				if(test.ID == id)
				{
					TestToAnswer = test;
				}
			}

			//initialize the map answers 
			mapAnswers = new Dictionary<Question, PossibleResponse>();



			//prepare the first question of the test to be rendered to the view 
			//, we use the static indexquestion defined above
			var model = PrepareNextQuestion(IndexQuestion);
			return View(model);
		}




		[HttpGet]
		public ActionResult NextQuestion()
		{
			// get the response 
			var choise = question.chosenRep;

			IndexQuestion++;
			var model = PrepareNextQuestion(IndexQuestion);

			if (model != null)
				return View(model);
			else
			{
				ViewBag.error = "there is no other question";
				return View();
			}
		}

		[HttpPost]
		public ActionResult NextQuestion(FormCollection frm)
		{
			// get the response 
	
			var chosenRep = frm["chosenRep"].ToString();
			PossibleResponse res = new PossibleResponse();
			res.ID = Convert.ToInt32(chosenRep);

			//add the responses to 
			mapAnswers.Add(question, res);


			IndexQuestion++;
			var model = PrepareNextQuestion(IndexQuestion);

			if(model != null)
			return View(model);
			else
			{
				ViewBag.error = "there is no other question";
				ViewData["test"] = TestToAnswer;

				return RedirectToAction("InfosOfAnswers", "Collaborator", null);
				//return View();
			}
		}

		
		public ActionResult AbandonAnswers()
		{
			//initialize variables
			return RedirectToAction("Dashboard", "Collaborator", null);
		}

		[NonAction]
		public Question PrepareNextQuestion(int index)
		{
			while (index < TestToAnswer.questions.Count)
			{
				question = new Question();
				question = TestToAnswer.questions.ElementAt(index);
				return question;
			}
			return null;
		}

		public ActionResult InfosOfAnswers()
		{
			ViewData["infos"] = mapAnswers;
			ViewBag.logger = logger.C_ID;
			var model = TestToAnswer; 
			return View(model);
		}
	}
}