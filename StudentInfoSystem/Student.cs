namespace StudentInfoSystem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("student_info_system.students")]
    public partial class Student
    {
        public int StudentId { get; set; }

        [StringLength(1073741823)]
        public string FirstName { get; set; }

        [StringLength(1073741823)]
        public string Surname { get; set; }

        [StringLength(1073741823)]
        public string LastName { get; set; }

        [StringLength(1073741823)]
        public string Faculty { get; set; }

        [StringLength(1073741823)]
        public string Programme { get; set; }

        public int Qualification { get; set; }

        public int Status { get; set; }

        [StringLength(1073741823)]
        public string FacultyNumber { get; set; }

        [StringLength(1073741823)]
        public string Course { get; set; }

        [StringLength(1073741823)]
        public string Stream { get; set; }

        [StringLength(1073741823)]
        public string Group { get; set; }

    }
}
