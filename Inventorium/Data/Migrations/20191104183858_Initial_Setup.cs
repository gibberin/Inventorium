using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventorium.Data.Migrations
{
    public partial class Initial_Setup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    OwnerID = table.Column<string>(nullable: true),
                    Edition = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ProjectID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BinRack",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    OwnerID = table.Column<string>(nullable: true),
                    Edition = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    RackXIndex = table.Column<int>(nullable: false),
                    RackYIndex = table.Column<int>(nullable: false),
                    RackZIndex = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinRack", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PartsBin",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    OwnerID = table.Column<string>(nullable: true),
                    Edition = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    RackID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsBin", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PartsBin_BinRack_RackID",
                        column: x => x.RackID,
                        principalTable: "BinRack",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    OwnerID = table.Column<string>(nullable: true),
                    Edition = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Features = table.Column<string>(nullable: true),
                    Manufacturer = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<float>(nullable: false),
                    Tax = table.Column<float>(nullable: false),
                    Shipping = table.Column<float>(nullable: false),
                    DateOfAcquisition = table.Column<DateTime>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    AssignmentID = table.Column<Guid>(nullable: true),
                    Height = table.Column<float>(nullable: false),
                    Width = table.Column<float>(nullable: false),
                    Depth = table.Column<float>(nullable: false),
                    Weight = table.Column<float>(nullable: false),
                    BinID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Item_Application_AssignmentID",
                        column: x => x.AssignmentID,
                        principalTable: "Application",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_PartsBin_BinID",
                        column: x => x.BinID,
                        principalTable: "PartsBin",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_AssignmentID",
                table: "Item",
                column: "AssignmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Item_BinID",
                table: "Item",
                column: "BinID");

            migrationBuilder.CreateIndex(
                name: "IX_PartsBin_RackID",
                table: "PartsBin",
                column: "RackID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropTable(
                name: "PartsBin");

            migrationBuilder.DropTable(
                name: "BinRack");
        }
    }
}
