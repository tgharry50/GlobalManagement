using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GlobalManagement.Models.Groups.Permissions
{
    public class GroupPermissions
    {
        // Permisje danej grupy, gdzie ma dostępy
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, Key]
        public required Guid Uuid { get; set; }
        [Required]
        public required string GroupName { get; set; }
        [Required]
        public required Guid GroupUuid { get; set; }
        [Required]
        public required bool UsersCanAccessGlobalApp { get; set; }
        [Required]
        public required bool UsersCanAccessReferenceHub { get; set; }
    }
}
