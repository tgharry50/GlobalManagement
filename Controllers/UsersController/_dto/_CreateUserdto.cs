namespace GlobalManagement.Controllers.UsersController._dto
{
    public class CreateUserdto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? FullName { get; set; }
        public string Email { get; set; }
        public string? Card { get; set; }
        public int Pin { get; set; }
    }
}
