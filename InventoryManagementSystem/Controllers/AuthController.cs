using System.Linq;
using System.Threading.Tasks;
using InventoryManagementSystem.Authentication.Interface;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventoryManagementSystem.Controllers
{
    [Authorize]
    //[ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly CustomerDbContext _cusDbContext;
        private readonly IAuthIMS _authIMS;

        public AuthController(CustomerDbContext cuDbContext,IAuthIMS iauth)
        {
            _cusDbContext = cuDbContext;
            _authIMS = iauth;
        }
        // GET: api/<AuthController>
        [HttpGet]
        public IActionResult GetUser()
        {
            return Ok(_cusDbContext.Users.Select(q=> new { q.Id,q.Name}).ToList());
        }

        // GET api/<AuthController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _cusDbContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            user.Password = "";
            return user;
        }

        // POST api/<AuthController>
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(User user)
        {
            if(!_cusDbContext.Users.Any(u => u.Name == user.Name && u.Password == user.Password))
            {
                return Unauthorized();
            }
            var token = _authIMS.Authenticate(user.Name, user.Password);
            if(token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }

        [HttpPost]
        public void postUser(User user)
        {
            _cusDbContext.Users.Add(user);
            _cusDbContext.SaveChanges();
        }

        // PUT api/<AuthController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id,User user)
        {
            if(id != user.Id)
            {
                return BadRequest();
            }
            _cusDbContext.Entry(user).State = EntityState.Modified;
            try
            {
                await _cusDbContext.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _cusDbContext.Users.Any(e => e.Id == id);
        }

        // DELETE api/<AuthController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _cusDbContext.Users.FindAsync(id);
            if(user == null)
            {
                return NotFound();
            }
            if(user.Name == "admin")
            {
                return BadRequest();
            }
            _cusDbContext.Users.Remove(user);
            await _cusDbContext.SaveChangesAsync();
            return user;

        }
    }
}
