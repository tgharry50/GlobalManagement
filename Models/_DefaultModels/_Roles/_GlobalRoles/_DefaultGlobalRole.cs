using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GlobalManagement.Models._DefaultModels._Roles._GlobalRoles
{
    public class _DefaultGlobalRole
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, Key]
        public Guid UUID { get; set; }
        [Required]
        public required string Role_Name { get; set; }
        [Required]
        public required string App_Name { get; set; }
        [Required]
        public required Guid App_UUID { get; set; }
        [Required]
        public bool CanAccessGlobal { get; set; }
        [Required]
        public bool CanBeEdited { get; set; }
        [Required]
        public bool CreateUser { get; set; }
        [Required]
        public bool UpdateUser { get; set; }
        [Required]
        public bool DeleteUser { get; set; }
        [Required]
        public bool CreateCustomRole { get; set; }
        [Required]
        public bool UpdateCustomRole { get; set; }
        [Required]
        public bool DeleteCustomRole { get; set; }
        
    }
}
