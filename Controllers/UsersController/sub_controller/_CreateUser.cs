using GlobalManagement.Controllers.UsersController._dto;
using GlobalManagement.Database;
using GlobalManagement.Models._DefaultModels._User;
using Microsoft.AspNetCore.Mvc;

namespace GlobalManagement.Controllers.UsersController.sub_controller
{
    public class CreateUser(GlobalDatabase context) : ControllerBase
    {
        protected readonly GlobalDatabase Context = context;

        public async Task<IActionResult> _Create(CreateUserdto dto)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                User user = new User
                {
                    Uuid = Guid.NewGuid(),
                    UserName = dto.UserName,
                    Password = dto.Password,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    FullName = dto.FullName,
                    Email = dto.Email,
                    Card = dto.Card,
                    Pin = dto.Pin,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                };
                Context.Users.Add(user);
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
