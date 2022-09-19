using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmporiumRemuneration.Repositories;
using EmporiumRemuneration.Models;

namespace EmporiumRemuneration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productController : ControllerBase
    {
        IProductInfo _productInfo;

        public productController(IProductInfo productCxt)
        {
            _productInfo = productCxt;
        }

        [HttpGet]
        [Route("getAllProducts")]
        public IActionResult GetProducts()
        {
            return Ok(_productInfo.GetProducts());
        }

        [HttpGet]
        [Route("getProductById")]
        public IActionResult GetProductById(int Id)
        {
            if (_productInfo.GetProductById(Id) == null)
                return NotFound("Product do not exists");

            return Ok(_productInfo.GetProductById(Id));
        }

        [HttpPost]
        [Route("AddProduct")]
        public IActionResult AddProduct(ProductInfo productInfo)
        {
            return Ok(_productInfo.AddProduct(productInfo));
        }


        [HttpPut]
        [Route("EditProduct")]
        public IActionResult EditProduct(ProductInfo product, int Id)
        {
            ProductInfo _productdata = _productInfo.EditProduct(product, Id);

            if (_productInfo == null)
                return NotFound("Consumer not found");

            return Ok(_productInfo.GetProducts());
        }

        [HttpDelete]
        [Route("DeleteProduct")]
        public IActionResult DeleteProduct(int Id)
        {
            _productInfo.DeleteProduct(Id);
            return Ok(_productInfo.GetProducts());
        }

    }
}
