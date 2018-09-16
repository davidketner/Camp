using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Camp.Data.Entity
{
    public class InstructorCamp
    {
        public int InstructorId { get; set; }
        public virtual Instructor Instructor { get; set; }
        public int CampBatchId { get; set; }
        public virtual CampBatch CampBatch { get; set; }
        public int InstructorRoleId { get; set; }
        public InstructorRole InstructorRole { get; set; }
    }
}
