using Camp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Camp.Data
{
    public interface ICampService
    {
        ICampCategoryRepository CampCategories { get; set; }
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

        void Dispose();
        void Commit();
    }
}
