using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerModule
{
    public float Power { get; private set; }

    public float Heat { get; private set; }

    public void UsePower( float powerToUse )
    {
        Power -= powerToUse;
    }

    public PowerModule()
    {
        Power = 1000;
    }
}
