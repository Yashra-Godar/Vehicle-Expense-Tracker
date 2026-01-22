using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class RemoveVehicleTypeFromCraneOilChangeLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_VehicleLoan_tbl_Vehicles_Vehicle_TypeId",
                table: "tbl_VehicleLoan");

            migrationBuilder.AlterColumn<int>(
                name: "Vehicle_TypeId",
                table: "tbl_VehicleLoan",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Crane_VehicleId",
                table: "tbl_VehicleLoan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_VehicleLoan_Crane_VehicleId",
                table: "tbl_VehicleLoan",
                column: "Crane_VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_VehicleLoan_tbl_CraneVehicle_Crane_VehicleId",
                table: "tbl_VehicleLoan",
                column: "Crane_VehicleId",
                principalTable: "tbl_CraneVehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_VehicleLoan_tbl_Vehicles_Vehicle_TypeId",
                table: "tbl_VehicleLoan",
                column: "Vehicle_TypeId",
                principalTable: "tbl_Vehicles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_VehicleLoan_tbl_CraneVehicle_Crane_VehicleId",
                table: "tbl_VehicleLoan");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_VehicleLoan_tbl_Vehicles_Vehicle_TypeId",
                table: "tbl_VehicleLoan");

            migrationBuilder.DropIndex(
                name: "IX_tbl_VehicleLoan_Crane_VehicleId",
                table: "tbl_VehicleLoan");

            migrationBuilder.DropColumn(
                name: "Crane_VehicleId",
                table: "tbl_VehicleLoan");

            migrationBuilder.AlterColumn<int>(
                name: "Vehicle_TypeId",
                table: "tbl_VehicleLoan",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_VehicleLoan_tbl_Vehicles_Vehicle_TypeId",
                table: "tbl_VehicleLoan",
                column: "Vehicle_TypeId",
                principalTable: "tbl_Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
