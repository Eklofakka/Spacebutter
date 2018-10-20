using UnityEngine;

public class ShipPosition
{
    public Vector2 Galaxy = new Vector2(0, 0);

    public Vector2 Solar = new Vector2(0, 0);

    private Vector2 GalaxyTarget = Vector2.zero;

    public void TravelGalaxy()
    {
        //Galaxy += new Vector2( 4f, 4f ) * Time.deltaTime;

        Galaxy = Vector2.MoveTowards(Galaxy, GalaxyTarget, 4f * Time.deltaTime);
    }

    public void SetGalaxyDestination( Vector3 pos )
    {
        GalaxyTarget = pos;
    }
}