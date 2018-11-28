using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateSurvey.Models
{
    public class CreateSurveyModel
    {
        List<String> answsers = new List<String>();
        public CreateSurveyModel()
        {
          
        }

        public CreateSurveyModel(int questionId, string question, string answer1,string answer2,string answer3,string answer4,string answer5,string answer6, string answer7, string category)
        {
            questionId = QuestionId;
            question = Question;
            answer1 = Answer1;
            answer2 = Answer2;
            answer3 = Answer3;
            answer4 = Answer4;
            answer5 = Answer5;
            answer5 = Answer5;
            answer7 = Answer7;
            category = Category;
        }

        public int QuestionId { get; set; }
        [System.ComponentModel.DataAnnotations.MinLength(2)]
        public string Question { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public string Answer5 { get; set; }
        public string Answer6 { get; set; }
        public string Answer7 { get; set; }
        public string Category { get; set; }
        public static implicit operator List<object>(CreateSurveyModel v)
        {
            throw new NotImplementedException();
        }
    }
}
