using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Http.Headers;
using Polly;
using System.Net;

namespace BlackFriday.Controllers
{
    [Produces("application/json")]
    [Route("api/PaymentMethods")]
    public class PaymentMethodsController : Controller
    {
        //https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client
        private readonly ILogger<PaymentMethodsController> _logger;
        private static readonly string creditcardServiceBaseAddress = "https://iegeasycreditcardservice20180v1.azurewebsites.net";
        private static readonly string creditcardServiceBaseAddress_2 = "https://iegeasycreditcardservice20180v2.azurewebsites.net";
        private static readonly string creditcardServiceBaseAddress_3 = "https://iegeasycreditcardservice20180v3.azurewebsites.net";
        private List<string> urlList = new List<string>();

        public PaymentMethodsController(ILogger<PaymentMethodsController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(creditcardServiceBaseAddress + "fehlerhaft");

            var retryPolicy = Policy
           .HandleResult<HttpResponseMessage>(message => !message.IsSuccessStatusCode)
           .WaitAndRetryAsync(3, j => TimeSpan.FromSeconds(2), (result, timeSpan, retryCount, context) =>
           {

               client = new HttpClient();
               if (retryCount == 1)
                   client.BaseAddress = new Uri(creditcardServiceBaseAddress_2);
               else
                   client.BaseAddress = new Uri(creditcardServiceBaseAddress_3);


           });
            var fallbackPolicy = Policy.HandleResult<HttpResponseMessage>(
                 r => r.StatusCode == HttpStatusCode.InternalServerError)
            .FallbackAsync(new HttpResponseMessage(HttpStatusCode.OK)
             {
              // _logger.LogWarning("falild");

        });
            var retryWithFallback = fallbackPolicy.WrapAsync(retryPolicy);


            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await retryWithFallback.ExecuteAsync(
                   () => client.GetAsync("api/AcceptedCreditCards"));

            string acceptedPaymentMethods = null;
            if (response.IsSuccessStatusCode)//Status Code is always 404
            {
                acceptedPaymentMethods = await response.Content.ReadAsStringAsync();
            }
            return new string[] { "value1", "value2" };
        }

    }
}

