using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Stargate : SolarSystemBody
{
    public Stargate Target { get; set; }

    public int SolarsystemID { get; set; }
    
    public Stargate( Vector2 stargateSolarPosition, int solarsystemID )
    {
        Position = new Vector2Int( Random.Range( -150, 150 ), Random.Range(-150, 150));

        SolarsystemID = solarsystemID;

        Name = Planet.Names[UnityEngine.Random.Range(0, Planet.Names.Count)];
    }

    public override string RadarInfo()
    {
        return Name + " -> " + ConstellationHandler.Constellation.SolarSystems[Target.SolarsystemID].Name;
    }
}
