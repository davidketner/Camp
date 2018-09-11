using Camp.Data.Entity;
using UtilityLibrary;

namespace Camp.Data.Repositories
{
    public interface IObjectOrderRepository : IGenericRepository<ObjectOrder, int>
    {
    }

    public class ObjectOrderRepository : GenericRepository<ObjectOrder, CampDbContext, int>, IObjectOrderRepository
    {
        public ObjectOrderRepository(CampDbContext context) : base(context)
        {
        }
    }
}