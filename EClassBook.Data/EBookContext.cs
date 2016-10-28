namespace EClassBook.Data
{
    using System;
    using System.Linq;

    using Common.Models;
    using Microsoft.EntityFrameworkCore;
    using Model;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        public DbSet<UserRole> UserRoles { get; set; }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = entity.DisplayName();
            }
            // Address
            // Course
            // Error
            // Grade
            // Headmaster
            modelBuilder.Entity<Headmaster>().Property(h => h.Username).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Headmaster>().Property(h => h.AddressId).IsRequired();

            // Teacher
            modelBuilder.Entity<Teacher>().Property(t => t.Username).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Teacher>().Property(t => t.AddressId).IsRequired();

            // Student
            modelBuilder.Entity<Student>().Property(s => s.Username).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Student>().Property(s => s.AddressId).IsRequired();

            // UserRole
            modelBuilder.Entity<UserRole>().Property(ur => ur.UserId).IsRequired();
            modelBuilder.Entity<UserRole>().Property(ur => ur.RoleId).IsRequired();

            // Role
            modelBuilder.Entity<Role>().Property(r => r.Name).IsRequired().HasMaxLength(50);
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

