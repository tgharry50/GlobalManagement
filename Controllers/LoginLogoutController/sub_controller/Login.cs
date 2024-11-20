using System.Diagnostics;
using GlobalManagement.AddinationalFunctions;
using GlobalManagement.Controllers.LoginLogoutController._dto;
using GlobalManagement.Database;
using GlobalManagement.Models._DefaultModels._User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalManagement.Controllers.LoginLogoutController.sub_controller
{
    [ApiController]
    [Route("login")]
    public class Login(GlobalDatabase Context) : ControllerBase
    {
        protected readonly GlobalDatabase Context = Context;
        // POST: Login
        [HttpPost]
        public async Task<IActionResult> _Login(LoginDto dto)
        {
            Stopwatch sw = new();
            Logging.Logging log = new(Context);
            sw.Start();
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                Hashing hs = new Hashing();
                User? user = await Context.Users.FirstOrDefaultAsync(x => x.UserName == dto.UserName);
                if (user == null) return NotFound();
                if (!hs.Compare(dto.Password, user.Password)) return Unauthorized();
                if (!user.IsActive) return Unauthorized("InActive");
                sw.Stop();
                await log.LogToDatabase("SUCCESS", "Login",$"User: {user.FullName} has logged in", sw.Elapsed);
                return Ok();
            }
            catch
            {
                sw.Stop();
                await log.LogToDatabase("FATAL", "Login", "Failure to login", sw.Elapsed);
                return BadRequest();
            }

        }
    }
}
