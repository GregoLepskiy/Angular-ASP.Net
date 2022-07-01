using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/replacements")]
    public class ReplacementController : Controller
    {
        ApplicationContext db;
        public ReplacementController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public IEnumerable<Replacement> Get()
        {
            return db.Replacements.ToList();
        }

        [HttpGet("{oldSymbol}")]
        public string GetNewSymbol(string oldSymbol)
        {
            Replacement replacement = db.Replacements.FirstOrDefault(x => x.OldSymbol == oldSymbol);
            return replacement.NewSymbol;
        }

        [HttpPost]
        public IActionResult Post(Replacement replacement)
        {
            if (ModelState.IsValid)
            {
                db.Replacements.Add(replacement);
                db.SaveChanges();
                return Ok(replacement);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(Replacement replacement)
        {
            if (ModelState.IsValid)
            {
                db.Update(replacement);
                db.SaveChanges();
                return Ok(replacement);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{oldSymbol}")]
        public IActionResult Delete(string oldSymbol)
        {
            Replacement replacement = db.Replacements.FirstOrDefault(x => x.OldSymbol == oldSymbol);
            if (replacement != null)
            {
                db.Replacements.Remove(replacement);
                db.SaveChanges();
            }
            return Ok(replacement);
        }
    }
}
