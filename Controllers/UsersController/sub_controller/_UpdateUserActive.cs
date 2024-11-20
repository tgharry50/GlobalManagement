﻿using GlobalManagement.Database;
using GlobalManagement.Models._DefaultModels._User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalManagement.Controllers.UsersController.sub_controller
{
    public class UpdateUserActive(GlobalDatabase context) : ControllerBase
    {
        protected readonly GlobalDatabase Context = context;
        public async Task<IActionResult> _Update(Guid uuid)
        {
            try
            {
                User? user = await Context.Users.FirstOrDefaultAsync(x => x.Uuid == uuid);
                if (user == null)
                {
                    return NotFound();
                }
                user.IsActive = !user.IsActive;
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