using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Test.Models;

public partial class BPADatabaseContext : DbContext
{
    public BPADatabaseContext()
    {
    }

    public BPADatabaseContext(DbContextOptions<BPADatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local);uid=sa;pwd=1;database=BPADatabase;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("Account", "BPA");

            entity.Property(e => e.id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.ToTable("Brand", "BPA");

            entity.Property(e => e.id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.ToTable("Feedback", "BPA");

            entity.HasIndex(e => e.customer_id, "IX_Feedback_customer_id");

            entity.HasIndex(e => e.product_id, "IX_Feedback_product_id");

            entity.Property(e => e.id).ValueGeneratedNever();

            entity.HasOne(d => d.customer).WithMany(p => p.Feedbacks).HasForeignKey(d => d.customer_id);

            entity.HasOne(d => d.product).WithMany(p => p.Feedbacks).HasForeignKey(d => d.product_id);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order", "BPA");

            entity.HasIndex(e => e.customer_id, "IX_Order_customer_id");

            entity.Property(e => e.id).ValueGeneratedNever();

            entity.HasOne(d => d.customer).WithMany(p => p.Orders).HasForeignKey(d => d.customer_id);
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.ToTable("OrderDetail", "BPA");

            entity.HasIndex(e => e.order_id, "IX_OrderDetail_order_id");

            entity.HasIndex(e => e.product_id, "IX_OrderDetail_product_id");

            entity.Property(e => e.id).ValueGeneratedNever();

            entity.HasOne(d => d.order).WithMany(p => p.OrderDetails).HasForeignKey(d => d.order_id);

            entity.HasOne(d => d.product).WithMany(p => p.OrderDetails).HasForeignKey(d => d.product_id);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.ToTable("Post", "BPA");

            entity.HasIndex(e => e.staff_id, "IX_Post_staff_id");

            entity.Property(e => e.id).ValueGeneratedNever();

            entity.HasOne(d => d.staff).WithMany(p => p.Posts).HasForeignKey(d => d.staff_id);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product", "BPA");

            entity.HasIndex(e => e.brand_id, "IX_Product_brand_id");

            entity.Property(e => e.id).ValueGeneratedNever();

            entity.HasOne(d => d.brand).WithMany(p => p.Products).HasForeignKey(d => d.brand_id);
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.ToTable("Report", "BPA");

            entity.HasIndex(e => e.customer_id, "IX_Report_customer_id");

            entity.Property(e => e.id).ValueGeneratedNever();

            entity.HasOne(d => d.customer).WithMany(p => p.Reports).HasForeignKey(d => d.customer_id);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
