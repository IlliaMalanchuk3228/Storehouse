using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.DataModels;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Iml
{
    public class TransportQueueManager : ITransportQueueManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransportQueueManager(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task CreatesTransportQueue(TransportQueueModel transportQueueModel)
        {
            await _unitOfWork.TransportQueueRepository.Create(transportQueueModel);
        }
        
        public async Task AddItemInTransportQueues(int id)
        {
            var buyQueueItem = await _unitOfWork.BuyQueueRepository.GetBuyQueueByIdAsync(id);
            
            var pr = await _unitOfWork.ProductRepository.GetProductByIdAsync(buyQueueItem.ProductId);
            
            var itemQueue = new TransportQueueModel()
            {
                IsShipping = true,
                BuyQueueModels = new List<BuyQueueModel>()
                {
                    buyQueueItem
                },
                ProductModels = new List<ProductModel>()
                {
                    pr
                }
            };
            await _unitOfWork.TransportQueueRepository.AddAsync(itemQueue);
        }
    }
}