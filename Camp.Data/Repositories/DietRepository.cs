using Camp.Data.Entity;
using UtilityLibrary;

namespace Camp.Data.Repositories
{
    public interface IDietRepository : IGenericRepository<Diet, int>
    {
    }

    public class DietRepository : GenericRepository<Diet, CampDbContext, int>, IDietRepository
    {
        public DietRepository(CampDbContext context) : base(context)
        {
        }
    }
}