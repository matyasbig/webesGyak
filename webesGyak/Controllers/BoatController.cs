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
        [Route("questions/{idx}")]
        public IActionResult GetQuestion(int idx)
        {
            HajosContext context = new();
            var question = 
                (from x in context.Questions
                 where x.QuestionId == idx
                 select x).FirstOrDefault();

            if (question == null) return BadRequest("Nincs ilyen sorszámú kérdés");

            return new JsonResult(question);
        }
    }
}
