using AutoMapper;
using Coffeeg.Dtos;
using Coffeeg.Dtos.BeverageCustomisation;
using Coffeeg.Dtos.User;
using Coffeeg.Entities;
using Coffeeg.Helpers;
using Coffeeg.Interfaces.Repositories;
using Coffeeg.Interfaces.Services;

namespace Coffeeg.Services
{
    public class BeverageCustomisationService(IBeverageCustomisationRepository Repo, IMapper Mapper) : IBeverageCustomisationService
    {
        public async Task<Result<CreateCustomisationResult>> CreateBeverageCustomisation(CreateBeverageCustomisation dto)
        {
            if (!dto.IngredientAmounts.Any() && !dto.ComplexIngredientAmounts.Any())
                return Result<CreateCustomisationResult>.Failure("At least one ingredient is required to create a customisation");

            //if (!dto.ComplexIngredientAmounts.Any())
            //    return Result<CreateCustomisationResult>.Failure("");

            //var beverageCustomisation = Mapper.Map<CreateBeverageCustomisation, BeverageCustomisaton>(dto);
            var result = Repo.CreateBeverageCustomisation(dto).Result;

            if (result.IsSuccess)
            {
                var beverageCustomisationResult = Mapper.Map<BeverageCustomisation, CreateCustomisationResult>(result.Value);
                return Result<CreateCustomisationResult>.Success(beverageCustomisationResult);
            }
            else
            {
                return Result<CreateCustomisationResult>.Failure("Something went wrong when trying to save a new beverage customisation");
            }

            //var result = await Repo.CreateBeverageCustomisation(beverageCustomisation);
            //var bevCust = result.Value;
            //var createCustomisationResutl = Mapper.Map<BeverageCustomisaton, CreateCustomisationResult>(bevCust);
            //return Result<CreateBeverageCustomisation>()
        }

        public async Task<Result<List<GetBeverageType>>> GetBeverageTypesAsync()
        {
            var beverageTypes = await Repo.GetBeverageTypesAsync();

            return Result<List<GetBeverageType>>.Success(Mapper.Map<List<GetBeverageType>>(beverageTypes.Value));
        }

        public async Task<Result<BeverageCustomisation>> GetBeverageCustomisation(string userId, int beverageTypeId)
        {
            var beverageCustomisation = await Repo.GetBeverageCustomisationByBeverageType(userId, beverageTypeId);

            if (beverageCustomisation == null)
                return Result<BeverageCustomisation>.Failure("No beverage customisation with that id exists");

            return Result<BeverageCustomisation>.Success(beverageCustomisation);
        }

        public async Task<Result<List<BeverageCustomisation>>> GetUserBeverageCustomisations(string userId)
        {
            var beverageCustomisations = await Repo.GetBeverageCustomisationsForUser(userId);

            if (beverageCustomisations.Count == 0)
                return Result<List<BeverageCustomisation>>.Failure("No beverage customisations for this user exists");

            return Result<List<BeverageCustomisation>>.Success(beverageCustomisations);
        }

        public async Task<Result<List<SearchUserResult>>> GetUserByNames(string name)
        {
            var users = await Repo.GetUserByNames(name);

            if (users.Any())
                return Result<List<SearchUserResult>>.Success(Mapper.Map<List<SearchUserResult>>(users));
            else
                return Result<List<SearchUserResult>>.Failure("No user found with that name");
        }

        public async Task<Result<UserBeverageCustomisationResult>> UpdateBeverageCustomisation(UpdateBeverageCustomisation dto)
        {
            var entity = Mapper.Map<UpdateBeverageCustomisation, BeverageCustomisation>(dto);

            var result = Repo.UpdateBeverageCustomisation(entity).Result;

            if (result.IsSuccess)
                return Result<UserBeverageCustomisationResult>.Success(Mapper.Map<BeverageCustomisation, UserBeverageCustomisationResult>(result.Value));
            else
                return Result<UserBeverageCustomisationResult>.Failure("Could not update beverage customisation");
        }
    }
}
