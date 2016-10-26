namespace EClassBook.API.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Migrations;
    using EClassBook.Data;


    [DbContext(typeof(EBookContext))]
    [Migration("20161024183737_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EClassBook.Model.Entities.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Street");

                    b.HasKey("AddressId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("EClassBook.Model.Entities.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("TeacherId");

                    b.HasKey("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("EClassBook.Model.Entities.Grade", b =>
                {
                    b.Property<int>("GradeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CourseId");

                    b.Property<DateTime>("Date");

                    b.Property<int>("GradeValue");

                    b.Property<int?>("StudentId");

                    b.HasKey("GradeId");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("EClassBook.Model.Entities.Headmaster", b =>
                {
                    b.Property<int>("HeadmasterId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddressId");

                    b.Property<string>("Name");

                    b.Property<int>("RoleId");

                    b.HasKey("HeadmasterId");

                    b.HasIndex("AddressId");

                    b.HasIndex("RoleId");

                    b.ToTable("Headmasters");
                });

            modelBuilder.Entity("EClassBook.Model.Entities.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<DateTime>("Dob");

                    b.Property<string>("Name");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("EClassBook.Model.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Name");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("EClassBook.Model.Entities.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddressId");

                    b.Property<string>("Class");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Name");

                    b.Property<int>("RoleId");

                    b.HasKey("StudentId");

                    b.HasIndex("AddressId");

                    b.HasIndex("RoleId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("EClassBook.Model.Entities.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddressId");

                    b.Property<string>("Name");

                    b.Property<int>("RoleId");

                    b.HasKey("TeacherId");

                    b.HasIndex("AddressId");

                    b.HasIndex("RoleId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("EClassBook.Model.Entities.Course", b =>
                {
                    b.HasOne("EClassBook.Model.Entities.Teacher", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EClassBook.Model.Entities.Grade", b =>
                {
                    b.HasOne("EClassBook.Model.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EClassBook.Model.Entities.Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("EClassBook.Model.Entities.Headmaster", b =>
                {
                    b.HasOne("EClassBook.Model.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EClassBook.Model.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EClassBook.Model.Entities.Student", b =>
                {
                    b.HasOne("EClassBook.Model.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EClassBook.Model.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EClassBook.Model.Entities.Teacher", b =>
                {
                    b.HasOne("EClassBook.Model.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EClassBook.Model.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
