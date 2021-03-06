﻿using System;
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
                new CreateSurveyModel(){QuestionId=1, Question="Was ist ihre bevorzugte Art zu bezahlen?", Answer1="Bitcoin", Answer2="Kreditkarte", Answer3="Lastschrift", Answer4="Paypal", Answer5="Per Nachname", Answer6="SEPA", Answer7="Sofortueberweisung", Category="seller" },
                new CreateSurveyModel(){QuestionId=2, Question="Welche Lieferarten bieten Sie an?", Answer1="Per Zusteller in 24h", Answer2="Per Zusteller in 2-5 Tagen", Answer3="Per Post", Answer4="Per Post Express", Answer5="Ins EU Ausland Standard", Answer6="Ins EU Ausland Express", Answer7="Vor Ort Uebernahme", Category="buyer"  },
                new CreateSurveyModel(){QuestionId=3, Question="Welche Produkte wecken Ihr Interesse?", Answer1="Lebensmittel", Answer2="Regionale Lebensmittel", Answer3="Wurst und Kaese", Answer4="Wurst und Kaese aus der Region", Answer5="Weine", Answer6="Weine aus der Region", Answer7="Getraenke",Category="buyer"  },
                new CreateSurveyModel(){QuestionId=4, Question="Welche Produkte bieten Sie an?", Answer1="Lebensmittel", Answer2="Regionale Lebensmittel", Answer3="Wurst und Kaese", Answer4="Wurst und Kaese aus der Region", Answer5="Weine", Answer6="Weine aus der Region", Answer7="Getraenke", Category="seller"  },
                new CreateSurveyModel(){QuestionId=5, Question="Wie zufrieden sind Sie mit Ihren Verkaeufen?", Answer1="Bezahlung", Answer2="Abwicklung", Answer3="Uebersicht der Homepage", Answer4="Wuerden Sie uns empfehlen?", Answer5="Versand", Answer6="Benachrichtugungen", Answer7="Wuerden Sie uns nicht empfehlen?", Category="buyer"  },
                new CreateSurveyModel(){QuestionId=6, Question="Wie zufrieden sind Sie mit Ihrem Einkauf?", Answer1="Bezahlung", Answer2="Abwicklung", Answer3="Uebersicht der Homepage", Answer4="Wuerden Sie uns empfehlen?", Answer5="Versand", Answer6="Benachrichtugungen", Answer7="Wuerden Sie uns nicht empfehlen?", Category="seller"  },
            };
        }

        public List<CreateSurveyModel> Survey
        {
            get => survey; set => survey = value;
        }   
    
    }
}
