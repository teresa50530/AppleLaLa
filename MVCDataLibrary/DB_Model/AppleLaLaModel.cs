namespace MVCDataLibrary.DB_Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AppleLaLaModel : DbContext
    {
        public AppleLaLaModel()
            : base("name=AppleLaLaModel")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Admin_accounts> Admin_accounts { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Banner> Banner { get; set; }
        public virtual DbSet<Coupon> Coupon { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Designer> Designer { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Order_details> Order_details { get; set; }
        public virtual DbSet<Payway> Payway { get; set; }
        public virtual DbSet<Protfolio> Protfolio { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<Service_details> Service_details { get; set; }
        public virtual DbSet<Service_types> Service_types { get; set; }
        public virtual DbSet<Session> Session { get; set; }
        public virtual DbSet<Shop> Shop { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Work_schedule> Work_schedule { get; set; }
        public virtual DbSet<Customer_coupon> Customer_coupon { get; set; }
        public virtual DbSet<Designer_service> Designer_service { get; set; }
        public virtual DbSet<Environment> Environment { get; set; }
        public virtual DbSet<ForLineChart> ForLineChart { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Coupon>()
                .Property(e => e.Discount)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Coupon>()
                .HasMany(e => e.Customer_coupon)
                .WithRequired(e => e.Coupon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Customer_coupon)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Designer>()
                .HasMany(e => e.Designer_service)
                .WithRequired(e => e.Designer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Designer>()
                .HasMany(e => e.Work_schedule)
                .WithRequired(e => e.Designer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Order_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Order_details)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order_details>()
                .Property(e => e.Order_detail_no)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Order_details>()
                .Property(e => e.Order_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Protfolio>()
                .Property(e => e.Year)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Protfolio>()
                .Property(e => e.Month)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Protfolio>()
                .Property(e => e.Color_type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Service>()
                .HasMany(e => e.Service_types)
                .WithRequired(e => e.Service)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Service_details>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Service_details>()
                .Property(e => e.Discount_price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Service_details>()
                .HasMany(e => e.Order_details)
                .WithRequired(e => e.Service_details)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Service_types>()
                .HasMany(e => e.Service_details)
                .WithRequired(e => e.Service_types)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Service_types>()
                .HasMany(e => e.Designer_service)
                .WithOptional(e => e.Service_types)
                .HasForeignKey(e => e.Service_type_id);

            modelBuilder.Entity<Session>()
                .HasMany(e => e.Work_schedule)
                .WithRequired(e => e.Session)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Work_schedule>()
                .Property(e => e.Reference_order_detail)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Work_schedule>()
                .Property(e => e.On_work_flag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ForLineChart>()
                .Property(e => e.OrderDate)
                .IsUnicode(false);

            modelBuilder.Entity<ForLineChart>()
                .Property(e => e.Total)
                .HasPrecision(38, 0);
        }
    }
}
