using GlobalManagement.Controllers.PermissionsController.dto;
using GlobalManagement.Database;
using GlobalManagement.Models._DefaultModels._Roles._GlobalRoles;
using GlobalManagement.Models.AppModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalManagement.Controllers.PermissionsController.sub_controller
{
    public class _AddPermissionsGlobal(GlobalDatabase _context) : ControllerBase
    {
        protected readonly GlobalDatabase _context = _context;
        public async Task<ActionResult> _Create(_AddPermsGlobal new_perms)
        {
            App? app = await _context.Application.FirstOrDefaultAsync(a => a.Name == "GlobalApp");
            if (app == null) return NotFound("App not found");
            try
            {
                DefaultGlobalRole new_permissions = new DefaultGlobalRole
                {
                    RoleName = new_perms.RoleName,
                    AppName = "GlobalApp",
                    AppUuid = app.Uuid,
                    CanAccessGlobal = new_perms.CanAccessGlobal,
                    CanBeEdited = new_perms.CanBeEdited,
                    CreateUser = new_perms.CreateUser,
                    UpdateUser = new_perms.UpdateUser,
                    DeleteUser = new_perms.DeleteUser,
                    CreateCustomRole = new_perms.CreateCustomRole,
                    UpdateCustomRole = new_perms.UpdateCustomRole,
                    DeleteCustomRole = new_perms.DeleteCustomRole,
                    CanCreateGroup = new_perms.CanCreateGroup,
                    CanDeleteGroup = new_perms.CanDeleteGroup,
                    CanUpdateGroup = new_perms.CanUpdateGroup,
                    Uuid = Guid.NewGuid()
                };
                _context.GlobalPermissions.Add(new_permissions);
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