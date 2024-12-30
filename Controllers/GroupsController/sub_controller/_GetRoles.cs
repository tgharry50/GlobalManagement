using GlobalManagement.Controllers.GroupsController.dto;
using GlobalManagement.Database;
using GlobalManagement.Models.Groups._Default;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalManagement.Controllers.GroupsController.sub_controller
{
    public class _GetRoles(GlobalDatabase context) : ControllerBase
    {
        protected readonly GlobalDatabase _context = context;
        public async Task<ActionResult> _Get(Guid uuid)
        {
            try
            {
                List<GroupRoleModel> groupRoleModels = await _context.GroupRole.Where(x => x.GroupUuid == uuid).ToListAsync();
                List<_GetRolesForAdding> result = new();
                foreach(GroupRoleModel r in groupRoleModels)
                {
                    result.Add(new _GetRolesForAdding { Uuid = r.Uuid, RoleName = r.RoleName });
                }
                if(groupRoleModels.Count < 0)
                    return NotFound();
                return Ok(result);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 
    }
}
