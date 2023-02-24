using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeStatusController : ControllerBase
    {
        private readonly IEmployeeStatusServiceAsync employeeStatusServiceAsync;

        public EmployeeStatusController(IEmployeeStatusServiceAsync _employeeStatusServiceAsync)
        {
            employeeStatusServiceAsync = _employeeStatusServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> Post(EmployeeStatusRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await employeeStatusServiceAsync.AddEmployeeStatusAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await employeeStatusServiceAsync.GetAllEmployeeStatusAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await employeeStatusServiceAsync.GetEmployeeStatusByIdAsync(id);
            if (result == null)
            {
                return BadRequest("We don't have this Employee Status");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Invalid Id");
            var result = await employeeStatusServiceAsync.GetEmployeeStatusByIdAsync(id);
            if (result == null)
            {
                return BadRequest("We don't have this Employee Status");
            }

            await employeeStatusServiceAsync.DeleteEmployeeStatusAsync(id);
            return Ok("Deleted");
        }

    }
}
