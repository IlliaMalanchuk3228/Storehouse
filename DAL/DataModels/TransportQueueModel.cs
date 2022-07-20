using System.Collections.Generic;

namespace DAL.DataModels
{ 
    public class TransportQueueModel
    {
        public virtual int Id { get; set; }
        public virtual bool IsShipping { get; set; }
        public virtual int BuyQueueId { get; set; }
        public virtual int ProductId { get; set; }
    }
}
