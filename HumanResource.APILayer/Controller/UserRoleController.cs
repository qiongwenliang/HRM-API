using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleServiceAsync userRoleServiceAsync;

        public UserRoleController(IUserRoleServiceAsync _userRoleServiceAsync)
        {
            userRoleServiceAsync = _userRoleServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserRoleRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await userRoleServiceAsync.AddUserRoleAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await userRoleServiceAsync.GetAllUserRoleAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await userRoleServiceAsync.GetUserRoleByIdAsync(id);
            if (result == null)
            {
                return BadRequest(id);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Invalid Id");
            var result = await userRoleServiceAsync.GetUserRoleByIdAsync(id);
            if (result == null)
            {
                return BadRequest(id);
            }

            await userRoleServiceAsync.DeleteUserRoleAsync(id);
            return Ok("Deleted");
        }

    }
}
