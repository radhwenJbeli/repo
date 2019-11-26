namespace PiProject.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pi.t_answertestaffectation")]
    public partial class t_answertestaffectation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_answertestaffectation()
        {
            t_answerobject = new HashSet<AnswerAffectation>();
        }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idCollaborator { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idEvaluationTest { get; set; }

        public DateTime? dateAnswer { get; set; }

        [Column(TypeName = "bit")]
        public bool isAnswered { get; set; }

        public float scoreCalculated { get; set; }

        public int? feedback_F_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnswerAffectation> t_answerobject { get; set; }

        public virtual t_feedback t_feedback { get; set; }

        public virtual t_evaluationtest t_evaluationtest { get; set; }

        public virtual t_collaborator t_collaborator { get; set; }
    }
}
