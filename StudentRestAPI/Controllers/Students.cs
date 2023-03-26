using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Students : ControllerBase
    {
        [HttpGet]
        public string GetStudents ()
        {
            string studentName = "Jose";
            return studentName;
        }

    }
}
