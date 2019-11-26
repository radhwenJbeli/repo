using PiProject.data;
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
		}


        // GET: Collaborator
        public ActionResult Index()
        {
			

            return View();
        }


		public ActionResult Dashboard()
		{

			Getlogger();	
			return View();
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
				return RedirectToAction("InfosOfAnswers", "Collaborator", null);
				//return View();
			}
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
			return View();
		}
	}
}