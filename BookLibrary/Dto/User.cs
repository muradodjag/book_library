using BookLibrary.Models;

namespace BookLibrary.Dto
{
    public record UserRegister(string Name, string Email, string Password);
    public class UserResponse
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public static UserResponse FromAuth(User user, string token)
        {
            return new UserResponse
            {
               Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Token = token
            };
        }
    }
}
