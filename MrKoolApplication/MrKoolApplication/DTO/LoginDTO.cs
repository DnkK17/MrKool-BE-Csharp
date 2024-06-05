using Microsoft.AspNetCore.Identity;

namespace MrKoolApplication.DTO
{
    public class LoginDTO 
    { 
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
