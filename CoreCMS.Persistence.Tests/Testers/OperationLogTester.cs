using System;
using CoreCMS.Domain.Entities;
using FluentAssertions;

namespace CoreCMS.Persistence.Tests.Testers
{
    public static class OperationLogTester
    {
        public static OperationLog CreateInstance(int mId)
        {
            return new OperationLog
            {
                OperationType = "fly",
                OperatorId = mId,
                OperatorIp = "127.0.0.1",
                Note = "this is a note"
            };
        }

        public static void Validate(OperationLog data, int _mId)
        {
            data.Should().NotBeNull();
            data.Note.Should().Be("this is a note");
            data.OperatorId.Should().Be(_mId);
            data.Operator.ManagerId.Should().Be(_mId);
            data.OperatorIp.Should().Be("127.0.0.1");
            data.OperationType.Should().Be("fly");
            data.OperateTime.Should().BeCloseTo(DateTime.UtcNow, 60000);
        }
    }
}