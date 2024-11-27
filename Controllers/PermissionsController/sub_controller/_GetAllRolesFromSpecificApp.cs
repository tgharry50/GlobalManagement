using GlobalManagement.Controllers.PermissionsController.dto;
using GlobalManagement.Database;
using GlobalManagement.Models._DefaultModels._Roles._ControlReportRoles;
using GlobalManagement.Models._DefaultModels._Roles._GlobalRoles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalManagement.Controllers.PermissionsController.sub_controller
{
    public class _GetAllRolesFromSpecificApp(GlobalDatabase context) : ControllerBase
    {
        private readonly GlobalDatabase _context = context;
        public async Task<ActionResult> _Get(int i) {
            if (i <= 0)
                return BadRequest();
            try
            {
                switch (i)
                {
                    case (1): // Global App
                        List<DefaultGlobalRole> roles = await _context.GlobalPermissions.ToListAsync();
                        if (roles is null)
                            return NotFound();
                        List<_GetGlobalAppPermissions> r = new List<_GetGlobalAppPermissions>();
                        foreach (DefaultGlobalRole ro in roles)
                        {
                            r.Add(new _GetGlobalAppPermissions
                            {
                                Uuid = ro.Uuid,
                                AppName = ro.AppName,
                                AppUuid = ro.AppUuid,
                                CanAccessGlobal = ro.CanAccessGlobal,
                                CanBeEdited = ro.CanBeEdited,
                                CanCreateGroup = ro.CanCreateGroup,
                                CanDeleteGroup = ro.CanDeleteGroup,
                                CanUpdateGroup = ro.CanUpdateGroup,
                                CreateCustomRole = ro.UpdateCustomRole,
                                CreateUser = ro.CreateUser,
                                DeleteUser = ro.DeleteUser,
                                DeleteCustomRole = ro.DeleteCustomRole,
                                RoleName = ro.RoleName,
                                UpdateCustomRole = ro.UpdateCustomRole,
                                UpdateUser = ro.UpdateUser
                            });
                        }
                        return Ok(r);
                    case (2): // Global App
                        List<DefaultControlReportRole> roles2 = await _context.ControlReportPermissions.ToListAsync();
                        if (roles2 is null)
                            return NotFound();
                        List<_GetControlReportPermissions> n = new List<_GetControlReportPermissions>();
                        foreach (DefaultControlReportRole r2 in roles2)
                        {
                            n.Add(new _GetControlReportPermissions
                            {
                                UUID = r2.UUID,
                                AppName = r2.AppName,
                                AppUuid = r2.AppUuid,
                                CanBeEdited = r2.CanBeEdited,
                                RoleName = r2.RoleName,
                                CanCreateDeviation = r2.CanCreateDeviation,
                                CanCreateEcr = r2.CanCreateEcr,
                                CanCreateIntervention = r2.CanCreateIntervention,
                                CanCreateReference = r2.CanCreateReference,
                                CanCreateTask = r2.CanCreateTask,
                                CanDeleteDeviation = r2.CanDeleteDeviation,
                                CanDeleteEcr = r2.CanDeleteEcr,
                                CanDeleteIntervention = r2.CanDeleteIntervention,
                                CanDeleteReference = r2.CanDeleteReference,
                                CanDeleteTask = r2.CanDeleteTask,
                                CanReadDeviation = r2.CanReadDeviation,
                                CanReadEcr = r2.CanReadEcr,
                                CanReadIntervention = r2.CanReadIntervention,
                                CanReadReference = r2.CanReadReference,
                                CanReadTask = r2.CanReadTask,
                                CanUpdateDeviation = r2.CanReadDeviation,
                                CanUpdateEcr = r2.CanUpdateEcr,
                                CanUpdateIntervention = r2.CanUpdateIntervention,
                                CanUpdateReference = r2.CanUpdateReference,
                                CanUpdateTask = r2.CanUpdateTask,
                                CanUseApp = r2.CanUseApp,
                                HasAllPrivelage = r2.HasAllPrivelage
                            });
                        }
                        return Ok(n);
                    default:
                        return NotFound();

                };
            } catch(Exception e)
            {
                return BadRequest(e.Message);
            }
                
        }
    }
}
