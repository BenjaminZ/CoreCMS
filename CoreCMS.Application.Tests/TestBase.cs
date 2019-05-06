using System;
using CoreCMS.Persistence;
using FluentAssertions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace CoreCMS.Application.Tests
{
    public abstract class TestBase : IDisposable
    {
        public abstract void Dispose();

        protected CMSDbContext GetDbContext()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<CMSDbContext>()
                .UseSqlite(connection)
                .UseLazyLoadingProxies()
                .Options;
            var context = new CMSDbContext(options);
            context.Database.EnsureCreated().Should().Be(true);

            return context;
        }
    }
}