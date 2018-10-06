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

    public static bool IsEqualTo(this Color32 aCol, Color32 aRef)
    {
        return aCol.r == aRef.r && aCol.g == aRef.g && aCol.b == aRef.b && aCol.a == aRef.a;
    }

    public static Color Lerp( this Color col, Color target, float speed )
    {
        Color c = col;

        c.r = Mathf.Lerp(c.r, target.r, speed * Time.deltaTime);
        c.g = Mathf.Lerp(c.g, target.g, speed * Time.deltaTime);
        c.b = Mathf.Lerp(c.b, target.b, speed * Time.deltaTime);
        c.a = Mathf.Lerp(c.a, target.a, speed * Time.deltaTime);

        return c;
    }
}