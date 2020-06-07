namespace UserLogin
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LogContext : DbContext
    {
        public LogContext()
            : base("name=LogContext")
        {
        }
        public virtual DbSet<Log> Logs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>().Property(e => e.Activity).IsUnicode(false);
            modelBuilder.Entity<Log>().Property(e => e.Username).IsUnicode(false);
        }
    }
}
