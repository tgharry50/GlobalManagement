using GlobalManagement.Controllers.UsersController._dto;
using GlobalManagement.Controllers.UsersController.sub_controller;
using GlobalManagement.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GlobalManagement.Controllers.UsersController
{
    [ApiController]
    [Route("users")]
    public class UserController(GlobalDatabase context) : ControllerBase
    {
        protected readonly GlobalDatabase Context = context;

        // GET: Get all users #DONE
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            GetUsers gu = new GetUsers(Context);
            return await gu._Get();
        }
        // GET: Get user by uuid #DONE
        [HttpGet("{uuid}")]
        public async Task<IActionResult> GetUser(Guid uuid)
        {
            GetUserByUuid gu = new(Context);
            return await gu._Get(uuid);
        }
        // POST: Create user
        [HttpPost()]
        public async Task<IActionResult> CreateUser(CreateUserdto dto)
        {
            CreateUser cu = new(Context);
            return await cu._Create(dto);
        }
        // DELETE: Remove user 
        [HttpPost("delete/{uuid}")]
        public async Task<IActionResult> RemoveUser(string uuid)
        {
            Guid s = new Guid(uuid);
            RemoveUser ru = new(Context);
            return await ru._Remove(s);
        }
        //
        // UPDATE: Update user Basic < DONE
        [HttpPut("edit/{uuid}")]
        public async Task<IActionResult> UpdateUserBasic(Guid uuid, UpdateUserBasicdto dto)
        {
            UpdateUserBasic uub = new(Context);
            return await uub._Update(uuid, dto);
        }
        // UPDATE: Update user Password
        [HttpPut("password/{uuid}")]
        public async Task<IActionResult> UpdateUserPassword(Guid uuid, UpdateUserPassworddto dto)
        {
            UpdateUserPassword uup = new(Context);
            return await uup._Update(uuid, dto);
        }
        // UPDATE: Force update user password
        [HttpPut("force")]
        public async Task<IActionResult> ForceUpdateUserPassword(Guid uuid)
        {
            ForceUpdateUserPassword fuup = new(Context);
            return await fuup._Update(uuid);
        }
        // UPDATE: Update user active
        [HttpPut("active/{uuid}")]
        public async Task<IActionResult> UpdateUserActive(Guid uuid)
        {
            UpdateUserActive uua = new(Context);
            return await uua._Update(uuid);
        }
        [HttpPut("deactive/{uuid}")]
        public async Task<IActionResult> UpdateUserDeactive(Guid uuid)
        {
            UpdateUserActive uua = new(Context);
            return await uua._Update(uuid);
        }
    }
}
