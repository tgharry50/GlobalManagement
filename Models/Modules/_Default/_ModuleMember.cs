using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;

namespace GlobalManagement.Models.Modules._Default
{
    public class ModuleMember
    {
        // Definiuje członka danego modułu oraz jego uprawnienia
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, Key]
        public Guid Uuid { get; set; }
        [Required]
        public required string ModuleName { get; set; }
        [Required]
        public required string ModuleUuid { get; set; }
        [Required]
        public required string UserName { get; set; }
        [Required]
        public required string FullName { get; set; }
        [Required]
        public required string UserUuid { get; set; }
        [Required]
        public required string PermissionName { get; set; }
        [Required]
        public required string PermissionUuid { get; set; }
        [Required]
        public required bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? LastUpdatedDate { get; set; }
    }
}
