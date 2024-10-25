using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GlobalManagement.Models.AppModel._App
{
    public class App_Options
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, Key]
        public Guid UUID { get; set; }
        [Required]
        public required Guid App_UUID { get; set; } // WHAT APP
        // PERMISSIONS <- In case of future
    }
}
