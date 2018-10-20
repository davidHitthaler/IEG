using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEGProductCatalogService.Models
{
    public class ProductModel
    {
        /*ProductModel()
        {
        }*/

        public ProductModel(int productId, string productPublisher, string productName, int productPrice)
        {
            productId = ProductId;
            productPublisher = ProductPublisher;
            productName = ProductName;
            productPrice = ProductPrice;
        }

        public ProductModel()
        {
            ProductId = 01;ProductPublisher = "Best Producer";ProductName = "BestProduct"; ProductPrice = 1;
        }

        public int ProductId { get; set; }
        [System.ComponentModel.DataAnnotations.MinLength(2)]
        public string ProductPublisher { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }

        public static implicit operator List<object>(ProductModel v)
        {
            throw new NotImplementedException();
        }
    }
}
