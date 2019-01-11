using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace GetSecretKeyService.Controllers
{
    [Produces("application/json")]
    [Route("api/GetSecretKey")]
    public class GetSecretKeyController
    {
        private static readonly HttpClient client = new HttpClient();


        [HttpGet]
        public async System.Threading.Tasks.Task<IEnumerable<string>> GetAsync()
        {
            string a = await sendGetRequestAsync();
            return new string[] { a };
        }

        public async System.Threading.Tasks.Task<string> sendGetRequestAsync () {
            var responseString = await client.GetStringAsync("http://localhost:51999/api/SendSecretKey");
            return responseString.ToString();
            }
    }
}
