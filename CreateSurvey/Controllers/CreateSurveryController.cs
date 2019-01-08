using System;
using System.Collections.Generic;
using System.IO;
using CreateSurvey.Models;
using CreateSurvey.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CreateSurvey.Controllers
{
    [Route("api/createSurvery")]
    public class CreateSurveyController : Controller
    {
        private CreateSurveyStorage _surveryStorage = new CreateSurveyStorage();

        // GET api/values
        [HttpGet]
        public IEnumerable<CreateSurveyModel> Get()
        {
            LoggingFunction("getting Survey", "Information", "CreateSurvey:CreateSurveyController");
            return _surveryStorage.Survey;
        }

        [HttpPost]
        public IEnumerable<CreateSurveyModel> Post([FromBody] CreateSurveyModel survery)
        {
            _surveryStorage.Survey.Add(survery);
            //return CreatedAtAction("Payment Added, ID = ", new { id = paymentModel.PaymentId });
            LoggingFunction("post Survey", "Information", "CreateSurvey:CreateSurveyController");
            return _surveryStorage.Survey;
        }
        public void LoggingFunction(string message, string typ, string who)
        {
            string logMessage = DateTime.Now + ", TYPE: " + typ + ", WHO: " + who + ", MESSAGE: " + message + Environment.NewLine;
            System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\log.txt",true);
            file.WriteLine(logMessage);

            file.Close();
            logMessage = "";
        }
    }
}
