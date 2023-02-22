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
    }
}