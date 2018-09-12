using Camp.Data.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Camp.Data
{
    public class CampEFCoreService : CampService
    {
        public CampDbContext DbContext { get; }

        public CampEFCoreService(CampDbContext db) : base()
        {
            DbContext = db;
            CampCategories = new CampCategoryRepository(db);
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
        }

        public override void Commit()
        {
            DbContext.SaveChanges();
        }

        public override void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
