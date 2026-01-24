using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class ont_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Staff_MasterId",
                table: "tbl_VehicleLoan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Staff_MasterId",
                table: "tbl_ServiceParts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Staff_MasterId",
                table: "tbl_ServiceMaster",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Staff_MasterId",
                table: "tbl_LoanInstallment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Staff_MasterId",
                table: "tbl_InsurancePremium",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Staff_MasterId",
                table: "tbl_FuelExpenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Staff_MasterId",
                table: "tbl_CraneVehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Staff_MasterId",
                table: "tbl_CraneInsurance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Staff_MasterId",
                table: "craneOtherExpenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Staff_MasterId",
                table: "craneOilChangeLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_VehicleLoan_Staff_MasterId",
                table: "tbl_VehicleLoan",
                column: "Staff_MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ServiceParts_Staff_MasterId",
                table: "tbl_ServiceParts",
                column: "Staff_MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ServiceMaster_Staff_MasterId",
                table: "tbl_ServiceMaster",
                column: "Staff_MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_LoanInstallment_Staff_MasterId",
                table: "tbl_LoanInstallment",
                column: "Staff_MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_InsurancePremium_Staff_MasterId",
                table: "tbl_InsurancePremium",
                column: "Staff_MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_FuelExpenses_Staff_MasterId",
                table: "tbl_FuelExpenses",
                column: "Staff_MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_CraneVehicle_Staff_MasterId",
                table: "tbl_CraneVehicle",
                column: "Staff_MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_CraneInsurance_Staff_MasterId",
                table: "tbl_CraneInsurance",
                column: "Staff_MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_craneOtherExpenses_Staff_MasterId",
                table: "craneOtherExpenses",
                column: "Staff_MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_craneOilChangeLogs_Staff_MasterId",
                table: "craneOilChangeLogs",
                column: "Staff_MasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_craneOilChangeLogs_tbl_Staff_Master_Staff_MasterId",
                table: "craneOilChangeLogs",
                column: "Staff_MasterId",
                principalTable: "tbl_Staff_Master",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_craneOtherExpenses_tbl_Staff_Master_Staff_MasterId",
                table: "craneOtherExpenses",
                column: "Staff_MasterId",
                principalTable: "tbl_Staff_Master",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_CraneInsurance_tbl_Staff_Master_Staff_MasterId",
                table: "tbl_CraneInsurance",
                column: "Staff_MasterId",
                principalTable: "tbl_Staff_Master",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_CraneVehicle_tbl_Staff_Master_Staff_MasterId",
                table: "tbl_CraneVehicle",
                column: "Staff_MasterId",
                principalTable: "tbl_Staff_Master",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_FuelExpenses_tbl_Staff_Master_Staff_MasterId",
                table: "tbl_FuelExpenses",
                column: "Staff_MasterId",
                principalTable: "tbl_Staff_Master",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_InsurancePremium_tbl_Staff_Master_Staff_MasterId",
                table: "tbl_InsurancePremium",
                column: "Staff_MasterId",
                principalTable: "tbl_Staff_Master",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_LoanInstallment_tbl_Staff_Master_Staff_MasterId",
                table: "tbl_LoanInstallment",
                column: "Staff_MasterId",
                principalTable: "tbl_Staff_Master",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_ServiceMaster_tbl_Staff_Master_Staff_MasterId",
                table: "tbl_ServiceMaster",
                column: "Staff_MasterId",
                principalTable: "tbl_Staff_Master",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_ServiceParts_tbl_Staff_Master_Staff_MasterId",
                table: "tbl_ServiceParts",
                column: "Staff_MasterId",
                principalTable: "tbl_Staff_Master",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_VehicleLoan_tbl_Staff_Master_Staff_MasterId",
                table: "tbl_VehicleLoan",
                column: "Staff_MasterId",
                principalTable: "tbl_Staff_Master",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_craneOilChangeLogs_tbl_Staff_Master_Staff_MasterId",
                table: "craneOilChangeLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_craneOtherExpenses_tbl_Staff_Master_Staff_MasterId",
                table: "craneOtherExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_CraneInsurance_tbl_Staff_Master_Staff_MasterId",
                table: "tbl_CraneInsurance");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_CraneVehicle_tbl_Staff_Master_Staff_MasterId",
                table: "tbl_CraneVehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_FuelExpenses_tbl_Staff_Master_Staff_MasterId",
                table: "tbl_FuelExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_InsurancePremium_tbl_Staff_Master_Staff_MasterId",
                table: "tbl_InsurancePremium");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_LoanInstallment_tbl_Staff_Master_Staff_MasterId",
                table: "tbl_LoanInstallment");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_ServiceMaster_tbl_Staff_Master_Staff_MasterId",
                table: "tbl_ServiceMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_ServiceParts_tbl_Staff_Master_Staff_MasterId",
                table: "tbl_ServiceParts");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_VehicleLoan_tbl_Staff_Master_Staff_MasterId",
                table: "tbl_VehicleLoan");

            migrationBuilder.DropIndex(
                name: "IX_tbl_VehicleLoan_Staff_MasterId",
                table: "tbl_VehicleLoan");

            migrationBuilder.DropIndex(
                name: "IX_tbl_ServiceParts_Staff_MasterId",
                table: "tbl_ServiceParts");

            migrationBuilder.DropIndex(
                name: "IX_tbl_ServiceMaster_Staff_MasterId",
                table: "tbl_ServiceMaster");

            migrationBuilder.DropIndex(
                name: "IX_tbl_LoanInstallment_Staff_MasterId",
                table: "tbl_LoanInstallment");

            migrationBuilder.DropIndex(
                name: "IX_tbl_InsurancePremium_Staff_MasterId",
                table: "tbl_InsurancePremium");

            migrationBuilder.DropIndex(
                name: "IX_tbl_FuelExpenses_Staff_MasterId",
                table: "tbl_FuelExpenses");

            migrationBuilder.DropIndex(
                name: "IX_tbl_CraneVehicle_Staff_MasterId",
                table: "tbl_CraneVehicle");

            migrationBuilder.DropIndex(
                name: "IX_tbl_CraneInsurance_Staff_MasterId",
                table: "tbl_CraneInsurance");

            migrationBuilder.DropIndex(
                name: "IX_craneOtherExpenses_Staff_MasterId",
                table: "craneOtherExpenses");

            migrationBuilder.DropIndex(
                name: "IX_craneOilChangeLogs_Staff_MasterId",
                table: "craneOilChangeLogs");

            migrationBuilder.DropColumn(
                name: "Staff_MasterId",
                table: "tbl_VehicleLoan");

            migrationBuilder.DropColumn(
                name: "Staff_MasterId",
                table: "tbl_ServiceParts");

            migrationBuilder.DropColumn(
                name: "Staff_MasterId",
                table: "tbl_ServiceMaster");

            migrationBuilder.DropColumn(
                name: "Staff_MasterId",
                table: "tbl_LoanInstallment");

            migrationBuilder.DropColumn(
                name: "Staff_MasterId",
                table: "tbl_InsurancePremium");

            migrationBuilder.DropColumn(
                name: "Staff_MasterId",
                table: "tbl_FuelExpenses");

            migrationBuilder.DropColumn(
                name: "Staff_MasterId",
                table: "tbl_CraneVehicle");

            migrationBuilder.DropColumn(
                name: "Staff_MasterId",
                table: "tbl_CraneInsurance");

            migrationBuilder.DropColumn(
                name: "Staff_MasterId",
                table: "craneOtherExpenses");

            migrationBuilder.DropColumn(
                name: "Staff_MasterId",
                table: "craneOilChangeLogs");
        }
    }
}
