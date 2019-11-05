using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventorium.Data.Migrations
{
    public partial class Linked_App_With_Project : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Project",
                table: "Application");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectID",
                table: "Application",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Application_ProjectID",
                table: "Application",
                column: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Project_ProjectID",
                table: "Application",
                column: "ProjectID",
                principalTable: "Project",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_Project_ProjectID",
                table: "Application");

            migrationBuilder.DropIndex(
                name: "IX_Application_ProjectID",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "ProjectID",
                table: "Application");

            migrationBuilder.AddColumn<string>(
                name: "Project",
                table: "Application",
                nullable: true);
        }
    }
}
