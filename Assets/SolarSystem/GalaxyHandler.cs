using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GalaxyHandler
{
    public static Dictionary<int, SolarSystem> SolarSystems = new Dictionary<int, SolarSystem>()
    {
        { 0, new SolarSystem(0) },
        { 1, new SolarSystem(1) }
    };

    public static void GenerateGalaxy()
    {

    }

    private static void ConnectStargates()
    {
        Stargate first = SolarSystems[0].Stargates[0];
        Stargate second = SolarSystems[1].Stargates[1];

        first.Target = second;
        second.Target = first;
    }
}
