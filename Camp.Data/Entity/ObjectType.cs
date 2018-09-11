using System;
using System.Collections.Generic;
using System.Text;
using UtilityLibrary;

namespace Camp.Data.Entity
{
    public class ObjectType : BaseEntity<int>, ISoftDeletable
    {
        public string Name { get; set; }
        public string ObjectsName { get; set; }
        public int Capacity { get; set; }


        private ICollection<Object> objects;
        public virtual ICollection<Object> Objects
        {
            get { return objects ?? (objects = new HashSet<Object>()); }
            set { objects = value; }
        }

        private ICollection<ObjectTypePrice> prices;
        public virtual ICollection<ObjectTypePrice> Prices
        {
            get { return prices ?? (prices = new HashSet<ObjectTypePrice>()); }
            set { prices = value; }
        }
    }
}
