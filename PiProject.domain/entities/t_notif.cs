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
	[Table("t_Notif")]
	public partial class t_notif
	{

		[Key]
		public int IDNotif { get; set; }
		[StringLength(255)]
		public string content { get; set; }
		public Boolean is_checked { get; set; }

			[ForeignKey("collab")]
			public int  collabId { get; set; }

			public virtual t_collaborator collab { get; set; }

		[ForeignKey("Relatedwarning")]
			public int? WarningId { get; set; }
			public virtual Warning Relatedwarning { get; set; }
			
	}
}
