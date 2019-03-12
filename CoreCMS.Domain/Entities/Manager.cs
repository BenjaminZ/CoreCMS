using System;

namespace CoreCMS.Domain.Entities
{
    public class Manager
    {
        public int ManagerId { get; set; }
        public int Role { get; set; }
        public string AccountName { get; set; }
        public string Password { get; set; }
        public string HeadShot { get; set; }
        public string NickName { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public int LoginCount { get; set; }
        public string LastLoginIp { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public int? AddedBy { get; set; }
        public DateTime AddTime { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifyTime { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsDeleted { get; set; }
        public string Description { get; set; }
    }
}