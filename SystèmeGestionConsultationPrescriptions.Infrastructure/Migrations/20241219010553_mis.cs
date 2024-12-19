using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystèmeGestionConsultationPrescriptions.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MedecinId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Medecins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroLicence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroTelephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdresseCourriel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomUtilisateur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotDePasse = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medecins", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_MedecinId",
                table: "Patients",
                column: "MedecinId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Medecins_MedecinId",
                table: "Patients",
                column: "MedecinId",
                principalTable: "Medecins",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Medecins_MedecinId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "Medecins");

            migrationBuilder.DropIndex(
                name: "IX_Patients_MedecinId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MedecinId",
                table: "Patients");
        }
    }
}
