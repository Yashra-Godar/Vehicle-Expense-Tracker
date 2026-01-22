using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class gvc_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_craneOilChangeLogs_tbl_Vehicles_Vehicle_TypeId",
                table: "craneOilChangeLogs");

            migrationBuilder.AlterColumn<int>(
                name: "Vehicle_TypeId",
                table: "craneOilChangeLogs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Crane_VehicleId",
                table: "craneOilChangeLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_craneOilChangeLogs_Crane_VehicleId",
                table: "craneOilChangeLogs",
                column: "Crane_VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_craneOilChangeLogs_tbl_CraneVehicle_Crane_VehicleId",
                table: "craneOilChangeLogs",
                column: "Crane_VehicleId",
                principalTable: "tbl_CraneVehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_craneOilChangeLogs_tbl_Vehicles_Vehicle_TypeId",
                table: "craneOilChangeLogs",
                column: "Vehicle_TypeId",
                principalTable: "tbl_Vehicles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_craneOilChangeLogs_tbl_CraneVehicle_Crane_VehicleId",
                table: "craneOilChangeLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_craneOilChangeLogs_tbl_Vehicles_Vehicle_TypeId",
                table: "craneOilChangeLogs");

            migrationBuilder.DropIndex(
                name: "IX_craneOilChangeLogs_Crane_VehicleId",
                table: "craneOilChangeLogs");

            migrationBuilder.DropColumn(
                name: "Crane_VehicleId",
                table: "craneOilChangeLogs");

            migrationBuilder.AlterColumn<int>(
                name: "Vehicle_TypeId",
                table: "craneOilChangeLogs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_craneOilChangeLogs_tbl_Vehicles_Vehicle_TypeId",
                table: "craneOilChangeLogs",
                column: "Vehicle_TypeId",
                principalTable: "tbl_Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
