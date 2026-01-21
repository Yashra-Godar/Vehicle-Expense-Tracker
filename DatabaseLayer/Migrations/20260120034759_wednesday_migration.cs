using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class wednesday_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_ServiceMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vehicle_TypeId = table.Column<int>(type: "int", nullable: false),
                    Service_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Service_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Performed_By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ServiceMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_ServiceMaster_tbl_Vehicles_Vehicle_TypeId",
                        column: x => x.Vehicle_TypeId,
                        principalTable: "tbl_Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ServiceMaster_Vehicle_TypeId",
                table: "tbl_ServiceMaster",
                column: "Vehicle_TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_ServiceMaster");
        }
    }
}
