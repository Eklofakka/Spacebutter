using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHandler : MonoBehaviour
{
    // This script will keep the ship's 'pulse' going.
    // Providing with the Update event.
    public static ShipHandler Instance;

    public Ship ActiveShip { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ActiveShip = LevelLoaderShip.Instance.LoadShip("Rookie");

        ActiveShip.Start();
    }

    private void Update()
    {
        ActiveShip.Update();
    }
}



