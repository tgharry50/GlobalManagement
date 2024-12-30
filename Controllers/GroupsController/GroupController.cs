using GlobalManagement.Controllers.GroupsController.dto;
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
        [HttpPost("create")]
        public async Task<ActionResult> CreateGroup([FromForm] _CreateGroup createGroup)
        {
            _CreateGroups _CreateGroups = new _CreateGroups(_context);
            return await _CreateGroups._Create(createGroup);
        }
        [HttpGet("roles/{uuid}")]
        public async Task<ActionResult> GetRoles(Guid uuid)
        {
            _GetRoles getRoles = new _GetRoles(_context);
            return await getRoles._Get(uuid);
        }
        [HttpPost("members/add")]
        public async Task<ActionResult> AddMember([FromForm] _AddMember addmember)
        {
            _AddMembers addMember = new _AddMembers(_context);
            return await addMember._Add(addmember);
        }
        [HttpGet("members/get/{uuid}")]
        public async Task<ActionResult> GetAllMembers(Guid uuid)
        {
            _AllMembers members = new _AllMembers(_context);
            return await members._Get(uuid);
        }
        [HttpDelete("delete/{uuid}")]
        public async Task<ActionResult> DeleteGroup(Guid uuid)
        {

        }
    }
}
