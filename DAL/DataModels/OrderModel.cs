using System.Collections.Generic;
using DAL.Entities;

namespace DAL.DataModels
{
    public class OrderModel
    {
        public virtual int Id { get; set; }
        public virtual bool IsSold { get; set; }
        public virtual bool IsDelivered { get; set; }
        public virtual IEnumerable<ProductModel> Products { get; set; }
        public virtual CustomerModel Customers { get; set; }
    }
}