using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventorium.Data.Migrations
{
    public partial class Adjusted_Racks_n_Bins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RackZIndex",
                table: "BinRack",
                newName: "Width");

            migrationBuilder.RenameColumn(
                name: "RackYIndex",
                table: "BinRack",
                newName: "Height");

            migrationBuilder.RenameColumn(
                name: "RackXIndex",
                table: "BinRack",
                newName: "Depth");

            migrationBuilder.AddColumn<int>(
                name: "RackIndexX",
                table: "PartsBin",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RackIndexY",
                table: "PartsBin",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RackIndexZ",
                table: "PartsBin",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "LocationID",
                table: "BinRack",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    OwnerID = table.Column<string>(nullable: true),
                    Edition = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Addr1 = table.Column<string>(nullable: true),
                    Addr2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    OwnerID = table.Column<string>(nullable: true),
                    Edition = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TargetDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BinRack_LocationID",
                table: "BinRack",
                column: "LocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_BinRack_Location_LocationID",
                table: "BinRack",
                column: "LocationID",
                principalTable: "Location",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BinRack_Location_LocationID",
                table: "BinRack");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropIndex(
                name: "IX_BinRack_LocationID",
                table: "BinRack");

            migrationBuilder.DropColumn(
                name: "RackIndexX",
                table: "PartsBin");

            migrationBuilder.DropColumn(
                name: "RackIndexY",
                table: "PartsBin");

            migrationBuilder.DropColumn(
                name: "RackIndexZ",
                table: "PartsBin");

            migrationBuilder.DropColumn(
                name: "LocationID",
                table: "BinRack");

            migrationBuilder.RenameColumn(
                name: "Width",
                table: "BinRack",
                newName: "RackZIndex");

            migrationBuilder.RenameColumn(
                name: "Height",
                table: "BinRack",
                newName: "RackYIndex");

            migrationBuilder.RenameColumn(
                name: "Depth",
                table: "BinRack",
                newName: "RackXIndex");
        }
    }
}
