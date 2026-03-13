using AuthenticationAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAPI.Controllers
{
    public class UserController : ControllerBase
    {
        public readonly AuthDbContext context;
        public UserController(AuthDbContext context)
        {
            this.context = context;
        }

        [HttpPost("Register")]

        public IActionResult Register(UserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var objUser = context.Users.FirstOrDefault(u => u.Email == userDto.Email);
            if (objUser == null)
            {
                context.Users.Add(new User
                { FirstName = userDto.FirstName, LastName = userDto.LastName, Email = userDto.Email, Password = userDto.Password });
                context.SaveChanges();
                return Ok("User registered successfully.");
            }
            else
            {
                return BadRequest("User already registered with the same Email.");
            }

        }
        [HttpPost("login")]
        public IActionResult Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            var validuser = context.Users.FirstOrDefault(u => u.Email == loginDto.Email && u.Password == loginDto.Password && u.IsActive == true);
            if (validuser != null)
            {
                context.SaveChanges();
                return Ok(validuser);

            }
              return NotFound();
            
        }

        [HttpGet]
        [Route("GetUserProfile")]
        public IActionResult GetUserProfile(int userId)
        {
            var user = context.Users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            var users = context.Users.ToList();
            if (users == null)
                return NotFound();

            return Ok(users);
        }
    }
}
