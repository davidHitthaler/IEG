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

        public CreateSurveyModel(int questionId, string question, List<String> answers, string category)
        {
            questionId = QuestionId;
            question = Question;
            answers = Answers;
            category = Category;
        }

        public int QuestionId { get; set; }
        [System.ComponentModel.DataAnnotations.MinLength(2)]
        public string Question { get; set; }
        public List<String> Answers { get; set; }
        public string Category { get; set; }
        public static implicit operator List<object>(CreateSurveyModel v)
        {
            throw new NotImplementedException();
        }
    }
}
