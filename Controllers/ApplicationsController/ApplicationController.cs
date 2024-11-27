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
    }
}
