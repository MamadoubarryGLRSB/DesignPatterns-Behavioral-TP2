using PatternsBehavioral.Observer.Subjects;

namespace PatternsBehavioral;

/// <summary>
/// Classe principale du programme
/// Démontre l'utilisation des patterns Observer et Strategy pour un système de station météo
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== Système Météo avec Patterns Observer & Strategy ===\n");
        
        // Création de la station météo (sujet)
        var stationMeteo = new StationMeteo();
        
        // Création des observateurs
        var ecranStandard = new AffichageStandard("Écran Salon");
        var appMobile = new ApplicationMobile();
        var stationAlerte = new StationAlerte(30); // Alerte si > 30°C
        
        // Inscription des observateurs
        stationMeteo.AjouterObservateur(ecranStandard);
        stationMeteo.AjouterObservateur(appMobile);
        stationMeteo.AjouterObservateur(stationAlerte);
        
        // Première mesure
        stationMeteo.MesureTemperature(22.5);
        
        // Changement de stratégie pour l'écran standard (Celsius -> Fahrenheit)
        Console.WriteLine("\n=== Changement de stratégie d'affichage ===");
        ecranStandard.ChangerStrategyAffichage(new AffichageFahrenheit());
        
        // Nouvelle mesure
        stationMeteo.MesureTemperature(24.8);
        
        // Désabonnement d'un observateur
        Console.WriteLine("\n=== Suppression d'un observateur ===");
        stationMeteo.SupprimerObservateur(stationAlerte);
        
        // Changement de stratégie pour l'application mobile
        appMobile.ChangerStrategyAffichage(new AffichageFahrenheit());
        
        // Nouvelle mesure (sans la station d'alerte)
        stationMeteo.MesureTemperature(32.1);
        
        // Réabonnement de la station d'alerte avec une stratégie textuelle
        Console.WriteLine("\n=== Réabonnement d'un observateur avec nouvelle stratégie ===");
        stationAlerte.ChangerStrategyAffichage(new AffichageTextuel());
        stationMeteo.AjouterObservateur(stationAlerte);
        
        // Dernière mesure
        stationMeteo.MesureTemperature(31.5);
        
        Console.WriteLine("\n=== Fin du programme ===");
    }
}