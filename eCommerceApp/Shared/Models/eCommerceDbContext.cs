using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eCommerceApp.Shared.Models
{
    public partial class eCommerceDbContext : DbContext
    {
        public eCommerceDbContext()
        {
        }

        public eCommerceDbContext(DbContextOptions<eCommerceDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-JMTK4HT\\SQLEXPRESS;Initial Catalog=eCommerceDb;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.Property(e => e.NameProduct)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.OrderNumber)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderNumber)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.ProductCode).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
