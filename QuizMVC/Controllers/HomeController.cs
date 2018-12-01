using Newtonsoft.Json.Linq;
using Quiz.Models;
using QuizMVC.Models;
using System;
using System.Collections.Generic;
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
        private static Survey _survey = new Survey();
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
        [HttpPost]
        public ActionResult BuyerAction(string Answer)
        {
            return RedirectToAction("Save");

        }
        [HttpGet]
        public ActionResult SellerAction()
        {
            return View("sellerView", sellerQuiz);
        }
        [HttpPost]
        public ActionResult SellerAction(string Answer)
        {
            return RedirectToAction("Save");
        }
        [HttpGet]
        public ActionResult Save()
        {
            return View("saveView");
        }
        [HttpGet]
        public ActionResult Submit()
        {
            return View("saveView");
        }

    }
}
