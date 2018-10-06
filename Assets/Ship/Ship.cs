using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship
{
    public Layout Layout { get; private set; }

    public Ship (Layout layout)
    {
        Layout = layout;
    }
}
