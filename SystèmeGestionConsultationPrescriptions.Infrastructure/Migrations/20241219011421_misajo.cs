using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystèmeGestionConsultationPrescriptions.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class misajo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MedecinId",
                table: "Consultations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_MedecinId",
                table: "Consultations",
                column: "MedecinId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_Medecins_MedecinId",
                table: "Consultations",
                column: "MedecinId",
                principalTable: "Medecins",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_Medecins_MedecinId",
                table: "Consultations");

            migrationBuilder.DropIndex(
                name: "IX_Consultations_MedecinId",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "MedecinId",
                table: "Consultations");
        }
    }
}
