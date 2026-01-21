using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class set_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "craneOilChangeLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vehicle_TypeId = table.Column<int>(type: "int", nullable: false),
                    Oil_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Oil_Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Meter_Reading = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Change_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NextDue_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Changed_By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_craneOilChangeLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_craneOilChangeLogs_tbl_Vehicles_Vehicle_TypeId",
                        column: x => x.Vehicle_TypeId,
                        principalTable: "tbl_Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_craneOilChangeLogs_Vehicle_TypeId",
                table: "craneOilChangeLogs",
                column: "Vehicle_TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "craneOilChangeLogs");
        }
    }
}
