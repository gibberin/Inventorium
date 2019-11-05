using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventorium.Data.Migrations
{
    public partial class Added_Objects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Item",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AnalogPinCount",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "BLE",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Bluetooth",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CPU",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "FlashMemory",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GPIOCount",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "MaxSourceAmps",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Out3_3V",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Out5V",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PWMPinCount",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Platform",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PowerJack",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "RAM",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ResetButton",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "USBConnectorCount",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "USBPower",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Voltage",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Wifi",
                table: "Item",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "AnalogPinCount",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "BLE",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Bluetooth",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "CPU",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "FlashMemory",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "GPIOCount",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "MaxSourceAmps",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Out3_3V",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Out5V",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "PWMPinCount",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Platform",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "PowerJack",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "RAM",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "ResetButton",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "USBConnectorCount",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "USBPower",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Voltage",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Wifi",
                table: "Item");
        }
    }
}
