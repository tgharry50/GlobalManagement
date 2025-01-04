using GlobalManagement.Database;
using GlobalManagement.Models._DefaultModels._Roles._ControlReportRoles;
using GlobalManagement.Models._DefaultModels._Roles._GlobalRoles;
using GlobalManagement.Models.Permissions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalManagement.Controllers.PermissionsController.dto
{
    public class _GetUserPerms(GlobalDatabase _context) : ControllerBase
    {
        private readonly GlobalDatabase _context = _context;
        public async Task<IActionResult> _Get(Guid uuid)
        {
            if (uuid == null)
            {
                return BadRequest("UUID is required");
            }
            try
            {
                PermissionModel? globalPermModel = await _context.ApplicationPermissions.FirstOrDefaultAsync(x => x.UserUuid == uuid && x.AppName == "GlobalApp");
                PermissionModel? controlPermModel = await _context.ApplicationPermissions.FirstOrDefaultAsync(x => x.UserUuid == uuid && x.AppName == "ControlReport");
                if (globalPermModel == null && controlPermModel == null)
                {
                    return NotFound("User has no permissions");
                }
                if (globalPermModel == null) { return BadRequest(); };
                if (controlPermModel == null) { return BadRequest(); };
                DefaultGlobalRole defaultGlobalRole = await _context.GlobalPermissions.Where(x => x.Uuid == globalPermModel.RoleUuid).FirstOrDefaultAsync();
                DefaultControlReportRole defaultControlReportRole = await _context.ControlReportPermissions.Where(x => x.UUID == controlPermModel.RoleUuid).FirstOrDefaultAsync();

                Perms perms = new()
                {
                    GlobalPermissions = defaultGlobalRole,
                    ControlReportRolePermission = defaultControlReportRole
                };

                return Ok(perms);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        public struct Perms()
        {
            public DefaultGlobalRole? GlobalPermissions { get; set; }
            public DefaultControlReportRole? ControlReportRolePermission { get; set; }
        }
    }
}