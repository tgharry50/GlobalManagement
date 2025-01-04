using GlobalManagement.Controllers.UsersController._dto;
using GlobalManagement.Database;
using GlobalManagement.Models._DefaultModels._User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalManagement.Controllers.UsersController.sub_controller
{
    public class UpdateUserBasic(GlobalDatabase context) : ControllerBase
    {
        protected readonly GlobalDatabase Context = context;

        public async Task<IActionResult> _Update(Guid uuid, UpdateUserBasicdto dto)
        {
            try
            {
                User? user = await Context.Users.FirstOrDefaultAsync(x => x.Uuid == uuid);
                if (user == null)
                {
                    return NotFound();
                }
                user.UserName = dto.UserName.Trim();
                user.FirstName = dto.FirstName.Trim();
                user.LastName = dto.LastName.Trim();
                user.FullName = $"{dto.FirstName.Trim()} {dto.LastName.Trim()}";
                user.Email = dto.Email.Trim();
                user.Card = dto.Card;
                user.Pin = dto.Pin;
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
