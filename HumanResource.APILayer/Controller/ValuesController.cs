using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.APILayer.Controller
{
    [Route("api/[controller]")]
    //when typing in the url search bar, type the url from launchSetting.json, and then to access this ValuesController file,
    //we need to type /api/ + the name of the controller. eg: http://localhost:5293/api/values, we can also copy this url and paste
    //it in postman, to perform the http methods

    [ApiController]
    //if it's WebAPI controller, it's important to use the [ApiController] attribute on the top
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("This is working successfully");
        }

        [HttpGet]
        [Route("{name}")] //means add the name values behinde the url, eg: http://localhost:5293/api/values/betty
        public IActionResult Get(string name)
        {
            return Ok(new { Id = 1, Name = name, Age = 30, City = "Springfield" });
        }
        //query string is a value that you can pass to a server that can be visible in the url
    }
}
