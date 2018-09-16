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
        public string Description { get; set; }
        public string OrganizationalInformation { get; set; }
        public string Schedule { get; set; }
        public bool Active { get; set; } = true;
        [ForeignKey("CampCategory")]
        public int CampCategoryId { get; set; }
        public virtual CampCategory CampCategory { get; set; }

        public virtual User UserCreated { get; set; }
        public virtual User UserUpdated { get; set; }

        private ICollection<Photo> photos;
        public virtual ICollection<Photo> Photos
        {
            get { return photos ?? (photos = new HashSet<Photo>()); }
            set { photos = value; }
        }

        private ICollection<CampBatch> batches;
        public virtual ICollection<CampBatch> Batches
        {
            get { return batches ?? (batches = new HashSet<CampBatch>()); }
            set { batches = value; }
        }
    }
}
