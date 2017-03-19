using Microsoft.AspNetCore.Mvc;
using NetCoreSnackApp.Model;

namespace NetCoreSnackApp.Controller
{
    //[Produces("application/bson")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult BsonData()
        {
            Team team = new Team
            {
                Name = "Besiktas",
                City = "Istanbul"
            };

            return Ok(team);
        }
    }
}
