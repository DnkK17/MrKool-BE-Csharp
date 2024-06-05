using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MrKoolApplication.DTO;
using MrKoolApplication.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MrKoolApplication.Repository
{
    public class LoginRepository 
    {
       /* private readonly UserManager<LoginDTO> _userManager;

        private readonly SignInManager<LoginDTO> _signInManager;
        public LoginRepository(UserManager <LoginDTO> userManager, SignInManager<LoginDTO> signInManager) {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<bool> Authenticate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Email);
            if (user == null) throw new Exception("Cannot find Email");
            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, true);
            if (!result.Succeeded) return false;
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.Email),
            }
        }
}
        public Task<bool> Register(RegisterRequest request)
        {

        }*/
    }
}
