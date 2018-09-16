using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UtilityLibrary;

namespace Camp.Data.Entity
{
    public class InstructorRole : BaseEntity<int>, ISoftDeletable
    {
        [Required]
        public string Name { get; set; }
        public int Order { get; set; }
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
