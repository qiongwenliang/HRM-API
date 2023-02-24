using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionServiceAsync submissionServiceAsync;

        public SubmissionController(ISubmissionServiceAsync _submissionServiceAsync)
        {
            submissionServiceAsync = _submissionServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> Post(SubmissionRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await submissionServiceAsync.AddSubmissionAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await submissionServiceAsync.GetAllSubmissionAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await submissionServiceAsync.GetSubmissionByIdAsync(id);
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
            var result = await submissionServiceAsync.GetSubmissionByIdAsync(id);
            if (result == null)
            {
                return BadRequest(id);
            }

            await submissionServiceAsync.DeleteSubmissionAsync(id);
            return Ok("Deleted");
        }

    }
}
