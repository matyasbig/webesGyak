using Microsoft.AspNetCore.Mvc;
using webesGyak.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webesGyak.Controllers
{
    [Route("api/jokes")]
    [ApiController]
    public class JokeController : ControllerBase
    {
        // GET: api/<JokeController>
        [HttpGet]
        public IActionResult Get()
        {
            FunnyDatabaseContext context = new();
            return Ok(context.Jokes.ToList());
        }

        // GET api/jokes/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            FunnyDatabaseContext context = new();

            var targetJoke =
                (from x in context.Jokes
                 where x.JokeSk == id
                 select x).FirstOrDefault();

            return Ok(targetJoke);
        }

        // POST api/<JokeController>
        [HttpPost]
        public void Post([FromBody] Joke newJoke)
        {
            FunnyDatabaseContext context = new();

            context.Jokes.Add(newJoke);
            context.SaveChanges();
        }

        // PUT api/<JokeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<JokeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            FunnyDatabaseContext context = new();

            var jokeToDelete =
                (from x in context.Jokes
                 where x.JokeSk == id
                 select x).FirstOrDefault();

            context.Remove(jokeToDelete);
            context.SaveChanges();
        }
    }
}
