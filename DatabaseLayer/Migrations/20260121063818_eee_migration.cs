using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class eee_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "craneOtherExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vehicle_TypeId = table.Column<int>(type: "int", nullable: false),
                    Expense_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Expense_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Paid_To = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reference_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Payment_Mode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_craneOtherExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_craneOtherExpenses_tbl_Vehicles_Vehicle_TypeId",
                        column: x => x.Vehicle_TypeId,
                        principalTable: "tbl_Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_craneOtherExpenses_Vehicle_TypeId",
                table: "craneOtherExpenses",
                column: "Vehicle_TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "craneOtherExpenses");
        }
    }
}
