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
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;
        public ProductController(IProductManager manager)
        {
            _productManager = manager;
        }
        
        //GET
        [Route("getProduct")]
        [HttpGet]
        public async Task<ProductModel> GetProducts(int productId)
        {
            return await _productManager.GetProductsByIdAsync(productId);
        }
        
        //POST
        [Route("createProduct")]
        [HttpPost]
        public async Task CreateProducts(ProductModel productModel)
        {
            await _productManager.CreatesProductModel(productModel);
        }
        
    }
}
