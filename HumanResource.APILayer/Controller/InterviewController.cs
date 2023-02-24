using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewController : ControllerBase
    {
        private readonly IInterviewServiceAsync interviewServiceAsync;

        public InterviewController(IInterviewServiceAsync _interviewServiceAsync)
        {
            interviewServiceAsync = _interviewServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> Post(InterviewRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await interviewServiceAsync.AddInterviewAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await interviewServiceAsync.GetAllInterviewAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await interviewServiceAsync.GetInterviewByIdAsync(id);
            if (result == null)
            {
                return BadRequest("No Interview");
            }
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> Put(InterviewRequestModel model)
        {
            if (!ModelState.IsValid) return BadRequest("Wrong Update");
            var result = await interviewServiceAsync.UpdateInterviewAsync(model);
            if (result == null) { return BadRequest("Wrong Update"); }
            return Ok(result);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Invalid Id");
            var result = await interviewServiceAsync.GetInterviewByIdAsync(id);
            if (result == null)
            {
                return BadRequest("No Interview");
            }

            await interviewServiceAsync.DeleteInterviewAsync(id);
            return Ok("Deleted");
        }

    }
}
