using CoreCMS.Domain.Entities;
using CoreCMS.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CoreCMS.Persistence
{
    public class CMSDbContext : DbContext
    {
        public CMSDbContext(DbContextOptions options) : base(options)
        {
        }

        public CMSDbContext()
        {
        }

        public DbSet<Manager> Managers { get; set; }
        public DbSet<ManagerRole> ManagerRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            optionsBuilder.UseSqlite("Data Source=CoreCMS.db");
        }
    }
}