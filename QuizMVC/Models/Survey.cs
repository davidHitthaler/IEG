using Quiz.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizMVC.Models
{
    public class Survey
    {
        public ArrayList surveyList = new ArrayList();

        //action to get user details 
        //  public QuizModel GetQuiz()
        // {
        //      QuizModel quizMdl = null;

        //    foreach (QuizModel q in surveyList)

        //       if (q.QuestionId == id)
        //          quizMdl = q;
        //   return quizMdl;
        //  }
        //action to create new user 
        public void CreateList(QuizModel quizModel)
        {
            surveyList.Add(quizModel);
        }

    }
}