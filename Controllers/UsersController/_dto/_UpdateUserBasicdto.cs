using System.ComponentModel.DataAnnotations;

namespace GlobalManagement.Controllers.UsersController._dto
{
    public class UpdateUserBasicdto
    {
        public required string UserName { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string? Card { get; set; }
        public required int Pin { get; set; }
    }
}
