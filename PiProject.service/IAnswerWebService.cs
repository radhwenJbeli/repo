using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiProject.service
{
	public interface IAnswerWebService
	{
		 void AddTestAnswerAff(int idCollaborator, int idEvaluationTest);
		void AddAnswerToAff(int idCollaborator, int idEvaluationTest, int idQuestion, int idResponse);
		void AddFeedbackToAnswer(int idCollaborator, int idEvaluationTest);
	}
}
