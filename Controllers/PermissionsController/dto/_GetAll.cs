using GlobalManagement.Database;
using Microsoft.AspNetCore.Mvc;

namespace GlobalManagement.Controllers.PermissionsController.dto
{
    public class _GetAll(GlobalDatabase context) : ControllerBase
    {
        private readonly GlobalDatabase _context = context;
       
    }
}
