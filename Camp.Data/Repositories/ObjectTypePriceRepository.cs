using Camp.Data.Entity;
using UtilityLibrary;

namespace Camp.Data.Repositories
{
    public interface IObjectTypePriceRepository : IGenericRepository<ObjectTypePrice, int>
    {
    }

    public class ObjectTypePriceRepository : GenericRepository<ObjectTypePrice, CampDbContext, int>, IObjectTypePriceRepository
    {
        public ObjectTypePriceRepository(CampDbContext context) : base(context)
        {
        }
    }
}