namespace PatternsBehavioral.Strategy.Interfaces;

/// <summary>
/// Interface pour le pattern Strategy : définit différentes stratégies d'affichage de température
/// </summary>
public interface IStrategyAffichage
{
    /// <summary>
    /// Formate la température selon une stratégie spécifique
    /// </summary>
    /// <param name="temperature">La température brute à formater</param>
    /// <returns>La température formatée selon la stratégie</returns>
    string FormaterTemperature(double temperature);
}