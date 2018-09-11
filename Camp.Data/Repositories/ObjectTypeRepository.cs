using Camp.Data.Entity;
using UtilityLibrary;

namespace Camp.Data.Repositories
{
    public interface IObjectTypeRepository : IGenericRepository<ObjectType, int>
    {
    }

    public class ObjectTypeRepository : GenericRepository<ObjectType, CampDbContext, int>, IObjectTypeRepository
    {
        public ObjectTypeRepository(CampDbContext context) : base(context)
        {
        }
    }
}