using System.ComponentModel.DataAnnotations;

namespace GlobalManagement.Controllers.GroupsController.dto
{
    public class _CreateGroup
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Hala { get; set; }
        public required string Section { get; set; }
        public required string Type { get; set; }
    }
}
