using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Repository.DBContext.Core;

public partial class CoreContext : DbContext
{
    public CoreContext()
    {
    }

    public CoreContext(DbContextOptions<CoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Orderitem> Orderitems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Shipping> Shippings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pgcrypto");

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Brandid).HasName("brands_pkey");

            entity.ToTable("brands", "core");

            entity.Property(e => e.Brandid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("brandid");
            entity.Property(e => e.Brandname)
                .HasMaxLength(255)
                .HasColumnName("brandname");
            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Createdby)
                .HasMaxLength(500)
                .HasDefaultValueSql("'EcommerceSystem'::character varying")
                .HasColumnName("createdby");
            entity.Property(e => e.Createdon)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdon");
            entity.Property(e => e.Lastupdatedby)
                .HasMaxLength(500)
                .HasDefaultValueSql("'EcommerceSystem'::character varying")
                .HasColumnName("lastupdatedby");
            entity.Property(e => e.Modifiedon)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifiedon");

            entity.HasOne(d => d.Category).WithMany(p => p.Brands)
                .HasForeignKey(d => d.Categoryid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("brands_categoryid_fkey");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Cartid).HasName("cart_pkey");

            entity.ToTable("cart", "core");

            entity.Property(e => e.Cartid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("cartid");
            entity.Property(e => e.Createdby)
                .HasMaxLength(500)
                .HasDefaultValueSql("'EcommerceSystem'::character varying")
                .HasColumnName("createdby");
            entity.Property(e => e.Createdon)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdon");
            entity.Property(e => e.Customerid).HasColumnName("customerid");
            entity.Property(e => e.Lastupdatedby)
                .HasMaxLength(500)
                .HasDefaultValueSql("'EcommerceSystem'::character varying")
                .HasColumnName("lastupdatedby");
            entity.Property(e => e.Modifiedon)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifiedon");
            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                .HasForeignKey(d => d.Productid)
                .HasConstraintName("cart_productid_fkey");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Categoryid).HasName("categories_pkey");

            entity.ToTable("categories", "core");

