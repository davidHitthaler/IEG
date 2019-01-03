using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Quiz.Models;
using QuizMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

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
            string link = "http://localhost:50221/api/createSurvery";
            WebClient wc = new WebClient();

            try { 
            string surveyJson = wc.DownloadString(link);
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
                        LoggingFunction("Buyer action: Buyer questionare", "Information", "QuizMVC:HomeController");
                        Console.WriteLine("-----------------------");
                        Debug.WriteLine( "Buyer categorie");

                    }
                    if (category == "seller")
                    {
                        sellerQuiz.Add(new QuizModel(questionId, question, answer1, answer2, answer3, answer4, answer5, answer6, answer7, category));
                        LoggingFunction("Seller action: Seller questionare", "Information", "QuizMVC:HomeController");
                        Console.WriteLine("-----------------------");
                        Debug.WriteLine("Seller categorie");
                    }
                    _quiz.Add(new QuizModel(questionId, question, answer1, answer2, answer3, answer4, answer5, answer6, answer7, category));
                }
                ViewBag.Title = "Home Page";
                return View("index");

            }
            catch (Exception ex) {
                Console.WriteLine(link + "isn't not reachable");
                Debug.WriteLine(link + "isn't not reachable");
                LoggingFunction("Link:" + link+ "isn't not reachable", "Error", "QUizMVC:HomeController");
                LoggingFunction(ex.Message,"Exception","Quiz: HomeController");
                return View("ErrorView");
            }
            // JObject results = JObject.Parse(surveyJson);
           
            

            

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
            //string path = @"C:\Users\mabdullah\source\Repos\IEG\answers.txt";
            string path = @"V:\eigene-docs\master fh campus02\IEG1\SolHandelsplattform V.01 - SDK 2.0\answers.txt";
            //TODO make it relative, workaround: Get in your path to you IEG project file to test!

            int questionId;
            string answer;

            foreach (var key in fc.AllKeys)
            {
                if (key == "item.Category")
                {
                    string[] catName = fc[key].Split(',');
                    category_answer = catName[1];
                }
                string value = fc[key];
                if (key == "Answer1")
                {
                    questionId = 1;
                    answer = fc[key];
                    _answer.Add(new AnswerModel(questionId, answer, category_answer));

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
            Console.WriteLine("-----------------------");
            Debug.WriteLine("Modell is converted to json object");
            string readValues = null;
            try
            {
                string fileName = "answers.txt";
                string fullPath = System.IO.Path.GetFullPath(fileName);
                if (!System.IO.File.Exists(fileName))
                {

                    System.IO.File.AppendAllText(fullPath, anwer_json);
                    LoggingFunction("Exist File: File doesn't exist and new file is created", "Warning", "QuizMVC:HomeController");
                    Console.WriteLine("-----------------------");
                    Debug.WriteLine(fullPath + ":isn't exist and new one is created");
                }
                System.IO.File.AppendAllText(fileName, anwer_json);
                readValues = System.IO.File.ReadAllLines(fileName, Encoding.UTF8).ToString();
                //System.IO.File.AppendAllText(path, anwer_json);
                // System.IO.File.WriteAllText(@"C:\Users\mabdullah\source\Repos\IEG\answers.txt", json);
                string textToReturn = System.IO.File.ReadAllText(fileName).ToString();

                // return Json(textToReturn.ToString(), JsonRequestBehavior.AllowGet);
                return View("saveView");
            }
            catch (Exception ex)
            {
                readValues = ex.ToString();
                LoggingFunction(ex.Message, ex.GetType().ToString(), "QuizMVC: HomeController");
                Console.WriteLine("-----------------------");
                Debug.WriteLine(ex.Message);
                return View("ErrorView");
            }
            
        }

        public void LoggingFunction(string message, string typ, string who)
        {
            //StringBuilder sb = new StringBuilder();
            //sb.Append(message);
            // flush every 20 seconds as you do it
            //File.AppendAllText(filePath + "log.txt", sb.ToString());
            //sb.Clear();
            string logMessage = DateTime.Now  + ", TYPE: " + typ + ", WHO: " + who + ", MESSAGE: " + message + Environment.NewLine;
             //StreamWriter sw = new StreamWriter(@".\log.txt", true);
            //string path = Path.GetFullPath(@".\IEG\log.txt");
            string logFileName = "log.txt";
            string fullPath = System.IO.Path.GetFullPath(logFileName);
            if (!System.IO.File.Exists(logFileName))
            {
                System.IO.File.AppendAllText(fullPath, logMessage);
                LoggingFunction("Exist File: File doesn't exist and new file is created", "Warning", "QuizMVC:HomeController");

            }
             System.IO.File.AppendAllText(logFileName, logMessage);
            //System.IO.File.AppendAllText(@"C:\Users\mabdullah\source\Repos\IEG\log.txt", logMessage);
            // StreamWriter sw = new StreamWriter(@"C:\Users\mabdullah\source\Repos\IEG\log.txt", append:true);
            //sw.WriteLine(logMessage);
            //sw.Close();
            logMessage = "";
        }

    }
}
