using GlobalManagement.Controllers.GroupsController.dto;
using GlobalManagement.Database;
using GlobalManagement.Models.Groups;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalManagement.Controllers.GroupsController.sub_controller
{
    public class _GetAllGroups(GlobalDatabase context) : ControllerBase
    {
        private readonly GlobalDatabase _context = context;
        public async Task<ActionResult> _Get()
        {
            try
            {
                List<GroupModel> gm = await _context.Groups.ToListAsync();
                if (gm.Count == 0)
                    return NotFound();
                List<_GetGroup> gg = new List<_GetGroup>();
                foreach(GroupModel g in gm)
                {
                    gg.Add(new _GetGroup 
                    {
                        Uuid = g.Uuid, 
                        Name = g.Name,
                        Description = g.Description,
                        Hala = g.Hala,
                        IsActive = g.IsActive,
                        Section = g.Section,
                        Type = g.Type
                    });
                }
                if (gm.Count == 0)
                    return NotFound("2");
                return Ok(gm);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
