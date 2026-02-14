using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class n_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
