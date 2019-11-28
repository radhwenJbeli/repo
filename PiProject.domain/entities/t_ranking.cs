using PiProject.data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiProject.domain.entities
{
	[Table("t_ranking")]
	public class t_ranking
	{
		[Key]
		public int idRanking { get; set; }

		public int RankingAuto { get; set; }
		public int Ranking360 { get; set; }
		public int globalRanking { get; set; }

		
	}
}
