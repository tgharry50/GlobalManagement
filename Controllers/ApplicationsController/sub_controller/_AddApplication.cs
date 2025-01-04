using GlobalManagement.Controllers.ApplicationsController.dto;
using GlobalManagement.Database;
using GlobalManagement.Models.AppModel;
using Microsoft.AspNetCore.Mvc;

namespace GlobalManagement.Controllers.ApplicationsController.sub_controller
{
    public class _AddApplication(GlobalDatabase _context) : ControllerBase
    {
        private readonly GlobalDatabase _context = _context;
        public async Task<ActionResult> _Add(_AddApp app)
        {
            try
            {
                App a = new App
                {
                    Uuid = Guid.NewGuid(),
                    Name = app.Name,
                    Description = app.Description,
                    Address = app.Address,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                };
                await _context.Application.AddAsync(a);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
