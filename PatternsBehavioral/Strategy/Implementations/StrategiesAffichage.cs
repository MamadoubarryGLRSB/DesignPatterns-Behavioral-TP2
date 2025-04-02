using PatternsBehavioral.Strategy.Interfaces;

namespace PatternsBehavioral;

/// <summary>
/// Stratégie d'affichage en Celsius (température brute)
/// </summary>
public class AffichageCelsius : IStrategyAffichage
{
    public string FormaterTemperature(double temperature)
    {
        return $"{Math.Round(temperature, 1)}°C";
    }
}

/// <summary>
/// Stratégie d'affichage en Fahrenheit (conversion de Celsius vers Fahrenheit)
/// </summary>
public class AffichageFahrenheit : IStrategyAffichage
{
    public string FormaterTemperature(double temperature)
    {
        // Formule de conversion : (°C × 9/5) + 32 = °F
        double fahrenheit = (temperature * 9 / 5) + 32;
        return $"{Math.Round(fahrenheit, 1)}°F";
    }
}

/// <summary>
/// Stratégie d'affichage avec description textuelle (chaud, froid, etc.)
/// </summary>
public class AffichageTextuel : IStrategyAffichage
{
    public string FormaterTemperature(double temperature)
    {
        string description;
        
        if (temperature < 0)
            description = "Glacial";
        else if (temperature < 10)
            description = "Très froid";
        else if (temperature < 20)
            description = "Frais";
        else if (temperature < 25)
            description = "Agréable";
        else if (temperature < 30)
            description = "Chaud";
        else
            description = "Très chaud";
            
        return $"{Math.Round(temperature, 1)}°C - {description}";
    }
}