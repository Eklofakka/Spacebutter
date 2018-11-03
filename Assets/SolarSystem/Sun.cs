using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : SolarSystemBody
{
    public Sun()
    {
        Name = Random.Range(1000, 9999).ToString();
    }

    public override string RadarInfo()
    {
        return "Sun: " + Name;
    }
}
