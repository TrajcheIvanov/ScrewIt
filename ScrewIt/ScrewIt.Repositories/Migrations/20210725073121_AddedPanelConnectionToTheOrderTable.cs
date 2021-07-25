using Microsoft.EntityFrameworkCore.Migrations;

namespace ScrewIt.Repositories.Migrations
{
    public partial class AddedPanelConnectionToTheOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Panels_PanelId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "PanelId",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Panels_PanelId",
                table: "Orders",
                column: "PanelId",
                principalTable: "Panels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Panels_PanelId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "PanelId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Panels_PanelId",
                table: "Orders",
                column: "PanelId",
                principalTable: "Panels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
