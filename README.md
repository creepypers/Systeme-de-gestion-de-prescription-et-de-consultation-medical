# 🏥 Système de Gestion et de Consultation Médicale

[![.NET](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/download)
[![Entity Framework Core](https://img.shields.io/badge/EF%20Core-9.0-green.svg)](https://docs.microsoft.com/en-us/ef/core/)
[![WPF](https://img.shields.io/badge/WPF-Windows%20Presentation%20Foundation-purple.svg)](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/)
[![Clean Architecture](https://img.shields.io/badge/Architecture-Clean%20Architecture-orange.svg)](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)

## 📋 Description
Système de gestion médicale développé avec une architecture Clean, permettant la gestion des patients, dossiers médicaux, consultations et prescriptions. Ce projet démontre l'implémentation des principes SOLID et des patterns de conception dans une application .NET moderne.

## ✨ Fonctionnalités Principales
- 🔐 **Authentification sécurisée** des médecins
- 👥 **Gestion complète des patients** (CRUD)
- 📋 **Dossiers médicaux** avec historique des traitements
- 🩺 **Consultations** avec diagnostics et observations
- 💊 **Prescriptions** avec suivi des médicaments
- 📊 **Interface WPF** moderne et intuitive
- 🗄️ **Base de données** avec Entity Framework Core

## 🏗️ Architecture
- **Clean Architecture** avec séparation des couches
- **Entity Framework Core** pour la persistance des données
- **WPF** pour l'interface utilisateur
- **SQL Server LocalDB** pour la base de données

## 📁 Structure du Projet

```
Architecture Clean/
├── SGCP.Shared/     # Couche partagée
├── SGCP.Core/       # Logique métier
├── SGCP.Infra/      # Accès aux données
├── SGCP.UI/         # Interface WPF
└── SGCP.Test/       # Application de test
```

## 🔐 Identifiants de Connexion

### 👨‍⚕️ Médecins

| **Nom d'utilisateur** | **Mot de passe** | **Médecin** | **Numéro de licence** | **Email** |
|----------------------|------------------|-------------|----------------------|-----------|
| `dr.house` | `password` | Dr. Gregory House | HOUSE001 | g.house@hospital.com |

## 🚀 Démarrage Rapide

### 1. Prérequis
- .NET 8.0 SDK
- Visual Studio 2022 ou VS Code
- SQL Server LocalDB

### 2. Installation
```bash
# Cloner le projet
git clone [URL_DU_REPO]

# Naviguer vers le dossier
cd "Architecture Clean"

# Restaurer les packages
dotnet restore

# Construire la solution
dotnet build "Architecture Clean.sln"
```

### 3. Configuration de la Base de Données
```bash
# Créer la base de données
dotnet ef database update --project SystèmeGestionConsultationPrescriptions.Infrastructure --startup-project "SystèmeGestionConsultationPrescriptions.UserInterface/Systeme de gestion et de consultation medicale"
```

### 4. Exécution
```bash
# Lancer l'application
dotnet run --project "SystèmeGestionConsultationPrescriptions.UserInterface/Systeme de gestion et de consultation medicale"
```

## 📊 Données de Test

Le système inclut des données de test complètes :

### 👥 Patients (10 patients)
- Dupont Jean (1980) - Dr. Admin
- Martin Marie (1975) - Dr. Dupont
- Bernard Pierre (1990) - Dr. Admin
- Dubois Sophie (1985) - Dr. Dupont
- Lavoie Michel (1972) - Dr. Martin
- Gagnon Julie (1988) - Dr. Martin
- Roy André (1965) - Dr. Leblanc
- Bouchard Caroline (1995) - Dr. Leblanc
- Morin David (1982) - Dr. Tremblay
- Pelletier Isabelle (1978) - Dr. Tremblay

### 📋 Dossiers Médicaux
- Un dossier médical pour chaque patient
- Traitements passés (Amoxicilline, Ibuprofène, Paracétamol)
- Dates de création échelonnées

### 🩺 Consultations (8 consultations)
- **Motifs variés** : Consultation de routine, Douleur thoracique, Maux de tête, etc.
- **Diagnostics réalistes** : Hypertension, Migraine, Reflux gastro-œsophagien, etc.
- **Observations détaillées** pour chaque consultation

### 💊 Prescriptions (4 prescriptions)
- **Médicaments** : Amoxicilline, Ibuprofène, Paracétamol, Oméprazole, Métoprolol, Metformine
- **Posologies réalistes** avec instructions détaillées
- **Durées de traitement** adaptées

## 🛠️ Commandes Utiles

### Entity Framework Core
```bash
# Lister les migrations
dotnet ef migrations list --project SystèmeGestionConsultationPrescriptions.Infrastructure --startup-project "SystèmeGestionConsultationPrescriptions.UserInterface/Systeme de gestion et de consultation medicale"

# Créer une nouvelle migration
dotnet ef migrations add NomDeLaMigration --project SystèmeGestionConsultationPrescriptions.Infrastructure --startup-project "SystèmeGestionConsultationPrescriptions.UserInterface/Systeme de gestion et de consultation medicale"

# Mettre à jour la base de données
dotnet ef database update --project SystèmeGestionConsultationPrescriptions.Infrastructure --startup-project "SystèmeGestionConsultationPrescriptions.UserInterface/Systeme de gestion et de consultation medicale"

# Supprimer la base de données
dotnet ef database drop --project SystèmeGestionConsultationPrescriptions.Infrastructure --startup-project "SystèmeGestionConsultationPrescriptions.UserInterface/Systeme de gestion et de consultation medicale" --force
```

### Package Manager Console (Visual Studio)
```powershell
# Lister les migrations
Get-Migration -Project SystèmeGestionConsultationPrescriptions.Infrastructure -StartupProject "SystèmeGestionConsultationPrescriptions.UserInterface\Systeme de gestion et de consultation medicale"

# Créer une migration
Add-Migration NomDeLaMigration -Project SystèmeGestionConsultationPrescriptions.Infrastructure -StartupProject "SystèmeGestionConsultationPrescriptions.UserInterface\Systeme de gestion et de consultation medicale"

# Mettre à jour la base de données
Update-Database -Project SystèmeGestionConsultationPrescriptions.Infrastructure -StartupProject "SystèmeGestionConsultationPrescriptions.UserInterface\Systeme de gestion et de consultation medicale"
```

## 🏗️ Architecture Clean

### Couches
1. **SharedKernel** : Entités de base et interfaces communes
2. **Core** : Logique métier, entités, services et interfaces
3. **Infrastructure** : Implémentation des repositories, DbContext
4. **UserInterface** : Interface WPF et configuration DI

### Principes
- **Séparation des responsabilités**
- **Inversion de dépendance**
- **Injection de dépendances**
- **Repository Pattern**
- **Service Layer Pattern**

## 📝 Fonctionnalités

### ✅ Implémentées
- [x] Authentification des médecins
- [x] Gestion des patients (CRUD)
- [x] Gestion des dossiers médicaux (CRUD)
- [x] Gestion des consultations (CRUD)
- [x] Gestion des prescriptions (CRUD)
- [x] Sessions de médecins
- [x] Traitements passés
- [x] Seeding de données de test

### 🔄 Relations
- **Médecin** ↔ **Patient** (One-to-Many)
- **Patient** ↔ **Dossier Médical** (One-to-One)
- **Dossier Médical** ↔ **Consultation** (One-to-Many)
- **Consultation** ↔ **Prescription** (One-to-Many)
- **Médecin** ↔ **Session** (One-to-Many)

## 🐛 Résolution de Problèmes

### Erreur "Could not find a part of the path"
```bash
# Nettoyer et reconstruire
dotnet clean
dotnet build
```

### Erreur "Class Library cannot be started directly"
- Vérifier que le projet de démarrage est défini sur `SystèmeGestionConsultationPrescriptions.UserInterface`

### Erreur "GetEFProjectMetadata does not exist"
- Vérifier que le package `Microsoft.EntityFrameworkCore.Design` est installé dans le projet UI

## 📞 Support

Pour toute question ou problème :
1. Vérifier les logs de l'application
2. Consulter la documentation Entity Framework Core
3. Vérifier la configuration de la base de données

## 🤝 Contribution

Les contributions sont les bienvenues ! Pour contribuer :

1. Fork le projet
2. Créer une branche pour votre fonctionnalité (`git checkout -b feature/AmazingFeature`)
3. Commit vos changements (`git commit -m 'Add some AmazingFeature'`)
4. Push vers la branche (`git push origin feature/AmazingFeature`)
5. Ouvrir une Pull Request

## 📝 Changelog

### Version 1.0.0
- ✅ Authentification des médecins
- ✅ Gestion complète des patients (CRUD)
- ✅ Gestion des dossiers médicaux (CRUD)
- ✅ Gestion des consultations (CRUD)
- ✅ Gestion des prescriptions (CRUD)
- ✅ Interface WPF moderne
- ✅ Base de données avec Entity Framework Core
- ✅ Données de test complètes

## 🎯 Roadmap

- [ ] Interface web (Blazor/React)
- [ ] API REST
- [ ] Authentification JWT
- [ ] Rapports et statistiques
- [ ] Notifications en temps réel
- [ ] Support multi-langues
- [ ] Tests unitaires et d'intégration

## 📸 Captures d'écran

> *Captures d'écran de l'interface utilisateur à ajouter*

## 🏆 Réalisations

- ✅ Architecture Clean respectée
- ✅ Principes SOLID appliqués
- ✅ Patterns de conception implémentés
- ✅ Séparation des responsabilités
- ✅ Code maintenable et extensible

## 📄 Licence

Ce projet est développé dans le cadre d'un TP d'architecture logicielle.

## 👨‍💻 Auteur

**Étudiant en Informatique*
- Université du Québec à Rimouski (UQAR)

## 🙏 Remerciements

- Professeurs et assistants pour l'encadrement
- Communauté .NET pour la documentation
- Équipe Entity Framework Core pour l'ORM

---

**Développé avec ❤️ en utilisant Clean Architecture et .NET 8**

[![GitHub stars](https://img.shields.io/github/stars/username/repo.svg?style=social&label=Star)](https://github.com/creepypers/repo)
[![GitHub forks](https://img.shields.io/github/forks/username/repo.svg?style=social&label=Fork)](https://github.com/creepypers/repo/fork)
[![GitHub watchers](https://img.shields.io/github/watchers/username/repo.svg?style=social&label=Watch)](https://github.com/creepypers/repo)
