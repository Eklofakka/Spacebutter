using UnityEngine;

public class ShipPosition
{
    public Vector2 Solar = new Vector2(0, 0);
    public int SolarID = 0;

    public bool Moving = false;

    public Vector2 SolarTarget = Vector2.zero;

    public void TravelSolar()
    {
        Solar = Vector2.MoveTowards(Solar, SolarTarget, 4f * Time.deltaTime);

        Moving = SolarTarget != Solar;
    }

    public void SetSolarDestination( Vector3 pos )
    {
        SolarTarget = pos;
    }

    public void JumpToGalaxy( int solarID, int solargateID )
    {
        SolarID = solarID;

        Solar = GalaxyHandler.SolarSystems[solarID].Stargates[0].Position + new Vector2(5, 5);

        SolarTarget = Solar;
    }

    public void JumpToGalaxy(Stargate target)
    {
        SolarID = target.SolarsystemID;

        Solar = target.Position + new Vector2(5, 5);

        SolarTarget = Solar;
    }
}