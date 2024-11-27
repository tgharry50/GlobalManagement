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
        [HttpGet("gap")]
        public async Task<ActionResult> GetAllRolesFromSpecificApp(string app)
        {
            _GetAllRolesFromSpecificApp garfsa = new(_context);
            return await garfsa._Get(AppTypes.AppType[app]);
        }
    }
    public class AppTypes()
    {
        public static Dictionary<string, int> AppType { get; set; } = new Dictionary<string, int> { { "GlobalApp", 1 }, { "ControlReport", 2 } };
    }
}
