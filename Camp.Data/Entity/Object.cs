using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using UtilityLibrary;

namespace Camp.Data.Entity
{
    public class Object : BaseEntity<int>, ISoftDeletable
    {
        [Required]
        public string Mark { get; set; }

        [ForeignKey("ObjectType")]
        public int ObjectTypeId { get; set; }
        public virtual ObjectType ObjectType { get; set; }

        public virtual User UserCreated { get; set; }
        public virtual User UserUpdated { get; set; }

        private ICollection<ObjectOrderObject> orders;
        public virtual ICollection<ObjectOrderObject> Orders
        {
            get { return orders ?? (orders = new HashSet<ObjectOrderObject>()); }
            set { orders = value; }
        }

        public bool IsAvailable(DateTime From, DateTime To)
        {
            if (!Orders.Any(x => x.ObjectOrder.OrderState != Enums.OrderState.Canceled && x.ObjectOrder.From.Date < To.Date && From.Date < x.ObjectOrder.To.Date))
                return true;

            return false;
        }

        public IEnumerable<Term> OccupiedTerms => Orders.Where(x => x.ObjectOrder.OrderState != Enums.OrderState.Canceled).Select(x => new Term { From = x.ObjectOrder.From, To = x.ObjectOrder.To });
    }

    
}
