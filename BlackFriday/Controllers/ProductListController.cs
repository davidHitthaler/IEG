using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using IEGProductCatalogService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlackFriday.Controllers
{
    [Route("api/[controller]")]
    public class ProductListController : Controller
    {
        private readonly ILogger<ProductListController> _logger;
        //private static readonly string productCatalogServiceBaseAddress="http://iegeasycreditcardservice.azurewebsites.net/";
        private static readonly string productCatalogServiceBaseAddress = "http://localhost:54134/";
        // GET: http://iegblackfriday.azurewebsites.net/api/productlist

        [HttpGet]
        public List<ProductModel> Get()
        {
            List<ProductModel> getProduct = new List<ProductModel>();
            //getProduct.Add(new ProductModel() {ProductId =09, ProductPublisher="Apple", ProductName="Mac",ProductPrice=2500 });
            //return getProduct;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(productCatalogServiceBaseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(productCatalogServiceBaseAddress + "/api/ProductCatalog").Result;
            if (response.IsSuccessStatusCode)
            {
                getProduct = response.Content.ReadAsAsync<List<ProductModel>>().Result;
            }

            /*foreach (var item in getProduct)
            {
                _logger.LogError("Paymentmethod {0}", new object[] { item });

            }*/
            return getProduct;
        }

        [HttpGet("{id}")]
        public List<ProductModel> GetWithId()
        {
            List<ProductModel> getProductwithId = new List<ProductModel>();
            //getProduct.Add(new ProductModel() {ProductId =09, ProductPublisher="Apple", ProductName="Mac",ProductPrice=2500 });
            //return getProduct;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(productCatalogServiceBaseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(productCatalogServiceBaseAddress + "/api/ProductCatalog/" + RouteData.Values["id"]).Result;
            if (response.IsSuccessStatusCode)
            {
                getProductwithId = response.Content.ReadAsAsync<List<ProductModel>>().Result;
            }

            /*foreach (var item in getProduct)
            {
                _logger.LogError("Paymentmethod {0}", new object[] { item });
            }*/
            return getProductwithId;
        }

        [HttpPost()]
        public IActionResult Post([FromBody] ProductModel productModel)
        {
            //check model state!... if (ModelState.IsValid == false) error else do...
            ProductModel postThisObject = new ProductModel(productModel.ProductId, productModel.ProductPublisher, productModel.ProductName, productModel.ProductPrice);            
            //List<ProductModel> getProduct = new List<ProductModel>();
            //getProduct.Add(new ProductModel() {ProductId =09, ProductPublisher="Apple", ProductName="Mac",ProductPrice=2500 });
            //return getProduct;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(productCatalogServiceBaseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.PostAsJsonAsync(productCatalogServiceBaseAddress + "/api/ProductCatalog", postThisObject).Result;
                //getProduct = response.Content.ReadAsAsync<List<ProductModel>>().Result;
            return CreatedAtAction("Post ProductList: ", new { code = response.StatusCode });          
            /*foreach (var item in getProduct)
            {
                _logger.LogError("Paymentmethod {0}", new object[] { item });
            }*/
            //return getProduct;
        }
    }
}
