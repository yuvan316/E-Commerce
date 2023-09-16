using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ecommerce_Repository.DBContext.Admin
{
    public partial class AdminContext : DbContext
    {
        public AdminContext()
        {
        }

        public AdminContext(DbContextOptions<AdminContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<AdminAuditLog> AdminAuditLogs { get; set; } = null!;
        public virtual DbSet<AdminRole> AdminRoles { get; set; } = null!;
        public virtual DbSet<AdminUser> AdminUsers { get; set; } = null!;
        public virtual DbSet<AdminUserRole> AdminUserRoles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Addresses", "admin");

                entity.Property(e => e.AddressId)
                    .ValueGeneratedNever()
                    .HasColumnName("AddressID");

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.PostalCode).HasMaxLength(20);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.StreetAddress).HasMaxLength(255);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Addresses__UserI__60A75C0F");
            });

            modelBuilder.Entity<AdminAuditLog>(entity =>
            {
                entity.HasKey(e => e.AuditLogId)
                    .HasName("PK__AdminAud__EB5F6CDD8CEC3ED5");

                entity.ToTable("AdminAuditLog", "admin");

                entity.Property(e => e.AuditLogId)
                    .ValueGeneratedNever()
                    .HasColumnName("AuditLogID");

                entity.Property(e => e.Action).HasMaxLength(255);

                entity.Property(e => e.AdminUserId).HasColumnName("AdminUserID");

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.HasOne(d => d.AdminUser)
                    .WithMany(p => p.AdminAuditLogs)
                    .HasForeignKey(d => d.AdminUserId)
                    .HasConstraintName("FK__AdminAudi__Admin__5AEE82B9");
            });

            modelBuilder.Entity<AdminRole>(entity =>
            {
                entity.ToTable("AdminRoles", "admin");

                entity.Property(e => e.AdminRoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("AdminRoleID");

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<AdminUser>(entity =>
            {
                entity.ToTable("AdminUsers", "admin");

                entity.HasIndex(e => e.Email, "UQ__AdminUse__A9D105349F3CFAC9")
                    .IsUnique();

                entity.Property(e => e.AdminUserId)
                    .ValueGeneratedNever()
                    .HasColumnName("AdminUserID");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PasswordHash).HasMaxLength(255);
            });

            modelBuilder.Entity<AdminUserRole>(entity =>
            {
                entity.ToTable("AdminUserRoles", "admin");

                entity.Property(e => e.AdminUserRoleId).ValueGeneratedNever();

                entity.Property(e => e.AdminRoleId).HasColumnName("AdminRoleID");

                entity.Property(e => e.AdminUserId).HasColumnName("AdminUserID");

                entity.HasOne(d => d.AdminRole)
                    .WithMany(p => p.AdminUserRoles)
                    .HasForeignKey(d => d.AdminRoleId)
                    .HasConstraintName("FK__AdminUser__Admin__5812160E");

                entity.HasOne(d => d.AdminUser)
                    .WithMany(p => p.AdminUserRoles)
                    .HasForeignKey(d => d.AdminUserId)
                    .HasConstraintName("FK__AdminUser__Admin__571DF1D5");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users", "admin");

                entity.HasIndex(e => e.Email, "UQ__Users__A9D105348C60E8FD")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserID");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PasswordHash).HasMaxLength(255);

                entity.Property(e => e.Role).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
