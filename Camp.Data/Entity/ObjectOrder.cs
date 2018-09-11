using Camp.Data.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using UtilityLibrary;

namespace Camp.Data.Entity
{
    public class ObjectOrder : BaseEntity<int>, ISoftDeletable
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Zipcode { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string BusinessId { get; set; }
        public string TaxId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public int PersonsCount { get; set; }
        public int ChildrensCount { get; set; }
        public int BabiesCount { get; set; }
        public PaymentType PaymentType { get; set; }

        private ICollection<ObjectOrderDiet> objectOrderDiets;
        public virtual ICollection<ObjectOrderDiet> ObjectOrderDiets
        {
            get { return objectOrderDiets ?? (objectOrderDiets = new HashSet<ObjectOrderDiet>()); }
            set { objectOrderDiets = value; }
        }

        private ICollection<ObjectOrderObject> objects;
        public virtual ICollection<ObjectOrderObject> Objects
        {
            get { return objects ?? (objects = new HashSet<ObjectOrderObject>()); }
            set { objects = value; }
        }
    }
}
