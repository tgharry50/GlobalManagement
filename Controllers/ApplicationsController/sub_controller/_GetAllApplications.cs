using GlobalManagement.Controllers.ApplicationsController.dto;
using GlobalManagement.Database;
using GlobalManagement.Models.AppModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalManagement.Controllers.ApplicationsController.sub_controller
{
    public class _GetAllApplications(GlobalDatabase context) : ControllerBase
    {
        private readonly GlobalDatabase _context = context;
        public async Task<ActionResult> _GetAll()
        {
            try
            {
                List<App> a = await _context.Application.ToListAsync();
                if (a.Count == 0)
                    return NotFound();
                List<_ReturnAllApplications> r = new List<_ReturnAllApplications>();
                foreach(App app in a)
                {
                    r.Add(new _ReturnAllApplications 
                    {
                        Uuid = app.Uuid,
                        Name = app.Name,
                        Description = app.Description,
                        Address = app.Address,
                        IsActive = app.IsActive
                    });
                }
                if (r.Count == 0)
                    return NotFound();
                return Ok(r);
            } catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
