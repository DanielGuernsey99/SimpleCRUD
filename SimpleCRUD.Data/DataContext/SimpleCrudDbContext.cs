using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SimpleCRUD.Data.Entities;

namespace SimpleCRUD.Data.DataContext;

public partial class SimpleCrudDbContext : DbContext
{
    public SimpleCrudDbContext(DbContextOptions<SimpleCrudDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<ApplicationRole> ApplicationRoles { get; set; }

    public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }

    public virtual DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.ApplicationId).HasName("PK_ApplicationID");

            entity.Property(e => e.ApplicationId).ValueGeneratedNever();
        });

        modelBuilder.Entity<ApplicationRole>(entity =>
        {
            entity.HasKey(e => e.ApplicationRoleId).HasName("PK_ApplicationRoleID");

            entity.Property(e => e.ApplicationRoleId).ValueGeneratedNever();
        });

        modelBuilder.Entity<ApplicationUser>(entity =>
        {
            entity.HasKey(e => e.ApplicationUserId).HasName("PK_ApplicationUserID");

            entity.Property(e => e.ApplicationUserId).ValueGeneratedNever();

            entity.HasOne(d => d.User).WithMany(p => p.ApplicationUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserID");
        });

        modelBuilder.Entity<ApplicationUserRole>(entity =>
        {
            entity.HasKey(e => e.ApplicationUserRolesId).HasName("PK_ApplicationUserRolesID");

            entity.Property(e => e.ApplicationUserRolesId).ValueGeneratedNever();

            entity.HasOne(d => d.Application).WithMany(p => p.ApplicationUserRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApplicationID");

            entity.HasOne(d => d.ApplicationRole).WithMany(p => p.ApplicationUserRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApplicationRoleID");

            entity.HasOne(d => d.ApplicationUser).WithMany(p => p.ApplicationUserRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApplicationUserID");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__3214EC27BB834F9E");

            entity.Property(e => e.UserId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3A8C985CAD");

            entity.Property(e => e.RoleId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
