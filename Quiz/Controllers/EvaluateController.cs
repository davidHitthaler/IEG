using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiz.Models;

namespace Quiz.Controllers
{
    public class EvaluateController : Controller
    {

        /*[HttpGet]
        public IEnumerable<string> Get(int questionId)
        {
            string mostwanted = "";
            mostwanted = calcEvaluation(questionId);
            return new string[] { mostwanted };
        }*/
        /*
        private static string calcEvaluation(int questionId)
        {
            EvaluateModel evaluate = new EvaluateModel();

            //alle als list haben
            
            string mostwanted = "";

            /*
                switch (caseSwitch)
            {
                case 1:
                    Console.WriteLine("Case 1");
                    break;
                case 2:
                    Console.WriteLine("Case 2");
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
              

            //get alle daten aus der liste 
            for (int i = 0; i < liste.length(); i++)
            {
                if (questionId == evaluate.questionId[i]) {
                    answers = evaluate.answer;
                    if (answers == answer1)
                    {
                        ans1++;
                    }
                } 
            }



            return mostwanted;
    }*/
}
}
 