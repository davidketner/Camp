using Camp.Data.Entity;
using Camp.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Camp.Data
{
    public interface ICampService
    {
        ICampCategoryRepository CampCategories { get; set; }
        ICampBatchRepository CampBatches { get; set; }
        ICampRepository Camps { get; set; }
        IDietRepository Diets { get; set; }
        IInstructorRepository Instructors { get; set; }
        IInstructorRoleRepository InstructorRoles { get; set; }
        IObjectOrderRepository ObjectOrders { get; set; }
        IObjectRepository Objects { get; set; }
        IObjectTypePriceRepository ObjectTypePrices { get; set; }
        IObjectTypeRepository ObjectTypes { get; set; }
        IPaymentRepository Payments { get; set; }
        IPhotoRepository Photos { get; set; }
        IHttpContextAccessor Context { get; set; }
        ILogger Logger { get; }
        UserManager<User> UserManager { get; set; }
        void Dispose();
        void Commit();

        ResultSvc<Diet> CreateDiet(Diet diet);
        ResultSvc<InstructorRole> CreateInstructorRole(InstructorRole role);
        ResultSvc<Photo> CreatePhoto(Photo photo);
        ResultSvc<Instructor> CreateInstructor(Instructor instructor);
        ResultSvc<CampCategory> CreateCampCategory(CampCategory campCategory);
        ResultSvc<Entity.Camp> CreateCamp(Entity.Camp camp);
        ResultSvc<CampBatch> CreateCampBatch(CampBatch campBatch);
        ResultSvc<ObjectType> CreateObjectType(ObjectType objectType);
        ResultSvc<Entity.Object> CreateObject(Entity.Object _object);
        ResultSvc<ObjectTypePrice> CreateObjectTypePrice(ObjectTypePrice objectTypePrice);
        ResultSvc<InstructorCamp> AddInstructorToCamp(int instructorId, int campBatchId, int instructorRoleId);
        ResultSvc<ObjectOrder> CreateObjectOrder(ObjectOrder objectOrder);
        ResultSvc<Payment> CreatePayment(Payment payment);
        ResultSvc<InstructorRole> ChangeOrder(InstructorRole instructorRole, bool up);
        ResultSvc<InstructorRole> DeleteInstructorRole(InstructorRole instructorRole);
        ResultSvc<InstructorCamp> RemoveInstructorCampBatch(int campBatchId, int instructorId, int instructorRoleId);
    }
}
