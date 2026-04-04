using Coffeeg.Dtos;
using Coffeeg.Entities;

namespace Coffeeg.Interfaces.Repositories
{
    public interface IUserRepository
    {
        //Task<IEnumerable<SearchUserResult>> FindUserByName(string name);
        IEnumerable<User> FindUserByName(string name);
        Task<User> FindUserByUsernameAsync(string username);
    }
}
