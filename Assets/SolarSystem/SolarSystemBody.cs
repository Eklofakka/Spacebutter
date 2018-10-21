using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SolarSystemBody
{
    public Vector2 Position { get; set; }

    public string Name { get; set; }

    public abstract string RadarInfo();
}
