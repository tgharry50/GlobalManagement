using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GlobalManagement.Models.Groups._Default
{
    public class GroupRoleModel
    {

        // Definiowane jest tutaj co może robić użytkownik w grupie, bazowo istnieć będą User i Admin, z możliwością pisania własnych grup, bo i tak każda rola jest przypisana do danej grupy
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, Key]
        public required Guid Uuid { get; set; }
        [Required]
        public required string GroupName { get; set; }
        [Required]
        public required Guid GroupUuid { get; set; }
        [Required]
        public required string RoleName { get; set; }
        [Required]
        public required bool IsAdmin { get; set; }
        // Group
        [Required]
        public required bool CanModifyGroup { get; set; }
        [Required]
        public required bool CanRemoveGroup { get; set; }
        // Roles
        [Required]
        public required bool CanAddRoles { get; set; }
        [Required]
        public required bool CanModifyRoles { get; set; }
        [Required]
        public required bool CanRemoveRoles { get; set; }
        [Required]
        public required bool IsRoleRemovable { get; set; }
        // Users of group
        [Required]
        public required bool CanAddUser { get; set; }
        [Required]
        public required bool CanRemoveUser { get; set; }
        [Required]
        public required bool CanModifyUser { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
