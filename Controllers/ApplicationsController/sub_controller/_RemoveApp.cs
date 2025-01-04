using GlobalManagement.Database;
using GlobalManagement.Models.AppModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalManagement.Controllers.ApplicationsController.sub_controller
{
    public class _RemoveApp(GlobalDatabase context) : ControllerBase
    {
        private readonly GlobalDatabase _context = context;
        public async Task<ActionResult> _Remove(Guid uuid)
        {
            try
            {
                App? a = await _context.Application.FirstOrDefaultAsync(x => x.Uuid == uuid);
                if (a == null)
                    return NotFound();
                _context.Application.Remove(a);
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
