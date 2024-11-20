using GlobalManagement.Controllers.UsersController._dto;
using GlobalManagement.Database;
using GlobalManagement.Models._DefaultModels._User;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalManagement.Controllers.UsersController.sub_controller
{
    public class GetUsers(GlobalDatabase context) : ControllerBase
    {
        protected readonly GlobalDatabase Context = context;

        public async Task<ActionResult> _Get() 
        {
            try
            {
                List<User> users = await Context.Users.ToListAsync();
                if (users.Count == 0)
                    return NotFound();
                List<GetUserdto> result = users.Select(user => new GetUserdto
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
                    })
                    .ToList();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
