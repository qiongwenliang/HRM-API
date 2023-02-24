using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTypeController : ControllerBase
    {
        private readonly IEmployeeTypeServiceAsync employeeTypeServiceAsync;

        public EmployeeTypeController(IEmployeeTypeServiceAsync _employeeTypeServiceAsync)
        {
            employeeTypeServiceAsync = _employeeTypeServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> Post(EmployeeTypeRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await employeeTypeServiceAsync.AddEmployeeTypeAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await employeeTypeServiceAsync.GetAllEmployeeTypeAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await employeeTypeServiceAsync.GetEmployeeTypeByIdAsync(id);
            if (result == null)
            {
                return BadRequest("This Employee Type doesn't exist");
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(EmployeeTypeRequestModel model)
        {
            if (!ModelState.IsValid) return BadRequest("Wrong Update");
            var result = await employeeTypeServiceAsync.UpdateEmployeeTypeAsync(model);
            if (result == null) { return BadRequest("Wrong Update"); }
            return Ok(result);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Invalid Id");
            var result = await employeeTypeServiceAsync.GetEmployeeTypeByIdAsync(id);
            if (result == null)
            {
                return BadRequest("This Employee Type doesn't exist");
            }

            await employeeTypeServiceAsync.DeleteEmployeeTypeAsync(id);
            return Ok("Deleted");
        }
    }
}
