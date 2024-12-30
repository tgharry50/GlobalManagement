using GlobalManagement.Controllers.GroupsController.dto;
using GlobalManagement.Database;
using GlobalManagement.Models.Groups;
using GlobalManagement.Models.Groups._Default;
using GlobalManagement.Models.Groups.Permissions;
using Microsoft.AspNetCore.Mvc;

namespace GlobalManagement.Controllers.GroupsController.sub_controller
{
    public class _CreateGroups(GlobalDatabase context) : ControllerBase
    {
        protected readonly GlobalDatabase _context = context;
        public async Task<ActionResult> _Create(_CreateGroup group)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                // Group
                GroupModel groupModel = new GroupModel
                {
                    Uuid = Guid.NewGuid(),
                    Name = group.Name,
                    Type = group.Type,
                    Description = group.Description,
                    Section = group.Section,
                    Hala = group.Hala,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                };
                // Roles
                GroupRoleModel role_Leader = new GroupRoleModel
                {
                    Uuid = Guid.NewGuid(),
                    GroupName = groupModel.Name,
                    GroupUuid = groupModel.Uuid,
                    RoleName = "Lider",
                    IsAdmin = true,
                    CanModifyGroup = true,
                    CanAddRoles = true,
                    CanAddUser = true,
                    CanModifyRoles = true,
                    CanModifyUser = true,
                    CanRemoveGroup = true,
                    CanRemoveRoles = true,
                    CanRemoveUser = true,
                    IsRoleRemovable = false,
                    CreatedAt = DateTime.Now,
                };
                GroupRoleModel role_Manager = new GroupRoleModel
                {
                    Uuid = Guid.NewGuid(),
                    GroupName = groupModel.Name,
                    GroupUuid = groupModel.Uuid,
                    RoleName = "Menadżer",
                    IsAdmin = false,
                    CanModifyGroup = false,
                    CanAddRoles = false,
                    CanAddUser = true,
                    CanModifyRoles = false,
                    CanModifyUser = false,
                    CanRemoveGroup = false,
                    CanRemoveRoles = false,
                    CanRemoveUser = true,
                    IsRoleRemovable = false,
                    CreatedAt = DateTime.Now,
                };
                GroupRoleModel role_User = new GroupRoleModel
                {
                    Uuid = Guid.NewGuid(),
                    GroupName = groupModel.Name,
                    GroupUuid = groupModel.Uuid,
                    RoleName = "Członek",
                    IsAdmin = false,
                    CanModifyGroup = false,
                    CanAddRoles = false,
                    CanAddUser = false,
                    CanModifyRoles = false,
                    CanModifyUser = false,
                    CanRemoveGroup = false,
                    CanRemoveRoles = false,
                    CanRemoveUser = false,
                    IsRoleRemovable = false,
                    CreatedAt = DateTime.Now,
                };
                // Group Permissions
                GroupPermissions permissions = new GroupPermissions
                {
                    Uuid = Guid.NewGuid(),
                    GroupName = groupModel.Name,
                    GroupUuid = groupModel.Uuid,
                    UsersCanAccessGlobalApp = true, // < Global App
                    UsersCanAccessReferenceHub = true // < Reference HUB
                };
                //
                await _context.Groups.AddAsync(groupModel); // 1
                await _context.GroupRole.AddRangeAsync(role_Leader, role_Manager, role_User); // 2
                await _context.GroupPermissions.AddAsync(permissions); // 3
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
