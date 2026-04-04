using Coffeeg.Dtos;
using Coffeeg.Entities;

namespace Coffeeg.Interfaces.Repositories
{
    public interface IAdminBeverageManagementRepository
    {
        //bool AddBeverageType(string Description);
        Task<bool> AddBeverageType(BeverageType beverageType);
        //bool AddIngredient(AddIngredient dto);
        Task<bool> AddIngredient(Ingredient ingredient);
        Task<bool> BeverageTypeExists(string description);
        Task<bool> IngredientExists(string description);
    }
}
