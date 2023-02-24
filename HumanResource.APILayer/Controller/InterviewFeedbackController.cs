using HRM.ApplicationCore.Contract.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HRM.ApplicationCore.Model.Request;

namespace HumanResource.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewFeedbackController : ControllerBase
    {
        private readonly IInterviewFeedbackServiceAsync interviewFeedbackServiceAsync;

        public InterviewFeedbackController(IInterviewFeedbackServiceAsync _interviewFeedbackServiceAsync)
        {
            interviewFeedbackServiceAsync = _interviewFeedbackServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> Post(InterviewFeedbackRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await interviewFeedbackServiceAsync.AddInterviewFeedbackAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await interviewFeedbackServiceAsync.GetAllInterviewFeedbackAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await interviewFeedbackServiceAsync.GetInterviewFeedbackByIdAsync(id);
            if (result == null)
            {
                return BadRequest("No Feedback");
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(InterviewFeedbackRequestModel model)
        {
            if (!ModelState.IsValid) return BadRequest("Wrong Update");
            var result = await interviewFeedbackServiceAsync.UpdateInterviewFeedbackAsync(model);
            if (result == null) { return BadRequest("Wrong Update"); }
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Invalid Id");
            var result = await interviewFeedbackServiceAsync.GetInterviewFeedbackByIdAsync(id);
            if (result == null)
            {
                return BadRequest("No Feedback");
            }

            await interviewFeedbackServiceAsync.DeleteInterviewFeedbackAsync(id);
            return Ok("Deleted");
        }
    }
}
