using Microsoft.EntityFrameworkCore;
using MrKool.Models;
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

 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>()
                .HasKey(pc => new { pc.OrderID, pc.ServiceID, pc.TechnicianID });

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Service)
                .WithMany(s => s.OrderDetailList)
                .HasForeignKey(od => od.ServiceID);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Technician)
                .WithMany(t => t.OrderDetailList)
                .HasForeignKey(od => od.TechnicianID);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(c => c.OrderDetailList)
                .HasForeignKey(od => od.OrderID);

            modelBuilder.Entity<FixHistory>()
               .HasKey(pc => new { pc.CustomerID, pc.TechnicianID });

            modelBuilder.Entity<FixHistory>()
                .HasOne(od => od.Customer)
                .WithMany(s => s.FixHistoryList)
                .HasForeignKey(od => od.CustomerID);

            modelBuilder.Entity<FixHistory>()
                .HasOne(od => od.Technician)
                .WithMany(t => t.FixHistoryList)
                .HasForeignKey(od => od.TechnicianID);

            modelBuilder.Entity<Area>()
           .HasMany(a => a.StationList)
           .WithOne(s => s.Area)
           .HasForeignKey(s => s.StationID);
        }
    }
}
