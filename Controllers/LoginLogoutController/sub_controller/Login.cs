using System.Diagnostics;
using GlobalManagement.AddinationalFunctions;
using GlobalManagement.Controllers.LoginLogoutController._dto;
using GlobalManagement.Database;
using GlobalManagement.Models._DefaultModels._Roles._GlobalRoles;
using GlobalManagement.Models._DefaultModels._User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalManagement.Controllers.LoginLogoutController.sub_controller
{
    public class Login(GlobalDatabase Context) : ControllerBase
    {
        protected readonly GlobalDatabase Context = Context;
        // POST: Login
        [HttpPost]
        public async Task<IActionResult> _Login(_LoginModel.Login dto)
        {
            Stopwatch sw = new();
            Logging.Logging log = new(Context);
            sw.Start();
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                // Before
                Hashing hs = new Hashing();
                User? user = await Context.Users.FirstOrDefaultAsync(x => x.UserName == dto._login);
                if (user == null) return NotFound();
                if (!hs.Compare(dto._password, user.Password)) return Unauthorized();
                if (!user.IsActive) return Unauthorized("InActive");
                // Fetch Permissions
                var ap = await Context.ApplicationPermissions.FirstOrDefaultAsync(x => x.UserUuid == user.Uuid);
                DefaultGlobalRole? dgr = await Context.GlobalPermissions.FirstOrDefaultAsync(x => x.Uuid == ap.RoleUuid);
                // Bind to server DTO
                _LoginModel.ReturnUserData rud = new _LoginModel.ReturnUserData
                {
                    card = user.Card,
                    email = user.Email,
                    firstname = user.FirstName,
                    lastname = user.LastName,
                    pin = user.Pin,
                    username = user.UserName,
                    uuid = user.Uuid
                };
                // Bind to server Permissions
                _LoginModel.ReturnUserDataPermissions rudp = new _LoginModel.ReturnUserDataPermissions
                {
                    // General
                    CanAccessGlobal = dgr.CanAccessGlobal,
                    CanBeEdited = dgr.CanBeEdited,
                    // Users
                    CreateUser = dgr.CreateUser,
                    UpdateUser = dgr.UpdateUser,
                    DeleteUser = dgr.DeleteUser,
                    // Roles
                    CreateCustomRole = dgr.CreateCustomRole,
                    UpdateCustomRole = dgr.UpdateCustomRole,
                    DeleteCustomRole = dgr.DeleteCustomRole,
                    // Groups
                    CanCreateGroup = dgr.CanCreateGroup,
                    CanDeleteGroup = dgr.CanDeleteGroup,
                    CanUpdateGroup = dgr.CanUpdateGroup
                };
                ReturnData rd = new ReturnData{ _userdata = rud, _userperms = rudp};
                await log.LogToDatabase("SUCCESS", "Login",$"User: {user.FullName} has logged in", sw.Elapsed);
                return Ok(rd);
            }
            catch
            {
                sw.Stop();
                await log.LogToDatabase("FATAL", "Login", "Failure to login", sw.Elapsed);
                return BadRequest();
            }
        }
        public class ReturnData
        {
            public required _LoginModel.ReturnUserData _userdata { get; set; }
            public required _LoginModel.ReturnUserDataPermissions _userperms { get; set; }
        }
    }
}
