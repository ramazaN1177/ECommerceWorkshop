﻿using Business.Abstract;
using Business.Concrete;
using Core.Utils;
using Entities.Surrogate.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/v1/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("List_Product")]
        public IActionResult List_Product()
        {
            var result = _productService.GetAll();
            if (result.Status == ResultStatus.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Route("Save_Product")]
        [HttpPost]
        public IActionResult Save_Product(ProductRequest product)
        {
            _productService.Add(product);
            return Ok(product);
        }

        [Route("Find_Product/{id}")]
        [HttpGet]
        public IActionResult Find_Product(int id)
        {
            var product = _productService.Get(id);
            if (product.Status == ResultStatus.Error)
            {
                return NotFound();
            }
            else if (product.Status == ResultStatus.Success)
            {
                return Ok(product);
            }
            else
            {
                return BadRequest();
            }

        }

        [Route("Update_Product/{id}")]
        [HttpPut]
        public IActionResult Update_Product(int id, ProductRequest product)
        {
            _productService.Update(id, product);
            return Ok(product);
        }

        [Route("Delete_Product/{id}")]
        [HttpDelete]
        public IActionResult Delete_Product(int id)
        {
            _productService.Delete(id);
            return NoContent();
        }


    }
}
