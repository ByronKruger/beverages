using Coffeeg.Dtos.BeverageCustomisation;
using Coffeeg.Helpers;

namespace Coffeeg.Interfaces.Services
{
    public interface IAdminBeverageManagementService
    {
        Task<Result<bool>> CreateBeverageType(AddBeverageType dto);
        Task<Result<bool>> CreateIngredients(AddIngredients dto);
    }
}
