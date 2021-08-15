using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularProjectAPI.Data;
using AngularProjectAPI.Models;
using AngularProjectAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private readonly SocialContext _context;

        public UserController(IUserService userService, SocialContext context)
        {
            _userService = userService;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpGet("Company/{id}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsersCompany(int id)
        {
            return await _context.Users.Where(u => u.CompanyID == id).ToListAsync();
        }

        [HttpGet("noCompany")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsersNoCompany()
        {
            return await _context.Users.Where(u => u.Company == null).ToListAsync();
        }

        [HttpGet("addToCompany/{userID}/{companyID}")]
        public async Task<ActionResult<IEnumerable<User>>> addUserToCompany(int userID, int companyID)
        {
            var user = await _context.Users.FindAsync(userID);

            user.CompanyID = companyID;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            var user = _userService.Authenticate(userParam.Email, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Email or password is incorrect" });

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}