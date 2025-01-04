using GlobalManagement.Controllers.PermissionsController.dto;
using GlobalManagement.Controllers.PermissionsController.sub_controller;
using GlobalManagement.Database;
using Microsoft.AspNetCore.Mvc;

namespace GlobalManagement.Controllers.PermissionsController
{
    [ApiController]
    [Route("permission")]
    public class PermissionController(GlobalDatabase context) : ControllerBase
    {
        private readonly GlobalDatabase _context = context;
        [HttpGet("gap/{app}")]
        public async Task<ActionResult> GetAllRolesFromSpecificApp(string app)
        {
            _GetAllRolesFromSpecificApp garfsa = new(_context);
            return await garfsa._Get(AppTypes.AppType[app]);
        }
        // GET: User perms
        [HttpGet("user/{uuid}")]
        public async Task<IActionResult> GetUserPerms(Guid uuid)
        {
            _GetUserPerms gup = new(_context);
            return await gup._Get(uuid);
        }
        // GET: All perms
        [HttpGet("all")]
        public async Task<ActionResult> GetAllPerms()
        {
            //_GetAllPerms gap = new(_context);
            //return await gap._Get();
            return Ok();
        }
        // POST: Create perms for global app
        [HttpPost("create/global/{app}")]
        public async Task<ActionResult> CreatePerms([FromForm] _AddPermsGlobal perms)
        {
            _AddPermissionsGlobal ap = new(_context);
            return await ap._Create(perms);
        }
        // POST: Create perms for control report
        [HttpPost("create/control/{app}")]
        public async Task<ActionResult> CreatePerms([FromForm] _AddPermsControler perms)
        {
            _AddPermissionsControl ac = new(_context);
            return await ac._Add(perms);
        }
        // DELETE: Remove perms from an app
        [HttpDelete("delete/{uuid}")]
        public async Task<ActionResult> RemovePerms(Guid uuid)
        {
            //_RemovePerms rp = new(_context);
            //return await rp._Remove(uuid);
            return Ok();

        }
        // PUT: Update perms for a specific role

    }
    public class AppTypes()
    {
        public static Dictionary<string, int> AppType { get; set; } = new Dictionary<string, int> { { "GlobalApp", 1 }, { "ControlReport", 2 } };
    }
}
