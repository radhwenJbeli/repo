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
	[Table("t_Warning")]
	public partial class Warning
	{
		[Key]
		public int WId { get; set; }
		[StringLength(255)]
		public string Reason { get; set; }
		[StringLength(255)]
		public string Content { get; set; }
		public int is_Confirmed { get; set; }

		
		public Gravity gravity { get; set; }

		[ForeignKey("collab")]
		public int? ToWarnId { get; set; }
		public virtual t_collaborator  collab { get; set; }

		[ForeignKey("manager")]
		public int? ManagerId { get; set; }
		public virtual t_manager manager { get; set; }



	}
}
