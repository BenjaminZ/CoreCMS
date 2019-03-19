﻿using CoreCMS.Domain.Entities;
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
        public DbSet<OperationLog> OperationLogs { get; set; }
        public DbSet<AdminMenu> AdminMenus { get; set; }
        public DbSet<RoleAccess> RoleAccesses { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            
            if (optionsBuilder.IsConfigured) return;
            optionsBuilder.UseSqlite("Data Source=CoreCMS.db");
        }
    }
}