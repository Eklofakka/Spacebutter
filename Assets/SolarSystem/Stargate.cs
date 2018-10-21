using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stargate : SolarSystemBody
{
    public Stargate Target { get; set; }

    public int SolarsystemID { get; set; }
    
    public Stargate( Vector2 position, int solarsystemID )
    {
        Position = position;

        SolarsystemID = solarsystemID;

        Name = "Stargate";
    }

    public override string RadarInfo()
    {
        return Name + " -> " + GalaxyHandler.SolarSystems[Target.SolarsystemID].Name;
    }
}
