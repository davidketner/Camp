using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Camp.Data.Entity
{
    [NotMapped]
    public class Term
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
