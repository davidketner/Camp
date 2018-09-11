﻿using System;
using System.Collections.Generic;
using System.Text;
using UtilityLibrary;

namespace Camp.Data.Entity
{
    public class InstructorRole : BaseEntity<int>, ISoftDeletable
    {
        public string Name { get; set; }

        private ICollection<InstructorCamp> instructorCamps;
        public virtual ICollection<InstructorCamp> InstructorCamps
        {
            get { return instructorCamps ?? (instructorCamps = new HashSet<InstructorCamp>()); }
            set { instructorCamps = value; }
        }
    }
}