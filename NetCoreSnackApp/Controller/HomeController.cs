using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Bson;
using System;

namespace NetCoreSnackApp.Controller
{
    [Produces("application/bson")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult BsonData()
        {
            //Dictionary<string, string> values = new Dictionary<string, string>();
            //values.Add("test", "beta");

            var result = new JObject();
            JArray array = new JArray();
            array.Add("Manual text");
            array.Add(new DateTime(2000, 5, 23));
            result["id"] = 1;
            result["result"] = array;

            return Content(result.ToString(), "application/bson");
        }
    }
}
