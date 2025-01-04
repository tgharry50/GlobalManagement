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
        // GET: Get all groups #DONE
        [HttpGet("all")]
        public async Task<ActionResult> GetAllGroups()
        {
            _GetAllGroups gag = new _GetAllGroups(_context);
            return await gag._Get();
        }
        // POST: Create a group #DONE
        [HttpPost("create")]
        public async Task<ActionResult> CreateGroup([FromForm] _CreateGroup createGroup)
        {
            _CreateGroups _CreateGroups = new _CreateGroups(_context);
            return await _CreateGroups._Create(createGroup);
        }
        // GET: Get all roles for group #DONE
        [HttpGet("roles/{uuid}")]
        public async Task<ActionResult> GetRoles(Guid uuid)
        {
            _GetRoles getRoles = new _GetRoles(_context);
            return await getRoles._Get(uuid);
        }
        // POST: Add a member to group #DONE
        [HttpPost("members/add")]
        public async Task<ActionResult> AddMember([FromForm] _AddMember addmember)
        {
            _AddMembers addMember = new _AddMembers(_context);
            return await addMember._Add(addmember);
        }
        // GET: Get all members for a group #DONE
        [HttpGet("members/get/{uuid}")]
        public async Task<ActionResult> GetAllMembers(Guid uuid)
        {
            _AllMembers members = new _AllMembers(_context);
            return await members._Get(uuid);
        }
        // DELETE: Delete a group #DONE
        [HttpDelete("delete/{uuid}")]
        public async Task<ActionResult> DeleteGroup(Guid uuid)
        {
            _DeleteGroup delete = new _DeleteGroup(_context);
            return await delete._Delete(uuid);
        }
        // PUT: ACTIVE/INACTIVE a group #DONE
        [HttpPut("change/{uuid}")]
        public async Task<ActionResult> ChangeGroupStatus(Guid uuid)
        {
            _ChangeGroupStatus cgs = new(_context);
            return await cgs.Change(uuid);
        }
        // PUT: Edit a group
        [HttpPut("edit/{uuid}")]
        public async Task<ActionResult> EditGroup(Guid uuid, [FromForm] _EditGroup new_data) // < Edit class
        {
            _EditGroups eg = new(_context);
            return await eg._Edit(uuid, new_data);
        }
        // DELETE: Remove user from group
        [HttpDelete("member/remove/{uuid}")]
        public async Task<ActionResult> RemoveMember(Guid uuid)
        {
            return Ok();
        }
        // PUT: Edit rank
        [HttpPut("member/rank/{uuid}")]
        public async Task<ActionResult> ChangeRank(Guid uuid)
        {
            return Ok();
        }
    }
}
