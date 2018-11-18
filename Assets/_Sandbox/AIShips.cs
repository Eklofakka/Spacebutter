using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShips : MonoBehaviour
{
    public static List<AIShip> Ships = new List<AIShip>();

    void Start()
    {
        AddNewShips();
    }

    void Update()
    {
        foreach (var ship in Ships)
        {
            ship.Tick();
        }
    }

    private void AddNewShips()
    {
        for (int i = 0; i < 100; i++)
        {
            Ships.Add(new AIShip());
        }
    }
}
