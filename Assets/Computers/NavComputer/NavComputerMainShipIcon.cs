using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavComputerMainShipIcon : MonoBehaviour {

    private void Update()
    {
        transform.localPosition = Ship.MainShip.Position.ToV3();
    }
}