using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class ini_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_craneOilChangeLogs_tbl_Vehicles_Vehicle_TypeId",
                table: "craneOilChangeLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_craneOtherExpenses_tbl_Vehicles_Vehicle_TypeId",
                table: "craneOtherExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_FuelExpenses_tbl_Vehicles_Vehicle_TypeId",
                table: "tbl_FuelExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_VehicleLoan_tbl_Vehicles_Vehicle_TypeId",
                table: "tbl_VehicleLoan");

            migrationBuilder.DropIndex(
                name: "IX_tbl_VehicleLoan_Vehicle_TypeId",
                table: "tbl_VehicleLoan");

            migrationBuilder.DropIndex(
                name: "IX_tbl_FuelExpenses_Vehicle_TypeId",
                table: "tbl_FuelExpenses");

            migrationBuilder.DropIndex(
                name: "IX_craneOtherExpenses_Vehicle_TypeId",
                table: "craneOtherExpenses");

            migrationBuilder.DropIndex(
                name: "IX_craneOilChangeLogs_Vehicle_TypeId",
                table: "craneOilChangeLogs");

            migrationBuilder.DropColumn(
                name: "Vehicle_TypeId",
                table: "tbl_VehicleLoan");

            migrationBuilder.DropColumn(
                name: "Vehicle_TypeId",
                table: "tbl_FuelExpenses");

            migrationBuilder.DropColumn(
                name: "Vehicle_TypeId",
                table: "craneOtherExpenses");

            migrationBuilder.DropColumn(
                name: "Vehicle_TypeId",
                table: "craneOilChangeLogs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Vehicle_TypeId",
                table: "tbl_VehicleLoan",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Vehicle_TypeId",
                table: "tbl_FuelExpenses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Vehicle_TypeId",
                table: "craneOtherExpenses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Vehicle_TypeId",
                table: "craneOilChangeLogs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_VehicleLoan_Vehicle_TypeId",
                table: "tbl_VehicleLoan",
                column: "Vehicle_TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_FuelExpenses_Vehicle_TypeId",
                table: "tbl_FuelExpenses",
                column: "Vehicle_TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_craneOtherExpenses_Vehicle_TypeId",
                table: "craneOtherExpenses",
                column: "Vehicle_TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_craneOilChangeLogs_Vehicle_TypeId",
                table: "craneOilChangeLogs",
                column: "Vehicle_TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_craneOilChangeLogs_tbl_Vehicles_Vehicle_TypeId",
                table: "craneOilChangeLogs",
                column: "Vehicle_TypeId",
                principalTable: "tbl_Vehicles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_craneOtherExpenses_tbl_Vehicles_Vehicle_TypeId",
                table: "craneOtherExpenses",
                column: "Vehicle_TypeId",
                principalTable: "tbl_Vehicles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_FuelExpenses_tbl_Vehicles_Vehicle_TypeId",
                table: "tbl_FuelExpenses",
                column: "Vehicle_TypeId",
                principalTable: "tbl_Vehicles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_VehicleLoan_tbl_Vehicles_Vehicle_TypeId",
                table: "tbl_VehicleLoan",
                column: "Vehicle_TypeId",
                principalTable: "tbl_Vehicles",
                principalColumn: "Id");
        }
    }
}
