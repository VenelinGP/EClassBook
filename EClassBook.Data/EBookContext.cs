namespace EClassBook.Data
{
    using System;
    using System.Linq;

    using Common.Models;
    using Microsoft.EntityFrameworkCore;
    using Model;

    public class EBookContext : DbContext
    {
        public EBookContext(DbContextOptions<EBookContext> options)
            : base(options)
        {
        }

        public DbSet<Headmaster> Headmasters { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Address> Address { get; set; }

        public DbSet<Grade> Grades { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Role> Roles { get; set; }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }
        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }

}

