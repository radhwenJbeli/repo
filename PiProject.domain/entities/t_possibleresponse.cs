namespace PiProject.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pi.t_possibleresponse")]
    public partial class t_possibleresponse
    {
        [Key]
        public int Pr_ID { get; set; }

        [StringLength(255)]
        public string Pr_Content { get; set; }

        [StringLength(255)]
        public string Pr_Description { get; set; }

        public int? Pr_score { get; set; }

        public int? criteria_Cr_ID { get; set; }

        public virtual t_criteria t_criteria { get; set; }
    }
}
