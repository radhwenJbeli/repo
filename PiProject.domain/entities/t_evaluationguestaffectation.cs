namespace PiProject.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pi.t_evaluationguestaffectation")]
    public partial class t_evaluationguestaffectation
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idCollaborator { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idEvaluationTest { get; set; }

        public DateTime? sendingDate { get; set; }

        [Column(TypeName = "bit")]
        public bool? isAnswered { get; set; }

        public virtual t_collaborator t_collaborator { get; set; }

        public virtual t_evaluationtest t_evaluationtest { get; set; }
    }
}
