using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Server_Example.Models;

public partial class TamiDBContext : DbContext
{
    public TamiDBContext()
    {
    }

    public TamiDBContext(DbContextOptions<TamiDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Classroom> Classrooms { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<SubjectClassroomAssignment> SubjectClassroomAssignments { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB;Initial Catalog=MyAppName_DB;User ID=TaskAdminLogin;Password=kukuPassword;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Classroom>(entity =>
        {
            entity.HasKey(e => e.ClassroomId).HasName("PK__Classroo__11618EAA8D7CC63A");

            entity.Property(e => e.ClassroomId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentId).HasName("PK__Enrollme__7F68771BED25704A");

            entity.Property(e => e.EnrollmentId).ValueGeneratedNever();

            entity.HasOne(d => d.Student).WithMany(p => p.Enrollments).HasConstraintName("FK__Enrollmen__Stude__2D27B809");

            entity.HasOne(d => d.Subject).WithMany(p => p.Enrollments).HasConstraintName("FK__Enrollmen__Subje__2E1BDC42");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__32C52B99E6E11617");

            entity.Property(e => e.StudentId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__Subjects__AC1BA3A87D2946F5");

            entity.Property(e => e.SubjectId).ValueGeneratedNever();

            entity.HasOne(d => d.Teacher).WithMany(p => p.Subjects).HasConstraintName("FK__Subjects__Teache__286302EC");
        });

        modelBuilder.Entity<SubjectClassroomAssignment>(entity =>
        {
            entity.HasKey(e => e.AssignmentId).HasName("PK__SubjectC__32499E7766E3C9E7");

            entity.Property(e => e.AssignmentId).ValueGeneratedNever();

            entity.HasOne(d => d.Classroom).WithMany(p => p.SubjectClassroomAssignments).HasConstraintName("FK__SubjectCl__Class__31EC6D26");

            entity.HasOne(d => d.Subject).WithMany(p => p.SubjectClassroomAssignments).HasConstraintName("FK__SubjectCl__Subje__30F848ED");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__Teachers__EDF259644C8E80F8");

            entity.Property(e => e.TeacherId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
