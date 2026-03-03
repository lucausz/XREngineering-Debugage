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
        Debug.Log("Le contrôleur déplace " + planets.Length + " planètes à la date : " + time);
        foreach (var planet in planets)
        {
            Vector3 pos = ephemeris.GetPlanetPosition(planet.planet, time);
            Vector3 finalPos = pos * config.distanceScale;
            planet.SetPosition(finalPos);
            if(planet.planet == PlanetData.Planet.Earth) {
                Debug.Log($"[MATH] Terre - Brute: {pos} | Scale: {config.distanceScale} | Finale: {finalPos}");
            }
        }
    }
}
