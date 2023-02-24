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

        private readonly IEmployeeServiceAsync EmployeeServiceAsync;

        public EmployeeController(IEmployeeServiceAsync _EmployeeServiceAsync)
        {
            EmployeeServiceAsync = _EmployeeServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> Post(EmployeeRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await EmployeeServiceAsync.AddEmployeeAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await EmployeeServiceAsync.GetAllEmployeeAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await EmployeeServiceAsync.GetEmployeeByIdAsync(id);
            if (result == null)
            {
                return BadRequest("This Employee doesn't exist");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Invalid Id");
            var result = await EmployeeServiceAsync.GetEmployeeByIdAsync(id);
            if (result == null)
            {
                return BadRequest("This Employee doesn't exist");
            }

            await EmployeeServiceAsync.DeleteEmployeeAsync(id);
            return Ok("Deleted");
        }

    }
}
