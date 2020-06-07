namespace UserLogin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("student_info_system.logs")]
    public partial class Log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LogsId { get; set; }

        [Required]
        [StringLength(1073741823)]
        public string Activity { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        public int UserRole { get; set; }
    }
}
