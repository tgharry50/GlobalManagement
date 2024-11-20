using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GlobalManagement.Models.Permissions
{
    public class PermissionModel
    {
        // Definiowane permisje użytkownika, generowane na każdą aplikacje, czyli kto, gdzie i co może
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, Key]
        public required Guid UUID { get; set; }
        [Required]
        public required Guid UserUuid { get; set; }
        // APP
        [Required]
        public required string AppName { get; set; }
        [Required]
        public required Guid AppUuid { get; set; }
        // ROLE
        [Required]
        public required string Role { get; set; }
        [Required]
        public required Guid RoleUuid { get; set; }
        [Required]
        public required DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
