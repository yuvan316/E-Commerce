using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Repository.DBContext.Admin;

public partial class EcommerceContext : DbContext
{
    public EcommerceContext()
    {
    }

    public EcommerceContext(DbContextOptions<EcommerceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<AdminUser> AdminUsers { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;User Id=postgres;Password=admin;Database=Ecommerce;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pgcrypto");

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Addressid).HasName("addresses_pkey");

            entity.ToTable("addresses", "admin");

            entity.Property(e => e.Addressid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("addressid");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .HasColumnName("city");
            entity.Property(e => e.Customerid).HasColumnName("customerid");
            entity.Property(e => e.Streetaddress)
                .HasMaxLength(255)
                .HasColumnName("streetaddress");

            entity.HasOne(d => d.Customer).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.Customerid)
                .HasConstraintName("addresses_customerid_fkey");
        });

        modelBuilder.Entity<AdminUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("AdminUser_pkey");

            entity.ToTable("AdminUser", "admin");

            entity.Property(e => e.UserId).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.Email).HasMaxLength(300);
            entity.Property(e => e.FirstName).HasColumnType("character varying");
            entity.Property(e => e.LastName).HasColumnType("character varying");
            entity.Property(e => e.PasswordHash).HasColumnType("character varying");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Customerid).HasName("customer_pkey");

            entity.ToTable("customer", "admin");

            entity.Property(e => e.Customerid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("customerid");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(255)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(255)
                .HasColumnName("lastname");
            entity.Property(e => e.Passwordhash)
                .HasMaxLength(255)
                .HasColumnName("passwordhash");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
