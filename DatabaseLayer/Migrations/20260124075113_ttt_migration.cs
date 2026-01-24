using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class ttt_migration : Migration
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
                name: "FK_tbl_CraneInsurance_tbl_Vehicles_Vehicle_TypeId",
                table: "tbl_CraneInsurance");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_FuelExpenses_tbl_Vehicles_Vehicle_TypeId",
                table: "tbl_FuelExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_InsurancePremium_tbl_Vehicles_Vehicle_TypeId",
                table: "tbl_InsurancePremium");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_ServiceMaster_tbl_Vehicles_Vehicle_TypeId",
                table: "tbl_ServiceMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_VehicleLoan_tbl_Vehicles_Vehicle_TypeId",
                table: "tbl_VehicleLoan");

            migrationBuilder.RenameColumn(
                name: "Vehicle_TypeId",
                table: "tbl_VehicleLoan",
                newName: "Crane_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_VehicleLoan_Vehicle_TypeId",
                table: "tbl_VehicleLoan",
                newName: "IX_tbl_VehicleLoan_Crane_VehicleId");

            migrationBuilder.RenameColumn(
                name: "Vehicle_TypeId",
                table: "tbl_ServiceMaster",
                newName: "Crane_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_ServiceMaster_Vehicle_TypeId",
                table: "tbl_ServiceMaster",
                newName: "IX_tbl_ServiceMaster_Crane_VehicleId");

            migrationBuilder.RenameColumn(
                name: "Vehicle_TypeId",
                table: "tbl_InsurancePremium",
                newName: "Crane_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_InsurancePremium_Vehicle_TypeId",
                table: "tbl_InsurancePremium",
                newName: "IX_tbl_InsurancePremium_Crane_VehicleId");

            migrationBuilder.RenameColumn(
                name: "Vehicle_TypeId",
                table: "tbl_FuelExpenses",
                newName: "Crane_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_FuelExpenses_Vehicle_TypeId",
                table: "tbl_FuelExpenses",
                newName: "IX_tbl_FuelExpenses_Crane_VehicleId");

            migrationBuilder.RenameColumn(
                name: "Vehicle_TypeId",
                table: "tbl_CraneInsurance",
                newName: "Crane_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_CraneInsurance_Vehicle_TypeId",
                table: "tbl_CraneInsurance",
                newName: "IX_tbl_CraneInsurance_Crane_VehicleId");

            migrationBuilder.RenameColumn(
                name: "Vehicle_TypeId",
                table: "craneOtherExpenses",
                newName: "Crane_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_craneOtherExpenses_Vehicle_TypeId",
                table: "craneOtherExpenses",
                newName: "IX_craneOtherExpenses_Crane_VehicleId");

            migrationBuilder.RenameColumn(
                name: "Vehicle_TypeId",
                table: "craneOilChangeLogs",
                newName: "Crane_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_craneOilChangeLogs_Vehicle_TypeId",
                table: "craneOilChangeLogs",
                newName: "IX_craneOilChangeLogs_Crane_VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_craneOilChangeLogs_tbl_CraneVehicle_Crane_VehicleId",
                table: "craneOilChangeLogs",
                column: "Crane_VehicleId",
                principalTable: "tbl_CraneVehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_craneOtherExpenses_tbl_CraneVehicle_Crane_VehicleId",
                table: "craneOtherExpenses",
                column: "Crane_VehicleId",
                principalTable: "tbl_CraneVehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_CraneInsurance_tbl_CraneVehicle_Crane_VehicleId",
                table: "tbl_CraneInsurance",
                column: "Crane_VehicleId",
                principalTable: "tbl_CraneVehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_FuelExpenses_tbl_CraneVehicle_Crane_VehicleId",
                table: "tbl_FuelExpenses",
                column: "Crane_VehicleId",
                principalTable: "tbl_CraneVehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_InsurancePremium_tbl_CraneVehicle_Crane_VehicleId",
                table: "tbl_InsurancePremium",
                column: "Crane_VehicleId",
                principalTable: "tbl_CraneVehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_ServiceMaster_tbl_CraneVehicle_Crane_VehicleId",
                table: "tbl_ServiceMaster",
                column: "Crane_VehicleId",
                principalTable: "tbl_CraneVehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_VehicleLoan_tbl_CraneVehicle_Crane_VehicleId",
                table: "tbl_VehicleLoan",
                column: "Crane_VehicleId",
                principalTable: "tbl_CraneVehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_craneOilChangeLogs_tbl_CraneVehicle_Crane_VehicleId",
                table: "craneOilChangeLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_craneOtherExpenses_tbl_CraneVehicle_Crane_VehicleId",
                table: "craneOtherExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_CraneInsurance_tbl_CraneVehicle_Crane_VehicleId",
                table: "tbl_CraneInsurance");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_FuelExpenses_tbl_CraneVehicle_Crane_VehicleId",
                table: "tbl_FuelExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_InsurancePremium_tbl_CraneVehicle_Crane_VehicleId",
                table: "tbl_InsurancePremium");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_ServiceMaster_tbl_CraneVehicle_Crane_VehicleId",
                table: "tbl_ServiceMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_VehicleLoan_tbl_CraneVehicle_Crane_VehicleId",
                table: "tbl_VehicleLoan");

            migrationBuilder.RenameColumn(
                name: "Crane_VehicleId",
                table: "tbl_VehicleLoan",
                newName: "Vehicle_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_VehicleLoan_Crane_VehicleId",
                table: "tbl_VehicleLoan",
                newName: "IX_tbl_VehicleLoan_Vehicle_TypeId");

            migrationBuilder.RenameColumn(
                name: "Crane_VehicleId",
                table: "tbl_ServiceMaster",
                newName: "Vehicle_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_ServiceMaster_Crane_VehicleId",
                table: "tbl_ServiceMaster",
                newName: "IX_tbl_ServiceMaster_Vehicle_TypeId");

            migrationBuilder.RenameColumn(
                name: "Crane_VehicleId",
                table: "tbl_InsurancePremium",
                newName: "Vehicle_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_InsurancePremium_Crane_VehicleId",
                table: "tbl_InsurancePremium",
                newName: "IX_tbl_InsurancePremium_Vehicle_TypeId");

            migrationBuilder.RenameColumn(
                name: "Crane_VehicleId",
                table: "tbl_FuelExpenses",
                newName: "Vehicle_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_FuelExpenses_Crane_VehicleId",
                table: "tbl_FuelExpenses",
                newName: "IX_tbl_FuelExpenses_Vehicle_TypeId");

            migrationBuilder.RenameColumn(
                name: "Crane_VehicleId",
                table: "tbl_CraneInsurance",
                newName: "Vehicle_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_CraneInsurance_Crane_VehicleId",
                table: "tbl_CraneInsurance",
                newName: "IX_tbl_CraneInsurance_Vehicle_TypeId");

            migrationBuilder.RenameColumn(
                name: "Crane_VehicleId",
                table: "craneOtherExpenses",
                newName: "Vehicle_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_craneOtherExpenses_Crane_VehicleId",
                table: "craneOtherExpenses",
                newName: "IX_craneOtherExpenses_Vehicle_TypeId");

            migrationBuilder.RenameColumn(
                name: "Crane_VehicleId",
                table: "craneOilChangeLogs",
                newName: "Vehicle_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_craneOilChangeLogs_Crane_VehicleId",
                table: "craneOilChangeLogs",
                newName: "IX_craneOilChangeLogs_Vehicle_TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_craneOilChangeLogs_tbl_Vehicles_Vehicle_TypeId",
                table: "craneOilChangeLogs",
                column: "Vehicle_TypeId",
                principalTable: "tbl_Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_craneOtherExpenses_tbl_Vehicles_Vehicle_TypeId",
                table: "craneOtherExpenses",
                column: "Vehicle_TypeId",
                principalTable: "tbl_Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_CraneInsurance_tbl_Vehicles_Vehicle_TypeId",
                table: "tbl_CraneInsurance",
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

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_InsurancePremium_tbl_Vehicles_Vehicle_TypeId",
                table: "tbl_InsurancePremium",
                column: "Vehicle_TypeId",
                principalTable: "tbl_Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_ServiceMaster_tbl_Vehicles_Vehicle_TypeId",
                table: "tbl_ServiceMaster",
                column: "Vehicle_TypeId",
                principalTable: "tbl_Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
