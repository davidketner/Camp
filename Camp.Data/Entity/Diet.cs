using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UtilityLibrary;

namespace Camp.Data.Entity
{
    public class Diet : BaseEntity<int>, ISoftDeletable
    {
        [Required]
        public string Name { get; set; }
        public decimal PersonPrice { get; set; }
        public decimal ChildrenPrice { get; set; }

        private ICollection<ObjectOrderDiet> objectOrderDiets;
        public virtual ICollection<ObjectOrderDiet> ObjectOrderDiets
        {
            get { return objectOrderDiets ?? (objectOrderDiets = new HashSet<ObjectOrderDiet>()); }
            set { objectOrderDiets = value; }
        }
    }
}
