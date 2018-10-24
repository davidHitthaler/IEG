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

namespace BlackFriday.Controllers
{
    [Produces("application/json")]
    [Route("api/PaymentMethods")]
    public class PaymentMethodsController : Controller
    {
        //this Code works 
        //https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client
        private readonly ILogger<PaymentMethodsController> _logger;
        private static readonly string creditcardServiceBaseAddress = "https://iegeasycreditcardservice20180v1.azurewebsites.net/api/AcceptedCreditCards";
        private static readonly string creditcardServiceBaseAddress_2 = "https://iegeasycreditcardservice20180v2.azurewebsites.net/api/AcceptedCreditCards";
        private static readonly string creditcardServiceBaseAddress_3 = "https://iegeasycreditcardservice20180v3.azurewebsites.net/api/AcceptedCreditCards";
        private List<string> urlList = new List<string>();

        public PaymentMethodsController(ILogger<PaymentMethodsController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            urlList.Add(creditcardServiceBaseAddress);
            urlList.Add(creditcardServiceBaseAddress_2);
            urlList.Add(creditcardServiceBaseAddress_3);

            List<string> acceptedPaymentMethods = null;//= new string[] { "Diners", "Master" };
            _logger.LogError("Accepted Paymentmethods");

            var count = 0;
            var policy = Policy
                .Handle<Exception>()
                .OrResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                .RetryAsync(3, (ex, retryCount) =>
                {
                    Console.WriteLine($"Retry count {retryCount}");

                    if (retryCount == 3)
                    {
                        count = retryCount;

                    }
                });

            for (int i = 0; i < urlList.Count; i++)
            {
                if (count < 3)
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(urlList[i]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await policy.ExecuteAsync(
                         () => client.GetAsync(urlList[i]));

                    if (!response.IsSuccessStatusCode)
                    {
                        count = 0;
                        i++;
                        if (i == urlList.Count - 1)
                        {
                            acceptedPaymentMethods = null;
                            break;
                        }
                        response = await policy.ExecuteAsync(() => client.GetAsync(urlList[i]));
                    }
                    if (response.IsSuccessStatusCode)
                        acceptedPaymentMethods = response.Content.ReadAsAsync<List<string>>().Result;
                    _logger.LogInformation("Response was successful.");
                    foreach (var item in acceptedPaymentMethods)
                    {
                        _logger.LogError("Paymentmethod {0}", new object[] { item });

                    }
                    break;

                }
            }


            if (acceptedPaymentMethods == null)
                return null;
            else
                return acceptedPaymentMethods;
        }
    }
}
//ALternative
//

/*

// dieser Code funktioniert aber immer StatusCode ist 404 !!!

            //HttpResponseMessage response = client.GetAsync(creditcardServiceBaseAddress + "api/AcceptedCreditCards").Result;
            var count = 0;
            var policy = Policy
           .HandleResult<HttpResponseMessage>(message => !message.IsSuccessStatusCode)
           .WaitAndRetryAsync(3, j => TimeSpan.FromSeconds(2), (result, timeSpan, retryCount, context) =>
           {

               if (retryCount == 3)
               {
                   // I want to change client.GetSync with another Url when retrycount=3 and the IsSuccessStatsCode is false!!!!!!!!
                   count = retryCount;
               }

               _logger.LogWarning($"Request failed with {result.Result.StatusCode}. Waiting {timeSpan} before next retry. Retry attempt {retryCount}");
           });
            for (int i = 0; i < urlList.Count; i++)
            {
                if (count < 3)
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(urlList[i]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await policy.ExecuteAsync(
                         () => client.GetAsync(urlList[i]));


                    if (!response.IsSuccessStatusCode)//Status Code is always 404
                    {
                        count = 0;
                        i++;
                        if (i == urlList.Count - 1)
                        {
                            _logger.LogInformation("Status Code 404 not found.");
                            acceptedPaymentMethods = null;
                            break;


                        }
                        response = await policy.ExecuteAsync(() => client.GetAsync(urlList[i]));
                    }
                    if (response.IsSuccessStatusCode)
                    
                        acceptedPaymentMethods = response.Content.ReadAsAsync<List<string>>().Result;
                        _logger.LogInformation("Response was successful.");
                        foreach (var item in acceptedPaymentMethods)
                        {
                            _logger.LogError("Paymentmethod {0}", new object[] { item });

                        }
                        break;
                    
                }

            }
            
            if (acceptedPaymentMethods == null)
                return acceptedPaymentMethods = null;
            else

                return acceptedPaymentMethods;
        }
    }
}



 */
