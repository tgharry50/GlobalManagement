using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GlobalManagement.Controllers.ApplicationsController.dto
{
    public class _ReturnAllApplications
    {
        public Guid Uuid { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Address { get; set; }
        public required bool IsActive { get; set; }
    }
}
