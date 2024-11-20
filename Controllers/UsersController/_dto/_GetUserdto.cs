using System.ComponentModel.DataAnnotations;

namespace GlobalManagement.Controllers.UsersController._dto
{
    public class GetUserdto
    {
        public Guid Uuid { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? FullName { get; set; }
        public string Email { get; set; }
        public string? Card { get; set; }
        public int Pin { get; set; }
        public string? Image { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
