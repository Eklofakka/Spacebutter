using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship
{
    public Layout Layout { get; private set; }

    public ShipPosition Position;

    Vector2 ff = new Vector2(1, 1);


    public Ship (Layout layout)
    {
        Layout = layout;

        Position = new ShipPosition();
    }

    public virtual void Update(  )
    {
        // SHULD ONLY BE CALLED ON THE SERVER

        Position.TravelGalaxy();

        Vector2 f = Vector2.zero;
    }
}

