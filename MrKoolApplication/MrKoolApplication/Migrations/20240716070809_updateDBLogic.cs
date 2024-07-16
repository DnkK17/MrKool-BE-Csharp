using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MrKoolApplication.Migrations
{
    /// <inheritdoc />
    public partial class updateDBLogic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Orders_OrderID",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_OrderID",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestID",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderID",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequestID",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_OrderID",
                table: "Requests",
                column: "OrderID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Orders_OrderID",
                table: "Requests",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID");
        }
    }
}
