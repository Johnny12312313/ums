using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplicationDB.Models
{
    public partial class postgresContext : DbContext
    {
        public postgresContext()
        {
        }

        public postgresContext(DbContextOptions<postgresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Faculty> Faculties { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<StudentByCourse> StudentByCourses { get; set; } = null!;
        public virtual DbSet<TeacherByCourse> TeacherByCourses { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course", "Users");

                entity.HasIndex(e => e.Id, "course_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Credits).HasColumnName("credits");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department", "Users");

                entity.HasIndex(e => e.Id, "department_id_uindex")
                    .IsUnique();

                entity.Property(e => e.FacultyId).HasColumnName("Faculty_Id");

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.FacultyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("department_faculty_id_fk");
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.ToTable("Faculty", "Users");

                entity.HasIndex(e => e.Id, "faculty_id_uindex")
                    .IsUnique();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role", "Users");

                entity.HasIndex(e => e.Id, "\"role\"_\"id\"_uindex")
                    .IsUnique();
            });

            modelBuilder.Entity<StudentByCourse>(entity =>
            {
                entity.ToTable("Student_By_Course", "Users");

                entity.HasIndex(e => e.Id, "student_by_course_id_uindex")
                    .IsUnique();

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StudentByCourses)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("student_by_course_course_id_fk");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.StudentByCourses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("student_by_course_user_id_fk");
            });

            modelBuilder.Entity<TeacherByCourse>(entity =>
            {
                entity.ToTable("Teacher_By_Course", "Users");

                entity.HasIndex(e => e.Id, "teacher_by_course_id_uindex")
                    .IsUnique();

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.TeacherByCourses)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("teacher_by_course_course_id_fk");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TeacherByCourses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("teacher_by_course_user_id_fk");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "Users");

                entity.HasIndex(e => e.Id, "user_id_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "user_username_uindex")
                    .IsUnique();

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("Date of Birth");

                entity.Property(e => e.InsertedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.Username).HasColumnName("username");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_role_id_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
