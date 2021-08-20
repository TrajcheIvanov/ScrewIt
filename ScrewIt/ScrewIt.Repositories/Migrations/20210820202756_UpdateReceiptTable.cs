using Microsoft.EntityFrameworkCore.Migrations;

namespace ScrewIt.Repositories.Migrations
{
    public partial class UpdateReceiptTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_AspNetUsers_UserId",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_UserId",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Receipts");

            migrationBuilder.AddColumn<string>(
                name: "EmplyeeId",
                table: "Receipts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_EmplyeeId",
                table: "Receipts",
                column: "EmplyeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_AspNetUsers_EmplyeeId",
                table: "Receipts",
                column: "EmplyeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_AspNetUsers_EmplyeeId",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_EmplyeeId",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "EmplyeeId",
                table: "Receipts");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Receipts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_UserId",
                table: "Receipts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_AspNetUsers_UserId",
                table: "Receipts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
