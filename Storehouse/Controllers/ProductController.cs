using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using DAL.DataModels;
using DAL.Entities;

namespace Storehouse.Controllers
{
    [ApiController]
    [Route("[controller]/product")]
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;
        public ProductController(IProductManager manager)
        {
            _productManager = manager;
        }
        
        //GET
        [Route("take")]
        [HttpGet]
        public async Task<ProductModel> GetProducts(int productId)
        {
            return await _productManager.GetProductsByIdAsync(productId);
        }
        

        //POST
        [Route("create")]
        [HttpPost]
        public async Task CreateProducts(ProductModel productModel)
        {
            await _productManager.CreatesProductModel(productModel);
        }
    }
}