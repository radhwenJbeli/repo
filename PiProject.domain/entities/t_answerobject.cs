namespace PiProject.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pi.t_answerobject")]
    public partial class t_answerobject
    {
        [Key]
        public int A_ObjectID { get; set; }

        public int idAnswer { get; set; }

        public int idQuestion { get; set; }

        public int? affectedTo_idCollaborator { get; set; }

        public int? affectedTo_idEvaluationTest { get; set; }

        public virtual t_answertestaffectation t_answertestaffectation { get; set; }
    }
}
