using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constellation 
{
    public string Name { get; set; }

    public List<SolarSystem> SolarSystems { get; set; }

    public Constellation( string name )
    {
        Name = name;

        SolarSystems = new List<SolarSystem>();
    }

    public SolarSystem SolarSystemByPosition( Vector2Int pos )
    {
        foreach (var system in SolarSystems)
        {
            if (system.Position == pos) return system;
        }

        return null;
    }
}
