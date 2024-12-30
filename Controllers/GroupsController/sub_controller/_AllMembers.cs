using GlobalManagement.Controllers.GroupsController.dto;
using GlobalManagement.Database;
using GlobalManagement.Models.Groups.Members;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalManagement.Controllers.GroupsController.sub_controller
{
    public class _AllMembers(GlobalDatabase context) : ControllerBase
    {
        protected readonly GlobalDatabase _context = context;
        public async Task<ActionResult> _Get(Guid uuid)
        {
            try
            {
                if (uuid == Guid.Empty || uuid == null)
                    return BadRequest();
                List<GroupMember> getMembers = await _context.GroupMembers.Where(x => x.GroupUUID == uuid).ToListAsync();
                if (getMembers.Count <= 0)
                    return NotFound();
                List<_GetMember> gms = new();
                foreach(GroupMember gm in getMembers)
                {
                    gms.Add(new _GetMember
                    {
                        Uuid = gm.Uuid,
                        GroupName = gm.GroupName,
                        GroupUUID = gm.GroupUUID,
                        Username = gm.Username,
                        UserGuid = gm.UserGuid,
                        Role = gm.Role,
                        RoleGuid = gm.RoleGuid,
                        IsActive = gm.IsActive
                    });
                }
                if (gms.Count <= 0)
                    return NotFound();
                return Ok(gms);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
