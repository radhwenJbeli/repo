namespace PiProject.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pi.t_evaluationtest")]
    public partial class t_evaluationtest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_evaluationtest()
        {
            t_answertestaffectation = new HashSet<t_answertestaffectation>();
            t_criteria = new HashSet<t_criteria>();
            t_evaluationguestaffectation = new HashSet<t_evaluationguestaffectation>();
            t_evaluationtargetaffectation = new HashSet<t_evaluationtargetaffectation>();
        }

        [Key]
        public int ET_ID { get; set; }

        public float? ET_actuelGlobalNote { get; set; }

        [StringLength(255)]
        public string ET_Description { get; set; }

        [StringLength(255)]
        public string ET_Type { get; set; }

        [StringLength(255)]
        public string Et_tType { get; set; }

        public int? creator_C_ID { get; set; }

        public int? Et_actualParticipantsNumber { get; set; }

        public int? creator_id { get; set; }

        public float globaloNoteSoFar { get; set; }

        public int? testType_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_answertestaffectation> t_answertestaffectation { get; set; }

        public virtual t_collaborator t_collaborator { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_criteria> t_criteria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_evaluationguestaffectation> t_evaluationguestaffectation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_evaluationtargetaffectation> t_evaluationtargetaffectation { get; set; }

        public virtual t_manager t_manager { get; set; }

        public virtual t_testtype t_testtype { get; set; }
    }
}
