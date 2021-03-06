﻿using Camp.Data.Entity;
using Camp.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Camp.Data
{
    public class CampEFCoreService : CampService
    {
        public CampDbContext DbContext { get; }

        public CampEFCoreService(CampDbContext db) : base()
        {
            DbContext = db;
            CampCategories = new CampCategoryRepository(db);
            CampBatches = new CampBatchRepository(db);
            Camps = new CampRepository(db);
            Diets = new DietRepository(db);
            Instructors = new InstructorRepository(db);
            InstructorRoles = new InstructorRoleRepository(db);
            ObjectOrders = new ObjectOrderRepository(db);
            Objects = new ObjectRepository(db);
            ObjectTypePrices = new ObjectTypePriceRepository(db);
            ObjectTypes = new ObjectTypeRepository(db);
            Payments = new PaymentRepository(db);
            Photos = new PhotoRepository(db);
            Context = new HttpContextAccessor();
            LoggerFactory = new LoggerFactory();
            LoggerFactory.AddFile("Logs/{Date}.txt");
            Logger = LoggerFactory.CreateLogger("Log");
        }

        public override void Commit()
        {
            DbContext.SaveChanges();
        }

        public override void Dispose()
        {
            DbContext.Dispose();
        }

        public override ResultSvc<InstructorCamp> RemoveInstructorCampBatch(int campBatchId, int instructorId, int instructorRoleId)
        {
            var instructorCamp = DbContext.InstructorCamps.FirstOrDefault(x => x.CampBatchId == campBatchId && x.InstructorId == instructorId && x.InstructorRoleId == instructorRoleId);
            var result = new ResultSvc<InstructorCamp>(instructorCamp);
            try
            {
                if(instructorCamp == null)
                {
                    result.Errors.Add("Nenalezeno");
                }
                else
                {
                    DbContext.InstructorCamps.Remove(instructorCamp);
                }
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
            }
            return result;
        }
    }
}
