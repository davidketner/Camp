using Camp.Data.Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Camp.Data.Entity
{
    public class ObjectOrderDiet
    {
        public int ObjectOrderId { get; set; }
        public virtual ObjectOrder ObjectOrder { get; set; }
        public int DietId { get; set; }
        public virtual Diet Diet { get; set; }
        public PersonType PersonType { get; set; }
        public int Count { get; set; }

        public decimal Price => (PersonType == PersonType.Person ? Diet.PersonPrice : Diet.ChildrenPrice) * Count;
    }
}
