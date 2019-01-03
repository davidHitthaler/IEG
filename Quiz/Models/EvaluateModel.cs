using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Models
{
    public class EvaluateModel
    {
        public EvaluateModel(int questionId, int answer, string category)
        {
            this.QuestionId = questionId;
            this.Answer = answer;
            this.Category = category;
        }

        public EvaluateModel()
        {

        }

        public int QuestionId { get; set; }
        public int Answer { get; set; }
        public string Category { get; set; }
    }
}
