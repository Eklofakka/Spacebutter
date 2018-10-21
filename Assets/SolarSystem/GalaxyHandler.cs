using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GalaxyHandler
{
    public static Dictionary<int, SolarSystem> SolarSystems;

    public static void GenerateGalaxy()
    {
        if ( SolarSystems == null )
            SolarSystems = new Dictionary<int, SolarSystem>()
            {
                { 0, new SolarSystem(0) },
                { 1, new SolarSystem(1) }
            };


        ConnectStargates();
    }

    private static void ConnectStargates()
    {
        Stargate first = SolarSystems[0].Stargates[0];
        Stargate second = SolarSystems[1].Stargates[0];

        first.Target = second;
        second.Target = first;
    }
}
