namespace PiProject.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pi.t_criteria")]
    public partial class t_criteria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_criteria()
        {
            t_possibleresponse = new HashSet<t_possibleresponse>();
        }

        [Key]
        public int Cr_ID { get; set; }

        public int? Cr_coefficient { get; set; }

        [StringLength(255)]
        public string Cr_Content { get; set; }

        [StringLength(255)]
        public string Cr_Description { get; set; }

        public int? evaluationTest_ET_ID { get; set; }

        public virtual t_evaluationtest t_evaluationtest { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_possibleresponse> t_possibleresponse { get; set; }
    }
}
