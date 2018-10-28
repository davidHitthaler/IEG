using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IEGPaymentService.Models;

namespace IEGPaymentService.Repositories
{
    public class PaymentStorage
    {
        private List<PaymentModel> _paymentMethod = new List<PaymentModel>();
        public PaymentStorage()
        {
            PaymentModel paymentInit = new PaymentModel();
            _paymentMethod.Add(paymentInit);
        }

        public IEnumerable<PaymentModel> Get()
        {
            return _paymentMethod;
        }

        public PaymentModel Get(int productId)
        {
            return _paymentMethod.Where(p => p.PaymentId == productId).SingleOrDefault();
        }        

        public List<PaymentModel> Add(PaymentModel paymentModel)
        {
            paymentModel.PaymentId = _paymentMethod.Max(p => p.PaymentId) + 1;
            _paymentMethod.Add(paymentModel);
            return _paymentMethod;
        }

    }
}