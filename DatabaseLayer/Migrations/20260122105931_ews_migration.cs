using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class ews_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_InsurancePremium",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Crane_InsuranceId = table.Column<int>(type: "int", nullable: false),
                    Vehicle_TypeId = table.Column<int>(type: "int", nullable: false),
                    Premium_Month = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Payment_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Payment_Mode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Paid_To = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_InsurancePremium", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_InsurancePremium_tbl_CraneInsurance_Crane_InsuranceId",
                        column: x => x.Crane_InsuranceId,
                        principalTable: "tbl_CraneInsurance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_InsurancePremium_tbl_Vehicles_Vehicle_TypeId",
                        column: x => x.Vehicle_TypeId,
                        principalTable: "tbl_Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_InsurancePremium_Crane_InsuranceId",
                table: "tbl_InsurancePremium",
                column: "Crane_InsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_InsurancePremium_Vehicle_TypeId",
                table: "tbl_InsurancePremium",
                column: "Vehicle_TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_InsurancePremium");
        }
    }
}
