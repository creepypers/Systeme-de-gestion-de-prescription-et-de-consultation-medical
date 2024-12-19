using SystèmeGestionConsultationPrescriptions.Core.Entities;

namespace SystèmeGestionConsultationPrescriptions.Core.Interfaces
{
    public interface IAuthenticationService
    {
        string HashPassword(string password);
        Medecin VerifierCredentials(string username, string hashedPassword);
    }
} 