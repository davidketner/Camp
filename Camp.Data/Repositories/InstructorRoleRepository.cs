using Camp.Data.Entity;
using UtilityLibrary;

namespace Camp.Data.Repositories
{
    public interface IInstructorRoleRepository : IGenericRepository<InstructorRole, int>
    {
    }

    public class InstructorRoleRepository : GenericRepository<InstructorRole, CampDbContext, int>, IInstructorRoleRepository
    {
        public InstructorRoleRepository(CampDbContext context) : base(context)
        {
        }
    }
}