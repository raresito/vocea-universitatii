using System;
using System.Collections.Generic;
using LegacyDatabaseMigration.CourseEvalModels;
using Microsoft.EntityFrameworkCore;

namespace LegacyDatabaseMigration.CourseEvakData;

public partial class CourseevalDrept13122023Context : DbContext
{
    public CourseevalDrept13122023Context()
    {
    }

    public CourseevalDrept13122023Context(DbContextOptions<CourseevalDrept13122023Context> options)
        : base(options)
    {
    }

    public virtual DbSet<ActiveIncognitoUser> ActiveIncognitoUsers { get; set; }

    public virtual DbSet<ActiveStorageAttachment> ActiveStorageAttachments { get; set; }

    public virtual DbSet<ActiveStorageBlob> ActiveStorageBlobs { get; set; }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<ActivityType> ActivityTypes { get; set; }

    public virtual DbSet<ArInternalMetadatum> ArInternalMetadata { get; set; }

    public virtual DbSet<Cohort> Cohorts { get; set; }

    public virtual DbSet<CompletedEvaluation> CompletedEvaluations { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<EvalSessionActivity> EvalSessionActivities { get; set; }

    public virtual DbSet<EvaluationSession> EvaluationSessions { get; set; }

    public virtual DbSet<EvaluationSessionCohort> EvaluationSessionCohorts { get; set; }

    public virtual DbSet<Form> Forms { get; set; }

    public virtual DbSet<IncognitoUser> IncognitoUsers { get; set; }

    public virtual DbSet<Preference> Preferences { get; set; }

    public virtual DbSet<SchemaMigration> SchemaMigrations { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Database=courseeval_drept_13122023;User Id=rarescristea;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActiveIncognitoUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("active_incognito_users_pkey");

            entity.ToTable("active_incognito_users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.IncognitoUserToken)
                .HasColumnType("character varying")
                .HasColumnName("incognito_user_token");
            entity.Property(e => e.StartDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start_date");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ActiveStorageAttachment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("active_storage_attachments_pkey");

            entity.ToTable("active_storage_attachments");

            entity.HasIndex(e => e.BlobId, "index_active_storage_attachments_on_blob_id");

            entity.HasIndex(e => new { e.RecordType, e.RecordId, e.Name, e.BlobId }, "index_active_storage_attachments_uniqueness").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BlobId).HasColumnName("blob_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.RecordId).HasColumnName("record_id");
            entity.Property(e => e.RecordType)
                .HasColumnType("character varying")
                .HasColumnName("record_type");

            entity.HasOne(d => d.Blob).WithMany(p => p.ActiveStorageAttachments)
                .HasForeignKey(d => d.BlobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rails_c3b3935057");
        });

        modelBuilder.Entity<ActiveStorageBlob>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("active_storage_blobs_pkey");

            entity.ToTable("active_storage_blobs");

            entity.HasIndex(e => e.Key, "index_active_storage_blobs_on_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ByteSize).HasColumnName("byte_size");
            entity.Property(e => e.Checksum)
                .HasColumnType("character varying")
                .HasColumnName("checksum");
            entity.Property(e => e.ContentType)
                .HasColumnType("character varying")
                .HasColumnName("content_type");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Filename)
                .HasColumnType("character varying")
                .HasColumnName("filename");
            entity.Property(e => e.Key)
                .HasColumnType("character varying")
                .HasColumnName("key");
            entity.Property(e => e.Metadata).HasColumnName("metadata");
        });

        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("activities_pkey");

            entity.ToTable("activities");

            entity.HasIndex(e => e.CohortId, "index_activities_on_cohort_id");

            entity.HasIndex(e => e.CourseId, "index_activities_on_course_id");

            entity.HasIndex(e => e.TeacherId, "index_activities_on_teacher_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActivityType)
                .HasColumnType("character varying")
                .HasColumnName("activity_type");
            entity.Property(e => e.CohortId).HasColumnName("cohort_id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.IsOptional).HasColumnName("is_optional");
            entity.Property(e => e.Semester).HasColumnName("semester");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Cohort).WithMany(p => p.Activities)
                .HasForeignKey(d => d.CohortId)
                .HasConstraintName("fk_rails_40aa3e43ea");

            entity.HasOne(d => d.Course).WithMany(p => p.Activities)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("fk_rails_03b79b4764");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Activities)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("fk_rails_84377f5437");
        });

        modelBuilder.Entity<ActivityType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("activity_types_pkey");

            entity.ToTable("activity_types");

            entity.HasIndex(e => e.FormId, "index_activity_types_on_form_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FormId).HasColumnName("form_id");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");

            entity.HasOne(d => d.Form).WithMany(p => p.ActivityTypes)
                .HasForeignKey(d => d.FormId)
                .HasConstraintName("fk_rails_3d39d0e6b2");
        });

        modelBuilder.Entity<ArInternalMetadatum>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("ar_internal_metadata_pkey");

            entity.ToTable("ar_internal_metadata");

            entity.Property(e => e.Key)
                .HasColumnType("character varying")
                .HasColumnName("key");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.Value)
                .HasColumnType("character varying")
                .HasColumnName("value");
        });

        modelBuilder.Entity<Cohort>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cohorts_pkey");

            entity.ToTable("cohorts");

            entity.HasIndex(e => e.DepartmentId, "index_cohorts_on_department_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.IsTerminal).HasColumnName("is_terminal");
            entity.Property(e => e.Language)
                .HasColumnType("character varying")
                .HasColumnName("language");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.OptionalsNumber)
                .HasDefaultValueSql("0")
                .HasColumnName("optionals_number");
            entity.Property(e => e.StudentsNumber).HasColumnName("students_number");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Department).WithMany(p => p.Cohorts)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("fk_rails_8411f69ce0");
        });

        modelBuilder.Entity<CompletedEvaluation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("completed_evaluations_pkey");

            entity.ToTable("completed_evaluations");

            entity.HasIndex(e => e.EvalSessionActivityId, "index_completed_evaluations_on_eval_session_activity_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.EvalSessionActivityId).HasColumnName("eval_session_activity_id");
            entity.Property(e => e.IncognitoToken)
                .HasColumnType("character varying")
                .HasColumnName("incognito_token");
            entity.Property(e => e.Time).HasColumnName("time");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.EvalSessionActivity).WithMany(p => p.CompletedEvaluations)
                .HasForeignKey(d => d.EvalSessionActivityId)
                .HasConstraintName("fk_rails_dbf4050a08");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("courses_pkey");

            entity.ToTable("courses");

            entity.HasIndex(e => e.DepartmentId, "index_courses_on_department_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.Specialization)
                .HasColumnType("character varying")
                .HasColumnName("specialization");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");
            entity.Property(e => e.Uid)
                .HasColumnType("character varying")
                .HasColumnName("uid");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.Year)
                .HasColumnType("character varying")
                .HasColumnName("year");

            entity.HasOne(d => d.Department).WithMany(p => p.Courses)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("fk_rails_4e7d7b190d");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("departments_pkey");

            entity.ToTable("departments");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<EvalSessionActivity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("eval_session_activities_pkey");

            entity.ToTable("eval_session_activities");

            entity.HasIndex(e => e.CourseId, "index_eval_session_activities_on_course_id");

            entity.HasIndex(e => e.EvaluationSessionCohortId, "index_eval_session_activities_on_evaluation_session_cohort_id");

            entity.HasIndex(e => e.EvaluationSessionId, "index_eval_session_activities_on_evaluation_session_id");

            entity.HasIndex(e => e.TeacherId, "index_eval_session_activities_on_teacher_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActivityType)
                .HasColumnType("character varying")
                .HasColumnName("activity_type");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.EvaluationSessionCohortId).HasColumnName("evaluation_session_cohort_id");
            entity.Property(e => e.EvaluationSessionId).HasColumnName("evaluation_session_id");
            entity.Property(e => e.IsOptional).HasColumnName("is_optional");
            entity.Property(e => e.Semester).HasColumnName("semester");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Course).WithMany(p => p.EvalSessionActivities)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("fk_rails_3a51dfd0af");

            entity.HasOne(d => d.EvaluationSessionCohort).WithMany(p => p.EvalSessionActivities)
                .HasForeignKey(d => d.EvaluationSessionCohortId)
                .HasConstraintName("fk_rails_365998c3bd");

            entity.HasOne(d => d.EvaluationSession).WithMany(p => p.EvalSessionActivities)
                .HasForeignKey(d => d.EvaluationSessionId)
                .HasConstraintName("fk_rails_b70e42b3d4");

            entity.HasOne(d => d.Teacher).WithMany(p => p.EvalSessionActivities)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("fk_rails_ebcb8f9745");
        });

        modelBuilder.Entity<EvaluationSession>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("evaluation_sessions_pkey");

            entity.ToTable("evaluation_sessions");

            entity.HasIndex(e => e.FormId, "index_evaluation_sessions_on_form_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.FormAId).HasColumnName("formA_id");
            entity.Property(e => e.FormId).HasColumnName("form_id");
            entity.Property(e => e.FormLId).HasColumnName("formL_id");
            entity.Property(e => e.FormPId).HasColumnName("formP_id");
            entity.Property(e => e.FormSId).HasColumnName("formS_id");
            entity.Property(e => e.LastRefresh)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_refresh");
            entity.Property(e => e.Semester).HasColumnName("semester");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Status)
                .HasColumnType("character varying")
                .HasColumnName("status");
            entity.Property(e => e.Terminal).HasColumnName("terminal");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.Visibility)
                .HasDefaultValueSql("false")
                .HasColumnName("visibility");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Form).WithMany(p => p.EvaluationSessions)
                .HasForeignKey(d => d.FormId)
                .HasConstraintName("fk_rails_ae26e7f508");
        });

        modelBuilder.Entity<EvaluationSessionCohort>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("evaluation_session_cohorts_pkey");

            entity.ToTable("evaluation_session_cohorts");

            entity.HasIndex(e => e.DepartmentId, "index_evaluation_session_cohorts_on_department_id");

            entity.HasIndex(e => e.EvaluationSessionId, "index_evaluation_session_cohorts_on_evaluation_session_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.EvaluationSessionId).HasColumnName("evaluation_session_id");
            entity.Property(e => e.IsTerminal).HasColumnName("is_terminal");
            entity.Property(e => e.Language)
                .HasColumnType("character varying")
                .HasColumnName("language");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.OptionalsNumber).HasColumnName("optionals_number");
            entity.Property(e => e.StudentsNumber).HasColumnName("students_number");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Department).WithMany(p => p.EvaluationSessionCohorts)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("fk_rails_c0d4f5252c");

            entity.HasOne(d => d.EvaluationSession).WithMany(p => p.EvaluationSessionCohorts)
                .HasForeignKey(d => d.EvaluationSessionId)
                .HasConstraintName("fk_rails_000ebca8b0");
        });

        modelBuilder.Entity<Form>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("forms_pkey");

            entity.ToTable("forms");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<IncognitoUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("incognito_users_pkey");

            entity.ToTable("incognito_users");

            entity.HasIndex(e => e.EvaluationSessionCohortId, "index_incognito_users_on_evaluation_session_cohort_id");

            entity.HasIndex(e => e.EvaluationSessionId, "index_incognito_users_on_evaluation_session_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.EvaluationSessionCohortId).HasColumnName("evaluation_session_cohort_id");
            entity.Property(e => e.EvaluationSessionId).HasColumnName("evaluation_session_id");
            entity.Property(e => e.Token)
                .HasColumnType("character varying")
                .HasColumnName("token");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.EvaluationSessionCohort).WithMany(p => p.IncognitoUsers)
                .HasForeignKey(d => d.EvaluationSessionCohortId)
                .HasConstraintName("fk_rails_df4d7d9985");

            entity.HasOne(d => d.EvaluationSession).WithMany(p => p.IncognitoUsers)
                .HasForeignKey(d => d.EvaluationSessionId)
                .HasConstraintName("fk_rails_93bbf416eb");
        });

        modelBuilder.Entity<Preference>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("preferences_pkey");

            entity.ToTable("preferences");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Value)
                .HasColumnType("character varying")
                .HasColumnName("value");
        });

        modelBuilder.Entity<SchemaMigration>(entity =>
        {
            entity.HasKey(e => e.Version).HasName("schema_migrations_pkey");

            entity.ToTable("schema_migrations");

            entity.Property(e => e.Version)
                .HasColumnType("character varying")
                .HasColumnName("version");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("teachers_pkey");

            entity.ToTable("teachers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Department)
                .HasColumnType("character varying")
                .HasColumnName("department");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasColumnType("character varying")
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasColumnType("character varying")
                .HasColumnName("last_name");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.Uuid).HasColumnName("uuid");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Uid).HasColumnName("uid");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasColumnType("character varying")
                .HasColumnName("first_name");
            entity.Property(e => e.IsAdmin)
                .HasColumnType("character varying")
                .HasColumnName("is_admin");
            entity.Property(e => e.IsManagement)
                .HasColumnType("character varying")
                .HasColumnName("is_management");
            entity.Property(e => e.IsStudent)
                .HasColumnType("character varying")
                .HasColumnName("is_student");
            entity.Property(e => e.IsTeacher)
                .HasColumnType("character varying")
                .HasColumnName("is_teacher");
            entity.Property(e => e.LastName)
                .HasColumnType("character varying")
                .HasColumnName("last_name");
            entity.Property(e => e.PasswordDigest)
                .HasColumnType("character varying")
                .HasColumnName("password_digest");
            entity.Property(e => e.Status)
                .HasColumnType("character varying")
                .HasColumnName("status");
            entity.Property(e => e.Token)
                .HasColumnType("character varying")
                .HasColumnName("token");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
