using Camp.Data.Entity;
using UtilityLibrary;

namespace Camp.Data.Repositories
{
    public interface IObjectRepository : IGenericRepository<Object, int>
    {
    }

    public class ObjectRepository : GenericRepository<Object, CampDbContext, int>, IObjectRepository
    {
        public ObjectRepository(CampDbContext context) : base(context)
        {
        }
    }
}