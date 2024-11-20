using GlobalManagement.Database;
using GlobalManagement.Models._DefaultModels._User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalManagement.Controllers.LoginLogoutController.sub_controller
{
    [ApiController]
    [Route("logout")]
    public class Logout(GlobalDatabase Context) : ControllerBase
    {
        protected readonly GlobalDatabase Context = Context;
        [HttpPost]
        public async Task<IActionResult> _Logout(Guid uuid)
        {
            if (uuid == Guid.Empty) return NotFound();
            try
            {
                User? user = await Context.Users.FirstOrDefaultAsync(x => x.Uuid == uuid);
                if (user == null) return NotFound();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
