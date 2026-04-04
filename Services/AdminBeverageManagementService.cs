using Coffeeg.Dtos.BeverageCustomisation;
using Coffeeg.Entities;
using Coffeeg.Helpers;
using Coffeeg.Interfaces.Repositories;
using Coffeeg.Interfaces.Services;

namespace Coffeeg.Services
{
    public class AdminBeverageManagementService(IAdminBeverageManagementRepository Repo) : IAdminBeverageManagementService
    {
        public async Task<Result<bool>> CreateBeverageType(AddBeverageType dto)
        {
            if (await Repo.BeverageTypeExists(dto.Description))
                return Result<bool>.Failure("Beverage type with that description already exists.");

            var beverageType = new BeverageType { Descr = dto.Description };

            foreach (var ing in dto.Ingredients)
            {
                beverageType.Ingredients.Add(new Ingredient { Id = ing });
            }
            
            // 1.
            //await Repo.AddBeverageType(beverageType);
            //return Result<bool>.Success(true);

            // 2.
            return await Repo.AddBeverageType(beverageType) ? 
                Result<bool>.Success(true) : 
                Result<bool>.Failure("Something went wrong when trying to save a new beverage type") ;
        }

        public async Task<Result<bool>> CreateIngredients(AddIngredients dto)
        {
            if (await Repo.IngredientExists(dto.Description))
                return Result<bool>.Failure("Ingredient with that description already exists");

            //var beverageType = new BeverageType { Id = dto.BeverageTypeId };
            var ingredient = new Ingredient { Descr = dto.Description };
            //ingredient.BeverageTypes.Add(beverageType);

            if (dto.ComplexIngredientDescriptions.Count() != 0)
            {
                ingredient.IsComplex = true;
                foreach (var ci in dto.ComplexIngredientDescriptions)
                {
                    var complexIngredient = new ComplexIngredient { Descr = ci };
                    ingredient.ComplexIngredients.Add(complexIngredient);
                }
            }
            await Repo.AddIngredient(ingredient);
            return Result<bool>.Success(true);
        }

        // what about a complex ingredient (within the same category of ingredient) already existing?
    }
}
