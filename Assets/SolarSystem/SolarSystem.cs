using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem {

    public Vector2Int Position { get; set; }

    public string Name { get; set; }

    public List<Planet> Planets { get; set; }

    public List<Stargate> Stargates { get; set; }

    public Sun Sun { get; set; }

    public int SolarsystemID { get; set; }

    public SolarSystem( int id )
    {
        SolarsystemID = id;

        Position = new Vector2Int(Random.Range(0, 500), Random.Range(0, 500));

        Name = Planet.Names[UnityEngine.Random.Range(0, Planet.Names.Count)];

        Planets = new List<Planet>();

        Sun = new Sun();

        Stargates = new List<Stargate>();

        GeneratePlanets();

        GenerateStargates();
    }

    public SolarSystem(int id, Vector2Int position)
    {
        SolarsystemID = id;

        Position = position;

        Name = Planet.Names[UnityEngine.Random.Range(0, Planet.Names.Count)];

        Planets = new List<Planet>();

        Sun = new Sun();

        Stargates = new List<Stargate>();
    }

    private void GeneratePlanets()
    {
        int numPlanets = 10;

        Tuple<Vector2, int> Point = new Tuple<Vector2, int>(Vector2.zero, 0);

        for (int i = 0; i < numPlanets; i++)
        {
            Point = CalculatePoint(Point.Second, 50, 100);

            Planets.Add( new Planet( Point.First ) );
        }
    }

    private void GenerateStargates()
    {
        Stargates.Add( new Stargate( CalculatePoint( 0, 50, 200 ).First, SolarsystemID) );
    }

    private Tuple<Vector2, int> CalculatePoint(int previousRange, int minDist, int maxDist )
    {
        int radius = previousRange + Random.Range(minDist, maxDist);

        var angle = Random.Range(0.0f, 1.0f) * (Mathf.PI * 2);
        var x = radius * Mathf.Cos(angle);
        var y = radius * Mathf.Sin(angle);
        return new Tuple<Vector2, int>(new Vector2((int)x, (int)y), radius);
    }
}
