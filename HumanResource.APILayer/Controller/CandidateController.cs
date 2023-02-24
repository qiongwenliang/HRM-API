using Hrm.ApplicationCore.Contract.Service;
using Hrm.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateServiceAsync candidateServiceAsync;

        public CandidateController(ICandidateServiceAsync _candidateServiceAsync)//here is due to dependency injection
        {
            candidateServiceAsync = _candidateServiceAsync;
        }
        
        [HttpPost]
        //to execute, it must be async and await
        public async Task<IActionResult> Post(CandidateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await candidateServiceAsync.AddCandidateAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await candidateServiceAsync.GetAllCandidatesAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await candidateServiceAsync.GetCandidateByIdAsync(id);
            if (result == null)
            {
                return BadRequest("This candidate doesn't exist!");
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(CandidateRequestModel model)
        {
            if (!ModelState.IsValid) return BadRequest("Wrong Update");
            var result = await candidateServiceAsync.UpdateCandidateAsync(model);
            if (result == null) { return BadRequest("Wrong Update"); }
            return Ok(result);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Invalid Id");
            var result = await candidateServiceAsync.GetCandidateByIdAsync(id);
            if (result == null)
            {
                return BadRequest("This candidate doesn't exist!");
            }

            await candidateServiceAsync.DeleteCandidateAsync(id);
            return Ok("Deleted");
        }
    }
}