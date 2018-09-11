﻿// <auto-generated />
using System;
using Camp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Camp.Data.Migrations
{
    [DbContext(typeof(CampDbContext))]
    [Migration("20180911184151_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Camp.Data.Entity.Camp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Batch");

                    b.Property<int>("CampCategoryId");

                    b.Property<int>("Capacity");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("Deleted");

                    b.Property<string>("Description");

                    b.Property<DateTime>("From");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<string>("OrganizationalInformation");

                    b.Property<decimal>("Price");

                    b.Property<string>("Schedule");

                    b.Property<DateTime>("To");

                    b.Property<DateTime?>("Updated");

                    b.Property<string>("UserCreated");

                    b.Property<string>("UserDeleted");

                    b.Property<string>("UserUpdated");

                    b.HasKey("Id");

                    b.HasIndex("CampCategoryId");

                    b.ToTable("Camps");
                });

            modelBuilder.Entity("Camp.Data.Entity.CampCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("Deleted");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("Updated");

                    b.Property<string>("UserCreated");

                    b.Property<string>("UserDeleted");

                    b.Property<string>("UserUpdated");

                    b.HasKey("Id");

                    b.ToTable("CampCategories");
                });

            modelBuilder.Entity("Camp.Data.Entity.Diet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("ChildrenPrice");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("Deleted");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<decimal>("PersonPrice");

                    b.Property<DateTime?>("Updated");

                    b.Property<string>("UserCreated");

                    b.Property<string>("UserDeleted");

                    b.Property<string>("UserUpdated");

                    b.HasKey("Id");

                    b.ToTable("Diets");
                });

            modelBuilder.Entity("Camp.Data.Entity.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("DateOfBirth");

                    b.Property<DateTime?>("Deleted");

                    b.Property<string>("Description");

                    b.Property<string>("Email");

                    b.Property<string>("Facebook");

                    b.Property<string>("Firstname");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Lastname");

                    b.Property<string>("Phone");

                    b.Property<string>("Title");

                    b.Property<DateTime?>("Updated");

                    b.Property<string>("UserCreated");

                    b.Property<string>("UserDeleted");

                    b.Property<string>("UserUpdated");

                    b.HasKey("Id");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("Camp.Data.Entity.InstructorCamp", b =>
                {
                    b.Property<int>("InstructorId");

                    b.Property<int>("CampId");

                    b.Property<int>("InstructorRoleId");

                    b.HasKey("InstructorId", "CampId", "InstructorRoleId");

                    b.HasIndex("CampId");

                    b.HasIndex("InstructorRoleId");

                    b.ToTable("InstructorCamps");
                });

            modelBuilder.Entity("Camp.Data.Entity.InstructorRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("Deleted");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("Updated");

                    b.Property<string>("UserCreated");

                    b.Property<string>("UserDeleted");

                    b.Property<string>("UserUpdated");

                    b.HasKey("Id");

                    b.ToTable("InstructorRoles");
                });

            modelBuilder.Entity("Camp.Data.Entity.Object", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("Deleted");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Mark");

                    b.Property<int>("ObjectTypeId");

                    b.Property<DateTime?>("Updated");

                    b.Property<string>("UserCreated");

                    b.Property<string>("UserDeleted");

                    b.Property<string>("UserUpdated");

                    b.HasKey("Id");

                    b.HasIndex("ObjectTypeId");

                    b.ToTable("Objects");
                });

            modelBuilder.Entity("Camp.Data.Entity.ObjectOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BusinessId");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("Deleted");

                    b.Property<string>("Email");

                    b.Property<string>("Firstname");

                    b.Property<DateTime>("From");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Lastname");

                    b.Property<int>("OrderState");

                    b.Property<int>("PaymentType");

                    b.Property<string>("Street");

                    b.Property<string>("TaxId");

                    b.Property<string>("Telephone");

                    b.Property<DateTime>("To");

                    b.Property<DateTime?>("Updated");

                    b.Property<string>("UserCreated");

                    b.Property<string>("UserDeleted");

                    b.Property<string>("UserUpdated");

                    b.Property<string>("Zipcode");

                    b.HasKey("Id");

                    b.ToTable("ObjectOrders");
                });

            modelBuilder.Entity("Camp.Data.Entity.ObjectOrderDiet", b =>
                {
                    b.Property<int>("ObjectOrderId");

                    b.Property<int>("DietId");

                    b.Property<int>("PersonType");

                    b.Property<int>("Count");

                    b.HasKey("ObjectOrderId", "DietId", "PersonType");

                    b.HasIndex("DietId");

                    b.ToTable("ObjectOrderDiets");
                });

            modelBuilder.Entity("Camp.Data.Entity.ObjectOrderObject", b =>
                {
                    b.Property<int>("ObjectOrderId");

                    b.Property<int>("ObjectId");

                    b.Property<int>("BabiesCount");

                    b.Property<int>("ChildrensCount");

                    b.Property<int>("PersonsCount");

                    b.HasKey("ObjectOrderId", "ObjectId");

                    b.HasIndex("ObjectId");

                    b.ToTable("ObjectOrderObjects");
                });

            modelBuilder.Entity("Camp.Data.Entity.ObjectType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("Deleted");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<string>("ObjectsName");

                    b.Property<DateTime?>("Updated");

                    b.Property<string>("UserCreated");

                    b.Property<string>("UserDeleted");

                    b.Property<string>("UserUpdated");

                    b.HasKey("Id");

                    b.ToTable("ObjectTypes");
                });

            modelBuilder.Entity("Camp.Data.Entity.ObjectTypePrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("Deleted");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("MaxNights");

                    b.Property<int>("MinNights");

                    b.Property<int>("ObjectTypeId");

                    b.Property<int>("PersonsCount");

                    b.Property<decimal>("Price");

                    b.Property<DateTime?>("Updated");

                    b.Property<string>("UserCreated");

                    b.Property<string>("UserDeleted");

                    b.Property<string>("UserUpdated");

                    b.HasKey("Id");

                    b.HasIndex("ObjectTypeId");

                    b.ToTable("ObjectTypePrices");
                });

            modelBuilder.Entity("Camp.Data.Entity.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("Deleted");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ObjectOrderId");

                    b.Property<DateTime?>("Updated");

                    b.Property<string>("UserCreated");

                    b.Property<string>("UserDeleted");

                    b.Property<string>("UserUpdated");

                    b.HasKey("Id");

                    b.HasIndex("ObjectOrderId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Camp.Data.Entity.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CampId");

                    b.Property<int?>("CampcategoryId");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("Deleted");

                    b.Property<string>("Description");

                    b.Property<int?>("InstructorId");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("Main");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<string>("Path");

                    b.Property<DateTime?>("Updated");

                    b.Property<string>("UserCreated");

                    b.Property<string>("UserDeleted");

                    b.Property<string>("UserUpdated");

                    b.HasKey("Id");

                    b.HasIndex("CampId");

                    b.HasIndex("CampcategoryId");

                    b.HasIndex("InstructorId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Camp.Data.Entity.Camp", b =>
                {
                    b.HasOne("Camp.Data.Entity.CampCategory", "CampCategory")
                        .WithMany("Camps")
                        .HasForeignKey("CampCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Camp.Data.Entity.InstructorCamp", b =>
                {
                    b.HasOne("Camp.Data.Entity.Camp", "Camp")
                        .WithMany("InstructorCamps")
                        .HasForeignKey("CampId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Camp.Data.Entity.Instructor", "Instructor")
                        .WithMany("InstructorCamps")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Camp.Data.Entity.InstructorRole", "InstructorRole")
                        .WithMany("InstructorCamps")
                        .HasForeignKey("InstructorRoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Camp.Data.Entity.Object", b =>
                {
                    b.HasOne("Camp.Data.Entity.ObjectType", "ObjectType")
                        .WithMany("Objects")
                        .HasForeignKey("ObjectTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Camp.Data.Entity.ObjectOrderDiet", b =>
                {
                    b.HasOne("Camp.Data.Entity.Diet", "Diet")
                        .WithMany("ObjectOrderDiets")
                        .HasForeignKey("DietId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Camp.Data.Entity.ObjectOrder", "ObjectOrder")
                        .WithMany("ObjectOrderDiets")
                        .HasForeignKey("ObjectOrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Camp.Data.Entity.ObjectOrderObject", b =>
                {
                    b.HasOne("Camp.Data.Entity.Object", "Object")
                        .WithMany("Orders")
                        .HasForeignKey("ObjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Camp.Data.Entity.ObjectOrder", "ObjectOrder")
                        .WithMany("Objects")
                        .HasForeignKey("ObjectOrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Camp.Data.Entity.ObjectTypePrice", b =>
                {
                    b.HasOne("Camp.Data.Entity.ObjectType", "ObjectType")
                        .WithMany("Prices")
                        .HasForeignKey("ObjectTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Camp.Data.Entity.Payment", b =>
                {
                    b.HasOne("Camp.Data.Entity.ObjectOrder", "ObjectOrder")
                        .WithMany("Payments")
                        .HasForeignKey("ObjectOrderId");
                });

            modelBuilder.Entity("Camp.Data.Entity.Photo", b =>
                {
                    b.HasOne("Camp.Data.Entity.Camp", "Camp")
                        .WithMany("Photos")
                        .HasForeignKey("CampId");

                    b.HasOne("Camp.Data.Entity.CampCategory", "CampCategory")
                        .WithMany("Photos")
                        .HasForeignKey("CampcategoryId");

                    b.HasOne("Camp.Data.Entity.Instructor", "Instructor")
                        .WithMany("Photos")
                        .HasForeignKey("InstructorId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
