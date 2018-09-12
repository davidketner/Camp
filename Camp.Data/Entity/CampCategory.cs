using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UtilityLibrary;

namespace Camp.Data.Entity
{
    public class CampCategory : BaseEntity<int>, ISoftDeletable
    {
        [Required]
        public string Name { get; set; }

        private ICollection<Camp> camps;
        public virtual ICollection<Camp> Camps
        {
            get { return camps ?? (camps = new HashSet<Camp>()); }
            set { camps = value; }
        }

        private ICollection<Photo> photos;
        public virtual ICollection<Photo> Photos
        {
            get { return photos ?? (photos = new HashSet<Photo>()); }
            set { photos = value; }
        }
    }
}
