namespace PiProject.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pi.__migrationhistory")]
    public partial class C__migrationhistory
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(150)]
        public string MigrationId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(300)]
        public string ContextKey { get; set; }

        [Required]
        public byte[] Model { get; set; }

        [Required]
        [StringLength(32)]
        public string ProductVersion { get; set; }
    }
}
