using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Repository.DBContext.Admin;

public partial class AdminContext : DbContext
{
    public AdminContext()
    {
    }

    public AdminContext(DbContextOptions<AdminContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<AdminUser> AdminUsers { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

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
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .HasColumnName("country");
            entity.Property(e => e.Createdby)
                .HasMaxLength(500)
                .HasDefaultValueSql("'EcommerceSystem'::character varying")
                .HasColumnName("createdby");
            entity.Property(e => e.Createdon)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdon");
            entity.Property(e => e.Customerid).HasColumnName("customerid");
            entity.Property(e => e.Houseno)
                .HasPrecision(15)
                .HasColumnName("houseno");
            entity.Property(e => e.Landmark)
                .HasMaxLength(500)
                .HasColumnName("landmark");
            entity.Property(e => e.Lastupdatedby)
                .HasMaxLength(500)
                .HasDefaultValueSql("'EcommerceSystem'::character varying")
                .HasColumnName("lastupdatedby");
            entity.Property(e => e.Modifiedon)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifiedon");
            entity.Property(e => e.Pincode)
                .HasPrecision(15)
                .HasColumnName("pincode");
            entity.Property(e => e.Streetorarea)
                .HasMaxLength(500)
                .HasColumnName("streetorarea");

            entity.HasOne(d => d.Customer).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.Customerid)
                .HasConstraintName("addresses_customerid_fkey");
        });

        modelBuilder.Entity<AdminUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("AdminUser_pkey");

            entity.ToTable("AdminUser", "admin");

            entity.Property(e => e.UserId).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.Createdby)
                .HasMaxLength(500)
                .HasDefaultValueSql("'EcommerceSystem'::character varying")
                .HasColumnName("createdby");
            entity.Property(e => e.Createdon)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdon");
            entity.Property(e => e.Email).HasMaxLength(300);
            entity.Property(e => e.FirstName).HasColumnType("character varying");
            entity.Property(e => e.LastName).HasColumnType("character varying");
            entity.Property(e => e.Lastupdatedby)
                .HasMaxLength(500)
                .HasDefaultValueSql("'EcommerceSystem'::character varying")
                .HasColumnName("lastupdatedby");
            entity.Property(e => e.Modifiedon)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifiedon");
            entity.Property(e => e.PasswordHash).HasColumnType("character varying");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Customerid).HasName("customer_pkey");

            entity.ToTable("customer", "admin");

            entity.Property(e => e.Customerid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("customerid");
            entity.Property(e => e.Createdby)
                .HasMaxLength(500)
                .HasDefaultValueSql("'EcommerceSystem'::character varying")
                .HasColumnName("createdby");
            entity.Property(e => e.Createdon)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdon");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(255)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(255)
                .HasColumnName("lastname");
            entity.Property(e => e.Lastupdatedby)
                .HasMaxLength(500)
                .HasDefaultValueSql("'EcommerceSystem'::character varying")
                .HasColumnName("lastupdatedby");
            entity.Property(e => e.Modifiedon)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifiedon");
            entity.Property(e => e.Passwordhash)
                .HasMaxLength(255)
                .HasColumnName("passwordhash");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
