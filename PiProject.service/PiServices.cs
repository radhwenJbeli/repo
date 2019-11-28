using PiProject.data;
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

		public Boolean VerifyNegativityOfFeedback(t_feedback feedback , List<String> BadWordsDictionnary)
		{
			char[] separators = new char[] { ' ' };
			List<String> AllWords = feedback.F_content.Split(separators).ToList();

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




		public string VerifyNbrBadFeedbacks(t_collaborator c , int maxPermitted)
		{
			List<t_performancenote> notes = new List<t_performancenote>();

			foreach (t_performancenote note in notes)
			{
				if(note.NbreBadFeedbacks < maxPermitted)
				{
					return ("vous n'avez pas encore atteint la limite");
				}
				if(note.NbreBadFeedbacks == maxPermitted)
				{
					return ("vous avez atteint le nombre max ");
				}
				if(note.NbreBadFeedbacks> maxPermitted)
				{
					return ("vous avez dépassé le nombre max :> warning");
				}
				
			}
			return null;
			
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

										.Where<t_collaborator>(c => c.C_ID == 13)
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
