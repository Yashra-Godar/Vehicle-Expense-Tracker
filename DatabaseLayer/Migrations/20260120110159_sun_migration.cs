using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class sun_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_LoanInstallment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vehicle_LoanId = table.Column<int>(type: "int", nullable: false),
                    Installment_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount_Paid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Payment_Method = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Receipt_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Paid_On = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_LoanInstallment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_LoanInstallment_tbl_VehicleLoan_Vehicle_LoanId",
                        column: x => x.Vehicle_LoanId,
                        principalTable: "tbl_VehicleLoan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_LoanInstallment_Vehicle_LoanId",
                table: "tbl_LoanInstallment",
                column: "Vehicle_LoanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_LoanInstallment");
        }
    }
}
