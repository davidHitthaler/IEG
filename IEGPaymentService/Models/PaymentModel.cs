using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEGPaymentService.Models
{
    public class PaymentModel
    {
        /*public PaymentModel()
        {
            PaymentId = 1;
            PaymentBank = "Sparkasse";
            PaymentArt = "Kreditkarte";
            PaymentLand = "Österreich";
        }

        public PaymentModel(int paymentId, string paymentArt, string paymentBank, string paymentLand)
        {
            paymentId = PaymentId;
            paymentArt = PaymentArt;
            paymentBank = PaymentBank;
            paymentLand = PaymentLand;
        }*/

        public int PaymentId { get; set; }
        [System.ComponentModel.DataAnnotations.MinLength(2)]
        public string PaymentArt { get; set; }
        public string PaymentBank { get; set; }
        public string PaymentLand { get; set; }

        public static implicit operator List<object>(PaymentModel v)
        {
            throw new NotImplementedException();
        }
    }
}
