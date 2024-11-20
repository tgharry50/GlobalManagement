using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GlobalManagement.Models.Groups
{
    // Struktura grupy
    // Powiązane jest to z Group Member który łączy się z dwoma rzeczami Group Member, czyli użytkownik danej grupy
    // Group Member łączy się z _Group_Role_Model, tam definiowana jest struktura wszystkich funkcji użytkownika w grupie
    // Group Permission definiuje gdzie która grupa ma dostępy, narazie nie ma to znaczenia, może w przyszłości gdzie która grupe gdzie może wejść

    public class GroupModel
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, Key]
        public required Guid Uuid { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Description { get; set; }
        [Required]
        public required string Hala { get; set; }
        [Required]
        public required string Section { get; set; }
        [Required]
        public required bool IsActive { get; set; }
        [Required]
        public required DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
