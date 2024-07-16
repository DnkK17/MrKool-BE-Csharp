using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MrKoolApplication.Migrations
{
    /// <inheritdoc />
    public partial class updateWalletCore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "userID",
                table: "Wallets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_userID",
                table: "Wallets",
                column: "userID");

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_Users_userID",
                table: "Wallets",
                column: "userID",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_Users_userID",
                table: "Wallets");

            migrationBuilder.DropIndex(
                name: "IX_Wallets_userID",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "userID",
                table: "Wallets");
        }
    }
}
