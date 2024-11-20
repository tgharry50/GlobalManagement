using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GlobalManagement.Logging
{
    public class _Log_Model
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, Key]
        public Guid Uuid { get; set; }
        [Required]
        public required string Class { get; set; }
        [Required]
        public required string Message { get; set; }
        [Required]
        public required TimeSpan End { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
