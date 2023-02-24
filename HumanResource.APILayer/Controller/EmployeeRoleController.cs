using Hrm.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRoleController : ControllerBase
    {
        private readonly IEmployeeRoleServiceAsync employeeRoleServiceAsync;

        public EmployeeRoleController(IEmployeeRoleServiceAsync _employeeRoleServiceAsync)
        {
            employeeRoleServiceAsync = _employeeRoleServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> Post(EmployeeRoleRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await employeeRoleServiceAsync.AddEmployeeRoleAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await employeeRoleServiceAsync.GetAllEmployeeRoleAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await employeeRoleServiceAsync.GetEmployeeRoleByIdAsync(id);
            if (result == null)
            {
                return BadRequest("We don't have this Employee Role");
            }
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> Put(EmployeeRoleRequestModel model)
        {
            if (!ModelState.IsValid) return BadRequest("Wrong Update");
            var result = await employeeRoleServiceAsync.UpdateEmployeeRoleAsync(model);
            if (result == null) { return BadRequest("Wrong Update"); }
            return Ok(result);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Invalid Id");
            var result = await employeeRoleServiceAsync.GetEmployeeRoleByIdAsync(id);
            if (result == null)
            {
                return BadRequest("We don't have this Employee Role");
            }

            await employeeRoleServiceAsync.DeleteEmployeeRoleAsync(id);
            return Ok("Deleted");
        }

    }
}
