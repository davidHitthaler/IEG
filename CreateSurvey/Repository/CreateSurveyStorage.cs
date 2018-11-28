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
            survey = new List<CreateSurveyModel>
             {
                new CreateSurveyModel(){QuestionId=1, Question="Was ist ihre bevorzugte Art zu bezahlen?", Answer1="Bitcoin", Answer2="Kreditkarte", Answer3="Paypal", Answer4="Per Nachname", Answer5="Per Post Express", Answer6="Ins EU Ausland Standard", Answer7="Ins EU Ausland Express", Category="seller" },
                new CreateSurveyModel(){QuestionId=2, Question="Welche Lieferarten bieten Sie an?", Answer1="Per Zusteller in 24h", Answer2="Per Zusteller in 2-5 Tagen", Answer3="Per Post", Answer4="Per Nachname", Answer5="SEPA", Answer6="Bitcoin", Answer7="Sofort Ueberweisung", Category="buyer"  },
                new CreateSurveyModel(){QuestionId=3, Question="Welche Produkte wecken Ihr Interesse?", Answer1="Lebensmittel", Answer2="Regionale Lebensmittel", Answer3="Wurst und Käse", Answer4="Wurst und Käse aus der Region", Answer5="Weine", Answer6="Weine aus der Region", Answer7="Getränke",Category="buyer"  },
                new CreateSurveyModel(){QuestionId=4, Question="Welche Produkte bieten Sie an?", Answer1="Lebensmittel", Answer2="Regionale Lebensmittel", Answer3="Wurst und Käse", Answer4="Wurst und Käse aus der Region", Answer5="Weine", Answer6="Weine aus der Region", Answer7="Getränke", Category="seller"  },
                new CreateSurveyModel(){QuestionId=5, Question="Wie zufrieden sind Sie mit Ihren Verkäufen?", Answer1="Bezahlung", Answer2="Abwicklung", Answer3="Übersicht der Homepage", Answer4="Würden Sie uns empfehlen?", Answer5="Versand", Answer6="Benachrichtugungen", Answer7="Würden Sie uns nicht empfehlen?", Category="buyer"  },
                new CreateSurveyModel(){QuestionId=6, Question="Wie zufrieden sind Sie mit Ihrem Einkauf?", Answer1="Bezahlung", Answer2="Abwicklung", Answer3="Übersicht der Homepage", Answer4="Würden Sie uns empfehlen?", Answer5="Versand", Answer6="Benachrichtugungen", Answer7="Würden Sie uns nicht empfehlen?", Category="seller"  },
            };
        }

        public List<CreateSurveyModel> Survey
        {
            get => survey; set => survey = value;
        }   
    
    }
}
