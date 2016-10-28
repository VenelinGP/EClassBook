using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EClassBook.Data;

namespace EClassBook.Data.Migrations
{
    [DbContext(typeof(EBookContext))]
    partial class EBookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EClassBook.Model.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<string>("Email");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Street");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("EClassBook.Model.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("Name");

                    b.Property<int>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("EClassBook.Model.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CourseId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime>("Date");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<int>("GradeValue");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<int?>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("Grade");
                });

            modelBuilder.Entity("EClassBook.Model.Headmaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddressId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<string>("FirstName");

                    b.Property<string>("HashedPassword");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsLocked");

                    b.Property<string>("LastName");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("Salt");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Headmaster");
                });

            modelBuilder.Entity("EClassBook.Model.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<int>("Name")
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("EClassBook.Model.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddressId");

                    b.Property<string>("Class");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<string>("FirstName");

                    b.Property<string>("HashedPassword");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsLoked");

                    b.Property<string>("LastName");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("Name");

                    b.Property<int>("RoleId");

                    b.Property<string>("Salt");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("RoleId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("EClassBook.Model.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddressId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<string>("FirstName");

                    b.Property<string>("HashedPassword");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsLoked");

                    b.Property<string>("LastName");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("Salt");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("EClassBook.Model.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<int?>("HeadmasterId");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<int>("RoleId");

                    b.Property<int?>("StudentId");

                    b.Property<int?>("TeacherId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("HeadmasterId");

                    b.HasIndex("RoleId");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("EClassBook.Model.Course", b =>
                {
                    b.HasOne("EClassBook.Model.Teacher", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EClassBook.Model.Grade", b =>
                {
                    b.HasOne("EClassBook.Model.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EClassBook.Model.Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("EClassBook.Model.Headmaster", b =>
                {
                    b.HasOne("EClassBook.Model.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EClassBook.Model.Student", b =>
                {
                    b.HasOne("EClassBook.Model.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EClassBook.Model.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EClassBook.Model.Teacher", b =>
                {
                    b.HasOne("EClassBook.Model.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EClassBook.Model.UserRole", b =>
                {
                    b.HasOne("EClassBook.Model.Headmaster")
                        .WithMany("UserRoles")
                        .HasForeignKey("HeadmasterId");

                    b.HasOne("EClassBook.Model.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EClassBook.Model.Student")
                        .WithMany("UserRoles")
                        .HasForeignKey("StudentId");

                    b.HasOne("EClassBook.Model.Teacher")
                        .WithMany("UserRoles")
                        .HasForeignKey("TeacherId");
                });
        }
    }
}
