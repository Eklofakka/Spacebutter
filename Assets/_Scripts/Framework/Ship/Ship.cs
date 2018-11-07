using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ship
{
    public Layout Layout { get; private set; }

    public ShipPosition Position;

    public ShipRadar Radar;

    public Ship (Layout layout)
    {
        Layout = layout;

        Position = new ShipPosition();

        Radar = new ShipRadar();
    }

    public virtual void Update(  )
    {
        // SHULD ONLY BE CALLED ON THE SERVER

        Position.TravelSolar();
        
        Radar.Scan( ConstellationHandler.Constellation.SolarSystems[Position.SolarID] );
    }
}