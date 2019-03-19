using System.Linq;
using CoreCMS.Domain.Entities;
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


                // Insertions
                context.ManagerRoles.Add(ManagerRoleTester.CreateInstance());
                context.SaveChanges();
                var managerRole= context.ManagerRoles.First();

                context.Managers.Add(ManagerTester.CreateInstance(managerRole.ManagerRoleId));
                context.SaveChanges();
                var manager = context.Managers.First();

                context.OperationLogs.Add(OperationLogTester.CreateInstance(manager.ManagerId));
                context.SaveChanges();
                var operationLog = context.OperationLogs.First();

                context.AdminMenus.Add(AdminMenuTester.CreateInstance(1));
                context.SaveChanges();
                var rootMenu = context.AdminMenus.First();
                context.AdminMenus.Add(AdminMenuTester.CreateInstance(rootMenu.AdminMenuId));
                context.SaveChanges();
                var testMenu = context.AdminMenus.First(m => m.AdminMenuId == 2);

                context.RoleAccesses.Add(RoleAccessTester.CreateInstance(managerRole.ManagerRoleId,
                    testMenu.AdminMenuId));
                context.SaveChanges();
                var ra = context.RoleAccesses.First();

                // Validations
                ManagerRoleTester.Validate(managerRole);
                ManagerTester.Validate(manager, managerRole.ManagerRoleId);
                OperationLogTester.Validate(operationLog, manager.ManagerId);
                AdminMenuTester.Validate(testMenu, rootMenu.AdminMenuId);
                RoleAccessTester.Validate(ra, managerRole.ManagerRoleId, testMenu.AdminMenuId);
            }

            connection.Close();
        }
    }
}