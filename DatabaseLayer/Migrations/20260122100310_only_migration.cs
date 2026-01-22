using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class only_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_CraneInsurance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vehicle_TypeId = table.Column<int>(type: "int", nullable: false),
                    Policy_No = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Insurance_Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Policy_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Start_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Premium_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Premium_Frequency = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Agent_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Agent_ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_CraneInsurance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_CraneInsurance_tbl_Vehicles_Vehicle_TypeId",
                        column: x => x.Vehicle_TypeId,
                        principalTable: "tbl_Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_CraneInsurance_Vehicle_TypeId",
                table: "tbl_CraneInsurance",
                column: "Vehicle_TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_CraneInsurance");
        }
    }
}
