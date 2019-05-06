using System;
using System.Collections;
using System.Collections.Generic;

namespace CoreCMS.Domain.Entities
{
    public class AdminMenu
    {
        public int AdminMenuId { get; set; }
        public int? ParentMenuId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string IconPath { get; set; }
        public string Url { get; set; }
        public int OrderNumber { get; set; }
        public string OperationLevel { get; set; }
        public bool IsDisplayed { get; set; }
        public bool IsDefault { get; set; }
        public int AddedBy { get; set; }
        public DateTime AddTime { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? ModifyTime { get; set; }
        public bool IsDeleted { get; set; }
        public virtual AdminMenu ParentMenu { get; set; }

        public virtual ICollection<AdminMenu> ChildMenus { get; set; }

        public virtual ICollection<RoleAccess> RoleAccesses { get; set; }
    }
}