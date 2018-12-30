using Newtonsoft.Json.Linq;
using Quiz.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Repository
{
    public class ReadOutStoredFileFromQuiz
    {
        private static List<EvaluateModel> _evaluateStorage = new List<EvaluateModel>();

        public IEnumerable<EvaluateModel> Get()
        {
            _evaluateStorage.Clear();
            quizParse();
            return _evaluateStorage;
        }

        public EvaluateModel Get(int questionId)
        {
            _evaluateStorage.Clear();
            quizParse();
            return _evaluateStorage.Where(p => p.QuestionId == questionId).SingleOrDefault();
        }

        private static void quizParse()
        {
            string json_string = File.ReadAllText(@"..\answers.txt", Encoding.UTF8);
            //string json_string = File.ReadAllText(@"c:\answer.txt", Encoding.UTF8);
            JArray results = JArray.Parse(json_string);

            foreach (JObject o in results.Children<JObject>())
            {
                int QuestionId = Int32.Parse((string)o["QuestionId"]);
                int Answer = Int32.Parse((string)o["Answer"]);
                string Category = (string)o["Category"];

                _evaluateStorage.Add(new EvaluateModel() { QuestionId = QuestionId, Answer = Answer, Category = Category });

            }

            string predef_json_string = File.ReadAllText(@"..\predefinedAnswers.txt", Encoding.UTF8);
            JArray predefResults = JArray.Parse(predef_json_string);

            foreach (JObject o in predefResults.Children<JObject>())
            {
                int QuestionId = Int32.Parse((string)o["QuestionId"]);
                int Answer = Int32.Parse((string)o["Answer"]);
                string Category = (string)o["Category"];

                _evaluateStorage.Add(new EvaluateModel() { QuestionId = QuestionId, Answer = Answer, Category = Category });
            }
        }
    }
}
