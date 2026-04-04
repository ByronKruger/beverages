using AutoMapper;
using Coffeeg.Dtos.User;
using Coffeeg.Entities;
using Coffeeg.Helpers;
using Coffeeg.Interfaces.Repositories;
using Coffeeg.Interfaces.Services;
using Microsoft.AspNetCore.Identity;

namespace Coffeeg.Services
{
    public class UserManagementService(IMapper Mapper,
        UserManager<User> UserManager, ITokenService TokenService,
        IUserRepository UserRepo) : IUserManagementService
    {
        public async Task<Result<LogInUserResponse>> CheckUserPasswordAsync(LogInUser dto)
        {
            var user = await UserManager.FindByEmailAsync(dto.Username);

            if (user == null) return Result<LogInUserResponse>.Failure("Invalid username");

            var result = await UserManager.CheckPasswordAsync(user, dto.Password);

            if (!result) return Result<LogInUserResponse>.Failure("Invalid password");

            return Result<LogInUserResponse>.Success(
                new LogInUserResponse(await TokenService.CreateToken(Mapper.Map<User>(dto)))
            );
        }

        public async Task<Result<RegisterUserResponse>> CreateUserAsync(RegisterUser dto)
        {
            var user = Mapper.Map<User>(dto);

            var result = await UserManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {

                }
                return Result<RegisterUserResponse>.Failure();
            }
            else
            {
                return Result<RegisterUserResponse>.Success(
                    new RegisterUserResponse(await TokenService.CreateToken(Mapper.Map<User>(dto)))
                );
            }
        }
    }
}
