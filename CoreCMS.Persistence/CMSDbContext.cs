﻿using CoreCMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreCMS.Persistence
{
    public class CMSDbContext : DbContext
    {
        public CMSDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}