﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Camp.Data.Entity
{
    public class ObjectOrderObject
    {
        public int ObjectOrderId { get; set; }
        public virtual ObjectOrder ObjectOrder { get; set; }
        public int ObjectId { get; set; }
        public virtual Object Object { get; set; }
        public int PersonsCount { get; set; }
        public int ChildrensCount { get; set; }
        public int BabiesCount { get; set; }

        public int TotalPayingPersons => PersonsCount + ChildrensCount;
    }
}
