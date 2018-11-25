using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreateSurvey.Models;

namespace CreateSurvey.Repositories
{
    public class CreateSurveyStorage
    {
        private List<CreateSurveyModel> survey;
        public CreateSurveyStorage()
        {

            List<String> answers1 = new List<String>();
            List<String> answers2 = new List<String>();
            List<String> answers3 = new List<String>();
            List<String> answers4 = new List<String>();
            List<String> answers5 = new List<String>();
            List<String> answers6 = new List<String>();
            answers1.Add("Bitcoin");answers1.Add("Kreditkarte"); answers1.Add("Paypal"); answers1.Add("Per Nachname"); answers1.Add("SEPA"); answers1.Add("Sofort Ueberweisung");
            answers2.Add("Per Zusteller in 24h"); answers2.Add("Per Zusteller in 2-5 Tagen"); answers2.Add("Per Post"); answers2.Add("Per Post Express"); answers2.Add("Ins EU Ausland Standard"); answers2.Add("Ins EU Ausland Express");
            answers3.Add("Lebensmittel"); answers3.Add("Regionale Lebensmittel"); answers3.Add("Wurst und Käse"); answers3.Add("Wurst und Käse aus der Region"); answers3.Add("Weine"); answers3.Add("Weine aus der Region"); answers3.Add("Getränke"); answers3.Add("Getränke aus der Region");
            answers4.Add("Lebensmittel"); answers4.Add("Regionale Lebensmittel"); answers4.Add("Wurst und Käse"); answers4.Add("Wurst und Käse aus der Region"); answers4.Add("Weine"); answers4.Add("Weine aus der Region"); answers4.Add("Getränke"); answers4.Add("Getränke aus der Region");
            answers5.Add("Bezahlung"); answers5.Add("Abwicklung"); answers5.Add("Übersicht der Homepage"); answers5.Add("Würden Sie uns empfehlen?");
            answers6.Add("Bezahlung"); answers6.Add("Abwicklung"); answers6.Add("Übersicht der Homepage"); answers6.Add("Würden Sie uns empfehlen?");


            survey = new List<CreateSurveyModel>
             {
                new CreateSurveyModel(){QuestionId=1, Question="Was ist ihre bevorzugte Art zu bezahlen?", Answers=answers1, Category="seller" },
                new CreateSurveyModel(){QuestionId=2, Question="Welche Lieferarten bieten Sie an?", Answers=answers2, Category="buyer"  },
                new CreateSurveyModel(){QuestionId=3, Question="Welche Produkte wecken Ihr Interesse?", Answers=answers3,Category="buyer"  },
                new CreateSurveyModel(){QuestionId=4, Question="Welche Produkte bieten Sie an?", Answers=answers4, Category="seller"  },
                new CreateSurveyModel(){QuestionId=5, Question="Wie zufrieden sind Sie mit Ihren Verkäufen?", Answers=answers5, Category="buyer"  },
                new CreateSurveyModel(){QuestionId=6, Question="Wie zufrieden sind Sie mit Ihrem Einkauf?", Answers=answers6, Category="seller"  },
            };
        }

        public List<CreateSurveyModel> Survey
        {
            get => survey; set => survey = value;
        }   
    
    }
}
