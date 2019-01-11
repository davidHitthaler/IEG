using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SecretKeyService.Controllers
{
    [Produces("application/json")]
    [Route("api/SendSecretKey")]
    public class SendSecretKeyController : Controller
    {
        [HttpGet]
        public string Get()
        {
           string a = SecretKeys.currentKey;
            return a;
        }
    }
}