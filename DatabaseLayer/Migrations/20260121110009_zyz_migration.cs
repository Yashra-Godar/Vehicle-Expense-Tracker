using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class zyz_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_craneOtherExpenses_tbl_Vehicles_Vehicle_TypeId",
                table: "craneOtherExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_FuelExpenses_tbl_Vehicles_Vehicle_TypeId",
                table: "tbl_FuelExpenses");

            migrationBuilder.AlterColumn<int>(
                name: "Vehicle_TypeId",
                table: "tbl_FuelExpenses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Crane_VehicleId",
                table: "tbl_FuelExpenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Vehicle_TypeId",
                table: "craneOtherExpenses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Crane_VehicleId",
                table: "craneOtherExpenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_FuelExpenses_Crane_VehicleId",
                table: "tbl_FuelExpenses",
                column: "Crane_VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_craneOtherExpenses_Crane_VehicleId",
                table: "craneOtherExpenses",
                column: "Crane_VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_craneOtherExpenses_tbl_CraneVehicle_Crane_VehicleId",
                table: "craneOtherExpenses",
                column: "Crane_VehicleId",
                principalTable: "tbl_CraneVehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_craneOtherExpenses_tbl_Vehicles_Vehicle_TypeId",
                table: "craneOtherExpenses",
                column: "Vehicle_TypeId",
                principalTable: "tbl_Vehicles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_FuelExpenses_tbl_CraneVehicle_Crane_VehicleId",
                table: "tbl_FuelExpenses",
                column: "Crane_VehicleId",
                principalTable: "tbl_CraneVehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_FuelExpenses_tbl_Vehicles_Vehicle_TypeId",
                table: "tbl_FuelExpenses",
                column: "Vehicle_TypeId",
                principalTable: "tbl_Vehicles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_craneOtherExpenses_tbl_CraneVehicle_Crane_VehicleId",
                table: "craneOtherExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_craneOtherExpenses_tbl_Vehicles_Vehicle_TypeId",
                table: "craneOtherExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_FuelExpenses_tbl_CraneVehicle_Crane_VehicleId",
                table: "tbl_FuelExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_FuelExpenses_tbl_Vehicles_Vehicle_TypeId",
                table: "tbl_FuelExpenses");

            migrationBuilder.DropIndex(
                name: "IX_tbl_FuelExpenses_Crane_VehicleId",
                table: "tbl_FuelExpenses");

            migrationBuilder.DropIndex(
                name: "IX_craneOtherExpenses_Crane_VehicleId",
                table: "craneOtherExpenses");

            migrationBuilder.DropColumn(
                name: "Crane_VehicleId",
                table: "tbl_FuelExpenses");

            migrationBuilder.DropColumn(
                name: "Crane_VehicleId",
                table: "craneOtherExpenses");

            migrationBuilder.AlterColumn<int>(
                name: "Vehicle_TypeId",
                table: "tbl_FuelExpenses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Vehicle_TypeId",
                table: "craneOtherExpenses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_craneOtherExpenses_tbl_Vehicles_Vehicle_TypeId",
                table: "craneOtherExpenses",
                column: "Vehicle_TypeId",
                principalTable: "tbl_Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_FuelExpenses_tbl_Vehicles_Vehicle_TypeId",
                table: "tbl_FuelExpenses",
                column: "Vehicle_TypeId",
                principalTable: "tbl_Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
