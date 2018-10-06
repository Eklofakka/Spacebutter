using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerConsumer : MonoBehaviour {

    public static List<PowerConsumer> PowerConsumers = new List<PowerConsumer>();

    public float Consumption { get; private set; }

    public int ID { get; private set; }

    private void Awake()
    {
        ID = PowerConsumers.Count;

        PowerConsumers.Add( this );
    }
}
