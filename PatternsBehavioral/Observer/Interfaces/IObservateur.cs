namespace PatternsBehavioral.Observer.Interfaces;
/// <summary>
/// Interface pour le pattern Observer : définit le contrat pour tous les observateurs météo
/// </summary>
public interface IObservateur
{
    /// <summary>
    /// Méthode appelée par le sujet (StationMeteo) pour notifier d'un changement
    /// </summary>
    /// <param name="temperature">La nouvelle température mesurée</param>
    void MettreAJour(double temperature);
}