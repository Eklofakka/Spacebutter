using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ship
{
    public Layout Layout { get; private set; }

    public ShipPosition Position { get; private set; }

    public ShipRadar Radar { get; private set; }

    public WarpEngine WarpEngine { get; private set; }

    public Ship (Layout layout)
    {
        Layout = layout;

        Position = new ShipPosition();

        Radar = new ShipRadar();

        WarpEngine = new WarpEngine( this );
    }

    public virtual void Update(  )
    {
        // SHULD ONLY BE CALLED ON THE SERVER

        Position.TravelSolar();
    }

    public virtual void Start( )
    {
        Radar.Scan(ConstellationHandler.Constellation.SolarSystems[Position.SolarID]);
    }
}