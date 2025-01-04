using GlobalManagement.Controllers.PermissionsController.dto;
using GlobalManagement.Database;
using GlobalManagement.Models._DefaultModels._Roles._ControlReportRoles;
using GlobalManagement.Models.AppModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalManagement.Controllers.PermissionsController.sub_controller
{
    public class _AddPermissionsControl(GlobalDatabase context) : ControllerBase
    {
        protected readonly GlobalDatabase _context = context;
        public async Task<ActionResult> _Add(_AddPermsControler new_perms)
        {
            if (new_perms is null)
                return BadRequest();
            try
            {
                App? app = await _context.Application.FirstOrDefaultAsync(a => a.Name == "ControlReport");
                if (app == null) return NotFound("App not found");
                DefaultControlReportRole new_permissions = new DefaultControlReportRole
                {
                    RoleName = new_perms.RoleName,
                    AppName = "ControlReport",
                    AppUuid = app.Uuid,
                    UUID = Guid.NewGuid(),
                    CanCreateReference = new_perms.CanCreateReference,
                    CanDeleteReference = new_perms.CanDeleteReference,
                    CanUpdateReference = new_perms.CanUpdateReference,
                    CanReadReference = new_perms.CanReadReference,
                    CanCreateIntervention = new_perms.CanCreateIntervention,
                    CanDeleteIntervention = new_perms.CanDeleteIntervention,
                    CanUpdateIntervention = new_perms.CanUpdateIntervention,
                    CanReadIntervention = new_perms.CanReadIntervention,
                    CanCreateTask = new_perms.CanCreateTask,
                    CanDeleteTask = new_perms.CanDeleteTask,
                    CanUpdateTask = new_perms.CanUpdateTask,
                    CanReadTask = new_perms.CanReadTask,
                    CanCreateEcr = new_perms.CanCreateEcr,
                    CanDeleteEcr = new_perms.CanDeleteEcr,
                    CanUpdateEcr = new_perms.CanUpdateEcr,
                    CanReadEcr = new_perms.CanReadEcr,
                    CanCreateDeviation = new_perms.CanCreateDeviation,
                    CanDeleteDeviation = new_perms.CanDeleteDeviation,
                    CanUpdateDeviation = new_perms.CanUpdateDeviation,
                    CanReadDeviation = new_perms.CanReadDeviation,
                    CanBeEdited = true,
                    HasAllPrivelage = false,
                    CanUseApp = true
                };
                _context.ControlReportPermissions.Add(new_permissions);
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
