using System.ComponentModel.DataAnnotations;

namespace GlobalManagement.Controllers.GroupsController.dto
{
    public class _GetRolesForAdding
    {
        public required Guid Uuid { get; set; }
        public required string RoleName { get; set; }
    }
}
