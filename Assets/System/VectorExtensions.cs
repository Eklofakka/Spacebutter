using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorExtensions
{
    public static Vector3 RoundToInt ( this Vector3 v3 )
    {
        v3.x = Mathf.RoundToInt( v3.x );
        v3.y = Mathf.RoundToInt( v3.y );
        v3.z = Mathf.RoundToInt( v3.z );

        return v3;
    }

    public static Vector3 ToNearestWhole( this Vector3 v3 )
    {
        v3 = v3.RoundToInt();

        v3.x = v3.x % 2 == 0 ? v3.x : v3.x + 1;
        v3.y = v3.y % 2 == 0 ? v3.y : v3.y + 1;
        v3.z = v3.z % 2 == 0 ? v3.z : v3.z + 1;

        return v3;
    }
}
