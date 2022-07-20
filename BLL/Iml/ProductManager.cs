using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.DataModels;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Iml
{
    public class ProductManager: IProductManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
 
        public async Task CreatesProductModel(ProductModel productModel)
        {
            await _unitOfWork.ProductRepository.Create(productModel);
        }
        
        public async Task<ProductModel> GetProductsByIdAsync(int id)
        {
            return await _unitOfWork.ProductRepository.GetProductByIdAsync(id);
        }
        
    }
}
