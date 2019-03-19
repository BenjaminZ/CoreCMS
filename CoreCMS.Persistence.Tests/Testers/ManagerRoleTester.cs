using System;
using CoreCMS.Domain.Entities;
using FluentAssertions;

namespace CoreCMS.Persistence.Tests.Testers
{
    public static class ManagerRoleTester
    {
        public static void Validate(ManagerRole data)
        {
            data.Should().NotBeNull();
            data.ManagerRoleName.Should().Be("Superman");
            data.AddedBy.Should().Be(0);
            data.AddTime.Should().BeCloseTo(DateTime.UtcNow, 10000);
            data.IsDeleted.Should().Be(false);
            data.ModifyTime.Should().BeNull();
            data.ModifiedBy.Should().Be(0);
            data.IsSystemDefault.Should().Be(false);
            data.ManagerRoleType.Should().Be(1);
        }

        public static ManagerRole CreateInstance()
        {
            return new ManagerRole
            {
                ManagerRoleName = "Superman",
                ManagerRoleType = 1
            };
        }
    }
}