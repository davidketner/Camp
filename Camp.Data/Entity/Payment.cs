using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UtilityLibrary;

namespace Camp.Data.Entity
{
    public class Payment : BaseEntity<int>, ISoftDeletable
    {
        public decimal Amount { get; set; }
        [ForeignKey("ObjectOrder")]
        public int? ObjectOrderId { get; set; }
        public virtual ObjectOrder ObjectOrder { get; set; }
    }
}
