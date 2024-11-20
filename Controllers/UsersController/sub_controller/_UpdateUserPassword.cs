using GlobalManagement.Controllers.UsersController._dto;
using GlobalManagement.Database;
using GlobalManagement.Models._DefaultModels._User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalManagement.Controllers.UsersController.sub_controller
{
    public class UpdateUserPassword(GlobalDatabase context) : ControllerBase
    {
        protected readonly GlobalDatabase Context = context;

        public async Task<IActionResult> _Update(Guid uuid, UpdateUserPassworddto dto)
        {
            try
            {
                User? user = await Context.Users.FirstOrDefaultAsync(x => x.Uuid == uuid);
                if (user == null)
                {
                    return NotFound();
                }
                if(dto.Password == null)
                {
                    return BadRequest();
                }
                user.Password = dto.Password;
                await Context.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
