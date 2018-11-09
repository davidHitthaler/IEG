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
using System.Text;
using System.IO;

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
            LoggingFunction("HttpGet started", "Information", "BlackFriday:PaymentMethodsController");
            //old code before retry logic START
            /*client.BaseAddress = new Uri(creditcardServiceBaseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(creditcardServiceBaseAddress+ "/api/AcceptedCreditCards").Result;
            if (response.IsSuccessStatusCode)
            {
                acceptedPaymentMethods = response.Content.ReadAsAsync<List<string>>().Result;
            }
          
            foreach (var item in acceptedPaymentMethods)
            */
            //old code before retry logic END
            client.BaseAddress = new Uri(creditcardServiceBaseAddress + "fehlerhaft");

            var retryPolicy = Policy
           .HandleResult<HttpResponseMessage>(message => !message.IsSuccessStatusCode)
           .WaitAndRetryAsync(3, j => TimeSpan.FromSeconds(2), (result, timeSpan, retryCount, context) =>
           {

               client = new HttpClient();
               if (retryCount == 1)
               {
                   client.BaseAddress = new Uri(creditcardServiceBaseAddress_2 + "1");
                   LoggingFunction("Retry logic: Start with Alternative 1", "Warning    ", "BlackFriday:PaymentMethodsController");
                   LoggingFunction("Retry logic: Route 1 is dead...", "Error      ", "BlackFriday:PaymentMethodsController");
               }
               else
               {
                   client.BaseAddress = new Uri(creditcardServiceBaseAddress_3);
                   LoggingFunction("Retry logic: Route 2 is dead...", "Warning    ", "BlackFriday:PaymentMethodsController");
               }


           });
            var fallbackPolicy = Policy.HandleResult<HttpResponseMessage>(
                 r => r.StatusCode == HttpStatusCode.InternalServerError)
            .FallbackAsync(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("Please Try again later")

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
                return new string[] { acceptedPaymentMethods ,"BaseAdress 3 works"};
            }
            else
            return new string[] { "Service is not avaliable Try again later" };
        }

        public void LoggingFunction(string message, string typ, string who)
        {
            //StringBuilder sb = new StringBuilder();
            //sb.Append(message);
            // flush every 20 seconds as you do it
            //File.AppendAllText(filePath + "log.txt", sb.ToString());
            //sb.Clear();
            string logMessage = DateTime.Now + ", TYPE: " + typ + ", WHO: " + who + ", MESSAGE: " + message + "\n";
            StreamWriter sw = new StreamWriter(@".\log.txt", true);
            sw.WriteLine(logMessage);
            sw.Close();
            logMessage = "";
        }
    }
}

