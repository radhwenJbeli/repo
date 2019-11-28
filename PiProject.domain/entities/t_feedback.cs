namespace PiProject.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pi.t_feedback")]
    public partial class t_feedback
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_feedback()
        {
            t_answertestaffectation = new HashSet<t_answertestaffectation>();
        }

        [Key]
        public int F_ID { get; set; }

        [StringLength(255)]
        public string F_title { get; set; }

        [StringLength(255)]
        public string F_content { get; set; }

		public Boolean isBad { get; set; }

		public int? idCollab { get; set; }

        public int? idEval { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_answertestaffectation> t_answertestaffectation { get; set; }
    }
}
