using Microsoft.EntityFrameworkCore;

namespace lab1.Models
{
    public class Context_ :DbContext
    {
      public   Context_() : base()
        {

        }
        //for injection
        public Context_(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MvcDB;Integrated Security=True");
            base.OnConfiguring(optionsBuilder); 
        }

        public virtual DbSet<Trainee>trainees { get; set; }
        public virtual DbSet<Department>departments { get; set; }
        public virtual DbSet<Course> courses { get; set; }
        public virtual DbSet<CrsResult> crsResults { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }

    }
}
