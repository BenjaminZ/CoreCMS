namespace CoreCMS.Domain.Entities
{
    public class RoleAccess
    {
        public int RoleAccessId { get; set; }
        public int ManagerRoleId { get; set; }
        public int AdminMenuId { get; set; }
        public string AcessType { get; set; }
        public AdminMenu AdminMenu { get; set; }
        public ManagerRole ManagerRole { get; set; }
    }
}