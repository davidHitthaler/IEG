using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Quiz.Models;
using QuizMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace QuizMVC.Controllers
{
    public class HomeController : Controller
    {
        private static List<QuizModel> _quiz = new List<QuizModel>();
        private static List<QuizModel> buyerQuiz = new List<QuizModel>();
        private static List<QuizModel> sellerQuiz = new List<QuizModel>();
        private static List<AnswerModel> _answer = new List<AnswerModel>();
        private static Survey _survey = new Survey();
        string category_answer;
        [HttpGet]
        public ActionResult Index()
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
                if (category == "buyer")
                {
                    buyerQuiz.Add(new QuizModel(questionId, question, answer1, answer2, answer3, answer4, answer5, answer6, answer7, category));
                }
                if (category == "seller")
                {
                    sellerQuiz.Add(new QuizModel(questionId, question, answer1, answer2, answer3, answer4, answer5, answer6, answer7, category));
                }
                _quiz.Add(new QuizModel( questionId, question,answer1,  answer2,  answer3,  answer4,  answer5,  answer6,  answer7, category));
            }

                ViewBag.Title = "Home Page";
            return View("index");


        }
        [HttpGet]
        public ActionResult BuyerAction()
        {
            return View("buyerView", buyerQuiz);

        }
        
        
        [HttpGet]
        public ActionResult SellerAction()
        {
            return View("sellerView", sellerQuiz);
        }
        [HttpPost]
        public ActionResult Save(FormCollection fc, IEnumerable<QuizModel> model)
        {
            string path = @"C:\Users\mabdullah\source\Repos\IEG\answers.txt";
            int questionId; 
            string answer;

            foreach (var key in fc.AllKeys)
            {
                if (key == "item.Category")
                {
                    string[] catName = fc[key].Split(',');
                    category_answer = catName[0];
                }
                string value=fc[key];
                if (key == "Answer1")
                {
                    questionId = 1;
                    answer = fc[key];
                    _answer.Add(new AnswerModel(questionId,answer, category_answer));

                }
                if (key == "Answer2")
                {
                    questionId = 2;
                    answer = fc[key];
                    _answer.Add(new AnswerModel(questionId, answer, category_answer));
                }
                if (key == "Answer3")
                {
                    questionId = 3;
                    answer = fc[key];
                    _answer.Add(new AnswerModel(questionId, answer, category_answer));
                }
                if (key == "Answer4")
                {
                    questionId = 4;
                    answer = fc[key];
                    _answer.Add(new AnswerModel(questionId, answer, category_answer));
                }
                if (key == "Answer5")
                {
                    questionId = 5;
                    answer = fc[key];
                    _answer.Add(new AnswerModel(questionId, answer, category_answer));
                }
                if (key == "Answer6")
                {
                    questionId = 6;
                    answer = fc[key];
                    _answer.Add(new AnswerModel(questionId, answer, category_answer));
                }
               


            }
            //return View("saveView");

            // Request.InputStream.Seek(0, SeekOrigin.Begin);
            // string jsonData = new StreamReader(Request.InputStream).ReadToEnd();
           
            // Creates or overwrites the file with the contents of the JSON
            //System.IO.File.WriteAllText(@"C:\Users\mabdullah\source\Repos\IEG\answers.txt", jsonData);
            // var initialJson = System.IO.File.ReadAllText(@"C:\Users\mabdullah\source\Repos\IEG\answers.txt"");
            string anwer_json = JsonConvert.SerializeObject(_answer.ToArray());
            System.IO.File.AppendAllText(path, anwer_json);
            // System.IO.File.WriteAllText(@"C:\Users\mabdullah\source\Repos\IEG\answers.txt", json);
            string textToReturn = System.IO.File.ReadAllText(path).ToString();
           
           // return Json(textToReturn.ToString(), JsonRequestBehavior.AllowGet);
            return View("saveView");
        }



    }
}
