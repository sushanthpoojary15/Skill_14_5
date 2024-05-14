using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CollaboSphere.DataAccess.Entities;

public partial class CollaboSphereContext : DbContext
{
    public CollaboSphereContext()
    {
    }

    public CollaboSphereContext(DbContextOptions<CollaboSphereContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Xyz> Xyzs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=CollaboSphere;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.DocumentId).HasName("PK__Document__1ABEEF6FED1D15AB");

            entity.ToTable("Document");

            entity.Property(e => e.DocumentId).HasColumnName("DocumentID");
            entity.Property(e => e.DocumentName).HasMaxLength(100);
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.UploadDate).HasColumnType("datetime");
            entity.Property(e => e.UploadedByUserId).HasColumnName("UploadedByUserID");

            entity.HasOne(d => d.Project).WithMany(p => p.Documents)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__Document__Projec__440B1D61");

            entity.HasOne(d => d.UploadedByUser).WithMany(p => p.Documents)
                .HasForeignKey(d => d.UploadedByUserId)
                .HasConstraintName("FK__Document__Upload__4316F928");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK__Project__761ABED0CDD7BC6D");

            entity.ToTable("Project");

            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.ProjectDescription).HasMaxLength(255);
            entity.Property(e => e.ProjectManagerId).HasColumnName("ProjectManagerID");
            entity.Property(e => e.ProjectName).HasMaxLength(100);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.ProjectManager).WithMany(p => p.Projects)
                .HasForeignKey(d => d.ProjectManagerId)
                .HasConstraintName("FK__Project__Project__3C69FB99");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE3A0D32802F");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleDescription).HasMaxLength(255);
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__Task__7C6949D1910F0BF6");

            entity.ToTable("Task");

            entity.Property(e => e.TaskId).HasColumnName("TaskID");
            entity.Property(e => e.AssignedToUserId).HasColumnName("AssignedToUserID");
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TaskDescription).HasMaxLength(255);
            entity.Property(e => e.TaskName).HasMaxLength(100);

            entity.HasOne(d => d.AssignedToUser).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.AssignedToUserId)
                .HasConstraintName("FK__Task__AssignedTo__3F466844");

            entity.HasOne(d => d.Project).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__Task__ProjectID__403A8C7D");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CCACCCC6D7CF");

            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__User__RoleID__398D8EEE");
        });

        modelBuilder.Entity<Xyz>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__XYZ__3214EC278DF73C39");

            entity.ToTable("XYZ");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Column1)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Column2)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
