using GlobalManagement.Controllers.GroupsController.dto;
using GlobalManagement.Database;
using GlobalManagement.Models._DefaultModels._User;
using GlobalManagement.Models.Groups;
using GlobalManagement.Models.Groups._Default;
using GlobalManagement.Models.Groups.Members;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalManagement.Controllers.GroupsController.sub_controller
{
    public class _AddMembers(GlobalDatabase context) : ControllerBase
    {
        protected readonly GlobalDatabase _context = context;
        public async Task<ActionResult> _Add(_AddMember member)
        {
            try
            {
                if (member is null)
                    return BadRequest();
                // 1
                GroupModel? group = await _context.Groups.Where(x => x.Uuid == member.GroupUUID).FirstOrDefaultAsync();
                if (group is null)
                    return NotFound(1);
                // 2
                User? user = await _context.Users.Where(x => x.Uuid == member.UserGuid).FirstOrDefaultAsync();
                if (user is null)
                    return NotFound(2);
                // 3
                GroupRoleModel? role = await _context.GroupRole.Where(x => x.Uuid == member.RoleGuid).FirstOrDefaultAsync();
                if (role is null)
                    return NotFound(3);
                GroupMember newMember = new GroupMember
                {
                    Uuid = Guid.NewGuid(),
                    GroupName = group.Name,
                    GroupUUID = group.Uuid,
                    Username = user.FullName,
                    UserGuid = user.Uuid,
                    Role = role.RoleName,
                    RoleGuid = role.Uuid,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                };
                await _context.GroupMembers.AddAsync(newMember);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
