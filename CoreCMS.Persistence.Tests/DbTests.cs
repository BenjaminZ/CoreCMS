using System.Linq;
using CoreCMS.Domain.Entities;
using FluentAssertions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CoreCMS.Persistence.Tests
{
    public class DbTests
    {
        [Fact]
        public void DbContextTest()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<CMSDbContext>()
                    .UseSqlite(connection)
                    .Options;

                using (var context = new CMSDbContext(options))
                {
                    context.Database.EnsureCreated().Should().Be(true);
                    context.Managers.Add(new Manager
                    {
                        AccountName = "Ben"
                    });

                    var count = context.SaveChanges();

                    count.Should().Be(1);

                    var manager = context.Managers.FirstOrDefault();

                    manager.Should().NotBeNull();
                    manager.AccountName.Should().Be("Ben");
                    manager.ManagerId.Should().Be(1);
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}