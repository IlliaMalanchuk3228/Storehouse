using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.DataModels;
using DAL.Entities;
namespace BLL.Interfaces
{
    public interface IProductManager
    {
        Task<ProductModel> GetProductsByIdAsync(int id);
        Task CreatesProductModel(ProductModel productModel);
    }
}
