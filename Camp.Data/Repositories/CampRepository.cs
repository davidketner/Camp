using Camp.Data.Entity;
using UtilityLibrary;

namespace Camp.Data.Repositories
{
    public interface ICampRepository : IGenericRepository<Entity.Camp, int>
    {
    }

    public class CampRepository : GenericRepository<Entity.Camp, CampDbContext, int>, ICampRepository
    {
        public CampRepository(CampDbContext context) : base(context)
        {
        }
    }
}