using Hrm.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeServiceAsync employeeServiceAsync;

        public EmployeeController(IEmployeeServiceAsync _employeeServiceAsync)
        {
            employeeServiceAsync = _employeeServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> Post(EmployeeRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await employeeServiceAsync.AddEmployeeAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await employeeServiceAsync.GetAllEmployeeAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await employeeServiceAsync.GetEmployeeByIdAsync(id);
            if (result == null)
            {
                return BadRequest("This Employee doesn't exist");
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(EmployeeRequestModel model)
        {
            if (!ModelState.IsValid) return BadRequest("Wrong Update");
            var result = await employeeServiceAsync.UpdateEmployeeAsync(model);
            if (result == null) { return BadRequest("Wrong Update"); }
            return Ok(result);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Invalid Id");
            var result = await employeeServiceAsync.GetEmployeeByIdAsync(id);
            if (result == null)
            {
                return BadRequest("This Employee doesn't exist");
            }

            await employeeServiceAsync.DeleteEmployeeAsync(id);
            return Ok("Deleted");
        }

    }
}
