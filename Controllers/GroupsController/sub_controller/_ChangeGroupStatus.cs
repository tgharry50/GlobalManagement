using GlobalManagement.Database;
using GlobalManagement.Models.Groups;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalManagement.Controllers.GroupsController.sub_controller
{
    public class _ChangeGroupStatus(GlobalDatabase _context) : ControllerBase
    {
        protected readonly GlobalDatabase _context = _context;
        public async Task<ActionResult> Change(Guid uuid)
        {
            if (uuid == Guid.Empty) return BadRequest();
            try
            {
                GroupModel? group = await _context.Groups.Where(x => x.Uuid == uuid).FirstOrDefaultAsync();
                if (group is null)
                    return NotFound();
                group.IsActive = !group.IsActive;
                await _context.SaveChangesAsync();
                return Ok();
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
