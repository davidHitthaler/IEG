using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using IEGPaymentService.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using MediaTypeHeaderValue = Microsoft.Net.Http.Headers.MediaTypeHeaderValue;

namespace IEGPaymentService.Formatter
{
    public class CsvOutputFormatter: TextOutputFormatter
    {
        

        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

         protected override bool CanWriteType(Type type)
         {
             if (typeof(PaymentModel).IsAssignableFrom(type) || typeof(IEnumerable<PaymentModel>).IsAssignableFrom(type))
             {
                 return base.CanWriteType(type);
             }

             return false;
         }

         public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
         {
             var response = context.HttpContext.Response;
             var buffer = new StringBuilder();

             if (context.Object is IEnumerable<PaymentModel>)
             {
                 foreach (var PaymentModel in (IEnumerable<PaymentModel>)context.Object)
                 {
                     FormatCsv(buffer, PaymentModel);
                 }
             }
             else
             {
                 FormatCsv(buffer, (PaymentModel)context.Object);
             }

             using (var writer = context.WriterFactory(response.Body, selectedEncoding))
             {
                 return writer.WriteAsync(buffer.ToString());
             }
         }

        private static void FormatCsv(StringBuilder buffer, PaymentModel paymentModel)
        {
            
             buffer.AppendLine($"{paymentModel.PaymentId},\"{paymentModel.PaymentBank},\"{paymentModel.PaymentArt},\"{paymentModel.PaymentLand}\"");
            
        }

    }
}
