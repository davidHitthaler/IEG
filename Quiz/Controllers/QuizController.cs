using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Http.Headers;

using System.Net;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Quiz.Models;

namespace Quiz.Controllers
{
    [Produces("application/json")]
    [Route("api/quiz")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private static List<QuizModel> _quiz = new List<QuizModel>();
        //string[] _answers = new string[5];

        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<string> survey = new List<string>();

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:50221/api/createSurvery");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //soll da behandelt ist!!!!
            HttpResponseMessage response = client.GetAsync("http://localhost:50221/api/createSurvery").Result;

            if (response.IsSuccessStatusCode)
            {
                WebClient wc = new WebClient();
                string surveyJson = wc.DownloadString("http://localhost:50221/api/createSurvery");

                // JObject results = JObject.Parse(surveyJson);
                JArray results = JArray.Parse(surveyJson);
                foreach (var result in results)
                {
                 //   string[] _answers = new string[8]; soll erst json änderen dann geht
                    int questionId = Int32.Parse((string)result["questionId"]);
                    string question = (string)result["question"];
                    string answer1 = (string)result["answer1"];
                    string answer2 = (string)result["answer2"];
                    string answer3 = (string)result["answer3"];
                    string answer4 = (string)result["answer4"];
                    string answer5 = (string)result["answer5"];
                    string answer6 = (string)result["answer6"];
                    string answer7 = (string)result["answer7"];
                    string category = (string)result["category"];

                    _quiz.Add(new QuizModel() { QuestionId = questionId, Question = question, Answer1 = answer1, Answer2 = answer2, Answer3 = answer3, Answer4 = answer4, Answer5 = answer5, Answer6 = answer6, Answer7 = answer7, Category = category });

                    /*  // Answers
                      JArray answers = (JArray)result["answers"];
                      for (int i = 0; i < answers.Count; i++)
                      {
                          _answers[i] = (string)answers[i];
                      }
                      //---
                      string category = (string)result["category"];
                      Console.WriteLine(_answers);
                      _answers = new string[8];*/
                }
            }
            else
            {
                return new string[] { survey.ToString(), "ok" };
            }


            return survey;

        }

    }
}
