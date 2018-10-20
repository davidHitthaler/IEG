using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IEGProductCatalogService.Models;

namespace IEGProductCatalogService.Repositories
{
    public class ProductStorage
    {
        private List<ProductModel> _products = new List<ProductModel>
        {
            new ProductModel(){ProductId=1, ProductPrice=1200, ProductPublisher="Apple", ProductName="Iphone X"},
            new ProductModel(){ProductId=2, ProductPrice=700, ProductPublisher="Samsung", ProductName="Samsung Galaxy S9"},
            new ProductModel(){ProductId=3, ProductPrice=370, ProductPublisher="Nokia", ProductName="Nokia 7+"},
            new ProductModel(){ProductId=4, ProductPrice=160, ProductPublisher="Xiaomi", ProductName="Xiaomi Redmi 5"},
            new ProductModel(){ProductId=5, ProductPrice=350, ProductPublisher="LG", ProductName="LG G7"},
            new ProductModel(){ProductId=6, ProductPrice=520, ProductPublisher="Apple", ProductName="IPhone 8"},
            new ProductModel(){ProductId=7, ProductPrice=200, ProductPublisher="Samsung", ProductName="Samsung J7"},
            new ProductModel(){ProductId=8, ProductPrice=445, ProductPublisher="Nikon", ProductName="Nikon D5600"},
            new ProductModel(){ProductId=9, ProductPrice=600, ProductPublisher="Huawei", ProductName="Huawei P20"},
            new ProductModel(){ProductId=10, ProductPrice=350, ProductPublisher="Apple", ProductName="IPad 6th gen"}
        };

        public ProductStorage()
        {
            //ProductModel productInit = new ProductModel();
            //_products.Add(productInit);
        }

        public IEnumerable<ProductModel> Get()
        {
            return _products;
        }

        public ProductModel Get(int productId)
        {
            return _products.Where(p => p.ProductId == productId).SingleOrDefault();
        }        

        public List<ProductModel> Add(ProductModel productModel)
        {
            productModel.ProductId = _products.Max(p => p.ProductId) + 1;
            _products.Add(productModel);
            return _products;
        }

    }
}

/*public sealed class Singleton
{
    private static Singleton instance = null;
    private static readonly object padlock = new object();

    Singleton()
    {
    }

    public static Singleton Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }
} 
*/
