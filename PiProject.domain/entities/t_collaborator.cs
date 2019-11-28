namespace PiProject.data
{
	using domain.entities;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;


    [Table("pi.t_collaborator")]
    public partial class t_collaborator
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_collaborator()
        {
            t_answertestaffectation = new HashSet<t_answertestaffectation>();
            t_evaluationtest = new HashSet<t_evaluationtest>();
            t_evaluationtargetaffectation = new HashSet<t_evaluationtargetaffectation>();
            t_performancenote = new HashSet<t_performancenote>();
			
            t_evaluationguestaffectation = new HashSet<t_evaluationguestaffectation>();
        }

        [Key]
        public int C_ID { get; set; }

        public int? C_Age { get; set; }

        [StringLength(255)]
        public string C_email { get; set; }

        [StringLength(255)]
        public string C_Forname { get; set; }

        [StringLength(255)]
        public string C_Lastname { get; set; }

        [StringLength(255)]
        public string C_password { get; set; }

		
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<t_answertestaffectation> t_answertestaffectation { get; set; }
		

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_evaluationtest> t_evaluationtest { get; set; }

        public virtual t_manager t_manager { get; set; }

        public virtual t_developper t_developper { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_evaluationtargetaffectation> t_evaluationtargetaffectation { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_performancenote> t_performancenote { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_evaluationguestaffectation> t_evaluationguestaffectation { get; set; }

		public int? SuperviserId { get; set; }
		[ForeignKey("SuperviserId")]
		public virtual t_manager superViser { get; set; }

		public virtual ICollection<t_notif> notifacations { get; set; }
		public virtual ICollection<Warning> warnings { get; set; }

		
	}
}
