using Camp.Data.Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Camp.Data.Entity
{
    public class ObjectOrderDiet
    {
        [Key]
        public int ObjectOrderId { get; set; }
        public virtual ObjectOrder ObjectOrder { get; set; }
        [Key]
        public int DietId { get; set; }
        public virtual Diet Diet { get; set; } 
        [Key]
        public PersonType PersonType { get; set; }
        public int Count { get; set; }
    }
}
