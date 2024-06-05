using Microsoft.AspNetCore.Mvc;
using MrKool.Data;
using MrKoolApplication.DTO;
using MrKoolApplication.Interface;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
namespace MrKoolApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly DBContext _context;
        private readonly ITokenRepository _tokenRepository;

        public AuthController(DBContext context, ITokenRepository tokenRepository)
        {
            _context = context;
            _tokenRepository = tokenRepository;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthDTO>> Login(LoginDTO loginDTO)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == loginDTO.Email );
            if (user == null) { return Unauthorized(); }
            using var hmac = new HMACSHA512(user.SaltPassword);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if(computedHash[i] != user.HashPassword[i]) return Unauthorized();
            }
            return new AuthDTO
            {
                Token = _tokenRepository.CreateToken(user),
            };
        }
    }
}
