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

        public QuizModel(int questionId, string question, string answer1, string answer2, string answer3, string answer4, string answer5, string answer6, string answer7, string category)
        {
            questionId = QuestionId;
            question = Question;
            answer1 = Answer1;
            answer2 = Answer2;
            category = Category;
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
        public string Category { get; set; }

        public static implicit operator List<object>(QuizModel v)
        {
            throw new NotImplementedException();
        }
    }
}
