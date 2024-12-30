using System.ComponentModel.DataAnnotations;

namespace GlobalManagement.Controllers.GroupsController.dto
{
    public class _GetMember
    {
        public required Guid Uuid { get; set; }
        public required string GroupName { get; set; }
        public required Guid GroupUUID { get; set; }
        public required string Username { get; set; }
        public required Guid UserGuid { get; set; }
        public required string Role { get; set; }
        public required Guid RoleGuid { get; set; }
        public required bool IsActive { get; set; }
    }
}
