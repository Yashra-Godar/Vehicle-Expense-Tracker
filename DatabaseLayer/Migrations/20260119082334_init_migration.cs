using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class init_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_CraneVehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vehicle_TypeId = table.Column<int>(type: "int", nullable: false),
                    Vehicle_No = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vehicle_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Make_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacture_Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity_Tons = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Max_Lifting_Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Import_From = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Import_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Purchase_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_CraneVehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_CraneVehicle_tbl_Vehicles_Vehicle_TypeId",
                        column: x => x.Vehicle_TypeId,
                        principalTable: "tbl_Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_CraneVehicle_Vehicle_TypeId",
                table: "tbl_CraneVehicle",
                column: "Vehicle_TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_CraneVehicle");

            migrationBuilder.DropTable(
                name: "tbl_Vehicles");
        }
    }
}
