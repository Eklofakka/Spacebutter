using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GalaxyHandler
{
    private static Dictionary<int, SolarSystem> _SolarSystems;
    public static Dictionary<int, SolarSystem> SolarSystems
    {
        get
        {
            if (_SolarSystems == null)
                GenerateGalaxy();

            return _SolarSystems;
        }
        set
        {
            _SolarSystems = value;
        }
    }

    public static void GenerateGalaxy()
    {
        if (_SolarSystems == null)
        {
            SolarSystems = new Dictionary<int, SolarSystem>()
            {
                { 0, new SolarSystem(0) },
                { 1, new SolarSystem(1) }
            };


            ConnectStargates();
        }
    }

    private static void ConnectStargates()
    {
        Stargate first = SolarSystems[0].Stargates[0];
        Stargate second = SolarSystems[1].Stargates[0];

        first.Target = second;
        second.Target = first;
    }
}
