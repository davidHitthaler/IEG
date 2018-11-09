using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebHooks;
using Newtonsoft.Json.Linq;

namespace GithubWebhookService.Controllers
{
    [Route("api/[controller]")]
    public class WebhookController : Controller
    {
        public static List<string> webhooktext = new List<string>();
        
        [GitHubWebHook]
        public IActionResult GitHubHandler(string id, string @event, JObject data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } else
            {
                webhooktext.Add(id + "\n" + @event + "\n" + data);      // for webhook test => ....ngrok.io/api/webhook => returns json object
            }

            return Ok();
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return webhooktext;
        }

    }
}