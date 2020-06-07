namespace StudentInfoSystem
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StudentContext : DbContext
    {
        public StudentContext() : base("name=StudentContext") {}
        public virtual DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().Property(e => e.FirstName).IsUnicode(false);
            modelBuilder.Entity<Student>().Property(e => e.Surname).IsUnicode(false);
            modelBuilder.Entity<Student>().Property(e => e.LastName).IsUnicode(false);
            modelBuilder.Entity<Student>().Property(e => e.Faculty).IsUnicode(false);
            modelBuilder.Entity<Student>().Property(e => e.Programme).IsUnicode(false);
            modelBuilder.Entity<Student>().Property(e => e.FacultyNumber).IsUnicode(false);
            modelBuilder.Entity<Student>().Property(e => e.Course).IsUnicode(false);
            modelBuilder.Entity<Student>().Property(e => e.Stream).IsUnicode(false);
            modelBuilder.Entity<Student>().Property(e => e.Group).IsUnicode(false);
        }
    }
}
