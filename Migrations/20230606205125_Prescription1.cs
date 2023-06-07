using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class Prescription1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_medicaments",
                table: "medicaments");

            migrationBuilder.RenameTable(
                name: "medicaments",
                newName: "Medicament");

            migrationBuilder.AddPrimaryKey(
                name: "Medicament_pk",
                table: "Medicament",
                column: "IdMedicament");

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    IdPrescription = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Prescription_pk", x => x.IdPrescription);
                });

            migrationBuilder.CreateTable(
                name: "Prescription_Medicament",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(type: "int", nullable: false),
                    IdPrescription = table.Column<int>(type: "int", nullable: false),
                    Dose = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrescriptionMedicament_pk", x => new { x.IdPrescription, x.IdMedicament });
                    table.ForeignKey(
                        name: "PrescriptionMedicament_Medicament",
                        column: x => x.IdMedicament,
                        principalTable: "Medicament",
                        principalColumn: "IdMedicament",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "PrescriptionMedicament_Prescription",
                        column: x => x.IdPrescription,
                        principalTable: "Prescription",
                        principalColumn: "IdPrescription",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medicament_IdMedicament",
                table: "Prescription_Medicament",
                column: "IdMedicament");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescription_Medicament");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropPrimaryKey(
                name: "Medicament_pk",
                table: "Medicament");

            migrationBuilder.RenameTable(
                name: "Medicament",
                newName: "medicaments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_medicaments",
                table: "medicaments",
                column: "IdMedicament");
        }
    }
}
