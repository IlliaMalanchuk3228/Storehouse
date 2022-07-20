using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.DataModels;
using DAL.Entities;

namespace DAL.Repositories
{
    public interface IProductRepository : IRepository<ProductModel>
    {
        Task<ProductModel> GetProductByIdAsync(int id);
        Task Create(ProductModel productModel);
    }
}
