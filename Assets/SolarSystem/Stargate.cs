using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Stargate : SolarSystemBody
{
    public Stargate Target { get; set; }

    public int SolarsystemID { get; set; }
    
    public Stargate( Vector2 stargateSolarPosition, int solarsystemID )
    {
        //Position = stargateSolarPosition;

        Position = new Vector2Int( Random.Range( -150, 150 ), Random.Range(-150, 150));

        SolarsystemID = solarsystemID;

        Name = "Stargate";
    }

    public override string RadarInfo()
    {
        //return Name + " -> " + ConstellationHandler.Constellation.SolarSystems.First( s => s.SolarsystemID == Target.SolarsystemID ).Name;
        Debug.Log( "Target: null " + Target == null );
        SolarSystem solarSystem = ConstellationHandler.Constellation.SolarSystems[Target.SolarsystemID];

        Debug.Log( solarSystem == null );

        return Name + " -> " + solarSystem.Name;
    }
}
