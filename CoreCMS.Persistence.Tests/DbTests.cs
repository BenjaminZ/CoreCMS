using System.Linq;
using CoreCMS.Persistence.Tests.Testers;
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

            var options = new DbContextOptionsBuilder<CMSDbContext>()
                .UseSqlite(connection)
                .Options;

            using (var context = new CMSDbContext(options))
            {
                context.Database.EnsureCreated().Should().Be(true);

                var managerRoleTester = new ManagerRoleTester();
                var managerTester = new ManagerTester();

                // Insertions
                context.ManagerRoles.Add(managerRoleTester.CreateInstance());
                context.SaveChanges();

                var managerRole= context.ManagerRoles.FirstOrDefault();
                context.Managers.Add(managerTester.CreateInstance(managerRole.ManagerRoleId));
                context.SaveChanges();

                // Validations
                var manager= context.Managers.FirstOrDefault();
                managerRoleTester.Validate(managerRole, context.ManagerRoles.Count());
                managerTester.Validate(manager);
            }

            connection.Close();
        }
    }
}