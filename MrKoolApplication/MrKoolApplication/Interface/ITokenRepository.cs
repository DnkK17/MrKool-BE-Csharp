using MrKoolApplication.Models;

namespace MrKoolApplication.Interface
{
    public interface ITokenRepository
    {
        string CreateToken(Users user);
    }
}
