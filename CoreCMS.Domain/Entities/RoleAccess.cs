namespace CoreCMS.Domain.Entities
{
    public class RoleAccess
    {
        public int RoleAccessId { get; set; }
        public int ManagerRoleId { get; set; }
        public int AdminMenuId { get; set; }
        public string AccessType { get; set; }
        public virtual AdminMenu AdminMenu { get; set; }
        public virtual ManagerRole ManagerRole { get; set; }
    }
}