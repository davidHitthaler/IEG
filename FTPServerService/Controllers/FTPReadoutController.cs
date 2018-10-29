using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using IEGProductCatalogService.Models;
using IEGProductCatalogService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FTPServerService.Controllers
{
    [Produces("application/json")]
    [Route("api/FTPReadout")]
    public class FTPReadoutController : Controller
    {
        static FTPProductStorage ftp_storage = new FTPProductStorage();

        [HttpGet]
        public IEnumerable<FTPProductModel> Get()
        {
            return ftp_storage.Get();
        }

        [HttpGet("{id}")]
        public FTPProductModel Get(int id)
        {
            return ftp_storage.Get(id);
        }

        /*[HttpPost]
        public IActionResult Post([FromBody] FTPProductModel productModel)
        {
            if (ModelState.IsValid == false)
                //return BadRequest(ModelState);
                return CreatedAtAction("Product NOT Added, ID = ", new { id = productModel.ProductId });
            else
                ftp_storage.Add(productModel);
            return CreatedAtAction("Product Added, ID = ", new { id = productModel.ProductId });
        }
        */
    }
}
