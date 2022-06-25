using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public virtual int Id { get; set; }
        public virtual DateTime Created { get; set; } = DateTime.Now;
        public virtual DateTime? Modified  { get; set; }
    }
}