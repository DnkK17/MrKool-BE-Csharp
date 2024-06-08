using Microsoft.AspNetCore.Mvc;
using MrKool.Data;
using MrKoolApplication.DTO;
using MrKoolApplication.Interface;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using MrKoolApplication.Models;
using MrKool.Models;
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
        public async Task<ActionResult<AuthDTO>> Login(LoginDTO loginDTO, string roleName,string name)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == loginDTO.Email );
            if (user == null) { return Unauthorized(); }
            using var hmac = new HMACSHA512(user.SaltPassword);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if(computedHash[i] != user.HashPassword[i]) return Unauthorized();
            }
            user.RoleName = roleName;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            if (roleName.ToLower() == "customer")
            {
                // Create a new customer with the same email and plain password
                var newCustomer = new Customer
                {
                    Email = loginDTO.Email,
                    Password = loginDTO.Password, // Store the plain password as per your requirement
                    user.Id = loginDTO.
                };
            }

            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();
            return new AuthDTO
            {
                Token = _tokenRepository.CreateToken(user),
            };
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthDTO>> Register(RegisterDTO registerDto)
        {
            using var hmac = new HMACSHA512();
            //if (await UserExists(registerDto.Email)) return BadRequest("UserEmail  Is Already Taken");
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = registerDto.Email.ToLower(),
                HashPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                SaltPassword = hmac.Key,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new AuthDTO
            {
                Token =  _tokenRepository.CreateToken(user),
            };
        }
    }
}
