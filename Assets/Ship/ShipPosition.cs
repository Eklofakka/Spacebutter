﻿using UnityEngine;

public class ShipPosition
{
    public Vector2 Solar = new Vector2(0, 0);
    public int SolarID = 0;


    private Vector2 SolarTarget = Vector2.zero;

    public void TravelSolar()
    {
        Solar = Vector2.MoveTowards(Solar, SolarTarget, 4f * Time.deltaTime);
    }

    public void SetSolarDestination( Vector3 pos )
    {
        SolarTarget = pos;
    }

    public void JumpToGalaxy( int solarID, Vector2 gatePos )
    {
        SolarID = solarID;

        Solar = gatePos + new Vector2(5, 5);

        SolarTarget = Solar;
    }
}