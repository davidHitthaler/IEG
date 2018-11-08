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
        PaymentStorage _paymentStorage = new PaymentStorage();
        // GET: api/PaymentService
        [HttpGet]
        public IEnumerable<PaymentModel> Get()
        {
            return _paymentStorage.Get();
        }

        [HttpGet("{id}")]
        public PaymentModel Get(int id)
        {
            return _paymentStorage.Get(id);            
        }


        [HttpPost]
        public IActionResult Post([FromBody] PaymentModel paymentModel) //TODO Datatyp return value
        { 
            _paymentStorage.Add(paymentModel);
            return CreatedAtAction("Payment Added, ID = ", new { id = paymentModel.PaymentId });
            //return _paymentStorage.Get(); //IEnumerable<PaymentModel>
        }
    }
}
