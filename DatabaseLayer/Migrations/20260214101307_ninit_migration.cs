using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class ninit_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_ServiceCentre_tbl_ServiceMaster_Service_MasterId",
                table: "tbl_ServiceCentre");

            migrationBuilder.DropIndex(
                name: "IX_tbl_ServiceCentre_Service_MasterId",
                table: "tbl_ServiceCentre");

            migrationBuilder.DropColumn(
                name: "Service_MasterId",
                table: "tbl_ServiceCentre");

            migrationBuilder.AddColumn<int>(
                name: "ServiceCentreId",
                table: "tbl_ServiceMaster",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ServiceMaster_ServiceCentreId",
                table: "tbl_ServiceMaster",
                column: "ServiceCentreId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_ServiceMaster_tbl_ServiceCentre_ServiceCentreId",
                table: "tbl_ServiceMaster",
                column: "ServiceCentreId",
                principalTable: "tbl_ServiceCentre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_ServiceMaster_tbl_ServiceCentre_ServiceCentreId",
                table: "tbl_ServiceMaster");

            migrationBuilder.DropIndex(
                name: "IX_tbl_ServiceMaster_ServiceCentreId",
                table: "tbl_ServiceMaster");

            migrationBuilder.DropColumn(
                name: "ServiceCentreId",
                table: "tbl_ServiceMaster");

            migrationBuilder.AddColumn<int>(
                name: "Service_MasterId",
                table: "tbl_ServiceCentre",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ServiceCentre_Service_MasterId",
                table: "tbl_ServiceCentre",
                column: "Service_MasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_ServiceCentre_tbl_ServiceMaster_Service_MasterId",
                table: "tbl_ServiceCentre",
                column: "Service_MasterId",
                principalTable: "tbl_ServiceMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
