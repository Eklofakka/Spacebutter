using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCore : MonoBehaviour {

    public static List<PowerCore> PowerCores = new List<PowerCore>();

    public int ID
    {
        get; private set;
    }

    public float Production { get; private set; }

    private void Awake()
    {
        ID = PowerCores.Count;

        PowerCores.Add(this);
    }
}
