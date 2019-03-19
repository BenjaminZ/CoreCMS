using CoreCMS.Domain.Entities;
using FluentAssertions;

namespace CoreCMS.Persistence.Tests.Testers
{
    public static class RoleAccessTester
    {
        public static RoleAccess CreateInstance(int mrId, int amId)
        {
            return new RoleAccess
            {
                AdminMenuId = amId,
                ManagerRoleId = mrId
            };
        }

        public static void Validate(RoleAccess data, int mrId, int amId)
        {
            data.Should().NotBeNull();
            data.ManagerRoleId.Should().Be(mrId);
            data.AdminMenuId.Should().Be(amId);
        }
    }
}