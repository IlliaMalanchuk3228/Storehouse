using System.Collections.Generic;

namespace DAL.Entities
{
    public class Order : BaseEntity
    {
        public virtual bool IsSold { get; set; }
        public virtual bool IsDelivered { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
        public virtual Customer Customer { get; set; }
    }
}