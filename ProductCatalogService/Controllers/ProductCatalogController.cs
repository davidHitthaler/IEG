using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IEGProductCatalogService.Models;
using IEGProductCatalogService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductCatalogService.Controllers
{
    [Produces("application/json")]
    [Route("api/ProductCatalog")]
    public class ProductCatalogController : Controller
    {
        ProductStorage _productStorage = new ProductStorage();
        // GET: api/Product
        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            return _productStorage.Get();
        }

        [HttpGet("{id}")]
        public ProductModel Get(int id)
        {
            return _productStorage.Get(id);            
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductModel productModel)
        {
            if (ModelState.IsValid == false)
                //return BadRequest(ModelState);
                return CreatedAtAction("Product NOT Added, ID = ", new { id = productModel.ProductId });
            else
                _productStorage.Add(productModel);
            return CreatedAtAction("Product Added, ID = ", new { id = productModel.ProductId });
        }

       
    }
}
