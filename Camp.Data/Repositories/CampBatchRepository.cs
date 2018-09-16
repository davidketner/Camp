using Camp.Data.Entity;
using UtilityLibrary;

namespace Camp.Data.Repositories
{
    public interface ICampBatchRepository : IGenericRepository<CampBatch, int>
    {
    }

    public class CampBatchRepository : GenericRepository<CampBatch, CampDbContext, int>, ICampBatchRepository
    {
        public CampBatchRepository(CampDbContext context) : base(context)
        {
        }
    }
}