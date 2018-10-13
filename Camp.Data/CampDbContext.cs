using Microsoft.EntityFrameworkCore;
using Camp.Data.Entity;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using UtilityLibrary;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Camp.Data
{
    public class CampDbContext : IdentityDbContext<User>
    {
        public CampDbContext(DbContextOptions<CampDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Camp;Trusted_Connection=True;");
        }

        public DbSet<Entity.Camp> Camps { get; set; }
        public DbSet<CampBatch> CampBatches { get; set; }
        public DbSet<CampCategory> CampCategories { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<InstructorCamp> InstructorCamps { get; set; }
        public DbSet<InstructorRole> InstructorRoles { get; set; }
        public DbSet<Entity.Object> Objects { get; set; }
        public DbSet<ObjectOrder> ObjectOrders { get; set; }
        public DbSet<ObjectOrderDiet> ObjectOrderDiets { get; set; }
        public DbSet<ObjectOrderObject> ObjectOrderObjects { get; set; }
        public DbSet<ObjectType> ObjectTypes { get; set; }
        public DbSet<ObjectTypePrice> ObjectTypePrices { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Photo> Photos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDeletable).IsAssignableFrom(entityType.ClrType) == true)
                {
                    entityType.GetOrAddProperty("IsDeleted", typeof(bool));

                    var parameter = Expression.Parameter(entityType.ClrType);

                    var propertyMethodInfo = typeof(EF).GetMethod("Property").MakeGenericMethod(typeof(bool));
                    var isDeletedProperty = Expression.Call(propertyMethodInfo, parameter, Expression.Constant("IsDeleted"));

                    BinaryExpression compareExpression = Expression.MakeBinary(ExpressionType.Equal, isDeletedProperty, Expression.Constant(false));

                    var lambda = Expression.Lambda(compareExpression, parameter);

                    builder.Entity(entityType.ClrType).HasQueryFilter(lambda);
                }
            }

            builder.Entity<InstructorCamp>()
                   .HasKey(ic => new { ic.InstructorId, ic.CampBatchId, ic.InstructorRoleId });

            builder.Entity<InstructorCamp>()
                   .HasOne(ic => ic.Instructor)
                   .WithMany(i => i.InstructorCamps)
                   .HasForeignKey(ic => ic.InstructorId);

            builder.Entity<InstructorCamp>()
                   .HasOne(ic => ic.CampBatch)
                   .WithMany(c => c.InstructorCamps)
                   .HasForeignKey(ic => ic.CampBatchId);

            builder.Entity<InstructorCamp>()
                   .HasOne(ic => ic.InstructorRole)
                   .WithMany(c => c.InstructorCamps)
                   .HasForeignKey(ic => ic.InstructorRoleId);

            builder.Entity<ObjectOrderDiet>()
                   .HasKey(o => new { o.ObjectOrderId, o.DietId, o.PersonType});

            builder.Entity<ObjectOrderDiet>()
                   .HasOne(o => o.ObjectOrder)
                   .WithMany(o => o.ObjectOrderDiets)
                   .HasForeignKey(o => o.ObjectOrderId);

            builder.Entity<ObjectOrderDiet>()
                   .HasOne(o => o.Diet)
                   .WithMany(o => o.ObjectOrderDiets)
                   .HasForeignKey(o => o.DietId);

            builder.Entity<ObjectOrderObject>()
                   .HasKey(o => new { o.ObjectOrderId, o.ObjectId });

            builder.Entity<ObjectOrderObject>()
                   .HasOne(o => o.ObjectOrder)
                   .WithMany(o => o.Objects)
                   .HasForeignKey(o => o.ObjectOrderId);

            builder.Entity<ObjectOrderObject>()
                   .HasOne(o => o.Object)
                   .WithMany(o => o.Orders)
                   .HasForeignKey(o => o.ObjectId);

        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is ISoftDeletable)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.CurrentValues["IsDeleted"] = false;
                            entry.CurrentValues["Created"] = DateTime.Now;
                            break;

                        case EntityState.Modified:
                            entry.CurrentValues["Updated"] = DateTime.Now;
                            break;

                        case EntityState.Deleted:
                            entry.State = EntityState.Modified;
                            entry.CurrentValues["IsDeleted"] = true;
                            entry.CurrentValues["Deleted"] = DateTime.Now;
                            break;
                    }
                }
            }
        }
    }
}