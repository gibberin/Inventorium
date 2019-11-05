using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventorium.Data.Migrations
{
    public partial class Fixed_App_Proj_Relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProjectID",
                table: "Application",
                newName: "Project");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Project",
                table: "Application",
                newName: "ProjectID");
        }
    }
}
