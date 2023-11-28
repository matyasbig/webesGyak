using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webesGyak.Models;

namespace webesGyak.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class BoatController : ControllerBase
    {
        [HttpGet]
        [Route("questions/all")]
        public IActionResult GetQuestions()
        {
            HajosContext context = new();
            var questions = from x in context.Questions select x.Question1;

            return Ok(questions);
        }
    }
}
