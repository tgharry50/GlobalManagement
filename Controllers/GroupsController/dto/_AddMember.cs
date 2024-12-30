namespace GlobalManagement.Controllers.GroupsController.dto
{
    public class _AddMember
    {
        public Guid GroupUUID { get; set; }
        public Guid UserGuid { get; set; }
        public Guid RoleGuid { get; set; }
    }
}
