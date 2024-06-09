using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MrKoolApplication.Migrations
{
    /// <inheritdoc />
    public partial class fixNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Areas_AreaID",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_User_userId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_FixHistories_Services_ServiceID",
                table: "FixHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Managers_User_userId",
                table: "Managers");

            migrationBuilder.DropForeignKey(
                name: "FK_Managers_Wallets_WalletID",
                table: "Managers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Transactions_TransactionID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Models_ModelConditionerModelID",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Requests_RequestOrderID_RequestAreaID_RequestCustomerID_RequestTechnicianID_RequestStationID_RequestManagerID",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Stations_Managers_ManagerID",
                table: "Stations");

            migrationBuilder.DropForeignKey(
                name: "FK_Technicians_Managers_ManagerID",
                table: "Technicians");

            migrationBuilder.DropForeignKey(
                name: "FK_Technicians_Stations_StationID",
                table: "Technicians");

            migrationBuilder.DropForeignKey(
                name: "FK_Technicians_User_userId",
                table: "Technicians");

            migrationBuilder.DropForeignKey(
                name: "FK_Technicians_Wallets_WalletID",
                table: "Technicians");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Wallets_WalletID",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Technicians",
                newName: "userID");

            migrationBuilder.RenameIndex(
                name: "IX_Technicians_userId",
                table: "Technicians",
                newName: "IX_Technicians_userID");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Managers",
                newName: "userID");

            migrationBuilder.RenameIndex(
                name: "IX_Managers_userId",
                table: "Managers",
                newName: "IX_Managers_userID");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Customers",
                newName: "userID");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_userId",
                table: "Customers",
                newName: "IX_Customers_userID");

            migrationBuilder.AlterColumn<long>(
                name: "WalletID",
                table: "Transactions",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Transactions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<long>(
                name: "WalletID",
                table: "Technicians",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Technicians",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "StationID",
                table: "Technicians",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerID",
                table: "Technicians",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Technicians",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Technicians",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerID",
                table: "Stations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RequestTechnicianID",
                table: "Services",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RequestStationID",
                table: "Services",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RequestOrderID",
                table: "Services",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RequestManagerID",
                table: "Services",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RequestCustomerID",
                table: "Services",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RequestAreaID",
                table: "Services",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ModelConditionerModelID",
                table: "Services",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Services",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Requests",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<long>(
                name: "TransactionID",
                table: "Orders",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerID",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "OrderDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Models",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<long>(
                name: "WalletID",
                table: "Managers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Managers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Managers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Managers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceID",
                table: "FixHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "FixHistories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "AreaID",
                table: "Customers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Areas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HashPassword = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    SaltPassword = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Areas_AreaID",
                table: "Customers",
                column: "AreaID",
                principalTable: "Areas",
                principalColumn: "AreaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_userID",
                table: "Customers",
                column: "userID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FixHistories_Services_ServiceID",
                table: "FixHistories",
                column: "ServiceID",
                principalTable: "Services",
                principalColumn: "ServiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_Users_userID",
                table: "Managers",
                column: "userID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_Wallets_WalletID",
                table: "Managers",
                column: "WalletID",
                principalTable: "Wallets",
                principalColumn: "WalletID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Transactions_TransactionID",
                table: "Orders",
                column: "TransactionID",
                principalTable: "Transactions",
                principalColumn: "TransactionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Models_ModelConditionerModelID",
                table: "Services",
                column: "ModelConditionerModelID",
                principalTable: "Models",
                principalColumn: "ConditionerModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Requests_RequestOrderID_RequestAreaID_RequestCustomerID_RequestTechnicianID_RequestStationID_RequestManagerID",
                table: "Services",
                columns: new[] { "RequestOrderID", "RequestAreaID", "RequestCustomerID", "RequestTechnicianID", "RequestStationID", "RequestManagerID" },
                principalTable: "Requests",
                principalColumns: new[] { "OrderID", "AreaID", "CustomerID", "TechnicianID", "StationID", "ManagerID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Stations_Managers_ManagerID",
                table: "Stations",
                column: "ManagerID",
                principalTable: "Managers",
                principalColumn: "ManagerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Technicians_Managers_ManagerID",
                table: "Technicians",
                column: "ManagerID",
                principalTable: "Managers",
                principalColumn: "ManagerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Technicians_Stations_StationID",
                table: "Technicians",
                column: "StationID",
                principalTable: "Stations",
                principalColumn: "StationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Technicians_Users_userID",
                table: "Technicians",
                column: "userID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Technicians_Wallets_WalletID",
                table: "Technicians",
                column: "WalletID",
                principalTable: "Wallets",
                principalColumn: "WalletID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Wallets_WalletID",
                table: "Transactions",
                column: "WalletID",
                principalTable: "Wallets",
                principalColumn: "WalletID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Areas_AreaID",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_userID",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_FixHistories_Services_ServiceID",
                table: "FixHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Managers_Users_userID",
                table: "Managers");

            migrationBuilder.DropForeignKey(
                name: "FK_Managers_Wallets_WalletID",
                table: "Managers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Transactions_TransactionID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Models_ModelConditionerModelID",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Requests_RequestOrderID_RequestAreaID_RequestCustomerID_RequestTechnicianID_RequestStationID_RequestManagerID",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Stations_Managers_ManagerID",
                table: "Stations");

            migrationBuilder.DropForeignKey(
                name: "FK_Technicians_Managers_ManagerID",
                table: "Technicians");

            migrationBuilder.DropForeignKey(
                name: "FK_Technicians_Stations_StationID",
                table: "Technicians");

            migrationBuilder.DropForeignKey(
                name: "FK_Technicians_Users_userID",
                table: "Technicians");

            migrationBuilder.DropForeignKey(
                name: "FK_Technicians_Wallets_WalletID",
                table: "Technicians");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Wallets_WalletID",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Technicians");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Technicians");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "FixHistories");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Areas");

            migrationBuilder.RenameColumn(
                name: "userID",
                table: "Technicians",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Technicians_userID",
                table: "Technicians",
                newName: "IX_Technicians_userId");

            migrationBuilder.RenameColumn(
                name: "userID",
                table: "Managers",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Managers_userID",
                table: "Managers",
                newName: "IX_Managers_userId");

            migrationBuilder.RenameColumn(
                name: "userID",
                table: "Customers",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_userID",
                table: "Customers",
                newName: "IX_Customers_userId");

            migrationBuilder.AlterColumn<long>(
                name: "WalletID",
                table: "Transactions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "WalletID",
                table: "Technicians",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Technicians",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "StationID",
                table: "Technicians",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ManagerID",
                table: "Technicians",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ManagerID",
                table: "Stations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RequestTechnicianID",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RequestStationID",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RequestOrderID",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RequestManagerID",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RequestCustomerID",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RequestAreaID",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModelConditionerModelID",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<long>(
                name: "TransactionID",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "WalletID",
                table: "Managers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Managers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceID",
                table: "FixHistories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AreaID",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HashPassword = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SaltPassword = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Areas_AreaID",
                table: "Customers",
                column: "AreaID",
                principalTable: "Areas",
                principalColumn: "AreaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_User_userId",
                table: "Customers",
                column: "userId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FixHistories_Services_ServiceID",
                table: "FixHistories",
                column: "ServiceID",
                principalTable: "Services",
                principalColumn: "ServiceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_User_userId",
                table: "Managers",
                column: "userId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_Wallets_WalletID",
                table: "Managers",
                column: "WalletID",
                principalTable: "Wallets",
                principalColumn: "WalletID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Transactions_TransactionID",
                table: "Orders",
                column: "TransactionID",
                principalTable: "Transactions",
                principalColumn: "TransactionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Models_ModelConditionerModelID",
                table: "Services",
                column: "ModelConditionerModelID",
                principalTable: "Models",
                principalColumn: "ConditionerModelID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Requests_RequestOrderID_RequestAreaID_RequestCustomerID_RequestTechnicianID_RequestStationID_RequestManagerID",
                table: "Services",
                columns: new[] { "RequestOrderID", "RequestAreaID", "RequestCustomerID", "RequestTechnicianID", "RequestStationID", "RequestManagerID" },
                principalTable: "Requests",
                principalColumns: new[] { "OrderID", "AreaID", "CustomerID", "TechnicianID", "StationID", "ManagerID" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stations_Managers_ManagerID",
                table: "Stations",
                column: "ManagerID",
                principalTable: "Managers",
                principalColumn: "ManagerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Technicians_Managers_ManagerID",
                table: "Technicians",
                column: "ManagerID",
                principalTable: "Managers",
                principalColumn: "ManagerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Technicians_Stations_StationID",
                table: "Technicians",
                column: "StationID",
                principalTable: "Stations",
                principalColumn: "StationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Technicians_User_userId",
                table: "Technicians",
                column: "userId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Technicians_Wallets_WalletID",
                table: "Technicians",
                column: "WalletID",
                principalTable: "Wallets",
                principalColumn: "WalletID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Wallets_WalletID",
                table: "Transactions",
                column: "WalletID",
                principalTable: "Wallets",
                principalColumn: "WalletID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
