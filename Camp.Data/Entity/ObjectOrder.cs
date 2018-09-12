using Camp.Data.Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using UtilityLibrary;

namespace Camp.Data.Entity
{
    public class ObjectOrder : BaseEntity<int>, ISoftDeletable
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Zipcode { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telephone { get; set; }
        public string BusinessId { get; set; }
        public string TaxId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
        public OrderState OrderState { get; set; } = OrderState.Created;

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

        private ICollection<Payment> payments;
        public virtual ICollection<Payment> Payments
        {
            get { return payments ?? (payments = new HashSet<Payment>()); }
            set { payments = value; }
        }

        public int PersonsCount => Objects.Sum(x => x.PersonsCount);
        public int ChildrensCount => Objects.Sum(x => x.ChildrensCount);
        public int BabiesCount => Objects.Sum(x => x.BabiesCount);

        public int Nights => (To.Date - From.Date).Days;

        public decimal PriceForObject => Objects.Sum(x => x.TotalPayingPersons * x.Object.ObjectType.ActualPrice(Nights) * Nights);

        public decimal PriceForDiet => ObjectOrderDiets.Sum(x => x.Price);

        public decimal TotalPrice => PriceForObject + PriceForDiet;
    }
}
