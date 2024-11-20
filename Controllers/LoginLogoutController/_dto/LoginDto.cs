using GlobalManagement.Database;
using GlobalManagement.Models._DefaultModels._User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalManagement.Controllers.LoginLogoutController._dto
{
    public class LoginDto
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
