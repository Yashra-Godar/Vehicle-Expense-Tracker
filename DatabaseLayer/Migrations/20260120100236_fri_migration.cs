using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class fri_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Vehicle_Loan_tbl_Vehicles_Vehicle_TypeId",
                table: "tbl_Vehicle_Loan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Vehicle_Loan",
                table: "tbl_Vehicle_Loan");

            migrationBuilder.RenameTable(
                name: "tbl_Vehicle_Loan",
                newName: "tbl_VehicleLoan");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_Vehicle_Loan_Vehicle_TypeId",
                table: "tbl_VehicleLoan",
                newName: "IX_tbl_VehicleLoan_Vehicle_TypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_VehicleLoan",
                table: "tbl_VehicleLoan",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_VehicleLoan_tbl_Vehicles_Vehicle_TypeId",
                table: "tbl_VehicleLoan",
                column: "Vehicle_TypeId",
                principalTable: "tbl_Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_VehicleLoan_tbl_Vehicles_Vehicle_TypeId",
                table: "tbl_VehicleLoan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_VehicleLoan",
                table: "tbl_VehicleLoan");

            migrationBuilder.RenameTable(
                name: "tbl_VehicleLoan",
                newName: "tbl_Vehicle_Loan");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_VehicleLoan_Vehicle_TypeId",
                table: "tbl_Vehicle_Loan",
                newName: "IX_tbl_Vehicle_Loan_Vehicle_TypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Vehicle_Loan",
                table: "tbl_Vehicle_Loan",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Vehicle_Loan_tbl_Vehicles_Vehicle_TypeId",
                table: "tbl_Vehicle_Loan",
                column: "Vehicle_TypeId",
                principalTable: "tbl_Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
