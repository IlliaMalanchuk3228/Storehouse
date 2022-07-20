using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using DAL.DataModels;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Iml
{
    public class BuyQueueManager : IBuyQueueManager
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public BuyQueueManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
         
        public async Task CreateBuyQueue(BuyQueueModel buyQueueModel)
        {
            await _unitOfWork.BuyQueueRepository.Create(buyQueueModel);
        }

        public async Task<BuyQueueModel> GetBuyQueuesByIdAsync(int buyQueueId)
        {
            return await _unitOfWork.BuyQueueRepository.GetBuyQueueByIdAsync(buyQueueId);
        }
        
        public async Task AddingToBuyQueue(int productId)
        {
            var product = await _unitOfWork.ProductRepository.GetProductByIdAsync(productId);
            
            if (product.IsAvailable == false)
            {
                var buyQueue = new BuyQueueModel()
                {
                    IsBuying = true,
                    ProductId = product.Id
                };
                await _unitOfWork.BuyQueueRepository.Update(buyQueue);
            }
        }
    }
}   
