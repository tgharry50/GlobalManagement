using GlobalManagement.Controllers.ApplicationsController.dto;
using GlobalManagement.Database;
using GlobalManagement.Models.AppModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalManagement.Controllers.ApplicationsController.sub_controller
{
    public class _EditApplication(GlobalDatabase context) : ControllerBase
    {
        private readonly GlobalDatabase _context = context;
        public async Task<ActionResult> _Edit(Guid uuid, _EditApp edit)
        {
            try
            {
                App? a = await _context.Application.FirstOrDefaultAsync(x => x.Uuid == uuid);
                if (a == null)
                    return NotFound();
                a.Address = edit.Address;
                a.Description = edit.Description;
                a.Name = edit.Name;
                _context.Application.Update(a);
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
