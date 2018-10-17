using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship
{
    public Layout Layout { get; private set; }

    public ShipPosition Position;

    public Ship (Layout layout)
    {
        Layout = layout;

        Position = new ShipPosition();
    }

    public virtual void Update(  )
    {
        // SHULD ONLY BE CALLED ON THE SERVER

        Position.TravelGalaxy();
    }
}

