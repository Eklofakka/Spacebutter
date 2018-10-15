using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipContainer : MonoBehaviour
{
    public Ship Ship;

    private void Start()
    {
        

        Layout layout = new Layout( 10, 10 );

        Ship = new Ship( layout );

        GetComponent<LayoutContainer>().GenerateTiles(Ship.Layout);


    }
}
