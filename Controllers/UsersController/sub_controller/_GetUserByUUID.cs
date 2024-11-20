using GlobalManagement.Controllers.UsersController._dto;
using GlobalManagement.Database;
using GlobalManagement.Models._DefaultModels._User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalManagement.Controllers.UsersController.sub_controller
{
    public class GetUserByUuid(GlobalDatabase context) : ControllerBase
    {
        protected readonly GlobalDatabase Context = context;

        public async Task<IActionResult> _Get(Guid uuid)
        {
            try
            {
                if (uuid == Guid.Empty)
                    return NotFound();
                User? user = await Context.Users.FirstOrDefaultAsync(x => x.Uuid == uuid);
                if (user == null)
                    return NotFound();
                GetUserdto result = new()
                {
                    Uuid = user.Uuid,
                    UserName = user.UserName,
                    Password = user.Password,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    FullName = user.FullName,
                    Email = user.Email,
                    Card = user.Card,
                    Pin = user.Pin,
                    Image = user.Image,
                    IsActive = user.IsActive,
                    CreatedDate = user.CreatedDate,
                };
                return Ok(result);
            } catch
            {
                return BadRequest();
            }
        }
    }
}
