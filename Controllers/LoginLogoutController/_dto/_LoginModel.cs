using System.ComponentModel.DataAnnotations;

namespace GlobalManagement.Controllers.LoginLogoutController._dto
{
    public class _LoginModel
    {
        public class Login
        {
            [Required]
            public required string _login { get; set; }
            [Required]
            public required string _password { get; set; }

        }
        public class ReturnUserData
        {
            // General
            public required Guid uuid { get; set; }
            public required string username { get; set; }
            public required string firstname { get; set; }
            public required string lastname { get; set; }
            public required string email { get; set; }
            public string? card { get; set; }
            public required int pin { get; set; }
        }
        public class ReturnUserDataPermissions
        {
            // Permissions
            public bool CanAccessGlobal { get; set; }
            public bool CanBeEdited { get; set; }
            // Users
            public bool CreateUser { get; set; }
            public bool UpdateUser { get; set; }
            public bool DeleteUser { get; set; }
            // Roles
            public bool CreateCustomRole { get; set; }
            public bool UpdateCustomRole { get; set; }
            public bool DeleteCustomRole { get; set; }
            // Groups
            public bool CanCreateGroup { get; set; }
            public bool CanDeleteGroup { get; set; }
            public bool CanUpdateGroup { get; set; }
        }
    }
}
