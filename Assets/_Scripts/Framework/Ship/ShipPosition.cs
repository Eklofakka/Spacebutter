using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using MEC;

public class ShipPosition
{
    public Vector2 Solar = new Vector2(0, 0);
    public int SolarID = 0;

    public bool Moving = false;

    public Vector2 SolarTarget = Vector2.zero;

    public System.Action OnReachedTargetPosition { get; set; } = delegate { };

    public void TravelSolar()
    {
        Moving = SolarTarget != Solar;

        if (Moving)
        {
            Solar = Vector2.MoveTowards(Solar, SolarTarget, 4f * Time.deltaTime);

            Moving = SolarTarget != Solar;

            if (Moving == false)
                OnReachedTargetPosition();
        }
    }

    public void SetSolarDestination( Vector3 pos )
    {
        SolarTarget = pos;
    }

    public void SetSolarDestination(Vector2 pos)
    {
        SolarTarget = pos;
    }

    public void JumpToGalaxy( int solarID, int solargateID )
    {
        SolarID = solarID;

        // TODO: This method needs access to the 'From' stargate.
        //Solar = ConstellationHandler.SolarSystems[solarID].Stargates[0].Position + new Vector2(5, 5);
        //Solar = ConstellationHandler.Constellation.SolarSystems[solarID].

        //SolarTarget = Solar;
    }

    public void JumpToGalaxy(Stargate target)
    {
        SolarID = target.SolarsystemID;

        Solar = target.Position + new Vector2(5, 5);

        SolarTarget = Solar;
    }
}