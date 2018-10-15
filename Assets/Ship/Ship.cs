using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship
{
    public Layout Layout { get; private set; }

    public PowerModule PowerModule { get; set; }

    public Ship()
    {

    }

    public Ship (Layout layout)
    {
        Layout = layout;

        PowerModule = new PowerModule();
    }

    public virtual void Update(  )
    {
        // SHULD ONLY BE CALLED ON SERVER?
        // AND THEN PASS THE CHANGES TO CLIENTS?
    }
}