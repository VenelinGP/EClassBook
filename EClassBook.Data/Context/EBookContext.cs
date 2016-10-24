namespace EClassBook.Data.Context
{
    using Model.Entities;
    using Microsoft.EntityFrameworkCore;

    public class EBookContext : DbContext
    {
        public EBookContext(DbContextOptions<EBookContext> options)
            : base(options)
        { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Headmaster> Headmasters { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
