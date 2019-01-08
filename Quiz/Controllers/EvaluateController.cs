using System;
using System.Collections.Generic;
using System.Linq;
using CreateSurvey.Models;
using CreateSurvey.Repositories;
using Microsoft.AspNetCore.Mvc;
using Quiz.Models;
using Quiz.Repository;

namespace Quiz.Controllers
{
    [Produces("application/json")]
    [Route("api/Evaluate")]
    public class EvaluateController : Controller
    {
        static ReadOutStoredFileFromQuiz liste = new ReadOutStoredFileFromQuiz();
        static CreateSurveyStorage surveyStorage = new CreateSurveyStorage();
       
        [HttpGet]
        public IEnumerable<string> Get()
        {
            string mostwanted = "";
            mostwanted = calcEvaluation(liste.Get(), 2);
            LoggingFunction("Get Evaluation", "Information", "Quiz:EvaluateController");
            return new string[] { "Please select a question-ID. URL Example: http://localhost:56482/api/evaluate/1" };
        }
        

        [HttpGet("{questionId}")]
        public IEnumerable<string> Get(int questionId)
        {
            string mostwanted = "";
            mostwanted = calcEvaluation(liste.Get(), questionId);
            LoggingFunction("Get Evaluation by question Id", "Information", "Quiz:EvaluateController");
            return new string[] { mostwanted };
        }

        private static string calcEvaluation(IEnumerable<EvaluateModel> quiz, int questionId)
        {
            string mostwanted = "";

            int case1 = 0;
            int case2 = 0;
            int case3 = 0;
            int case4 = 0;
            int case5 = 0;
            int case6 = 0;
            int case7 = 0;

            string answer1 = "";
            string answer2 = "";
            string answer3 = "";
            string answer4 = "";
            string answer5 = "";
            string answer6 = "";
            string answer7 = "";

            foreach (var item in quiz)
            {
                if (item.QuestionId == questionId)
                {
                    switch (item.Answer)
                    {
                        case 1:
                            case1 += 1;
                            break;
                        case 2:
                            case2 += 1;
                            break;
                        case 3:
                            case3 += 1;
                            break;
                        case 4:
                            case4 += 1;
                            break;
                        case 5:
                            case5 += 1;
                            break;
                        case 6:
                            case6 += 1;
                            break;
                        case 7:
                            case7 += 1;
                            break;
                        default:
                            break;
                    }
                }
            }

            string nameMax = (new[] {
                Tuple.Create("case1", case1),
                Tuple.Create("case2", case2),
                Tuple.Create("case3", case3),
                Tuple.Create("case4", case4),
                Tuple.Create("case5", case5),
                Tuple.Create("case6", case6),
                Tuple.Create("case7", case7)
                }).OrderByDescending(t => t.Item2).First().Item1;

            List<CreateSurveyModel> surveyList = surveyStorage.Survey;
            
            foreach (var surv in surveyList)
            {
                if (surv.QuestionId == questionId)
                {
                    answer1 = surv.Answer1;
                    answer2 = surv.Answer2;
                    answer3 = surv.Answer3;
                    answer4 = surv.Answer4;
                    answer5 = surv.Answer5;
                    answer6 = surv.Answer6;
                    answer7 = surv.Answer7;
                }
            }

            switch (nameMax)
            {
                case "case1":
                    if (questionId == 1)
                    {
                        mostwanted = answer1;
                    } else if (questionId == 2)
                    {
                        mostwanted = answer2;
                    } else if (questionId == 3)
                    {
                        mostwanted = answer3;
                    } else if (questionId == 4)
                    {
                        mostwanted = answer4;
                    } else if (questionId == 5)
                    {
                        mostwanted = answer5;
                    }
                    break;
                case "case2":
                    if (questionId == 1)
                    {
                        mostwanted = answer1;
                    }
                    else if (questionId == 2)
                    {
                        mostwanted = answer2;
                    }
                    else if (questionId == 3)
                    {
                        mostwanted = answer3;
                    }
                    else if (questionId == 4)
                    {
                        mostwanted = answer4;
                    }
                    else if (questionId == 5)
                    {
                        mostwanted = answer5;
                    }
                    break;
                case "case3":
                    if (questionId == 1)
                    {
                        mostwanted = answer1;
                    }
                    else if (questionId == 2)
                    {
                        mostwanted = answer2;
                    }
                    else if (questionId == 3)
                    {
                        mostwanted = answer3;
                    }
                    else if (questionId == 4)
                    {
                        mostwanted = answer4;
                    }
                    else if (questionId == 5)
                    {
                        mostwanted = answer5;
                    }
                    break;
                case "case4":
                    if (questionId == 1)
                    {
                        mostwanted = answer1;
                    }
                    else if (questionId == 2)
                    {
                        mostwanted = answer2;
                    }
                    else if (questionId == 3)
                    {
                        mostwanted = answer3;
                    }
                    else if (questionId == 4)
                    {
                        mostwanted = answer4;
                    }
                    else if (questionId == 5)
                    {
                        mostwanted = answer5;
                    }
                    break;
                case "case5":
                    if (questionId == 1)
                    {
                        mostwanted = answer1;
                    }
                    else if (questionId == 2)
                    {
                        mostwanted = answer2;
                    }
                    else if (questionId == 3)
                    {
                        mostwanted = answer3;
                    }
                    else if (questionId == 4)
                    {
                        mostwanted = answer4;
                    }
                    else if (questionId == 5)
                    {
                        mostwanted = answer5;
                    }
                    break;
                case "case6":
                    if (questionId == 1)
                    {
                        mostwanted = answer1;
                    }
                    else if (questionId == 2)
                    {
                        mostwanted = answer2;
                    }
                    else if (questionId == 3)
                    {
                        mostwanted = answer3;
                    }
                    else if (questionId == 4)
                    {
                        mostwanted = answer4;
                    }
                    else if (questionId == 5)
                    {
                        mostwanted = answer5;
                    }
                    break;
                case "case7":
                    if (questionId == 1)
                    {
                        mostwanted = answer1;
                    }
                    else if (questionId == 2)
                    {
                        mostwanted = answer2;
                    }
                    else if (questionId == 3)
                    {
                        mostwanted = answer3;
                    }
                    else if (questionId == 4)
                    {
                        mostwanted = answer4;
                    }
                    else if (questionId == 5)
                    {
                        mostwanted = answer5;
                    }
                    break;
            }

            return mostwanted;
        }
        public void LoggingFunction(string message, string typ, string who)
        {
            string logMessage = DateTime.Now + ", TYPE: " + typ + ", WHO: " + who + ", MESSAGE: " + message + Environment.NewLine;
            System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\log.txt", true);
            file.WriteLine(logMessage);

            file.Close();
            logMessage = "";
        }
    }
}
