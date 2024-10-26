using Microsoft.AspNetCore.Mvc;

namespace GlobalManagement.Controllers
{
    [ApiController]
    [Route("permission")]
    public class Permissions(){
        protected readonly GlobalDatabase _globalDatabase;
        public Permissions(GlobalDatabase globalDatabase){
            globalDatabase = _globalDatabase;
        };
        [httpGet]
        public async Task<IActionResult> GetAll(){
            try{
                List<List<_PermissionDTO_Get>> items = _globalDatabase.Permissions().ToListAsync();
                if(items == null)
                    return BadRequest("Failure to get all permissions");
                else if(items.length == 0)
                    return Ok("Empty");
                else
                    return Ok(items);
            } catch(Exception e){
                throw new Exception($"Failure to get all permission]\n{e.message}");
            };
        }
        [httpGet("single/{id}")]
        public async Task<IActionResult> Get(Guid id){
            try{
                if(id == Guid.Empty)
                    return BadRequest("Empty");
                PermissionModel pm = await _globalDatabase.Permissions.where(x => x.UUID == id).FIrstOrDefaultAsync();
                if(pm == null)
                    return NotFound();
                _PermissionDTO_Get pdg = new _PermissionDTO_Get();
                pdg.UUID = pm.UUID;
                pdg.User_UUID = pm.User_UUID;
                pdg.App_UUID = pm.App_UUID;
                pdg.Role = pm.Role;
                pdg.Role_UUID = pm.Role_UUID;     
                return Ok(pdg);
            } catch(Exception e){
                throw new Exception($"Failure to get permission with uuid: {id}\n{e.message}");
            };
        }
        public required Guid UUID { get; set; }
        public required Guid User_UUID { get; set; }
        public required string App_Name { get; set; }
        public required Guid App_UUID { get; set; }
        public required string Role { get; set; }
        public required Guid Role_UUID { get; set; }
        [httpPost]
        public async Task<IActionResult> Create(_PermissionDTO_Create pc){
            try{
                if(pc == null)
                    return BadRequest("Empty");
                PermissionModel pm = _globalDatabase.Permissions.where(x => x.User_UUID == pc.User_UUID && x.App_UUID == pc.App_UUID && x.Role_UUID == pc.Role_UUID);
                if(pm != null)
                    return BadRequest("Exist");
                PermissionModel new_pm = new PermissionModel();
                // user and app
                User _user = _globalDatabase.Users.Where(x => x.UUID == pc.UUID);
                _App _app = _globalDatabase.Application.Where(x => x.UUID == pc.App_UUID);
                // What Role to what app ??
                
            } catch(Exception e){
                throw new Exception($"Failure to create new permission for user with uuid: {id}\n{e.message}");
            }
        }
    }
    public _PermissionDTO_Create(){
        public required Guid User_UUID { get; set; }
        public required Guid App_UUID { get; set; }
        public required Guid Role_UUID { get; set; }
    }
    public _PermissionDTO_Get(){
        public required Guid UUID { get; set; }
        public required Guid User_UUID { get; set; }
        public required string App_Name { get; set; }
        public required Guid App_UUID { get; set; }
        public required string Role { get; set; }
        public required Guid Role_UUID { get; set; }
    }
}