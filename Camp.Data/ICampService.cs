﻿using Camp.Data.Entity;
using Camp.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

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
        ResultSvc<InstructorRole> CreateInstructorRole(InstructorRole role, string userId);
        ResultSvc<Photo> CreatePhoto(Photo photo, string userId);
        ResultSvc<Instructor> CreateInstructor(Instructor instructor, string userId);
        ResultSvc<CampCategory> CreateCampCategory(CampCategory campCategory, string userId);
        ResultSvc<Entity.Camp> CreateCamp(Entity.Camp camp, string userId);
        ResultSvc<CampBatch> CreateCampBatch(CampBatch campBatch, string userId);
        ResultSvc<ObjectType> CreateObjectType(ObjectType objectType, string userId);
        ResultSvc<Entity.Object> CreateObject(Entity.Object _object, string userId);
        ResultSvc<ObjectTypePrice> CreateObjectTypePrice(ObjectTypePrice objectTypePrice, string userId);
        ResultSvc<InstructorCamp> AddInstructorToCamp(int instructorId, int campBatchId, int instructorRoleId, string userId);
        ResultSvc<ObjectOrder> CreateObjectOrder(ObjectOrder objectOrder, string userId);
        ResultSvc<Payment> CreatePayment(Payment payment, string userId);
        ResultSvc<InstructorRole> ChangeOrder(InstructorRole instructorRole, bool up, string userId);
        ResultSvc<InstructorRole> DeleteInstructorRole(InstructorRole instructorRole, string userId);
        ResultSvc<InstructorCamp> RemoveInstructorCampBatch(int campBatchId, int instructorId, int instructorRoleId);
    }
}
