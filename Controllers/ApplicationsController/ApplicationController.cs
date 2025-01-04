using GlobalManagement.Controllers.ApplicationsController.dto;
using GlobalManagement.Controllers.ApplicationsController.sub_controller;
using GlobalManagement.Database;
using Microsoft.AspNetCore.Mvc;

namespace GlobalManagement.Controllers.ApplicationsController
{
    [ApiController]
    [Route("application")]
    public class ApplicationController(GlobalDatabase context) : ControllerBase
    {
        private readonly GlobalDatabase _context = context;
        // GET: fetch all applications 
        [HttpGet("all")]
        public async Task<ActionResult> GetAllApplications()
        {
            _GetAllApplications gap = new (_context);
            return await gap._GetAll();
        }
        // POST: Add application
        [HttpPost("create")]
        public async Task<ActionResult> AddApplication([FromForm] _AddApp app)
        {
            _AddApplication ap = new(_context);
            return await ap._Add(app);
        }
        // PUT: Update Application
        [HttpPut("edit/{uuid}")]
        public async Task<ActionResult> EditApplication(Guid uuid, [FromForm] _EditApp edit)
        {
            _EditApplication ea = new(_context);
            return await ea._Edit(uuid, edit);
        }
        // DELETE: Remove Application
        [HttpDelete("delete/{uuid}")]
        public async Task<ActionResult> RemoveApplication(Guid uuid)
        {
            _RemoveApp ra = new(_context);
            return await ra._Remove(uuid);
        }
    }
}
