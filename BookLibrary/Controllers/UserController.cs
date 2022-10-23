using BookLibrary.Data;
using BookLibrary.Dto;
using BookLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;

namespace BookLibrary.Controllers
{
    public class UserController : Controller
    {
        private readonly BookLibraryContext _context;
        private readonly IConfiguration _configuration;

        public UserController(BookLibraryContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegister userRegister)
        {
            
            if (await _context.Users.AnyAsync(u => u.Email == userRegister.Email))
            {
                return BadRequest("Duplicate Email");
            }


            var user = Models.User.FromUserRegister(userRegister);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(UserResponse.FromAuth(user, GenerateToken(user)));
        }

        private string GenerateToken(User user)
        {
            var claims = new Claim[]
            {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
