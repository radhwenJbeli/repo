namespace PiProject.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pi.t_performancenote")]
    public partial class t_performancenote
    {
        [Key]
        public int C_ID { get; set; }

        public float gloabalAutoNote { get; set; }

        public float global360Note { get; set; }

        public float globalPerformance { get; set; }

        public float performanceScoreCommunication { get; set; }

        public float performanceScoreSoftSkills { get; set; }

        public float performanceScoreTechnique { get; set; }

        public int? collaborator_C_ID { get; set; }

        public virtual t_collaborator t_collaborator { get; set; }
    }
}
