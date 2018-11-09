using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IEGPaymentService.Models;
using IEGPaymentService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PaymentService.Controllers
{
    [Route("api/PaymentService")]
    public class PaymentServiceController : Controller
    {
        private PaymentStorage _paymentStorage = new PaymentStorage();

        // GET: api/PaymentService
        [HttpGet]
        public IEnumerable<PaymentModel> Get()
        {
            return _paymentStorage.Payments;
        }

        [HttpPost]
        public IEnumerable<PaymentModel> Post([FromBody] PaymentModel payment)
        {
            _paymentStorage.Payments.Add(payment);
            //return CreatedAtAction("Payment Added, ID = ", new { id = paymentModel.PaymentId });
            return _paymentStorage.Payments; //IEnumerable<PaymentModel>
        }
    }
}
