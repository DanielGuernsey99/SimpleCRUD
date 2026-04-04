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

    public virtual DbSet<Applications> Applications { get; set; }

    public virtual DbSet<ApplicationRoles> ApplicationRoles { get; set; }

    public virtual DbSet<ApplicationUsers> ApplicationUsers { get; set; }

    public virtual DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }

    public virtual DbSet<Users> Users { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Applications>(entity =>
        {
            entity.HasKey(e => e.ApplicationId).HasName("PK_ApplicationID");

            entity.Property(e => e.ApplicationId).ValueGeneratedNever();
        });

        modelBuilder.Entity<ApplicationRoles>(entity =>
        {
            entity.HasKey(e => e.ApplicationRoleId).HasName("PK_ApplicationRoleID");

            entity.Property(e => e.ApplicationRoleId).ValueGeneratedNever();
        });

        modelBuilder.Entity<ApplicationUsers>(entity =>
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

            entity.HasOne(d => d.ApplicationRole).WithMany(p => p.ApplicationUserRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApplicationRoleID");

            entity.HasOne(d => d.ApplicationUser).WithMany(p => p.ApplicationUserRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApplicationUserID");
        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__3214EC27BB834F9E");

            entity.Property(e => e.UserId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Roles>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3A8C985CAD");

            entity.Property(e => e.RoleId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
