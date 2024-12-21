using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystèmeGestionConsultationPrescriptions.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medecins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroLicence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTelephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdresseCourriel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Identifiant = table.Column<int>(type: "int", nullable: false),
                    NomUtilisateur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotDePasse = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medecins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTelephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdresseCourriel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedecinId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Medecins_MedecinId",
                        column: x => x.MedecinId,
                        principalTable: "Medecins",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateConnexion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeconnexion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MedecinId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Medecins_MedecinId",
                        column: x => x.MedecinId,
                        principalTable: "Medecins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DossiersMedical",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TraitementsPassesString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    MedecinId = table.Column<int>(type: "int", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DossiersMedical", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DossiersMedical_Medecins_MedecinId",
                        column: x => x.MedecinId,
                        principalTable: "Medecins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DossiersMedical_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DossiersMedical_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Consultations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Motif = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diagnostic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DossierMedicalId = table.Column<int>(type: "int", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consultations_DossiersMedical_DossierMedicalId",
                        column: x => x.DossierMedicalId,
                        principalTable: "DossiersMedical",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Consultations_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Medicament = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dosage = table.Column<int>(type: "int", nullable: false),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duree = table.Column<string>(type: "nvarchar(48)", nullable: false),
                    Etat = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    ConsultationId = table.Column<int>(type: "int", nullable: false),
                    DossierMedicalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescription_Consultations_ConsultationId",
                        column: x => x.ConsultationId,
                        principalTable: "Consultations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescription_DossiersMedical_DossierMedicalId",
                        column: x => x.DossierMedicalId,
                        principalTable: "DossiersMedical",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prescription_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_DossierMedicalId",
                table: "Consultations",
                column: "DossierMedicalId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_SessionId",
                table: "Consultations",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_DossiersMedical_MedecinId",
                table: "DossiersMedical",
                column: "MedecinId");

            migrationBuilder.CreateIndex(
                name: "IX_DossiersMedical_PatientId",
                table: "DossiersMedical",
                column: "PatientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DossiersMedical_SessionId",
                table: "DossiersMedical",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_MedecinId",
                table: "Patients",
                column: "MedecinId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_ConsultationId",
                table: "Prescription",
                column: "ConsultationId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_DossierMedicalId",
                table: "Prescription",
                column: "DossierMedicalId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_PatientId",
                table: "Prescription",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_MedecinId",
                table: "Sessions",
                column: "MedecinId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "Consultations");

            migrationBuilder.DropTable(
                name: "DossiersMedical");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Medecins");
        }
    }
}
