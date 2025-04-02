using PatternsBehavioral.Observer.Interfaces;

namespace PatternsBehavioral.Observer.Subjects;

/// <summary>
/// Classe principale implémentant le pattern Observer (en tant que sujet)
/// Notifie tous les observateurs des changements de température
/// </summary>
public class StationMeteo
{
    private List<IObservateur> _observateurs = new List<IObservateur>();
    private double _temperature;

    /// <summary>
    /// Température actuelle de la station météo
    /// </summary>
    public double Temperature
    {
        get { return _temperature; }
        private set
        {
            // Mise à jour de la température et notification
            _temperature = value;
            NotifierObservateurs();
        }
    }

    /// <summary>
    /// Ajoute un observateur à la liste des abonnés
    /// </summary>
    /// <param name="observateur">L'observateur à ajouter</param>
    public void AjouterObservateur(IObservateur observateur)
    {
        _observateurs.Add(observateur);
        Console.WriteLine("Nouvel observateur ajouté.");
    }

    /// <summary>
    /// Supprime un observateur de la liste des abonnés
    /// </summary>
    /// <param name="observateur">L'observateur à supprimer</param>
    public void SupprimerObservateur(IObservateur observateur)
    {
        _observateurs.Remove(observateur);
        Console.WriteLine("Observateur supprimé.");
    }

    /// <summary>
    /// Notifie tous les observateurs d'un changement de température
    /// </summary>
    private void NotifierObservateurs()
    {
        foreach (var observateur in _observateurs)
        {
            observateur.MettreAJour(_temperature);
        }
    }

    /// <summary>
    /// Simule une mesure de température et met à jour la valeur
    /// </summary>
    /// <param name="nouvelleTemperature">La nouvelle température mesurée</param>
    public void MesureTemperature(double nouvelleTemperature)
    {
        Console.WriteLine($"\nNouvelle température mesurée : {nouvelleTemperature}°C");
        Temperature = nouvelleTemperature;
    }
}