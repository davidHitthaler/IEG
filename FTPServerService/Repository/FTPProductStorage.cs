using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using IEGProductCatalogService.Models;
using Newtonsoft.Json.Linq;

namespace IEGProductCatalogService.Repositories
{
    public class FTPProductStorage
    {
        private static List<FTPProductModel> _products = new List<FTPProductModel>();

        private static void jsonParse()
        {

            string json_string = "";

            string url = "ftp://localhost/";
            string filename = "productlist_json.json";
            string username = "ieg1";
            string password = "ieg1";
            WebClient request = new WebClient();
            string ftp_file = url + filename;
            request.Credentials = new NetworkCredential(username, password);

            try
            {
                byte[] newFileData = request.DownloadData(ftp_file);
                json_string = System.Text.Encoding.UTF8.GetString(newFileData);
            }
            catch (WebException e)
            {
                Console.WriteLine("Cannot download data from url");
                // Do something such as log error, but this is based on OP's original code
                // so for now we do nothing.
            }

            JObject results = JObject.Parse(json_string);

            foreach (var result in results["Productlist"])
            {
                int ProductID = Int32.Parse((string)result["ProductID"]);
                string Product = (string)result["Product"];
                string ProductName = (string)result["ProductName"];
                int Productprice = Int32.Parse((string)result["Price"]);

                _products.Add(new FTPProductModel() { ProductId = ProductID, ProductPrice = Productprice, ProductPublisher = Product, ProductName = ProductName });

            }
        }
        public FTPProductStorage()
        {
            //ProductModel productInit = new ProductModel();
            //_products.Add(productInit);
        }

        public IEnumerable<FTPProductModel> Get()
        {
            jsonParse();
            return _products;
        }

        public FTPProductModel Get(int productId)
        {
            return _products.Where(p => p.ProductId == productId).SingleOrDefault();
        }        

        public List<FTPProductModel> Add(FTPProductModel productModel)
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
