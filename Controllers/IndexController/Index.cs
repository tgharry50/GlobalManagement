using Microsoft.AspNetCore.Mvc;

namespace GlobalManagement.Controllers
{
    [ApiController]
    [Route("index")]
    public class Index : ControllerBase
    {
        private readonly GlobalManagement _globalManagement;
        public Index(GlobalManagement globalManagement){
            globalManagement = _globalManagement;
        }

        public async Task<IActionResult> Get(){
            try{
                
            }
        }
    }

}
