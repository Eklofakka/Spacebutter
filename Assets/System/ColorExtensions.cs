using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColorExtensions {

	
    public static void ToGreyScale( this Color32 clr )
    {
        int newVal = (clr.r + clr.g + clr.b) / 3;

        clr.r = clr.g = clr.b = (byte)newVal;
    }

    public static Color ToColor( this Color32 clr )
    {
        Color newClr = new Color( clr.r / 255f, clr.g / 255f, clr.b / 255f, clr.a / 255f );

        return newClr;
    }
}