using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiparisYonetim.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class adminmanagerinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Managers_Branches_BranchID",
                table: "Managers");

            migrationBuilder.DropIndex(
                name: "IX_Managers_BranchID",
                table: "Managers");

            migrationBuilder.AddColumn<int>(
                name: "BranchID1",
                table: "Managers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BranchID",
                table: "Admin",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Managers_BranchID1",
                table: "Managers",
                column: "BranchID1");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_BranchID",
                table: "Admin",
                column: "BranchID");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_Branches_BranchID",
                table: "Admin",
                column: "BranchID",
                principalTable: "Branches",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_Branches_BranchID1",
                table: "Managers",
                column: "BranchID1",
                principalTable: "Branches",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_Branches_BranchID",
                table: "Admin");

            migrationBuilder.DropForeignKey(
                name: "FK_Managers_Branches_BranchID1",
                table: "Managers");

            migrationBuilder.DropIndex(
                name: "IX_Managers_BranchID1",
                table: "Managers");

            migrationBuilder.DropIndex(
                name: "IX_Admin_BranchID",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "BranchID1",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "BranchID",
                table: "Admin");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_BranchID",
                table: "Managers",
                column: "BranchID");

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_Branches_BranchID",
                table: "Managers",
                column: "BranchID",
                principalTable: "Branches",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
