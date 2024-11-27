using GlobalManagement.Controllers.GroupsController.sub_controller;
using GlobalManagement.Database;
using Microsoft.AspNetCore.Mvc;

namespace GlobalManagement.Controllers.GroupsController
{
    [ApiController]
    [Route("group")]
    public class GroupController : ControllerBase
    {
        private readonly GlobalDatabase _context;
        public GroupController(GlobalDatabase context)
        {
            _context = context;
        }
        [HttpGet("all")]
        public async Task<ActionResult> GetAllGroups()
        {
            _GetAllGroups gag = new _GetAllGroups(_context);
            return await gag._Get();
        }  
    }
}
