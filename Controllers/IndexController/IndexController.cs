using GlobalManagement.Database;
using Microsoft.AspNetCore.Mvc;

namespace GlobalManagement.Controllers.IndexController
{
    [ApiController]
    [Route("")]
    public class IndexController(GlobalDatabase Context) : ControllerBase
    {
        protected readonly GlobalDatabase Context = Context;
        // GET: Get logs using WebSocket
    }
}
