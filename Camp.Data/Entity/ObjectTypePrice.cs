﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UtilityLibrary;

namespace Camp.Data.Entity
{
    public class ObjectTypePrice : BaseEntity<int>, ISoftDeletable
    {
        public int PersonsCount { get; set; }
        public int MinNights { get; set; }
        public int MaxNights { get; set; }

        [ForeignKey("ObjectType")]
        public int ObjectTypeId { get; set; }
        public virtual ObjectType ObjectType { get; set; }
    }
}