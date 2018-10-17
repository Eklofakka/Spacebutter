using UnityEngine;

public class ShipPosition
{
    public Vector2 Galaxy = new Vector2(0, 0);

    public Vector2 Solar = new Vector2(0, 0);

    public void TravelGalaxy()
    {
        Galaxy += new Vector2( 0.1f, 0.1f ) * Time.deltaTime;
    }
}