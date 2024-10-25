using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GlobalManagement.Models.Permissions
{
    public class PermissionModel
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, Key]
        public required Guid UUID { get; set; }
        [Required]
        public required Guid User_UUID { get; set; }
        // APP
        [Required]
        public required string App_Name { get; set; }
        [Required]
        public required Guid App_UUID { get; set; }
        // ROLE
        [Required]
        public required string Role { get; set; }
        [Required]
        public required Guid Role_UUID { get; set; }
    }
}
