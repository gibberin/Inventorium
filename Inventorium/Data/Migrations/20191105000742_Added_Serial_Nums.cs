using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventorium.Data.Migrations
{
    public partial class Added_Serial_Nums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "Item",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "Item");
        }
    }
}
