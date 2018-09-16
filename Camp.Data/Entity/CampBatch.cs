using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UtilityLibrary;

namespace Camp.Data.Entity
{
    public class CampBatch :BaseEntity<int>, ISoftDeletable
    {
        [Required]
        public int Batch { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("Camp")]
        public int CampId { get; set; }
        public virtual Camp Camp { get; set; }

        public virtual User UserCreated { get; set; }
        public virtual User UserUpdated { get; set; }

        private ICollection<InstructorCamp> instructorCamps;
        public virtual ICollection<InstructorCamp> InstructorCamps
        {
            get { return instructorCamps ?? (instructorCamps = new HashSet<InstructorCamp>()); }
            set { instructorCamps = value; }
        }
    }
}
