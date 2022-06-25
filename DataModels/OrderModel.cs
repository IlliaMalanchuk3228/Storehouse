using System.Collections.Generic;
using DAL.Entities;

namespace DataModels
{
    public class OrderModel
    {
        public virtual int Id { get; set; }
        public virtual bool IsSold { get; set; }
        public virtual bool IsDelivered { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
        public virtual IEnumerable<int> CustomerId { get; set; }
    }
}