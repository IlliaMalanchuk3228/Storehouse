#nullable enable
using System.Collections.Generic;
using DAL.Entities;

namespace DAL.DataModels
{
    public class CustomerModel
    { 
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual int Telephone { get; set; }
    }
}
