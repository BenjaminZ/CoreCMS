using System;
using CoreCMS.Domain.Entities;
using FluentAssertions;

namespace CoreCMS.Persistence.Tests.Testers
{
    public static class ManagerTester
    {
        public static Manager CreateInstance(int mrId)
        {
            return new Manager
            {
                AccountName = "Ben",
                Password = "sa123",
                ManagerRoleId = mrId
            };
        }

        public static void Validate(Manager data, int mrId)
        {
            data.Should().NotBeNull();
            data.Email.Should().BeNull();
            data.Password.Should().Be("sa123");
            data.AddedBy.Should().Be(0);
            data.AddTime.Should().BeCloseTo(DateTime.UtcNow, 10000);
            data.IsDeleted.Should().BeFalse();
            data.ModifyTime.Should().BeNull();
            data.ManagerRoleId.Should().Be(mrId);
            data.Note.Should().BeNull();
            data.HeadShot.Should().BeNull();
            data.IsLocked.Should().BeFalse();
            data.NickName.Should().BeNull();
            data.CellPhone.Should().BeNull();
            data.LoginCount.Should().Be(0);
            data.ModifiedBy.Should().Be(0);
            data.ModifyTime.Should().BeNull();
            data.AccountName.Should().Be("Ben");
            data.LastLoginIp.Should().BeNull();
            data.LastLoginTime.Should().BeNull();
        }
    }
}