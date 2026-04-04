using Coffeeg.Entities;

namespace Coffeeg.Interfaces.Services
{
    public interface ITokenService
    {
        Task<string> CreateToken(User dto);
    }
}
