namespace UserLogin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("student_info_system.users")]
    public partial class User
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(10)]
        public string FacultyNumber { get; set; }

        public int Role { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Created { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime? ActiveTo { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime? LastTimeLogged { get; set; }
    }
}
