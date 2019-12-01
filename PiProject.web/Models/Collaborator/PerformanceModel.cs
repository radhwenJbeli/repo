using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PiProject.web.Models.Collaborator
{
	public class PerformanceModel
	{

		public float gloabalAutoNote { get; set; }

		public float global360Note { get; set; }


		public float globalPerformance { get; set; }

		public float performanceScoreCommunication { get; set; }

		public float performanceScoreSoftSkills { get; set; }

		public float performanceScoreTechnique { get; set; }

		public int NbreBadFeedbacks { get; set; }

		public int RankingAuto { get; set; }
		public int Ranking360 { get; set; }
		public int globalRanking { get; set; }

	}
}