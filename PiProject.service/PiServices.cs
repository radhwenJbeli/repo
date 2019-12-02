using PiProject.data;
using PiProject.domain.entities;
using PiProject.domain.serviceEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiProject.service
{
	public class PiServices
	{
		private PiContext _context;
		public PiServices()
		{
			this._context = new PiContext();
			_context.Database.Initialize(force: false);
		}

		public Boolean VerifyNegativityOfFeedback(Feedback360 feedback , List<String> BadWordsDictionnary)
		{
			char[] separators = new char[] { ' ' };
			List<String> AllWords = feedback.content.Split(separators).ToList();

			List<String> badWords = new List<string>();
			foreach (var word in BadWordsDictionnary )
			{
				if(AllWords.Where(w => w.Equals(word)).Any())
				{
					badWords.Add(word);
				}

			}
			if (badWords.Count >= 2) return true; 
			
			else return false; 


		}

		public t_evaluationtest GetEvaluationTest(int idTest)
		{
			t_evaluationtest test = _context.t_evaluationtest.Include("t_criteria")
									.Include("t_criteria.t_possibleresponse")
									.Where(e => e.ET_ID == idTest)
									.FirstOrDefault();

			return test;
		}




		public string VerifyFeedback(int idCollaborator)
		{
			t_collaborator collab = GetCollaborator(idCollaborator);

			int res = VerifyNbrBadFeedbacks(collab, 2);

			string retour = "";

			//si entre ici ca veut dire son nombre de bad feedback <2
			//=> pas de warning 
			if (res == 1)
			{
				retour = "pas de warning feedback ";

			}
			//il atteint la limite 
			//=> warning fedback type normal
			else if (res == 2)
			{
				Warning warn = new Warning();
				warn.gravity = Gravity.normal;
				warn.Reason = "Feedback";
				warn.Content = "you have reached the max permitted of bad feedbacks = 2";
				warn.is_Confirmed = 0;
				warn.manager = collab.superViser;
				warn.collab = collab;
				AddWarning(warn);

				retour = "warning feedback normal";
			}

			//il a dépassé  la limite 
			//=> warning fedback type serious
			else
			{
				Warning warn = new Warning();
				warn.gravity = Gravity.serious;
				warn.Reason = "Feedback";
				warn.Content = "you have depassed the max permitted of bad feedbacks = 2";
				warn.is_Confirmed = 0;
				warn.manager = collab.superViser;
				warn.collab = collab;
				AddWarning(warn);
				retour = "warning feedback serious";

			}
			return retour;

		}



		//if this returns 1 => warning 360 type serious ;
		//if this retuns 2 => warning 360 type normal ; 
		public int VerifyRank360(int idcollab)
		{

			int w = 0;
			t_collaborator collab = GetCollaborator(idcollab);

			int allCollabsNumber = GetAllCollabsNumber();

			//Last 3 indexes 
			List<int> LastThreeIndexes = new List<int>();
			for (int i = allCollabsNumber; i > allCollabsNumber - 3; i--)
			{
				LastThreeIndexes.Add(i);
			}

			// last 5 indexes
			List<int> LastFiveIndexes = new List<int>();
			for (int i = allCollabsNumber; i > allCollabsNumber - 5; i--)
			{
				LastFiveIndexes.Add(i);
			}





			//si parmi les 3 derniers warning grave


			foreach (int index in LastThreeIndexes)
			{
				if (collab.t_performancenote.ElementAt(0).rank.Ranking360 == index)
				{
					//w = 1 warning grave
					w = 1;
					//creation du warning type grave 
					Warning warn = new Warning();
					warn.gravity = Gravity.serious;
					warn.Reason = "360Note";
					warn.Content = "your 360 Note is between the last 3";
					warn.is_Confirmed = 0;
					warn.manager = collab.superViser;
					warn.collab = collab;
					AddWarning(warn);

				}

			}
			//si parmi les 5 derniers => <warning normaal
			//on entre seulement si il n'est pas des 3 derniers
			if (w != 1)
			{
				foreach (int index in LastFiveIndexes)
				{
					if (collab.t_performancenote.ElementAt(0).rank.Ranking360 == index)
					{
						//w = 2 warning normal
						w = 2;
						Warning warn = new Warning();
						warn.gravity = Gravity.normal;
						warn.Reason = "360Note";
						warn.Content = "your 360 Note is between the last 5";
						warn.is_Confirmed = 0;
						warn.manager = collab.superViser;
						warn.collab = collab;
						AddWarning(warn);
					}

				}
			}

			var t = w;
			return w;

		}






		//if this returns 1 => warning auto type serious ;
		//if this retuns 2 => warning auto	 type normal ;  
		public int VerifyRankingAuto(int  idcollab)
		{
			int w = 0;
			t_collaborator collab = GetCollaborator(idcollab);

			int allCollabsNumber = GetAllCollabsNumber();

			//Last 3 indexes 
			List<int> LastThreeIndexes = new List<int>();
			for(int i = allCollabsNumber; i> allCollabsNumber-3; i--)
			{
				LastThreeIndexes.Add(i);
			}

			// last 5 indexes
			List<int> LastFiveIndexes = new List<int>();
			for (int i = allCollabsNumber; i > allCollabsNumber - 5; i--)
			{
				LastFiveIndexes.Add(i);
			}





			//si parmi les 3 derniers warning grave
			
			
			foreach (int index in LastThreeIndexes)
			{
				if (collab.t_performancenote.ElementAt(0).rank.RankingAuto == index)
				{
					//w = 1 warning grave
					w = 1;
					//creation du warning type grave 
					Warning warn = new Warning();
					warn.gravity = Gravity.serious;
					warn.Reason = "AutoNote";
					warn.Content = "your Auto Note is between the last 3";
					warn.is_Confirmed = 0;
					warn.manager = collab.superViser;
					warn.collab = collab;
					AddWarning(warn); 
					
 				}

			}
			//si parmi les 5 derniers => <warning normaal
			//on entre seulement si il n'est pas des 3 derniers
			if (w != 1)
			{
				foreach (int index in LastFiveIndexes)
				{
					if (collab.t_performancenote.ElementAt(0).rank.RankingAuto == index)
					{
						//w = 2 warning normal
						w = 2;
						Warning warn = new Warning();
						warn.gravity = Gravity.normal;
						warn.Reason = "AutoNote";
						warn.Content = "your Auto Note is between the last 5";
						warn.is_Confirmed = 0;
						warn.manager = collab.superViser;
						warn.collab = collab;
						AddWarning(warn);
					}

				}
			}

			var t = w;
			return w;
			
		}



		public Warning AddWarning(Warning w)
		{
			Warning wa =  _context.t_warning.Add(w);
			_context.SaveChanges();
			return wa;
		}



		
		public int GetAllCollabsNumber()
		{
			return _context.t_collaborator.Count();
		}



		//utilisé pour savoir si la note du test est au moyenne ou pas
		public double? CaclculateAverageOfTest(int Idtest)
		{
			t_evaluationtest test = GetEvaluationTest(Idtest);
			double? allQuestcoeff = 0;

			
			double? MaxNoteOfTest = 0;
			foreach (t_criteria question in test.t_criteria)
			{
				
				allQuestcoeff += question.Cr_coefficient;
				foreach(t_possibleresponse respon in question.t_possibleresponse)
				{
					if (respon.isRight == 1)
					{
						
						MaxNoteOfTest += respon.Pr_score * question.Cr_coefficient;
					}
				}

			}

			double? e = MaxNoteOfTest / allQuestcoeff;

			double? AverageNoteOfTest = e / 2;  

			return AverageNoteOfTest;
		}

		//vérifier la note auto de collaborateur si au dessus de moyenne
		public int VerifyAuto(List<t_collaborator> targetList)
		{
			foreach(t_collaborator co in targetList)
			{


			}
			return 0;
		}


		
			
		

		public int VerifyNbrBadFeedbacks(t_collaborator c , int maxPermitted)
		{
			List<t_performancenote> notes = new List<t_performancenote>();
			notes = c.t_performancenote.ToList();
			int retour = 0;
			var w = maxPermitted;

			int j = notes.ElementAt(0).NbreBadFeedbacks;
			
				if(j < maxPermitted)
				{
					//il n'a pas encore atteint le maxpermitted
					retour = 1;
					
				}
				else if(j == maxPermitted)
				{
					retour = 2;
					//il  a exactement atteint le maxpermitted
					
				}
				else  
				{
					retour = 3;

					//il a depassé le maxpermitted
					
				}
				
			
			return retour;
			
			
		}

		public List<Warning> GetAllWarningOfmanager(int idManager)
		{
			List<Warning> AllList = _context.t_warning
				.ToList();
			List<Warning> ListOfManager = AllList
											.Where(w => w.ManagerId == idManager && w.is_Confirmed==0).ToList();

			return ListOfManager;
		}


		public List<Warning> GetAllWarningsOfCollab(int idCollaborator)
		{
			List<Warning> AllList = _context.t_warning.ToList();
			List<Warning> ListOfWarnings = AllList.Where(w => w.collab.C_ID == idCollaborator && w.is_Confirmed == 1).ToList();


			return ListOfWarnings;
		}

		public void UpdateWarning(Warning warn)
		{
			_context.SaveChanges();
		}
		public Warning GetWarning(int idWarning)
		{
			Warning w = _context.t_warning.Where(w0 => w0.WId == idWarning).FirstOrDefault();
			return w;
		}

		public t_collaborator GetCollaborator(int idCollaborator)
		{
			t_collaborator collab = _context.t_collaborator
										.Include("superViser")
										.Include("t_answertestaffectation")
										.Include("t_answertestaffectation.t_feedback")
										.Include("superViser.t_collaborator")
										.Include("notifacations")
										.Include("notifacations.Relatedwarning")

										.Include("warnings")

										.Where<t_collaborator>(c => c.C_ID == idCollaborator)
										.FirstOrDefault();
			ICollection<t_performancenote> notes = collab.t_performancenote


													.ToList();

			//obligatoire
			foreach (t_performancenote note in notes)
			{
				var e = note.rank;
			}

			return collab;
		}





	}
}
