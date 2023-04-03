using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using KPZ_LAB_3.Repository.Models;

#nullable disable

namespace KPZ_LAB_3.Repository
{
    public partial class JewelryStoreDbContext : DbContext
    {
        public JewelryStoreDbContext()
        {
        }

        public JewelryStoreDbContext(DbContextOptions<JewelryStoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerOrder> CustomerOrders { get; set; }
        public virtual DbSet<CustomerOrderStatus> CustomerOrderStatuses { get; set; }
        public virtual DbSet<Delivery> Deliveries { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<PersonDatum> PersonData { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCollection> ProductCollections { get; set; }
        public virtual DbSet<ProductComposition> ProductCompositions { get; set; }
        public virtual DbSet<ProductMaterial> ProductMaterials { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<Saler> Salers { get; set; }
        public virtual DbSet<VCustomerOrderSalerInfoCheck> VCustomerOrderSalerInfoChecks { get; set; }
        public virtual DbSet<VCustomerOrderSalerInfoCheck2> VCustomerOrderSalerInfoCheck2s { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-QAU2I64;Initial Catalog=jewelry_store_vasiutyk_ostap;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Ukrainian_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<CustomerOrder>(entity =>
            {
                entity.ToTable("customer_order");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.CustomerOrderStatusId).HasColumnName("customer_order_status_id");

                entity.Property(e => e.OperationTime)
                    .HasColumnType("datetime")
                    .HasColumnName("operation_time");

                entity.Property(e => e.PaymentTypeId).HasColumnName("payment_type_id");

                entity.Property(e => e.SalerId).HasColumnName("saler_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerOrders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__customer___custo__2A4B4B5E");

                entity.HasOne(d => d.CustomerOrderStatus)
                    .WithMany(p => p.CustomerOrders)
                    .HasForeignKey(d => d.CustomerOrderStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__customer___custo__2C3393D0");

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.CustomerOrders)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__customer___payme__2B3F6F97");

                entity.HasOne(d => d.Saler)
                    .WithMany(p => p.CustomerOrders)
                    .HasForeignKey(d => d.SalerId);
            });

            modelBuilder.Entity<CustomerOrderStatus>(entity =>
            {
                entity.ToTable("customer_order_status");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.ToTable("delivery");

                entity.HasIndex(e => e.CustomerOrderId, "UQ__delivery__1A3F6EA1E7F6605B")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CustomerOrderId).HasColumnName("customer_order_id");

                entity.Property(e => e.DeliveryMethod)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("delivery_method");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("price");

                entity.HasOne(d => d.CustomerOrder)
                    .WithOne(p => p.Delivery)
                    .HasForeignKey<Delivery>(d => d.CustomerOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__delivery__custom__47DBAE45");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.ToTable("manufacturer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("order_details");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CustomerOrderId).HasColumnName("customer_order_id");

                entity.Property(e => e.ProductAmount).HasColumnName("product_amount");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.CustomerOrder)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.CustomerOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__order_det__custo__3F466844");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__order_det__produ__403A8C7D");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.ToTable("payment_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<PersonDatum>(entity =>
            {
                entity.ToTable("person_data");

                entity.HasIndex(e => e.CustomerId, "UQ__person_d__CD65CB848CC34CE3")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("phone_number");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("street");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("surname");

                entity.HasOne(d => d.Customer)
                    .WithOne(p => p.PersonDatum)
                    .HasForeignKey<PersonDatum>(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__person_da__custo__440B1D61");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.ToTable("product");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.ProductCollectionId).HasColumnName("product_collection_id");

                entity.Property(e => e.ProductTypeId).HasColumnName("product_type_id");

                entity.Property(e => e.Weight)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("weight");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__product__manufac__37A5467C");

                entity.HasOne(d => d.ProductCollection)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductCollectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__product__product__38996AB5");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__product__product__36B12243");
            });

            modelBuilder.Entity<ProductCollection>(entity =>
            {
                entity.ToTable("product_collection");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<ProductComposition>(entity =>
            {
                entity.ToTable("product_composition");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProductMaterialId).HasColumnName("product_material_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductCompositions)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__product_c__produ__3B75D760");

                entity.HasOne(d => d.ProductMaterial)
                    .WithMany(p => p.ProductCompositions)
                    .HasForeignKey(d => d.ProductMaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__product_c__produ__3C69FB99");
            });

            modelBuilder.Entity<ProductMaterial>(entity =>
            {
                entity.ToTable("product_material");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.ToTable("product_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Saler>(entity =>
            {
                entity.ToTable("saler");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsManager)
                    .HasColumnName("isManager")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<VCustomerOrderSalerInfoCheck>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vCustomerOrderSalerInfoCheck");

                entity.Property(e => e.CustomerUsername)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("customer_username");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.OperationTime)
                    .HasColumnType("datetime")
                    .HasColumnName("operation_time");

                entity.Property(e => e.Saler)
                    .HasMaxLength(30)
                    .HasColumnName("saler");
            });

            modelBuilder.Entity<VCustomerOrderSalerInfoCheck2>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vCustomerOrderSalerInfoCheck2");

                entity.Property(e => e.CustomerUsername)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("customer_username");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.OperationTime)
                    .HasColumnType("datetime")
                    .HasColumnName("operation_time");

                entity.Property(e => e.Saler)
                    .HasMaxLength(30)
                    .HasColumnName("saler");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
