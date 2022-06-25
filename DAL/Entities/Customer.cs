using System.Collections.Generic;

namespace DAL.Entities
{
    public class Customer : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual int Telephone { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }
    }
}