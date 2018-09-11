using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Camp.Data.Entity
{
    public class InstructorCamp
    {
        [Key]
        public int InstructorId { get; set; }
        public virtual Instructor Instructor { get; set; }
        [Key]
        public int CampId { get; set; }
        public virtual Camp Camp { get; set; }
        [Key]
        public int InstructorRoleId { get; set; }
        public InstructorRole InstructorRole { get; set; }
    }
}
