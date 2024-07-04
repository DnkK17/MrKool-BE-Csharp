using Microsoft.AspNetCore.Mvc;
using MrKool.Data;
using MrKoolApplication.DTO;
using MrKoolApplication.Interface;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using MrKoolApplication.Models;
using MrKool.Models;
using Microsoft.AspNetCore.Cors;
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
        [EnableCors("AllowSpecificOrigin")]
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

        [HttpPost("register")]
        [EnableCors("AllowSpecificOrigin")]
        public async Task<ActionResult<AuthDTO>> Register(RegisterDTO registerDto)
        {
            // Check for duplicate email
            if (await _context.Users.AnyAsync(u => u.Email == registerDto.Email.ToLower()))
            {
                return BadRequest("Email is already in use.");
            }

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                using var hmac = new HMACSHA512();
                var user = new Users
                {
                    Id = Guid.NewGuid(),
                    Email = registerDto.Email.ToLower(),
                    HashPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                    SaltPassword = hmac.Key,
                    RoleName = registerDto.roleName.ToLower(),
                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                if (registerDto.roleName.ToLower() == "customer")
                {
                    var newCustomer = new Customer
                    {
                        Email = registerDto.Email,
                        Password = registerDto.Password,
                        Telephone = registerDto.Telephone,
                        userID = user.Id,
                        CustomerName = registerDto.name,
                        Status = true
                    };
                    _context.Customers.Add(newCustomer);
                    await _context.SaveChangesAsync();
                }
                else if (registerDto.roleName.ToLower() == "technician")
                {
                    var newTechnician = new Technician
                    {
                        Email = registerDto.Email,
                        Password = registerDto.Password,
                        Telephone = registerDto.Telephone,
                        userID = user.Id,
                        TechnicianName = registerDto.name
                    };
                    _context.Technicians.Add(newTechnician);
                    await _context.SaveChangesAsync();
                }
                else if (registerDto.roleName.ToLower() == "manager")
                {
                    var newManager = new Manager
                    {
                        Email = registerDto.Email,
                        Password = registerDto.Password,
                        Telephone = registerDto.Telephone,
                        userID = user.Id,
                        ManagerName = registerDto.name
                    };
                    _context.Managers.Add(newManager);
                    await _context.SaveChangesAsync();
                }

                // Commit the transaction
                await transaction.CommitAsync();

                return new AuthDTO
                {
                    Token = _tokenRepository.CreateToken(user),
                };
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }


    }
}
