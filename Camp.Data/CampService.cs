using System;
using System.Collections.Generic;
using System.Text;
using Camp.Data.Repositories;

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
    }
}
