using GlobalManagement.Database;
using GlobalManagement.Models._DefaultModels._User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalManagement.Controllers.UsersController.sub_controller
{
    public class RemoveUser(GlobalDatabase context) : ControllerBase
    {
        protected readonly GlobalDatabase Context = context;

        public async Task<IActionResult> _Remove(Guid uuid)
        {
            try
            {
                User? user = await Context.Users.FirstOrDefaultAsync(u => u.Uuid == uuid);
                if (user == null) return NotFound();
                //Context.Users.Remove(user);
                //await Context.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
