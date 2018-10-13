using System;
using System.Linq;
using Camp.Data.Entity;
using Camp.Data.Repositories;
using Camp.Web.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Camp.Data
{
    public class CampService : ICampService
    {
        public ICampCategoryRepository CampCategories { get; set; }
        public ICampBatchRepository CampBatches { get; set; }
        public ICampRepository Camps { get; set; }
        public IDietRepository Diets { get; set; }
        public IInstructorRepository Instructors { get; set; }
        public IInstructorRoleRepository InstructorRoles { get; set; }
        public IObjectOrderRepository ObjectOrders { get; set; }
        public IObjectRepository Objects { get; set; }
        public IObjectTypePriceRepository ObjectTypePrices { get; set; }
        public IObjectTypeRepository ObjectTypes { get; set; }
        public IPaymentRepository Payments { get; set; }
        public IPhotoRepository Photos { get; set; }
        public IHttpContextAccessor Context { get; set; }
        public ILogger Logger { get; set; }
        public ILoggerFactory LoggerFactory { get; set; }
        public UserManager<User> UserManager { get; set; }

        public virtual void Commit()
        {
            throw new NotImplementedException();
        }

        public virtual void Dispose()
        {
            throw new NotImplementedException();
        }

        public ResultSvc<Diet> CreateDiet(Diet diet)
        {
            var result = new ResultSvc<Diet>(diet);
            try
            {
                if (!Diets.Items.Any(x => x.Name == diet.Name.Trim()))
                {
                    diet.Name = diet.Name?.Trim();
                    diet.UserCreatedId = Context.HttpContext.User.GetUserId();
                    Diets.Add(diet);
                }
                else
                {
                    result.Errors.Add("Strava s tímto názvem již existuje!");
                }
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
            }
            return result;
        }

        public ResultSvc<InstructorRole> CreateInstructorRole(InstructorRole role)
        {
            var result = new ResultSvc<InstructorRole>(role);
            try
            {
                if (!InstructorRoles.Items.Any(x => x.Name == role.Name.Trim()))
                {
                    role.Name = role.Name?.Trim();
                    role.Order = InstructorRoles.Items.Select(x => x.Order).DefaultIfEmpty(0).Max() + 1;
                    role.UserCreatedId = Context.HttpContext.User.GetUserId();
                    InstructorRoles.Add(role);
                }
                else
                {
                    result.Errors.Add("Role s tímto názvem již existuje!");
                }
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
            }
            return result;
        }

        public ResultSvc<Photo> CreatePhoto(Photo photo)
        {
            var result = new ResultSvc<Photo>(photo);
            try
            {
                photo.Name = photo.Name?.Trim();
                photo.Description = photo.Description?.Trim();
                photo.UserCreatedId = Context.HttpContext.User.GetUserId();
                Photos.Add(photo);
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
            }
            return result;
        }

        public ResultSvc<Instructor> CreateInstructor(Instructor instructor)
        {
            var result = new ResultSvc<Instructor>(instructor);
            try
            {
                if(!Instructors.Items.Any(x => x.Firstname == instructor.Firstname.Trim() && x.Lastname == instructor.Lastname.Trim() && (!string.IsNullOrEmpty(instructor.Title) && x.Title == instructor.Title.Trim())))
                {
                    instructor.Firstname = instructor.Firstname?.Trim();
                    instructor.Lastname = instructor.Lastname?.Trim();
                    instructor.Title = instructor.Title?.Trim();
                    instructor.Description = instructor.Description?.Trim();
                    instructor.Email = instructor.Email?.Trim();
                    instructor.Phone = instructor.Phone?.Trim();
                    instructor.Facebook = instructor.Facebook?.Trim();
                    instructor.UserCreatedId = Context.HttpContext.User.GetUserId();
                    Instructors.Add(instructor);
                }
                else
                {
                    result.Errors.Add("Tento instruktor již existuje!");
                }
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
            }
            return result;
        }

        public ResultSvc<CampCategory> CreateCampCategory(CampCategory campCategory)
        {
            var result = new ResultSvc<CampCategory>(campCategory);
            try
            {
                if (!CampCategories.Items.Any(x => x.Name == campCategory.Name.Trim()))
                {
                    campCategory.Name = campCategory.Name?.Trim();
                    campCategory.UserCreatedId = Context.HttpContext.User.GetUserId();
                    CampCategories.Add(campCategory);
                }
                else
                {
                    result.Errors.Add("Kategorie táboru s tímto názvem již existuje!");
                }
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
            }
            return result;
        }

        public ResultSvc<Entity.Camp> CreateCamp(Entity.Camp camp)
        {
            var result = new ResultSvc<Entity.Camp>(camp);
            try
            {
                if(!Camps.Items.Any(x => x.Name == camp.Name.Trim() && x.CampCategoryId == camp.CampCategoryId))
                {
                    camp.Name = camp.Name?.Trim();
                    camp.Description = camp.Description?.Trim();
                    camp.OrganizationalInformation = camp.OrganizationalInformation?.Trim();
                    camp.Schedule = camp.Schedule?.Trim();
                    camp.UserCreatedId = Context.HttpContext.User.GetUserId();
                    Camps.Add(camp);
                }
                else
                {
                    result.Errors.Add("Tábor se stejnými údaji již existuje!");
                }
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
            }
            return result;
        }

        public ResultSvc<InstructorCamp> AddInstructorToCamp(int instructorId, int campBatchId, int instructorRoleId)
        {
            var result = new ResultSvc<InstructorCamp>(new InstructorCamp { CampBatchId = campBatchId, InstructorId = instructorId, InstructorRoleId = instructorRoleId });
            try
            {
                var campBatch = CampBatches.Items.Include(x => x.InstructorCamps).FirstOrDefault(x => x.Id == campBatchId);
                if(!campBatch.InstructorCamps.Any(x => x.InstructorId == instructorId && x.InstructorRoleId == instructorRoleId))
                {
                    campBatch.InstructorCamps.Add(new InstructorCamp { InstructorId = instructorId, InstructorRoleId = instructorRoleId });
                    campBatch.UserUpdatedId = Context.HttpContext.User.GetUserId();
                    CampBatches.Update(campBatch);
                }
                else
                {
                    result.Errors.Add("Tábor již obsahuje tohoto instruktora ve zvolené roli!");
                }
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
            }
            return result;
        }

        public ResultSvc<ObjectType> CreateObjectType(ObjectType objectType)
        {
            var result = new ResultSvc<ObjectType>(objectType);
            try
            {
                if(!ObjectTypes.Items.Any(x => x.Name == objectType.Name.Trim() && x.Capacity == objectType.Capacity))
                {
                    objectType.Name = objectType.Name?.Trim();
                    objectType.ObjectsName = objectType.ObjectsName?.Trim();
                    objectType.UserCreatedId = Context.HttpContext.User.GetUserId();
                    ObjectTypes.Add(objectType);
                }
                else
                {
                    result.Errors.Add("Typ objektu s těmito údaji již existuje!");
                }
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
            }
            return result;
        }

        public ResultSvc<Entity.Object> CreateObject(Entity.Object _object)
        {
            var result = new ResultSvc<Entity.Object>(_object);
            try
            {
                if (!Objects.Items.Any(x => x.Mark == _object.Mark.Trim() && x.ObjectTypeId == _object.ObjectTypeId))
                {
                    _object.Mark = _object.Mark?.Trim();
                    _object.UserCreatedId = Context.HttpContext.User.GetUserId();
                    Objects.Add(_object);
                }
                else
                {
                    result.Errors.Add("Objekt s tímto označením a objektovým typem již existuje!");
                }
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
            }
            return result;
        }

        public ResultSvc<ObjectTypePrice> CreateObjectTypePrice(ObjectTypePrice objectTypePrice)
        {
            var result = new ResultSvc<ObjectTypePrice>(objectTypePrice);
            try
            {
                if(!ObjectTypePrices.Items.Any(x => x.PersonsCount == objectTypePrice.PersonsCount && x.MinNights == objectTypePrice.MinNights && x.MaxNights == objectTypePrice.MaxNights && x.ObjectTypeId == objectTypePrice.ObjectTypeId))
                {
                    objectTypePrice.UserCreatedId = Context.HttpContext.User.GetUserId();
                    ObjectTypePrices.Add(objectTypePrice);
                }
                else
                {
                    result.Errors.Add("Tento cenový typ se stejnými údaji již u objektového typu existuje!");
                }
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
            }
            return result;
        }

        public ResultSvc<ObjectOrder> CreateObjectOrder(ObjectOrder objectOrder)
        {
            var result = new ResultSvc<ObjectOrder>(objectOrder);
            try
            {
                if (!objectOrder.Objects.Any())
                {
                    result.Errors.Add("Není vybráno žádné ubytování.");
                    return result;
                }

                foreach (var _object in objectOrder.Objects)
                {
                    var obj = Objects.Items.Include(x => x.ObjectType).FirstOrDefault(x => x.Id == _object.ObjectId);
                    if (obj.ObjectType.Capacity < _object.TotalPayingPersons)
                        result.Errors.Add("Zvolené ubytování nemá tak velkou kapacitu.");
                    if (!obj.IsAvailable(objectOrder.From, objectOrder.To))
                        result.Errors.Add("Zvolené ubytování je v tomto termínu obsazené.");
                }

                if(result.Errors.Count == 0)
                {
                    objectOrder.Firstname = objectOrder.Firstname?.Trim();
                    objectOrder.Lastname = objectOrder.Lastname?.Trim();
                    objectOrder.Telephone = objectOrder.Telephone?.Trim();
                    objectOrder.Email = objectOrder.Email?.Trim();
                    objectOrder.UserCreatedId = Context.HttpContext.User.GetUserId();
                    ObjectOrders.Add(objectOrder);
                }
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
            }
            return result;
        }

        public ResultSvc<Payment> CreatePayment(Payment payment)
        {
            var result = new ResultSvc<Payment>(payment);
            try
            {
                payment.UserCreatedId = Context.HttpContext.User.GetUserId();
                Payments.Add(payment);
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
            }
            return result;
        }

        public ResultSvc<InstructorRole> ChangeOrder(InstructorRole instructorRole, bool up)
        {
            var result = new ResultSvc<InstructorRole>(instructorRole);
            try
            {
                if((instructorRole.Order == 1 && up) || (instructorRole.Order == InstructorRoles.Items.Select(x => x.Order).DefaultIfEmpty(1).Max() && !up))
                {
                    result.Errors.Add("Nelze změnit pořadí! Pořadí je již buď nejmenší nebo největší možné.");
                }
                else
                {
                    var iRole = InstructorRoles.Items.FirstOrDefault(x => x.Order == (up ? instructorRole.Order - 1 : instructorRole.Order + 1));
                    iRole.Order = up ? iRole.Order + 1 : iRole.Order - 1;
                    iRole.UserUpdatedId = Context.HttpContext.User.GetUserId();
                    instructorRole.Order = up ? instructorRole.Order - 1 : instructorRole.Order + 1;
                    instructorRole.UserUpdatedId = Context.HttpContext.User.GetUserId();
                    InstructorRoles.Update(iRole);
                    InstructorRoles.Update(instructorRole);
                }
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
            }
            return result;
        }

        public ResultSvc<InstructorRole> DeleteInstructorRole(InstructorRole instructorRole)
        {
            var result = new ResultSvc<InstructorRole>(instructorRole);
            try
            {
                foreach (var ir in InstructorRoles.Items.Where(x => x.Order > instructorRole.Order))
                {
                    ir.Order--;
                    InstructorRoles.Update(ir);
                }
                instructorRole.UserDeletedId = Context.HttpContext.User.GetUserId();
                InstructorRoles.Delete(instructorRole);
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
            }
            return result;
        }

        public ResultSvc<CampBatch> CreateCampBatch(CampBatch campBatch)
        {
            var result = new ResultSvc<CampBatch>(campBatch);
            try
            {
                if (!CampBatches.Items.Any(x => x.Batch == campBatch.Batch && x.CampId == campBatch.CampId && x.From == campBatch.From && x.To == campBatch.To))
                {
                    campBatch.UserCreatedId = Context.HttpContext.User.GetUserId();
                    CampBatches.Add(campBatch);
                }
                else
                {
                    result.Errors.Add("Tento turnus ve stejném datu již existuje!");
                }
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
            }
            return result;
        }

        public virtual ResultSvc<InstructorCamp> RemoveInstructorCampBatch(int campBatchId, int instructorId, int instructorRoleId)
        {
            throw new NotImplementedException();
        }
    }
}
