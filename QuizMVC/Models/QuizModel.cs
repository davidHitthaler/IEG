using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Models
{
    public class QuizModel
    {
     

        public QuizModel()
        {
        }
        // model für HTML später binden
        public QuizModel(int questionId, string question, string answer1, string answer2, string answer3, string answer4, string answer5, string answer6, string answer7, string category)
        {
            QuestionId=questionId;
            Question=question;
            Answer1=answer1;
            Answer2=answer2;
            Answer3=answer3;
            Answer4=answer4;
            Answer5= answer5;
            Answer6= answer6;
            Answer7=answer7;
            Category=category;
        }

        public int QuestionId { get; set; }
        public string Question { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public string Answer5 { get; set; }
        public string Answer6 { get; set; }
        public string Answer7 { get; set; }
        public string SelectedAnswer { get; set; }
        public string Category { get; set; }

    }
}
