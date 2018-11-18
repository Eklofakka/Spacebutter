using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShip : SolarSystemBody
{
    public ShipPosition Positions;

    public AIShip( )
    {
        Positions = new ShipPosition();

        Positions.Solar = new Vector2((int)Random.Range( -300, 300 ), (int)Random.Range(-300, 300));

        Positions.OnReachedTargetPosition += NeedNewTargetPosition;

        NeedNewTargetPosition();
    }

    public override string RadarInfo()
    {
        return "AI Ship";
    }

    public void Tick()
    {
        Positions.TravelSolar();
    }

    private void NeedNewTargetPosition()
    {
        int ran = Random.Range(0, 100);

        if ( ran >= 0 && ran <= 70 )
        {
            var planets = ConstellationHandler.Constellation.SolarSystems[0].Planets;
            var stargate = ConstellationHandler.Constellation.SolarSystems[0].Stargates;
            int vals = planets.Count + stargate.Count;

            ran = Random.Range(0, vals);

            if ( ran >= planets.Count )
            {
                Positions.SetSolarDestination( stargate[ ran - planets.Count ].Position);
            }
            else
            {
                Positions.SetSolarDestination( planets[ran].Position);
            }
        }
        else if ( ran > 70 && ran <= 90)
        {
            Positions.SetSolarDestination(new Vector2((int)Random.Range(-300, 300), (int)Random.Range(-300, 300)));
        }
        else
        {
            Positions.SetSolarDestination( Vector2.zero );
        }
    }
}
