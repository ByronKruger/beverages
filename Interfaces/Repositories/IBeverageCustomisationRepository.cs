using Coffeeg.Dtos;
using Coffeeg.Dtos.User;
using Coffeeg.Entities;
using Coffeeg.Helpers;

namespace Coffeeg.Interfaces.Repositories
{
    public interface IBeverageCustomisationRepository
    {
        Task<UserBeverageCustomisationResult> GetUserBeverageCustomisation(GetUserBeverageCustomisation entity); // refactor

        //Task<Result<BeverageCustomisaton>> CreateBeverageCustomisation(BeverageCustomisaton entity);
        Task<Result<BeverageCustomisation>> CreateBeverageCustomisation(CreateBeverageCustomisation dto); // see if you can refactor back to using an entity -- requires coplexity to move to mapper profile
        Task<Result<BeverageCustomisation>> UpdateBeverageCustomisation(BeverageCustomisation entity);
        Task<Result<List<BeverageType>>> GetBeverageTypesAsync();
        Task<List<User>> GetUserByNames(string name);
        Task<List<BeverageCustomisation>> GetBeverageCustomisationsForUser(string userId); 
        Task<BeverageCustomisation?> GetBeverageCustomisationByBeverageType(string userId, int beverageTypeId);
    }
}
