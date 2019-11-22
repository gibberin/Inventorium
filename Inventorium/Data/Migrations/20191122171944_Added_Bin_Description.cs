using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventorium.Data.Migrations
{
    public partial class Added_Bin_Description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PartsBin",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "PartsBin");
        }
    }
}
