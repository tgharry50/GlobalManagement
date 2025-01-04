using System.ComponentModel.DataAnnotations;

namespace GlobalManagement.Controllers.ApplicationsController.dto
{
    public class _AddApp
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Address { get; set; }
    }
}
