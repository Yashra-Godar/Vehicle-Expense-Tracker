using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class dfg_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_FuelExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vehicle_TypeId = table.Column<int>(type: "int", nullable: false),
                    Fuel_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fuel_Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fuel_Station = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fuel_Qty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Odometer_Reading = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Payment_Method = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Receipt_No = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_FuelExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_FuelExpenses_tbl_Vehicles_Vehicle_TypeId",
                        column: x => x.Vehicle_TypeId,
                        principalTable: "tbl_Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_FuelExpenses_Vehicle_TypeId",
                table: "tbl_FuelExpenses",
                column: "Vehicle_TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_FuelExpenses");
        }
    }
}
