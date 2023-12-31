﻿// <auto-generated />

#nullable disable

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using VoceaUniversitatiiDataModels;

namespace VoceaUniversitatiiMigrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20231112194811_TeachersFix")]
    partial class TeachersFix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("vocea_universitatii.Models.AcademicYear", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("EndYear")
                        .HasColumnType("integer");

                    b.Property<int>("StartYear")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("AcademicYears");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            EndYear = 2023,
                            StartYear = 2022
                        },
                        new
                        {
                            Id = 2L,
                            EndYear = 2024,
                            StartYear = 2023
                        },
                        new
                        {
                            Id = 3L,
                            EndYear = 2025,
                            StartYear = 2024
                        });
                });

            modelBuilder.Entity("vocea_universitatii.Models.Department", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CreatedByid")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DeletedByid")
                        .HasColumnType("integer");

                    b.Property<long>("FacultyId")
                        .HasColumnType("bigint");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("UpdatedByid")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByid");

                    b.HasIndex("DeletedByid");

                    b.HasIndex("FacultyId");

                    b.HasIndex("UpdatedByid");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("vocea_universitatii.Models.Faculty", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CreatedByid")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DeletedByid")
                        .HasColumnType("integer");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("UpdatedByid")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByid");

                    b.HasIndex("DeletedByid");

                    b.HasIndex("UpdatedByid");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("vocea_universitatii.Models.StudyProgram", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CreatedByid")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DeletedByid")
                        .HasColumnType("integer");

                    b.Property<long>("FacultyId")
                        .HasColumnType("bigint");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Language")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("UpdatedByid")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByid");

                    b.HasIndex("DeletedByid");

                    b.HasIndex("FacultyId");

                    b.HasIndex("UpdatedByid");

                    b.ToTable("StudyPrograms");
                });

            modelBuilder.Entity("vocea_universitatii.Models.Teacher", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("CNP")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CreatedByid")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DeletedByid")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("TeacherTitleId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("UpdatedByid")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByid");

                    b.HasIndex("DeletedByid");

                    b.HasIndex("TeacherTitleId");

                    b.HasIndex("UpdatedByid");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("vocea_universitatii.Models.TeacherDepartmentMembership", b =>
                {
                    b.Property<long>("TeacherId")
                        .HasColumnType("bigint");

                    b.Property<long>("DepartmentId")
                        .HasColumnType("bigint");

                    b.Property<bool>("BaseDepartment")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CreatedByid")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DeletedByid")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("UpdatedByid")
                        .HasColumnType("integer");

                    b.HasKey("TeacherId", "DepartmentId");

                    b.HasIndex("CreatedByid");

                    b.HasIndex("DeletedByid");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("UpdatedByid");

                    b.ToTable("TeacherDepartmentMembership");
                });

            modelBuilder.Entity("vocea_universitatii.Models.TeacherTitle", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CreatedByid")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DeletedByid")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("UpdatedByid")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByid");

                    b.HasIndex("DeletedByid");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.HasIndex("UpdatedByid");

                    b.ToTable("TeacherTitles");
                });

            modelBuilder.Entity("vocea_universitatii.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("vocea_universitatii.Models.Department", b =>
                {
                    b.HasOne("vocea_universitatii.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByid");

                    b.HasOne("vocea_universitatii.User", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedByid");

                    b.HasOne("vocea_universitatii.Models.Faculty", "Faculty")
                        .WithMany("Departments")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("vocea_universitatii.User", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByid");

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("Faculty");

                    b.Navigation("UpdatedBy");
                });

            modelBuilder.Entity("vocea_universitatii.Models.Faculty", b =>
                {
                    b.HasOne("vocea_universitatii.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByid");

                    b.HasOne("vocea_universitatii.User", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedByid");

                    b.HasOne("vocea_universitatii.User", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByid");

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("UpdatedBy");
                });

            modelBuilder.Entity("vocea_universitatii.Models.StudyProgram", b =>
                {
                    b.HasOne("vocea_universitatii.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByid");

                    b.HasOne("vocea_universitatii.User", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedByid");

                    b.HasOne("vocea_universitatii.Models.Faculty", "Faculty")
                        .WithMany("StudyPrograms")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("vocea_universitatii.User", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByid");

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("Faculty");

                    b.Navigation("UpdatedBy");
                });

            modelBuilder.Entity("vocea_universitatii.Models.Teacher", b =>
                {
                    b.HasOne("vocea_universitatii.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByid");

                    b.HasOne("vocea_universitatii.User", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedByid");

                    b.HasOne("vocea_universitatii.Models.TeacherTitle", "Title")
                        .WithMany("Teachers")
                        .HasForeignKey("TeacherTitleId");

                    b.HasOne("vocea_universitatii.User", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByid");

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("Title");

                    b.Navigation("UpdatedBy");
                });

            modelBuilder.Entity("vocea_universitatii.Models.TeacherDepartmentMembership", b =>
                {
                    b.HasOne("vocea_universitatii.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByid");

                    b.HasOne("vocea_universitatii.User", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedByid");

                    b.HasOne("vocea_universitatii.Models.Department", "Department")
                        .WithMany("TeacherDepartmentMemberships")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("vocea_universitatii.Models.Teacher", "Teacher")
                        .WithMany("TeacherDepartmentMemberships")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("vocea_universitatii.User", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByid");

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("Department");

                    b.Navigation("Teacher");

                    b.Navigation("UpdatedBy");
                });

            modelBuilder.Entity("vocea_universitatii.Models.TeacherTitle", b =>
                {
                    b.HasOne("vocea_universitatii.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByid");

                    b.HasOne("vocea_universitatii.User", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedByid");

                    b.HasOne("vocea_universitatii.User", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByid");

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("UpdatedBy");
                });

            modelBuilder.Entity("vocea_universitatii.Models.Department", b =>
                {
                    b.Navigation("TeacherDepartmentMemberships");
                });

            modelBuilder.Entity("vocea_universitatii.Models.Faculty", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("StudyPrograms");
                });

            modelBuilder.Entity("vocea_universitatii.Models.Teacher", b =>
                {
                    b.Navigation("TeacherDepartmentMemberships");
                });

            modelBuilder.Entity("vocea_universitatii.Models.TeacherTitle", b =>
                {
                    b.Navigation("Teachers");
                });
#pragma warning restore 612, 618
        }
    }
}
