using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.ViewModels;

public class ConsultationViewModel : ViewModelBase
{
    private DateTime _date;
    private string _motif;
    private string _observations;
    private string _diagnostic;

    public DateTime Date
    {
        get => _date;
        set => SetProperty(ref _date, value);
    }

    public string Motif
    {
        get => _motif;
        set => SetProperty(ref _motif, value);
    }

    public string Observations
    {
        get => _observations;
        set => SetProperty(ref _observations, value);
    }

    public string Diagnostic
    {
        get => _diagnostic;
        set => SetProperty(ref _diagnostic, value);
    }
} 