            entity.Property(e => e.Categoryid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("categoryid");
            entity.Property(e => e.Categoryname)
                .HasMaxLength(255)
                .HasColumnName("categoryname");
            entity.Property(e => e.Createdby)
                .HasMaxLength(500)
                .HasDefaultValueSql("'EcommerceSystem'::character varying")
                .HasColumnName("createdby");
            entity.Property(e => e.Createdon)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdon");
            entity.Property(e => e.Lastupdatedby)
                .HasMaxLength(500)
                .HasDefaultValueSql("'EcommerceSystem'::character varying")
                .HasColumnName("lastupdatedby");
            entity.Property(e => e.Modifiedon)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifiedon");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.Imageid).HasName("images_pkey");

            entity.ToTable("images", "core");

            entity.Property(e => e.Imageid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("imageid");
            entity.Property(e => e.Createdby)
                .HasMaxLength(500)
                .HasDefaultValueSql("'EcommerceSystem'::character varying")
                .HasColumnName("createdby");
            entity.Property(e => e.Createdon)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdon");
            entity.Property(e => e.Entityid).HasColumnName("entityid");
            entity.Property(e => e.Entitytype)
                .HasMaxLength(255)
                .HasColumnName("entitytype");
            entity.Property(e => e.Filename)
                .HasMaxLength(255)
                .HasColumnName("filename");
            entity.Property(e => e.Filesize).HasColumnName("filesize");
            entity.Property(e => e.Imagedata).HasColumnName("imagedata");
            entity.Property(e => e.Lastupdatedby)
                .HasMaxLength(500)
                .HasDefaultValueSql("'EcommerceSystem'::character varying")
                .HasColumnName("lastupdatedby");
            entity.Property(e => e.Modifiedon)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifiedon");
            entity.Property(e => e.Uploaddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("uploaddate");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Orderid).HasName("orders_pkey");

            entity.ToTable("orders", "core");

            entity.Property(e => e.Orderid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("orderid");
            entity.Property(e => e.Createdby)
                .HasMaxLength(500)
                .HasDefaultValueSql("'EcommerceSystem'::character varying")
                .HasColumnName("createdby");
            entity.Property(e => e.Createdon)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdon");
            entity.Property(e => e.Customerid).HasColumnName("customerid");
            entity.Property(e => e.Lastupdatedby)
                .HasMaxLength(500)
                .HasDefaultValueSql("'EcommerceSystem'::character varying")
                .HasColumnName("lastupdatedby");
            entity.Property(e => e.Modifiedon)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifiedon");
            entity.Property(e => e.Orderdate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("orderdate");
        });

        modelBuilder.Entity<Orderitem>(entity =>
        {
            entity.HasKey(e => e.Orderitemid).HasName("orderitems_pkey");

            entity.ToTable("orderitems", "core");

            entity.Property(e => e.Orderitemid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("orderitemid");
            entity.Property(e => e.Createdby)
                .HasMaxLength(500)
                .HasDefaultValueSql("'EcommerceSystem'::character varying")
                .HasColumnName("createdby");
            entity.Property(e => e.Createdon)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdon");
            entity.Property(e => e.Lastupdatedby)
                .HasMaxLength(500)
                .HasDefaultValueSql("'EcommerceSystem'::character varying")
                .HasColumnName("lastupdatedby");
            entity.Property(e => e.Modifiedon)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifiedon");
            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Order).WithMany(p => p.Orderitems)
                .HasForeignKey(d => d.Orderid)
                .HasConstraintName("orderitems_orderid_fkey");

            entity.HasOne(d => d.Product).WithMany(p => p.Orderitems)
                .HasForeignKey(d => d.Productid)
                .HasConstraintName("orderitems_productid_fkey");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Productid).HasName("products_pkey");

            entity.ToTable("products", "core");

            entity.Property(e => e.Productid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("productid");
            entity.Property(e => e.Brandid).HasColumnName("brandid");
            entity.Property(e => e.Createdby)
                .HasMaxLength(500)
                .HasDefaultValueSql("'EcommerceSystem'::character varying")
                .HasColumnName("createdby");
            entity.Property(e => e.Createdon)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdon");
            entity.Property(e => e.Lastupdatedby)
                .HasMaxLength(500)
                .HasDefaultValueSql("'EcommerceSystem'::character varying")
                .HasColumnName("lastupdatedby");
            entity.Property(e => e.Modifiedon)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifiedon");
            entity.Property(e => e.Price)
                .HasPrecision(18, 2)
                .HasColumnName("price");
            entity.Property(e => e.Productname)
                .HasMaxLength(255)
                .HasColumnName("productname");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.Brandid)
                .HasConstraintName("brandid_productid_fkey");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Reviewid).HasName("reviews_pkey");

            entity.ToTable("reviews", "core");

            entity.Property(e => e.Reviewid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("reviewid");
            entity.Property(e => e.Createdby)
                .HasMaxLength(500)
                .HasDefaultValueSql("'EcommerceSystem'::character varying")
                .HasColumnName("createdby");
            entity.Property(e => e.Createdon)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdon");
            entity.Property(e => e.Customerid).HasColumnName("customerid");
            entity.Property(e => e.Lastupdatedby)
                .HasMaxLength(500)
                .HasDefaultValueSql("'EcommerceSystem'::character varying")
                .HasColumnName("lastupdatedby");
            entity.Property(e => e.Modifiedon)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifiedon");
            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Reviewtext).HasColumnName("reviewtext");

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.Productid)
                .HasConstraintName("reviews_productid_fkey");
        });

        modelBuilder.Entity<Shipping>(entity =>
        {
            entity.HasKey(e => e.Shippingid).HasName("shipping_pkey");

            entity.ToTable("shipping", "core");

            entity.Property(e => e.Shippingid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("shippingid");
            entity.Property(e => e.Createdby)
                .HasMaxLength(500)
                .HasDefaultValueSql("'EcommerceSystem'::character varying")
                .HasColumnName("createdby");
            entity.Property(e => e.Createdon)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdon");
            entity.Property(e => e.Lastupdatedby)
                .HasMaxLength(500)
                .HasDefaultValueSql("'EcommerceSystem'::character varying")
                .HasColumnName("lastupdatedby");
            entity.Property(e => e.Modifiedon)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifiedon");
            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Shippingaddress)
                .HasMaxLength(255)
                .HasColumnName("shippingaddress");
            entity.Property(e => e.Shippingdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("shippingdate");

            entity.HasOne(d => d.Order).WithMany(p => p.Shippings)
                .HasForeignKey(d => d.Orderid)
                .HasConstraintName("shipping_orderid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
