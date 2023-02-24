using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobRequirementController : ControllerBase
    {
        private readonly IJobRequirementServiceAsync jobRequirementServiceAsync;

        public JobRequirementController(IJobRequirementServiceAsync _jobRequirementServiceAsync)
        {
            jobRequirementServiceAsync = _jobRequirementServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> Post(JobRequirementRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await jobRequirementServiceAsync.AddJobRequirementAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await jobRequirementServiceAsync.GetAllJobRequirementAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await jobRequirementServiceAsync.GetJobRequirementByIdAsync(id);
            if (result == null)
            {
                return BadRequest("We dont' have this Job Requirement");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Invalid Id");
            var result = await jobRequirementServiceAsync.GetJobRequirementByIdAsync(id);
            if (result == null)
            {
                return BadRequest("We dont' have this Job Requirement");
            }

            await jobRequirementServiceAsync.DeleteJobRequirementAsync(id);
            return Ok("Deleted");
        }
    }
}
