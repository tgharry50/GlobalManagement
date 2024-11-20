using GlobalManagement.Controllers.LoginLogoutController._dto;
using GlobalManagement.Controllers.LoginLogoutController.sub_controller;
using GlobalManagement.Database;
using Microsoft.AspNetCore.Mvc;

namespace GlobalManagement.Controllers.LoginLogoutController
{
    [ApiController]
    [Route(("access"))]
    public class LoginLogoutController(GlobalDatabase context) : ControllerBase
    {
        protected readonly GlobalDatabase Context = context;

        // POST: Login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            Login login = new(Context);
            return await login._Login(dto);
        }
        // POST: Logout
        [HttpPost("logout")]
        public async Task<IActionResult> Logout(Guid uuid)
        {
            Logout logout = new(Context);
            return await logout._Logout(uuid);
        }
    }
}
