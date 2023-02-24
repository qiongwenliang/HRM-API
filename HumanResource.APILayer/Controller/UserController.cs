using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServiceAsync userServiceAsync;

        public UserController(IUserServiceAsync _userServiceAsync)
        {
            userServiceAsync = _userServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await userServiceAsync.AddUserAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await userServiceAsync.GetAllUserAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await userServiceAsync.GetUserByIdAsync(id);
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
            var result = await userServiceAsync.GetUserByIdAsync(id);
            if (result == null)
            {
                return BadRequest(id);
            }

            await userServiceAsync.DeleteUserAsync(id);
            return Ok("Deleted");
        }
    }
}
