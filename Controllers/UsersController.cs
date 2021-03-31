using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsersAPI.Models;
using UsersAPI.Repository;

namespace UsersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _context;

        public UsersController(IUserRepo context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<UserServiceInfo> GetUserServiceInfos()
        {
            return  _context.GetAllUsers();
        }

       /* // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserServiceInfo>> GetUserServiceInfo(string id)
        {
            var userServiceInfo = await _context.UserServiceInfos.FindAsync(id);

            if (userServiceInfo == null)
            {
                return NotFound();
            }

            return userServiceInfo;
        }*/

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserServiceInfo(string id, UserServiceInfo userServiceInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var editedUser = await _context.EditUser(id,userServiceInfo);

            return Ok(editedUser);
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<UserServiceInfo>> PostUserServiceInfo(UserServiceInfo userServiceInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var addedUser = await _context.PostUser(userServiceInfo);

            return Ok(addedUser);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserServiceInfo(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var deletedUser = await _context.RemoveUser(id);

            return Ok(deletedUser);
        }

        
    }
}
