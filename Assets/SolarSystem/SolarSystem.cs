using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem {

    public SolarSystem()
    {
        Name = Random.Range(1000, 9999).ToString();

        Planets = new List<Planet>();

        Sun = new Sun();

        GeneratePlanets();
    }

    public string Name { get; set; }

    public List<Planet> Planets { get; set; }

    public Sun Sun { get; set; }

    private void GeneratePlanets()
    {
        int numPlanets = Random.Range(0, 10);

        for (int i = 0; i < numPlanets; i++)
        {
            Planets.Add( new Planet() );
        }
    }
}
