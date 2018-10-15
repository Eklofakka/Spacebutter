using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoaderShip : MonoBehaviour
{
    public SOBlueprint ActiveShip;

    private void Start()
    {
        ActiveShip = Resources.Load<SOBlueprint>("Rookie");
    }

}
