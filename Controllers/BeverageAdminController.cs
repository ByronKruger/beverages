using Coffeeg.Dtos.BeverageCustomisation;
using Coffeeg.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Coffeeg.Controllers
{
    [ApiController]
    [Authorize(Policy = "Moderator")]
    [Route("api/beverage-admin")]
    public class BeverageAdminController(IAdminBeverageManagementService Service) : ControllerBase
    {
        [HttpPost("add-beverage-type")]
        public async Task<IActionResult> CreateBeverageType(AddBeverageType dto)
        {
            // 1.
            var result = await Service.CreateBeverageType(dto);

            if (result.IsSuccess)
                return Ok();
            else
                return BadRequest(new { error = result.ErrorMessage });

            // 2.
            //var result = await Service.CreateBeverageType(description);

            //if (result.IsSuccess)
            //    return CreatedAtAction(
            //    nameof(GetBeverageType),           // ← prefer a real GET action name
            //    new { id = result.Value.Id },      // route values (must match route template of the GET action)
            //    result.Value                       // response body (usually the created DTO)
            //);
            //else
            //    return BadRequest(new { error = result.ErrorMessage });
        }

        [HttpPost("add-ingredients")]
        public async Task<IActionResult> CreateIngredients([FromBody] AddIngredients dto)
        {
            var result = await Service.CreateIngredients(dto);

            if (result.IsSuccess)
                return Ok();
            else
                return BadRequest(new { error = result.ErrorMessage });
        }
    }
}
