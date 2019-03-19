using System;
using CoreCMS.Domain.Entities;
using FluentAssertions;

namespace CoreCMS.Persistence.Tests.Testers
{
    public static class AdminMenuTester
    {
        public static AdminMenu CreateInstance(int parentId)
        {
            return new AdminMenu
            {
                ParentMenuId = parentId,
                Name = "Super menu",
            };
        }

        public static void Validate(AdminMenu data, int parentId)
        {
            data.Should().NotBeNull();
            data.ParentMenuId.Should().Be(parentId);
            data.Name.Should().Be("Super menu");
            data.AddTime.Should().BeCloseTo(DateTime.UtcNow, 60000);
        }
    }
}