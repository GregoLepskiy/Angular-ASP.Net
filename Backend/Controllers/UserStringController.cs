using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/userstrings")]
    public class UserStringController : Controller
    {
        ApplicationContext db;

        public UserStringController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet("{data}")]
        public UserString GetCipherString(UserString data)
        {
            return new UserString() {
                InString = CipheredString(data.InString),
                Date = data.Date
            };
        }

        [HttpGet]
        public IEnumerable<UserString> Get()
        {
            var cipheredStrings = new List<UserString>();

            foreach (UserString us in db.UserStrings.ToList())
                cipheredStrings.Add(new UserString() {
                    InString = CipheredString(us.InString),
                    Date = us.Date
                });

            return cipheredStrings;
        }

        private string CipheredString(string inString)
        {
            var res = "";
            if (inString != null)
                foreach (char c in inString)
                {
                    var replace = db.Replacements.Where(r => r.OldSymbol == c.ToString());
                    if (replace.Count() == 1)
                        res += replace.First().NewSymbol;
                    else res += c;
                }
            return res;
        }

        [HttpPost]
        public IActionResult Post(UserString userString)
        {
            if (ModelState.IsValid)
            {
                userString.Date = DateTime.Now;
                db.UserStrings.Add(userString);
                db.SaveChanges();
                var cipher = new UserString()
                {
                    InString = CipheredString(userString.InString),
                    Date = userString.Date,
                    Id = userString.Id
                };
                return Ok(cipher);
            }
            else return BadRequest(ModelState);
        }
    }
}
