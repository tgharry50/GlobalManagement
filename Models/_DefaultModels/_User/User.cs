using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GlobalManagement.Models._DefaultModels._User
{
    public class User
    {
        // Użytkownik
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, Key]
        public Guid Uuid { get; set; }
        [MaxLength(32), Required] 
        public required string UserName { get; set; }
        [Required]
        public required string Password { get; set; }
        [MaxLength(48), Required] 
        public required string FirstName { get; set; }
        [MaxLength(48), Required] 
        public required string LastName { get; set; }
        [MaxLength(48)] 
        public string? FullName { get; set; }
        [MaxLength(64), Required] 
        public required string Email { get; set; }
        [MaxLength(28), Required] 
        public required string? Card { get; set; }
        [MaxLength(16), Required]
        public required int Pin {  get; set; }
        public string? Image { get; set; }
        //// Other funcionality
        [Required]
        public required bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? LastUpdatedDate { get; set; }
        //[Required]
        //public required int IndividualOrGroupBasedPermissions { get; set; } = 0; // 0 - user, 1 - group, 2+ custom for future
    }
}
