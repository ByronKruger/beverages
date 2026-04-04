using AutoMapper;
using AutoMapper.QueryableExtensions;
using Coffeeg.Data;
using Coffeeg.Dtos;
using Coffeeg.Dtos.BeverageCustomisation;
using Coffeeg.Dtos.User;
using Coffeeg.Entities;
using Coffeeg.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Coffeeg.Controllers
{
    [ApiController]
    [Route("api/beverage-customisation")]
    public class BeverageCustomisationController(
        ILogger<BeverageCustomisationController> _logger, 
        CoffeegDbContext context, IMapper Mapper,
        IBeverageCustomisationService Service) : ControllerBase
    {
        //[HttpGet]
        //public async Task<ActionResult<UserBeverageCustomisationResult>> GetUserBeverageCustomisation([FromBody] GetUserBeverageCustomisation dto)
        //{
        //    var query = context.BeverageCustomisations
        //        .Where(bc => bc.Id == dto.BeverageCustomisationId)
        //        .Where(bc => bc.UserId == dto.UserId)
        //        .Where(bc => bc.BeverageTypeId == dto.BeverageTypeId)

        //        .Include(bc => bc.User)

        //        .Include(bc => bc.BeverageType.Ingredients)
        //            .ThenInclude(i => i.ComplexIngredients)

        //        .Include(bc => bc.ComplexIngredientAmounts);

        //    return await query.ProjectTo<UserBeverageCustomisationResult>(Mapper.ConfigurationProvider)
        //        .SingleOrDefaultAsync();
        //}

        [HttpGet("beverage-types")]
        public async Task<ActionResult<List<GetBeverageType>>> GetBeverageTypes()
        {
            var result = await Service.GetBeverageTypesAsync();

            return Ok(result.Value);
        }

        [HttpPost("add-customisation")]
        public async Task<IActionResult> CreateBeverageCustomisation([FromBody] CreateBeverageCustomisation dto)
        {
            var result = await Service.CreateBeverageCustomisation(dto);

            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.ErrorMessage);
        }

        [HttpPatch("edit-customisation")]
        public async Task<IActionResult> UpdateUserBeverageCustomisation([FromBody] UpdateBeverageCustomisation dto)
        {
            var result = Service.UpdateBeverageCustomisation(dto).Result;

            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.ErrorMessage);
        }

        [HttpGet("customisations")]
        public async Task<ActionResult<List<BeverageCustomisation>>> GetUserBeverageCustomisations([FromQuery]string userId)
        {
            //return context.BeverageCustomisations
            //    .Include(bc => bc.BeverageType.Ingredients)
            //        .ThenInclude(i => i.ComplexIngredients)
            //    .Include(bc => bc.IngredientAmounts)
            //    .Include(bc => bc.ComplexIngredientAmounts)
            //    .ToList();
            var result = await Service.GetUserBeverageCustomisations(userId);

            return result.IsSuccess ? Ok(result.Value) : NotFound(result.ErrorMessage);
        }

        [HttpGet("customisation")]
        public async Task<ActionResult<List<BeverageCustomisation>>> GetBeverageCustomisation(
            [FromQuery]string userId, [FromQuery]int beverageTypeId)
        {
            var result = await Service.GetBeverageCustomisation(userId, beverageTypeId);

            return result.IsSuccess ? Ok(result.Value) : NotFound(result.ErrorMessage);
        }

        [HttpGet("users")]
        public async Task<ActionResult<List<User>>> GetUsers([FromQuery]string name)
        {
            var userSearchResult = await Service.GetUserByNames(name);
            
            return userSearchResult.IsSuccess ? Ok(userSearchResult.Value) : NotFound(userSearchResult.ErrorMessage);
        }
    }
}



// Admin
//      Create BeverageType (dto: Descr)
//      Create Ingredient (dto: Descr, BeverageTypeId)
// *    List all users
//          pagination
// *    Edit a beverageType/Ingredient configuration.
// User
//      Search for user (dto: username, first-name, last-name)
//      Get user's beverageCustomisation (dto: userId, BeverageCustomisationId).
//      Create a BeverageCustomisation (dto: BeverageTypeId, AssociatedIngredients' amounts and ComplexIngredients' amounts)
//      Edit beverageCustomisation (dto: userId (from context), Beverage customisation id, new amount for complex-/ingredient amount.