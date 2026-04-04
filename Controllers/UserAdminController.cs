using Coffeeg.Dtos.User;
using Coffeeg.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Coffeeg.Controllers
{
    [ApiController]
    [Route("/api/user-admin")]
    [Authorize(Policy = "Admin")]
    public class UserAdminController(UserManager<User> userManager) : ControllerBase
    {

        //to do: get all users (w/ roles).


        //[Authorize(Roles = "Admn")]
        [HttpPost("edit-user-roles")]
        public async Task<ActionResult> AddUserRole([FromBody] AddUserRole addUserRole)
        {
            var adminUser = await userManager.FindByEmailAsync(addUserRole.email);

            var result = await userManager.AddToRolesAsync(adminUser, addUserRole.roles);

            return result.Succeeded ? Ok() : BadRequest();
        }

        //to do: get all users (w/ beverageCusts)

    }
}
