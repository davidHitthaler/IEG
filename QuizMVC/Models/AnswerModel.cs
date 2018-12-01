using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizMVC.Models
{
    public class AnswerModel
    {
        public AnswerModel()
        {
        }
        // model für HTML später binden
        public AnswerModel(int questionId, string question, string answer,  string category)
        {
            QuestionId = questionId;
            Question = question;
            Answer = answer;
            Category = category;
        }

        public int QuestionId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Category { get; set; }

    
}
}