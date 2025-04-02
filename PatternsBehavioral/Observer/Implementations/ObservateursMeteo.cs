using PatternsBehavioral.Observer.Interfaces;
using PatternsBehavioral.Strategy.Interfaces;

namespace PatternsBehavioral;

/// <summary>
/// Observateur pour affichage sur un écran standard
/// </summary>
public class AffichageStandard : IObservateur
{
    private IStrategyAffichage _strategyAffichage;
    private string _nom;

    /// <summary>
    /// Constructeur avec stratégie d'affichage par défaut
    /// </summary>
    /// <param name="nom">Nom de l'affichage</param>
    public AffichageStandard(string nom)
    {
        _nom = nom;
        _strategyAffichage = new AffichageCelsius(); // Stratégie par défaut
    }

    /// <summary>
    /// Change la stratégie d'affichage (pattern Strategy)
    /// </summary>
    /// <param name="strategy">La nouvelle stratégie à utiliser</param>
    public void ChangerStrategyAffichage(IStrategyAffichage strategy)
    {
        _strategyAffichage = strategy;
        Console.WriteLine($"{_nom} a changé sa stratégie d'affichage.");
    }

    /// <summary>
    /// Mise à jour avec la nouvelle température (pattern Observer)
    /// </summary>
    /// <param name="temperature">La nouvelle température</param>
    public void MettreAJour(double temperature)
    {
        string temperatureFormatee = _strategyAffichage.FormaterTemperature(temperature);
        Console.WriteLine($"[{_nom}] Température actuelle : {temperatureFormatee}");
    }
}

/// <summary>
/// Observateur pour une application mobile
/// </summary>
public class ApplicationMobile : IObservateur
{
    private IStrategyAffichage _strategyAffichage;
    private double _temperaturePrecedente;
    private bool _premiereMesure = true;

    public ApplicationMobile()
    {
        _strategyAffichage = new AffichageTextuel(); // Par défaut : affichage textuel
    }

    /// <summary>
    /// Change la stratégie d'affichage (pattern Strategy)
    /// </summary>
    /// <param name="strategy">La nouvelle stratégie à utiliser</param>
    public void ChangerStrategyAffichage(IStrategyAffichage strategy)
    {
        _strategyAffichage = strategy;
        Console.WriteLine("Application mobile a changé sa stratégie d'affichage.");
    }

    /// <summary>
    /// Mise à jour avec la nouvelle température (pattern Observer)
    /// </summary>
    /// <param name="temperature">La nouvelle température</param>
    public void MettreAJour(double temperature)
    {
        string temperatureFormatee = _strategyAffichage.FormaterTemperature(temperature);
        
        Console.WriteLine($"[App Mobile] Température actuelle : {temperatureFormatee}");
        
        // Affichage de la tendance (sauf pour la première mesure)
        if (!_premiereMesure)
        {
            double difference = temperature - _temperaturePrecedente;
            string tendance = difference > 0 
                ? $"↑ En hausse de {Math.Round(difference, 1)}°C" 
                : $"↓ En baisse de {Math.Round(Math.Abs(difference), 1)}°C";
                
            Console.WriteLine($"[App Mobile] Tendance : {tendance}");
        }
        
        _temperaturePrecedente = temperature;
        _premiereMesure = false;
    }
}

/// <summary>
/// Observateur pour une station d'alerte météo
/// </summary>
public class StationAlerte : IObservateur
{
    private IStrategyAffichage _strategyAffichage;
    private double _seuilAlerte;

    public StationAlerte(double seuilAlerte)
    {
        _strategyAffichage = new AffichageCelsius();
        _seuilAlerte = seuilAlerte;
    }

    /// <summary>
    /// Change la stratégie d'affichage (pattern Strategy)
    /// </summary>
    /// <param name="strategy">La nouvelle stratégie à utiliser</param>
    public void ChangerStrategyAffichage(IStrategyAffichage strategy)
    {
        _strategyAffichage = strategy;
        Console.WriteLine("Station d'alerte a changé sa stratégie d'affichage.");
    }

    /// <summary>
    /// Mise à jour avec la nouvelle température (pattern Observer)
    /// </summary>
    /// <param name="temperature">La nouvelle température</param>
    public void MettreAJour(double temperature)
    {
        string temperatureFormatee = _strategyAffichage.FormaterTemperature(temperature);
        Console.WriteLine($"[Station Alerte] Température reçue : {temperatureFormatee}");
        
        // Vérification du dépassement du seuil
        if (temperature > _seuilAlerte)
        {
            Console.WriteLine($"[Station Alerte] ALERTE ! La température dépasse le seuil de {_seuilAlerte}°C !");
        }
    }
}