using Coffeeg.Dtos;
using Coffeeg.Dtos.BeverageCustomisation;
using Coffeeg.Dtos.User;
using Coffeeg.Entities;
using Coffeeg.Helpers;

namespace Coffeeg.Interfaces.Services
{
    public interface IBeverageCustomisationService
    {
        Task<Result<CreateCustomisationResult>> CreateBeverageCustomisation(CreateBeverageCustomisation dto);
        Task<Result<UserBeverageCustomisationResult>> UpdateBeverageCustomisation(UpdateBeverageCustomisation dto);
        Task<Result<List<GetBeverageType>>> GetBeverageTypesAsync();
        Task<Result<List<SearchUserResult>>> GetUserByNames(string name);
        Task<Result<BeverageCustomisation>> GetBeverageCustomisation(string userId, int beverageTypeId);
        Task<Result<List<BeverageCustomisation>>> GetUserBeverageCustomisations(string userId);
    }
}
