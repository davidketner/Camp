using Camp.Data.Entity;
using UtilityLibrary;

namespace Camp.Data.Repositories
{
    public interface IInstructorRepository : IGenericRepository<Instructor, int>
    {
    }

    public class InstructorRepository : GenericRepository<Instructor, CampDbContext, int>, IInstructorRepository
    {
        public InstructorRepository(CampDbContext context) : base(context)
        {
        }
    }
}