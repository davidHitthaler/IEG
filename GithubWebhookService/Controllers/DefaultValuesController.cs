using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GithubWebhookService.Controllers
{
    [Route("api/[controller]")]
    public class DefaultValuesController : Controller
    {
        // GET api/DefaultValues
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}