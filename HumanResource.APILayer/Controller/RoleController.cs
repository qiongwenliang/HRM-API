using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleServiceAsync roleServiceAsync;
        public RoleController(IRoleServiceAsync _roleServiceAsync)
        {
            roleServiceAsync = _roleServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> Post(RoleRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await roleServiceAsync.AddRoleAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await roleServiceAsync.GetAllRoleAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0) return BadRequest(id);
            var result = await roleServiceAsync.GetRoleByIdAsync(id);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Invalid Id");
            var result = await roleServiceAsync.GetRoleByIdAsync(id);
            if (result == null)
            {
                return BadRequest(id);
            }

            await roleServiceAsync.DeleteRoleAsync(id);
            return Ok("Deleted");
        }

    }
}
