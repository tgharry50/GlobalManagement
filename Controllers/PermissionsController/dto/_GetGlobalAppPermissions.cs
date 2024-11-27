using System.ComponentModel.DataAnnotations;

namespace GlobalManagement.Controllers.PermissionsController.dto
{
    public class _GetGlobalAppPermissions
    {
        public Guid Uuid { get; set; }
        public required string RoleName { get; set; }
        public required string AppName { get; set; }
        public required Guid AppUuid { get; set; }
        public bool CanAccessGlobal { get; set; }
        public bool CanBeEdited { get; set; }
        public bool CreateUser { get; set; }
        public bool UpdateUser { get; set; }
        public bool DeleteUser { get; set; }
        public bool CreateCustomRole { get; set; }
        public bool UpdateCustomRole { get; set; }
        public bool DeleteCustomRole { get; set; }
        public bool CanCreateGroup { get; set; }
        public bool CanDeleteGroup { get; set; }
        public bool CanUpdateGroup { get; set; }
    }
}
