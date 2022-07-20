using System.Collections.Generic;

namespace DAL.DataModels
{
    public class BuyQueueModel
    { 
        public virtual int Id { get; set; }
        public virtual bool IsBuying { get; set; }
        public virtual int ProductId { get; set; }
    }
}
