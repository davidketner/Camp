using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using UtilityLibrary;

namespace Camp.Data.Entity
{
    public class ObjectType : BaseEntity<int>, ISoftDeletable
    {
        [Required]
        public string Name { get; set; }
        [Required]
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

        public decimal ActualPrice(int Nights)
        {
            return Prices.FirstOrDefault(x => x.MinNights <= Nights && x.MaxNights >= Nights).Price;
        }

        public IEnumerable<Object> AvailableObjects(DateTime From, DateTime To)
        {
            return Objects.Where(x => x.IsAvailable(From, To));
        }
    }
}
