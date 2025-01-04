using GlobalManagement.Controllers.GroupsController.dto;
using GlobalManagement.Database;
using GlobalManagement.Models.Groups;
using GlobalManagement.Models.Groups._Default;
using GlobalManagement.Models.Groups.Members;
using GlobalManagement.Models.Groups.Permissions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalManagement.Controllers.GroupsController.sub_controller
{
    public class _EditGroups(GlobalDatabase _context) : ControllerBase
    {
        protected readonly GlobalDatabase _context = _context;
        public async Task<ActionResult> _Edit(Guid uuid, _EditGroup new_data)
        {
            if (uuid == Guid.Empty) return BadRequest();
            if (new_data is null) return BadRequest();
            try
            {
                // Base group
                GroupModel? group = await _context.Groups.Where(x => x.Uuid == uuid).FirstOrDefaultAsync();
                if (group is null)
                    return NotFound();
                group.Name = new_data.Name;
                group.Description = new_data.Description;
                group.Hala = new_data.Hala;
                group.Section = new_data.Section;
                // Other things
                List<GroupRoleModel> lgr = await _context.GroupRole.Where(x=>x.GroupUuid == group.Uuid).ToListAsync();
                foreach (GroupRoleModel gr in lgr)
                {
                    gr.GroupName = new_data.Name;
                }
                //
                List<GroupPermissions> groupPermissions = await _context.GroupPermissions.Where(x => x.GroupUuid == group.Uuid).ToListAsync();
                foreach (GroupPermissions gp in groupPermissions)
                {
                    gp.GroupName = new_data.Name;
                }
                //
                List<GroupMember> lgm = await _context.GroupMembers.Where(x => x.GroupUUID == group.Uuid).ToListAsync();
                foreach (GroupMember gm in lgm)
                {
                    gm.GroupName = new_data.Name;
                }
                await _context.SaveChangesAsync();
                return Ok();
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
