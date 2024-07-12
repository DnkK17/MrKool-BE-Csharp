using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MrKoolApplication.Migrations
{
    /// <inheritdoc />
    public partial class backToPreviousLogic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Models_ModelID",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "ModelID",
                table: "Services",
                newName: "ConditionalModelID");

            migrationBuilder.RenameIndex(
                name: "IX_Services_ModelID",
                table: "Services",
                newName: "IX_Services_ConditionalModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Models_ConditionalModelID",
                table: "Services",
                column: "ConditionalModelID",
                principalTable: "Models",
                principalColumn: "ConditionerModelID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Models_ConditionalModelID",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "ConditionalModelID",
                table: "Services",
                newName: "ModelID");

            migrationBuilder.RenameIndex(
                name: "IX_Services_ConditionalModelID",
                table: "Services",
                newName: "IX_Services_ModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Models_ModelID",
                table: "Services",
                column: "ModelID",
                principalTable: "Models",
                principalColumn: "ConditionerModelID");
        }
    }
}
