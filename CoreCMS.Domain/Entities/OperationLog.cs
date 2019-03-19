using System;

namespace CoreCMS.Domain.Entities
{
    public class OperationLog
    {
        public int LogId { get; set; }
        public string OperationType { get; set; }
        public int OperatorId { get; set; }
        public DateTime OperateTime { get; set; }
        public string OperatorIp { get; set; }
        public string Note { get; set; }
        public virtual Manager Operator { get; set; }
    }
}