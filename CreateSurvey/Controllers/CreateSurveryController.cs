using System;
using System.Collections.Generic;
using CreateSurvey.Models;
using CreateSurvey.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CreateSurvey.Controllers
{
    [Route("api/createSurvery")]
    public class CreateSurveyController : Controller
    {
        private static CreateSurveyStorage _surveryStorage = new CreateSurveyStorage();

        // GET api/values
        [HttpGet]
        public IEnumerable<CreateSurveyModel> Get()
        {
            return _surveryStorage.Survey;
        }

        [HttpPost]
        public IEnumerable<CreateSurveyModel> Post([FromBody] CreateSurveyModel survery)
        {
            _surveryStorage.Survey.Add(survery);
            //return CreatedAtAction("Payment Added, ID = ", new { id = paymentModel.PaymentId });
            return _surveryStorage.Survey;
        }
    }
}
