using Camp.Data.Entity;
using UtilityLibrary;

namespace Camp.Data.Repositories
{
    public interface ICampCategoryRepository : IGenericRepository<CampCategory, int>
    {
    }

    public class CampCategoryRepository : GenericRepository<CampCategory, CampDbContext, int>, ICampCategoryRepository
    {
        public CampCategoryRepository(CampDbContext context) : base(context)
        {
        }
    }
}