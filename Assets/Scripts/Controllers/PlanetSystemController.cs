using System;
using UnityEngine;

public class PlanetSystemController
{
    TimeModel timeModel;
    IPlanetEphemerisService ephemeris;

    PlanetView[] planets;

    SolarSystemConfig config;

    public PlanetSystemController(
        TimeModel timeModel,
        IPlanetEphemerisService ephemeris,
        PlanetView[] planets,
        SolarSystemConfig config)
    {
        this.timeModel = timeModel;
        this.ephemeris = ephemeris;
        this.planets = planets;
        this.config = config;

        timeModel.OnTimeChanged += UpdatePlanets;
    }

    void UpdatePlanets(DateTime time)
    {
        foreach (var planet in planets)
        {
            Vector3 pos = ephemeris.GetPlanetPosition(planet.planet, time);
            Vector3 finalPos = pos * config.distanceScale;
            planet.SetPosition(finalPos);
        }
    }

    // Ajoute cette méthode dans la classe PlanetSystemController
public void InitializeOrbits(int resolution = 100)
{
    foreach (var planetView in planets)
    {
        
        Vector3[] orbitPoints = new Vector3[resolution];
        
        // On calcule la durée d'une année pour cette planète (approximative)
        // Note : On peut simplifier en prenant 365 jours pour tout le monde au début
        DateTime startDate = DateTime.Now;

        for (int i = 0; i < resolution; i++)
        {
            // On avance dans le temps pour simuler un tour complet
            // On divise 365 jours par la résolution (ex: 100 points)
            float dayOffset = (365f / resolution) * i;
            DateTime orbitDate = startDate.AddDays(dayOffset);

            Vector3 rawPos = ephemeris.GetPlanetPosition(planetView.planet, orbitDate);
            
            // TRÈS IMPORTANT : Appliquer la même échelle que pour les planètes !
            orbitPoints[i] = rawPos * config.distanceScale;
        }

    }
}
}
