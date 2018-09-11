using Camp.Data.Entity;
using UtilityLibrary;

namespace Camp.Data.Repositories
{
    public interface IPaymentRepository : IGenericRepository<Payment, int>
    {
    }

    public class PaymentRepository : GenericRepository<Payment, CampDbContext, int>, IPaymentRepository
    {
        public PaymentRepository(CampDbContext context) : base(context)
        {
        }
    }
}