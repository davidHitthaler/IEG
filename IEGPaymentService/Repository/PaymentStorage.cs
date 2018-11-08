using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IEGPaymentService.Models;

namespace IEGPaymentService.Repositories
{
    public class PaymentStorage
    {
        private List<PaymentModel> _paymentMethod;
        public PaymentStorage()
        {
            _paymentMethod = new List<PaymentModel>
             {
                new PaymentModel(){PaymentId=1, PaymentArt="Kreditkarte", PaymentBank="Sparkasse", PaymentLand="Österreich"},
                new PaymentModel(){PaymentId=2, PaymentArt="SEPA Lastschriftverfahren", PaymentBank="ErsteBank", PaymentLand="Österreich"},
                new PaymentModel(){PaymentId=3, PaymentArt="Paypal", PaymentBank="Oberbank", PaymentLand="Österreich"},

            };
        }

        public List<PaymentModel> Payments {
            get => _paymentMethod; set => _paymentMethod = value;
        }   
    
    }
}
