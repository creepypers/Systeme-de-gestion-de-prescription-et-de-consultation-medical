# Système de Gestion de Consultation et Prescription Médicale (SGCP)

![Build Status](https://img.shields.io/badge/build-passing-brightgreen)
![Platform](https://img.shields.io/badge/platform-windows-lightgrey)
![.NET](https://img.shields.io/badge/.NET-8.0-blue)
![License](https://img.shields.io/badge/license-MIT-green)

## Vue d'ensemble

Le Système de Gestion de Consultation et Prescription Médicale (SGCP) est une application de bureau robuste développée en WPF et .NET 8, conçue pour faciliter la gestion quotidienne des cliniques médicales. Ce projet sert de démonstration technique pour l'implémentation d'une **Architecture Clean** (Clean Architecture), respectant les principes SOLID et les meilleures pratiques de développement logiciel moderne.

L'application permet aux professionnels de santé de gérer efficacement les dossiers patients, les consultations, les diagnostics et les prescriptions médicamenteuses au sein d'une interface unifiée et sécurisée.

## Fonctionnalités Clés

*   **Gestion des Patients** : Création, modification et consultation des dossiers patients avec historique complet.
*   **Consultations Médicales** : Enregistrement des visites, saisie des diagnostics et observations cliniques.
*   **Prescriptions** : Génération et suivi des prescriptions médicamenteuses liées aux consultations.
*   **Authentification Sécurisée** : Système de connexion pour les médecins garantissant la confidentialité des données.
*   **Historique Médical** : Vue d'ensemble des traitements et antécédents médicaux par patient.
*   **Architecture Modulaire** : Conception découplée facilitant la maintenance et l'évolution du code.

## Architecture Technique

Ce projet suit strictement les principes de la **Clean Architecture** pour assurer l'indépendance des frameworks, de l'interface utilisateur et de la base de données.

La solution est divisée en quatre couches principales :

1.  **SGCP.Core (Domaine & Application)** : Contient les entités métier, les règles d'affaires, les interfaces (ports) et les services. Cette couche ne dépend d'aucun détail technique externe.
2.  **SGCP.Infra (Infrastructure)** : Implémente les interfaces définies dans le Core. Elle gère l'accès aux données (Entity Framework Core), les communications externes et les services d'infrastructure.
3.  **SGCP.UI (Présentation)** : L'interface utilisateur WPF (Windows Presentation Foundation) qui interagit avec la couche Core via des ViewModels et l'injection de dépendances.
4.  **SGCP.Shared (Noyau Partagé)** : Contient les éléments transversaux et les utilitaires communs à toutes les couches.

### Technologies Utilisées

*   **Langage** : C# 12
*   **Framework** : .NET 8.0
*   **Interface Utilisateur** : WPF (Windows Presentation Foundation)
*   **ORM** : Entity Framework Core 9.0
*   **Base de Données** : SQL Server (LocalDB)
*   **Injection de Dépendances** : Microsoft.Extensions.DependencyInjection

## Guide de Démarrage

### Prérequis

*   SDK .NET 8.0 ou supérieur
*   Visual Studio 2022 (recommandé) ou VS Code
*   SQL Server LocalDB (inclus avec Visual Studio)

### Installation

1.  **Cloner le dépôt**
    ```bash
    git clone https://github.com/creepypers/Systeme-de-gestion-de-prescription-et-de-consultation-medical.git
    cd Systeme-de-gestion-de-prescription-et-de-consultation-medical
    ```

2.  **Restaurer les dépendances**
    ```bash
    dotnet restore
    ```

3.  **Configuration de la Base de Données**
    Appliquez les migrations pour créer la base de données locale.
    ```bash
    dotnet ef database update --project SGCP.Infra --startup-project SGCP.UI
    ```

4.  **Compilation et Exécution**
    ```bash
    dotnet build
    dotnet run --project SGCP.UI
    ```

## Utilisation

### Connexion

Pour accéder à l'application, utilisez les identifiants de démonstration suivants :

*   **Nom d'utilisateur** : `dr.house`
*   **Mot de passe** : `password`

### Navigation

*   **Tableau de bord** : Vue d'ensemble des activités récentes.
*   **Patients** : Recherche et gestion des fiches patients.
*   **Consultations** : Création de nouvelles consultations pour un patient sélectionné.

## Contribution

Les contributions sont encouragées pour améliorer ce projet académique et technique.

1.  Forkez le projet.
2.  Créez votre branche de fonctionnalité (`git checkout -b feature/MaNouvelleFonctionnalite`).
3.  Commitez vos changements (`git commit -m 'Ajout de MaNouvelleFonctionnalite'`).
4.  Poussez vers la branche (`git push origin feature/MaNouvelleFonctionnalite`).
5.  Ouvrez une Pull Request.

## Licence

Ce projet est distribué sous licence MIT. Voir le fichier `LICENSE` pour plus d'informations.

---
*Développé dans le cadre d'un projet d'architecture logicielle à l'Université du Québec à Rimouski (UQAR).*
