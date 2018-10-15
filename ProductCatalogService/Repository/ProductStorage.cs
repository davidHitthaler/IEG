using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IEGProductCatalogService.Models;

namespace IEGProductCatalogService.Repositories
{
    public class ProductStorage
    {
        private List<ProductModel> _products = new List<ProductModel>();
        public ProductStorage()
        {
            ProductModel productInit = new ProductModel();
            //ProductModel productInit = new ProductModel(5, "asdf", "3tr", 40);
            _products.Add(productInit);
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
