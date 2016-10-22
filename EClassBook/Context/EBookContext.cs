namespace EClassBook.Context
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class EBookContext : DbContext
    {
        public EBookContext(DbContextOptions<EBookContext> options)
            : base(options)
        { }

        public DbSet<Person> Persons { get; set; }
    }
}
