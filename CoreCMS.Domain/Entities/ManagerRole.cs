using System;
using System.Collections;
using System.Collections.Generic;

namespace CoreCMS.Domain.Entities
{
    public class ManagerRole
    {
        public ManagerRole()
        {
            Managers = new HashSet<Manager>();
        }

        public int ManagerRoleId { get; set; }
        public string ManagerRoleName { get; set; }
        public int ManagerRoleType { get; set; }
        public bool IsSystemDefault { get; set; }
        public int AddedBy { get; set; }
        public DateTime AddTime { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? ModifyTime { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Manager> Managers { get; }
    }
}