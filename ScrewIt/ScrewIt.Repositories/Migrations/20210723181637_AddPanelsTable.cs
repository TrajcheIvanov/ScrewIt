using Microsoft.EntityFrameworkCore.Migrations;

namespace ScrewIt.Repositories.Migrations
{
    public partial class AddPanelsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PanelId",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Panels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Length = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Thickness = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Panels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PanelId",
                table: "Orders",
                column: "PanelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Panels_PanelId",
                table: "Orders",
                column: "PanelId",
                principalTable: "Panels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Panels_PanelId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Panels");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PanelId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PanelId",
                table: "Orders");
        }
    }
}
