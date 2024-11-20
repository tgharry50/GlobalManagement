using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalManagement.Models.AppModel
{
    public class App
    {
        // Opis aplikacji
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, Key]
        public Guid Uuid { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Description { get; set; }
        [Required]
        public required string Address { get; set; }
        [Required]
        public required bool IsActive { get; set; }
        [Required]
        public required DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
