using BookLibrary.Dto;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace BookLibrary.Models
{
    public class User
    {
        [Key] 
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }


        public static User FromUserRegister(UserRegister userRegister)
        {
            var (name, email, password) = userRegister;
            return new User
            {
          
                Name = name,
                Email = email,
                Password = BCrypt.Net.BCrypt.HashPassword(userRegister.Password),
                CreatedAt = DateTime.UtcNow
            };
        }

    }
}
