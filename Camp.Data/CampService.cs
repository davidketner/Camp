using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Camp.Data.Entity;
using Camp.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Camp.Data
{
    public class CampService : ICampService
    {
        public ICampCategoryRepository CampCategories { get; set; }
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

        public virtual void Commit()
        {
            throw new NotImplementedException();
        }

        public virtual void Dispose()
        {
            throw new NotImplementedException();
        }

        public ResultSvc<Diet> CreateDiet(Diet diet, string userId)
        {
            var result = new ResultSvc<Diet>(false, null, diet);
            try
            {
                if (!Diets.Items.Any(x => x.Name == diet.Name.Trim()))
                {
                    diet.Name = diet.Name.Trim();
                    diet.UserCreated = userId;
                    Diets.Add(diet);
                    result.IsOK = true;
                }
                else
                {
                    result.Errors.Add("Strava s tímto názvem již existuje!");
                }
            }
            catch (Exception e)
            {
            }
            return result;
        }

        public ResultSvc<InstructorRole> CreateInstructorRole(InstructorRole role, string userId)
        {
            var result = new ResultSvc<InstructorRole>(false, null, role);
            try
            {
                if (!InstructorRoles.Items.Any(x => x.Name == role.Name.Trim()))
                {
                    role.Name = role.Name.Trim();
                    role.UserCreated = userId;
                    InstructorRoles.Add(role);
                    result.IsOK = true;
                }
                else
                {
                    result.Errors.Add("Role s tímto názvem již existuje!");
                }
            }
            catch (Exception e)
            {
            }
            return result;
        }

        public ResultSvc<Photo> CreatePhoto(Photo photo, string userId)
        {
            var result = new ResultSvc<Photo>(false, null, photo);
            try
            {
                photo.Name = photo.Name.Trim();
                photo.Description = photo.Description.Trim();
                photo.UserCreated = userId;
                Photos.Add(photo);
                result.IsOK = true;
            }
            catch (Exception e)
            {
            }
            return result;
        }

        public ResultSvc<Instructor> CreateInstructor(Instructor instructor, string userId)
        {
            var result = new ResultSvc<Instructor>(false, null, instructor);
            try
            {
                if(!Instructors.Items.Any(x => x.Firstname == instructor.Firstname.Trim() && x.Lastname == instructor.Lastname.Trim() && x.Title == instructor.Title.Trim()))
                {
                    instructor.Firstname = instructor.Firstname.Trim();
                    instructor.Lastname = instructor.Lastname.Trim();
                    instructor.Title = instructor.Title.Trim();
                    instructor.Description = instructor.Description.Trim();
                    instructor.Email = instructor.Email.Trim();
                    instructor.Phone = instructor.Phone.Trim();
                    instructor.Facebook = instructor.Facebook.Trim();
                    instructor.UserCreated = userId;
                    Instructors.Add(instructor);
                    result.IsOK = true;
                }
                else
                {
                    result.Errors.Add("Tento instruktor již existuje!");
                }
            }
            catch (Exception e)
            {
            }
            return result;
        }

        public ResultSvc<CampCategory> CreateCampCategory(CampCategory campCategory, string userId)
        {
            var result = new ResultSvc<CampCategory>(false, null, campCategory);
            try
            {
                if (!CampCategories.Items.Any(x => x.Name == campCategory.Name.Trim()))
                {
                    campCategory.Name = campCategory.Name.Trim();
                    CampCategories.Add(campCategory);
                    result.IsOK = true;
                }
                else
                {
                    result.Errors.Add("Kategorie táboru s tímto názvem již existuje!");
                }
            }
            catch (Exception e)
            {
            }
            return result;
        }

        public ResultSvc<Entity.Camp> CreateCamp(Entity.Camp camp, string userId)
        {
            var result = new ResultSvc<Entity.Camp>(false, null, camp);
            try
            {
                if(!Camps.Items.Any(x => x.Name == camp.Name.Trim() && x.Batch == camp.Batch && x.From == camp.From && x.To == camp.To && x.CampCategoryId == camp.CampCategoryId))
                {
                    camp.Name = camp.Name.Trim();
                    camp.Description = camp.Description.Trim();
                    camp.OrganizationalInformation = camp.OrganizationalInformation.Trim();
                    camp.Schedule = camp.Schedule.Trim();
                    camp.UserCreated = userId;
                    Camps.Add(camp);
                    result.IsOK = true;
                }
                else
                {
                    result.Errors.Add("Tábor se stejnými údaji již existuje!");
                }
            }
            catch (Exception e)
            {

            }
            return result;
        }

        public ResultSvc<InstructorCamp> AddInstructorToCamp(int instructorId, int campId, int instructorRoleId, string userId)
        {
            var result = new ResultSvc<InstructorCamp>(false, null, new InstructorCamp { CampId = campId, InstructorId = instructorId, InstructorRoleId = instructorRoleId });
            try
            {
                var camp = Camps.FindById(campId);
                if(!camp.InstructorCamps.Any(x => x.InstructorId == instructorId && x.InstructorRoleId == instructorRoleId))
                {
                    camp.InstructorCamps.Add(new InstructorCamp { InstructorId = instructorId, InstructorRoleId = instructorRoleId });
                    camp.UserUpdated = userId;
                    Camps.Update(camp);
                    result.IsOK = true;
                }
                else
                {
                    result.Errors.Add("Tábor již obsahuje tohoto instruktora ve zvolené roli!");
                }
            }
            catch (Exception e)
            {

            }
            return result;
        }

        public ResultSvc<ObjectType> CreateObjectType(ObjectType objectType, string userId)
        {
            var result = new ResultSvc<ObjectType>(false, null, objectType);
            try
            {
                if(!ObjectTypes.Items.Any(x => x.Name == objectType.Name.Trim() && x.Capacity == objectType.Capacity))
                {
                    objectType.Name = objectType.Name.Trim();
                    objectType.ObjectsName = objectType.ObjectsName.Trim();
                    objectType.UserCreated = userId;
                    ObjectTypes.Add(objectType);
                    result.IsOK = true;
                }
                else
                {
                    result.Errors.Add("Typ objektu s těmito údaji již existuje!");
                }
            }
            catch (Exception e)
            {

            }
            return result;
        }

        public ResultSvc<Entity.Object> CreateObject(Entity.Object _object, string userId)
        {
            var result = new ResultSvc<Entity.Object>(false, null, _object);
            try
            {
                if (!Objects.Items.Any(x => x.Mark == _object.Mark.Trim() && x.ObjectTypeId == _object.ObjectTypeId))
                {
                    _object.Mark = _object.Mark.Trim();
                    _object.UserCreated = userId;
                    Objects.Add(_object);
                    result.IsOK = true;
                }
                else
                {
                    result.Errors.Add("Objekt s tímto označením a objektovým typem již existuje!");
                }
            }
            catch (Exception e)
            {

            }
            return result;
        }

        public ResultSvc<ObjectTypePrice> CreateObjectTypePrice(ObjectTypePrice objectTypePrice, string userId)
        {
            var result = new ResultSvc<ObjectTypePrice>(false, null, objectTypePrice);
            try
            {
                if(!ObjectTypePrices.Items.Any(x => x.PersonsCount == objectTypePrice.PersonsCount && x.MinNights == objectTypePrice.MinNights && x.MaxNights == objectTypePrice.MaxNights && x.ObjectTypeId == objectTypePrice.ObjectTypeId))
                {
                    objectTypePrice.UserCreated = userId;
                    ObjectTypePrices.Add(objectTypePrice);
                    result.IsOK = true;
                }
                else
                {
                    result.Errors.Add("Tento cenový typ se stejnými údaji již u objektového typu existuje!");
                }
            }
            catch (Exception e)
            {

            }
            return result;
        }

        public ResultSvc<ObjectOrder> CreateObjectOrder(ObjectOrder objectOrder, string userId)
        {
            var result = new ResultSvc<ObjectOrder>(false, null, objectOrder);
            try
            {

            }
            catch
            {

            }
            return result;
        }
    }
}
