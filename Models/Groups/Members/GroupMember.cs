using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GlobalManagement.Models.Groups.Members
{
    public class GroupMember
    {
        // Tutaj jest definiowany użytkownik grupy, do której należy i które ma permisje, wraz z tym czy jest aktywny, zapisuje byłych członków
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, Key]
        public required Guid Uuid { get; set; }
        [Required]
        public required string GroupName { get; set; }
        [Required]
        public required Guid GroupUUID { get; set; }
        [Required]
        public required string Username { get; set; }
        [Required]
        public required Guid UserGuid { get; set; }
        [Required]
        public required string Role { get; set; }
        [Required]
        public required Guid RoleGuid { get; set; }
        [Required]
        public required bool IsActive { get; set; }
        [Required]
        public required DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
