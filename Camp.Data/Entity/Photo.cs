using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UtilityLibrary;

namespace Camp.Data.Entity
{
    public class Photo : BaseEntity<int>, ISoftDeletable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public int Order { get; set; }
        public bool Main { get; set; }

        [ForeignKey("Camp")]
        public int? CampId { get; set; }
        public virtual Camp Camp { get; set; }

        [ForeignKey("Instructor")]
        public int? InstructorId { get; set; }
        public virtual Instructor Instructor { get; set; }

        [ForeignKey("CampCategory")]
        public int? CampcategoryId { get; set; }
        public virtual CampCategory CampCategory { get; set; }
    }
}
