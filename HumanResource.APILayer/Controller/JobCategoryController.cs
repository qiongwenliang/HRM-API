using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobCategoryController : ControllerBase
    {
        private readonly IJobCategoryServiceAsync jobCategoryServiceAsync;

        public JobCategoryController(IJobCategoryServiceAsync _jobCategoryServiceAsync)
        {
            jobCategoryServiceAsync = _jobCategoryServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> Post(JobCategoryRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await jobCategoryServiceAsync.AddJobCategoryAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await jobCategoryServiceAsync.GetAllJobCategoryAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await jobCategoryServiceAsync.GetJobCategoryByIdAsync(id);
            if (result == null)
            {
                return BadRequest("We don't have this Job Category");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Invalid Id");
            var result = await jobCategoryServiceAsync.GetJobCategoryByIdAsync(id);
            if (result == null)
            {
                return BadRequest("We don't have this Job Category");
            }

            await jobCategoryServiceAsync.DeleteJobCategoryAsync(id);
            return Ok("Deleted");
        }
    }
}
