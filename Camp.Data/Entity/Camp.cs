using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UtilityLibrary;

namespace Camp.Data.Entity
{
    public class Camp : BaseEntity<int>, ISoftDeletable
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Batch { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string OrganizationalInformation { get; set; }
        public string Schedule { get; set; }

        [ForeignKey("CampCategory")]
        public int CampCategoryId { get; set; }
        public virtual CampCategory CampCategory { get; set; }

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
