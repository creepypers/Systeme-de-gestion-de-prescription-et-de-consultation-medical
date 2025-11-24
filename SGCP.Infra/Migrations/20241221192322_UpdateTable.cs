using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystèmeGestionConsultationPrescriptions.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_DossiersMedical_DossierMedicalId",
                table: "Consultations");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Patients_PatientId",
                table: "Prescription");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_PatientId",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Prescription");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_DossiersMedical_DossierMedicalId",
                table: "Consultations",
                column: "DossierMedicalId",
                principalTable: "DossiersMedical",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_DossiersMedical_DossierMedicalId",
                table: "Consultations");

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Prescription",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_PatientId",
                table: "Prescription",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_DossiersMedical_DossierMedicalId",
                table: "Consultations",
                column: "DossierMedicalId",
                principalTable: "DossiersMedical",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Patients_PatientId",
                table: "Prescription",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
