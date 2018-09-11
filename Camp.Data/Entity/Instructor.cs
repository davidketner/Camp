using System;
using System.Collections.Generic;
using System.Text;
using UtilityLibrary;

namespace Camp.Data.Entity
{
    public class Instructor : BaseEntity<int>, ISoftDeletable
    {
        public string Title { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Facebook { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }

        private ICollection<InstructorCamp> instructorCamps;
        public virtual ICollection<InstructorCamp> InstructorCamps
        {
            get { return instructorCamps ?? (instructorCamps = new HashSet<InstructorCamp>()); }
            set { instructorCamps = value; }
        }

        private ICollection<Photo> photos;
        public virtual ICollection<Photo> Photos
        {
            get { return photos ?? (photos = new HashSet<Photo>()); }
            set { photos = value; }
        }
    }
}
