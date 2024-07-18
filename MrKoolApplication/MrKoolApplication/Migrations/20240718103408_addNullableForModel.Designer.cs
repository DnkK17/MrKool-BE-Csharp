﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MrKool.Data;

#nullable disable

namespace MrKoolApplication.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20240718103408_addNullableForModel")]
    partial class addNullableForModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MrKool.Models.Area", b =>
                {
                    b.Property<int>("AreaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AreaID"));

                    b.Property<string>("AreaAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AreaID");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("MrKool.Models.ConditionerModel", b =>
                {
                    b.Property<int>("ConditionerModelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConditionerModelID"));

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ConditionerModelID");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("MrKool.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AreaID")
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("userID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CustomerID");

                    b.HasIndex("AreaID");

                    b.HasIndex("userID")
                        .IsUnique()
                        .HasFilter("[userID] IS NOT NULL");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("MrKool.Models.FixHistory", b =>
                {
                    b.Property<int>("FixHistoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FixHistoryID"));

                    b.Property<int?>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<int?>("TechnicianID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FixHistoryID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("TechnicianID");

                    b.ToTable("FixHistories");
                });

            modelBuilder.Entity("MrKool.Models.Manager", b =>
                {
                    b.Property<int>("ManagerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ManagerID"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ManagerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WalletID")
                        .HasColumnType("int");

                    b.Property<Guid?>("userID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ManagerID");

                    b.HasIndex("WalletID")
                        .IsUnique()
                        .HasFilter("[WalletID] IS NOT NULL");

                    b.HasIndex("userID")
                        .IsUnique()
                        .HasFilter("[userID] IS NOT NULL");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("MrKool.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CustomerID")
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("TechnicianID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<long?>("TransactionID")
                        .HasColumnType("bigint");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("TechnicianID");

                    b.HasIndex("TransactionID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MrKool.Models.OrderDetail", b =>
                {
                    b.Property<int?>("OrderID")
                        .HasColumnType("int");

                    b.Property<int?>("TechnicianID")
                        .HasColumnType("int");

                    b.Property<int?>("ServiceID")
                        .HasColumnType("int");

                    b.Property<int?>("FixHistoryID")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("OrderID", "TechnicianID", "ServiceID");

                    b.HasIndex("FixHistoryID");

                    b.HasIndex("ServiceID");

                    b.HasIndex("TechnicianID");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("MrKool.Models.Request", b =>
                {
                    b.Property<int>("RequestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequestID"));

                    b.Property<int?>("AreaID")
                        .HasColumnType("int");

                    b.Property<int?>("ConditionerModelID")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerID")
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("ManagerID")
                        .HasColumnType("int");

                    b.Property<string>("RequestAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StationID")
                        .HasColumnType("int");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("TechnicianID")
                        .HasColumnType("int");

                    b.Property<double?>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("RequestID");

                    b.HasIndex("AreaID");

                    b.HasIndex("ConditionerModelID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("ManagerID");

                    b.HasIndex("StationID");

                    b.HasIndex("TechnicianID");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("MrKool.Models.Service", b =>
                {
                    b.Property<int>("ServiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceID"));

                    b.Property<int?>("ConditionalModelID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("RequestID")
                        .HasColumnType("int");

                    b.Property<string>("ServiceTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServiceID");

                    b.HasIndex("ConditionalModelID");

                    b.HasIndex("RequestID");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("MrKool.Models.Station", b =>
                {
                    b.Property<int>("StationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StationID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AreaID")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("ManagerID")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("StationID");

                    b.HasIndex("AreaID");

                    b.HasIndex("ManagerID");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("MrKool.Models.Technician", b =>
                {
                    b.Property<int>("TechnicianID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TechnicianID"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("ManagerID")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StationID")
                        .HasColumnType("int");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("TechnicianName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WalletID")
                        .HasColumnType("int");

                    b.Property<Guid?>("userID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TechnicianID");

                    b.HasIndex("ManagerID");

                    b.HasIndex("StationID");

                    b.HasIndex("WalletID")
                        .IsUnique()
                        .HasFilter("[WalletID] IS NOT NULL");

                    b.HasIndex("userID")
                        .IsUnique()
                        .HasFilter("[userID] IS NOT NULL");

                    b.ToTable("Technicians");
                });

            modelBuilder.Entity("MrKool.Models.Transaction", b =>
                {
                    b.Property<long>("TransactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("TransactionID"));

                    b.Property<long>("Amount")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("WalletID")
                        .HasColumnType("int");

                    b.HasKey("TransactionID");

                    b.HasIndex("WalletID");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("MrKool.Models.Wallet", b =>
                {
                    b.Property<int>("WalletID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WalletID"));

                    b.Property<long>("Balance")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<Guid?>("userID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("WalletID");

                    b.HasIndex("userID");

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("MrKoolApplication.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequestId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("MrKoolApplication.Models.Users", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("HashPassword")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("SaltPassword")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MrKool.Models.Customer", b =>
                {
                    b.HasOne("MrKool.Models.Area", "Area")
                        .WithMany("CustomerList")
                        .HasForeignKey("AreaID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("MrKoolApplication.Models.Users", "user")
                        .WithOne()
                        .HasForeignKey("MrKool.Models.Customer", "userID");

                    b.Navigation("Area");

                    b.Navigation("user");
                });

            modelBuilder.Entity("MrKool.Models.FixHistory", b =>
                {
                    b.HasOne("MrKool.Models.Customer", "Customer")
                        .WithMany("FixHistoryList")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("MrKool.Models.Technician", "Technician")
                        .WithMany("FixHistoryList")
                        .HasForeignKey("TechnicianID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Customer");

                    b.Navigation("Technician");
                });

            modelBuilder.Entity("MrKool.Models.Manager", b =>
                {
                    b.HasOne("MrKool.Models.Wallet", "Wallet")
                        .WithOne()
                        .HasForeignKey("MrKool.Models.Manager", "WalletID");

                    b.HasOne("MrKoolApplication.Models.Users", "user")
                        .WithOne()
                        .HasForeignKey("MrKool.Models.Manager", "userID");

                    b.Navigation("Wallet");

                    b.Navigation("user");
                });

            modelBuilder.Entity("MrKool.Models.Order", b =>
                {
                    b.HasOne("MrKool.Models.Customer", "Customer")
                        .WithMany("OrderList")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("MrKool.Models.Technician", "Technician")
                        .WithMany()
                        .HasForeignKey("TechnicianID");

                    b.HasOne("MrKool.Models.Transaction", "Transaction")
                        .WithMany()
                        .HasForeignKey("TransactionID");

                    b.Navigation("Customer");

                    b.Navigation("Technician");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("MrKool.Models.OrderDetail", b =>
                {
                    b.HasOne("MrKool.Models.FixHistory", "FixHistory")
                        .WithMany("OrderDetailList")
                        .HasForeignKey("FixHistoryID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("MrKool.Models.Order", "Order")
                        .WithMany("OrderDetailList")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MrKool.Models.Service", "Service")
                        .WithMany("OrderDetailList")
                        .HasForeignKey("ServiceID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MrKool.Models.Technician", "Technician")
                        .WithMany("OrderDetailList")
                        .HasForeignKey("TechnicianID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FixHistory");

                    b.Navigation("Order");

                    b.Navigation("Service");

                    b.Navigation("Technician");
                });

            modelBuilder.Entity("MrKool.Models.Request", b =>
                {
                    b.HasOne("MrKool.Models.Area", "Area")
                        .WithMany("RequestList")
                        .HasForeignKey("AreaID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("MrKool.Models.ConditionerModel", "Model")
                        .WithMany("RequestList")
                        .HasForeignKey("ConditionerModelID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("MrKool.Models.Customer", "Customer")
                        .WithMany("RequestList")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("MrKool.Models.Manager", "Manager")
                        .WithMany("RequestList")
                        .HasForeignKey("ManagerID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("MrKool.Models.Station", "Station")
                        .WithMany("RequestList")
                        .HasForeignKey("StationID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("MrKool.Models.Technician", "Technician")
                        .WithMany("RequestList")
                        .HasForeignKey("TechnicianID");

                    b.Navigation("Area");

                    b.Navigation("Customer");

                    b.Navigation("Manager");

                    b.Navigation("Model");

                    b.Navigation("Station");

                    b.Navigation("Technician");
                });

            modelBuilder.Entity("MrKool.Models.Service", b =>
                {
                    b.HasOne("MrKool.Models.ConditionerModel", "Model")
                        .WithMany("Services")
                        .HasForeignKey("ConditionalModelID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("MrKool.Models.Request", "Request")
                        .WithMany("Services")
                        .HasForeignKey("RequestID");

                    b.Navigation("Model");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("MrKool.Models.Station", b =>
                {
                    b.HasOne("MrKool.Models.Area", "Area")
                        .WithMany("StationList")
                        .HasForeignKey("AreaID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("MrKool.Models.Manager", "Manager")
                        .WithMany("StationList")
                        .HasForeignKey("ManagerID");

                    b.Navigation("Area");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("MrKool.Models.Technician", b =>
                {
                    b.HasOne("MrKool.Models.Manager", "Manager")
                        .WithMany("TechnicianList")
                        .HasForeignKey("ManagerID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("MrKool.Models.Station", "Station")
                        .WithMany("TechnicianList")
                        .HasForeignKey("StationID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("MrKool.Models.Wallet", "Wallet")
                        .WithOne()
                        .HasForeignKey("MrKool.Models.Technician", "WalletID");

                    b.HasOne("MrKoolApplication.Models.Users", "user")
                        .WithOne()
                        .HasForeignKey("MrKool.Models.Technician", "userID");

                    b.Navigation("Manager");

                    b.Navigation("Station");

                    b.Navigation("Wallet");

                    b.Navigation("user");
                });

            modelBuilder.Entity("MrKool.Models.Transaction", b =>
                {
                    b.HasOne("MrKool.Models.Wallet", "Wallet")
                        .WithMany("TransactionList")
                        .HasForeignKey("WalletID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("MrKool.Models.Wallet", b =>
                {
                    b.HasOne("MrKoolApplication.Models.Users", "User")
                        .WithMany()
                        .HasForeignKey("userID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MrKoolApplication.Models.Payment", b =>
                {
                    b.HasOne("MrKool.Models.Request", "Request")
                        .WithMany()
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Request");
                });

            modelBuilder.Entity("MrKool.Models.Area", b =>
                {
                    b.Navigation("CustomerList");

                    b.Navigation("RequestList");

                    b.Navigation("StationList");
                });

            modelBuilder.Entity("MrKool.Models.ConditionerModel", b =>
                {
                    b.Navigation("RequestList");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("MrKool.Models.Customer", b =>
                {
                    b.Navigation("FixHistoryList");

                    b.Navigation("OrderList");

                    b.Navigation("RequestList");
                });

            modelBuilder.Entity("MrKool.Models.FixHistory", b =>
                {
                    b.Navigation("OrderDetailList");
                });

            modelBuilder.Entity("MrKool.Models.Manager", b =>
                {
                    b.Navigation("RequestList");

                    b.Navigation("StationList");

                    b.Navigation("TechnicianList");
                });

            modelBuilder.Entity("MrKool.Models.Order", b =>
                {
                    b.Navigation("OrderDetailList");
                });

            modelBuilder.Entity("MrKool.Models.Request", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("MrKool.Models.Service", b =>
                {
                    b.Navigation("OrderDetailList");
                });

            modelBuilder.Entity("MrKool.Models.Station", b =>
                {
                    b.Navigation("RequestList");

                    b.Navigation("TechnicianList");
                });

            modelBuilder.Entity("MrKool.Models.Technician", b =>
                {
                    b.Navigation("FixHistoryList");

                    b.Navigation("OrderDetailList");

                    b.Navigation("RequestList");
                });

            modelBuilder.Entity("MrKool.Models.Wallet", b =>
                {
                    b.Navigation("TransactionList");
                });
#pragma warning restore 612, 618
        }
    }
}
