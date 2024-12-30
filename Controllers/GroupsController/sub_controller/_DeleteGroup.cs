using GlobalManagement.Database;
using GlobalManagement.Models.Groups;
using GlobalManagement.Models.Groups._Default;
using GlobalManagement.Models.Groups.Members;
using GlobalManagement.Models.Groups.Permissions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalManagement.Controllers.GroupsController.sub_controller
{
    public class _DeleteGroup(GlobalDatabase context) : ControllerBase
    {
        protected readonly GlobalDatabase _context = context;
        public async Task<ActionResult> _Delete(Guid uuid)
        {
            try
            {
                if (uuid == Guid.Empty)
                    return BadRequest();
                GroupModel? group = await _context.Groups.Where(x => x.Uuid == uuid).FirstOrDefaultAsync();
                if (group is null)
                    return NotFound();
                List<GroupPermissions> permissions = await _context.GroupPermissions.Where(x => x.GroupUuid == group.Uuid).ToListAsync();
                if (permissions.Count > 0)
                    _context.GroupPermissions.RemoveRange(permissions);
                List<GroupRoleModel> model = await _context.GroupRole.Where(x => x.GroupUuid == group.Uuid).ToListAsync();
                if (model.Count > 0)
                    _context.GroupRole.RemoveRange(model);
                List<GroupMember> members = await _context.GroupMembers.Where(x => x.GroupUUID == group.Uuid).ToListAsync();
                if (members.Count > 0)
                    _context.GroupMembers.RemoveRange(members);
                _context.Remove(group);
                await _context.SaveChangesAsync();
                return Ok();
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
