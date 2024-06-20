using Microsoft.EntityFrameworkCore;
using MrKool.Models;
using MrKoolApplication.Models;
using System.Data;
using System.Reflection.Metadata;

namespace MrKool.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<FixHistory> FixHistories { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<ConditionerModel> Models { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Users> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure primary keys, foreign keys, relationships, indexes, etc.

            // Wallet entity
            modelBuilder.Entity<Wallet>()
                .HasKey(w => w.WalletID);

            // Transaction entity
            modelBuilder.Entity<Transaction>()
                .HasKey(t => t.TransactionID);

            // Users entity
            modelBuilder.Entity<Users>()
                .HasKey(u => u.Id);

            // Service entity
            modelBuilder.Entity<Service>()
                .HasKey(s => s.ServiceID);

            // Technician entity
            modelBuilder.Entity<Technician>()
                .HasKey(t => t.TechnicianID);

            // Station entity
            modelBuilder.Entity<Station>()
                .HasKey(s => s.StationID);

            // OrderDetail entity
            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new { od.OrderID, od.TechnicianID, od.ServiceID });

            // Define relationships

            // Technician - Users (one-to-one)
            modelBuilder.Entity<Technician>()
                .HasOne(t => t.user)
                .WithOne()
                .HasForeignKey<Technician>(t => t.userID);

            // Technician - Manager (many-to-one)
            modelBuilder.Entity<Technician>()
                .HasOne(t => t.Manager)
                .WithMany(m => m.TechnicianList)
                .HasForeignKey(t => t.ManagerID)
                .OnDelete(DeleteBehavior.NoAction); // or Cascade based on your needs

            // Technician - Station (many-to-one)
            modelBuilder.Entity<Technician>()
                .HasOne(t => t.Station)
                .WithMany(s => s.TechnicianList)
                .HasForeignKey(t => t.StationID)
                .OnDelete(DeleteBehavior.NoAction); // or Cascade based on your needs

            // Wallet - Technician (one-to-one)
            modelBuilder.Entity<Technician>()
                .HasOne(t => t.Wallet)
                .WithOne()
                .HasForeignKey<Technician>(t => t.WalletID);

            // Manager - Users (one-to-one)
            modelBuilder.Entity<Manager>()
                .HasOne(m => m.user)
                .WithOne()
                .HasForeignKey<Manager>(m => m.userID);

            // Manager - Wallet (one-to-one)
            modelBuilder.Entity<Manager>()
                .HasOne(m => m.Wallet)
                .WithOne()
                .HasForeignKey<Manager>(m => m.WalletID);

            // Station - Area (many-to-one)
            modelBuilder.Entity<Station>()
                .HasOne(s => s.Area)
                .WithMany(a => a.StationList)
                .HasForeignKey(s => s.AreaID)
                .OnDelete(DeleteBehavior.NoAction); // or Cascade based on your needs

            // Order - Customer (many-to-one)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.OrderList)
                .HasForeignKey(o => o.CustomerID)
                .OnDelete(DeleteBehavior.NoAction); // or Cascade based on your needs

            // OrderDetail - Order (many-to-one)
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetailList)
                .HasForeignKey(od => od.OrderID)
                .OnDelete(DeleteBehavior.NoAction); // Example: Cascade delete

            // Service - OrderDetail (many-to-one)
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Service)
                .WithMany(s => s.OrderDetailList)
                .HasForeignKey(od => od.ServiceID)
                .OnDelete(DeleteBehavior.NoAction); // or Cascade based on your needs

            // FixHistory - Technician (many-to-one)
            modelBuilder.Entity<FixHistory>()
                .HasOne(fh => fh.Technician)
                .WithMany(t => t.FixHistoryList)
                .HasForeignKey(fh => fh.TechnicianID)
                .OnDelete(DeleteBehavior.NoAction); // or Cascade based on your needs

            // FixHistory - Customer (many-to-one)
            modelBuilder.Entity<FixHistory>()
                .HasOne(fh => fh.Customer)
                .WithMany(c => c.FixHistoryList)
                .HasForeignKey(fh => fh.CustomerID)
                .OnDelete(DeleteBehavior.NoAction); // or Cascade based on your needs


            // Customer - Users (one-to-one)
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.user)
                .WithOne()
                .HasForeignKey<Customer>(c => c.userID);

            // Customer - Area (many-to-one)
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Area)
                .WithMany(a => a.CustomerList)
                .HasForeignKey(c => c.AreaID)
                .OnDelete(DeleteBehavior.NoAction); // or Cascade based on your needs

            // Area - Station (one-to-many)
            modelBuilder.Entity<Station>()
                .HasOne(s => s.Area)
                .WithMany(a => a.StationList)
                .HasForeignKey(s => s.AreaID)
                .OnDelete(DeleteBehavior.NoAction); // or Cascade based on your needs

            // Request - Area (many-to-one)
            modelBuilder.Entity<Request>()
                .HasOne(r => r.Area)
                .WithMany(a => a.RequestList)
                .HasForeignKey(r => r.AreaID)
                .OnDelete(DeleteBehavior.NoAction); // or Cascade based on your needs

            // Request - Customer (many-to-one)
            modelBuilder.Entity<Request>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.RequestList)
                .HasForeignKey(r => r.CustomerID)
                .OnDelete(DeleteBehavior.NoAction); // or Cascade based on your needs

            // Request - Station (many-to-one)
            modelBuilder.Entity<Request>()
                .HasOne(r => r.Station)
                .WithMany(s => s.RequestList)
                .HasForeignKey(r => r.StationID)
                .OnDelete(DeleteBehavior.NoAction); // or Cascade based on your needs

            // Request - Manager (many-to-one)
            modelBuilder.Entity<Request>()
                .HasOne(r => r.Manager)
                .WithMany(m => m.RequestList)
                .HasForeignKey(r => r.ManagerID)
                .OnDelete(DeleteBehavior.NoAction); // or Cascade based on your needs

            // Order - Request (one-to-one)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Request)           // Order entity has one Request
                .WithOne(r => r.Order)            // Request entity has one Order
                .HasForeignKey<Request>(r => r.OrderID) // Foreign key on Request pointing to OrderID
                .IsRequired()                     // Request must have a corresponding Order
                .OnDelete(DeleteBehavior.NoAction); // Cascade delete if needed


            // ConditionerModel - Service (one-to-many)
            modelBuilder.Entity<ConditionerModel>()
                .HasMany(cm => cm.ServiceList)
                .WithOne(s => s.Model)
                .HasForeignKey(s => s.ModelID)
                .OnDelete(DeleteBehavior.NoAction); // or Cascade based on your needs

            // Area - Customer (one-to-many)
            modelBuilder.Entity<Area>()
                .HasMany(a => a.CustomerList)
                .WithOne(c => c.Area)
                .HasForeignKey(c => c.AreaID)
                .OnDelete(DeleteBehavior.NoAction); // or Cascade based on your needs

            // Additional configurations as needed

        }
    }
}
