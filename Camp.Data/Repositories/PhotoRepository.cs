using Camp.Data.Entity;
using UtilityLibrary;

namespace Camp.Data.Repositories
{
    public interface IPhotoRepository : IGenericRepository<Photo, int>
    {
    }

    public class PhotoRepository : GenericRepository<Photo, CampDbContext, int>, IPhotoRepository
    {
        public PhotoRepository(CampDbContext context) : base(context)
        {
        }
    }
}