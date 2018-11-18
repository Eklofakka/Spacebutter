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
        Positions.SetSolarDestination(new Vector2((int)Random.Range(-300, 300), (int)Random.Range(-300, 300)));
    }
}
