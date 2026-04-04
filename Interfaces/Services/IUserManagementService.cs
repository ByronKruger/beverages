using Coffeeg.Dtos.User;
using Coffeeg.Helpers;

namespace Coffeeg.Interfaces.Services
{
    public interface IUserManagementService
    {
        Task<Result<RegisterUserResponse>> CreateUserAsync(RegisterUser dto);
        Task<Result<LogInUserResponse>> CheckUserPasswordAsync(LogInUser dto);
    }
}
