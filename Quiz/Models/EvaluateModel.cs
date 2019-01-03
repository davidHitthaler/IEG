using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Models
{
    public class EvaluateModel
    {
        public EvaluateModel(int QuestionId, int Answer, string Category)
        {
            questionId = QuestionId;
            answer = Answer;
            category = Category;
        }

        public EvaluateModel()
        {

        }

        public int questionId { get; set; }
        public int answer { get; set; }
        public string category { get; set; }
    }
}
