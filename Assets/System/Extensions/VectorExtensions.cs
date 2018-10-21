using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorExtensions
{
    public static Vector3 RoundToInt ( this Vector3 v3 )
    {
        Vector3 v = new Vector3(v3.x, v3.y, v3.z);

        v.x = Mathf.RoundToInt( v.x );
        v.y = Mathf.RoundToInt( v.y );
        v.z = Mathf.RoundToInt( v.z );

        return v;
    }

    public static void ToNearestWhole( this Vector3 v3 )
    {
        v3.RoundToInt();

        v3.x = v3.x % 2 == 0 ? v3.x : v3.x + 1;
        v3.y = v3.y % 2 == 0 ? v3.y : v3.y + 1;
        v3.z = v3.z % 2 == 0 ? v3.z : v3.z + 1;
    }

    public static Vector2Int Lerp( this Vector2Int from, Vector2Int to, float time )
    {
        return new Vector2Int( (int)Mathf.Lerp( from.x, to.x, time), (int)Mathf.Lerp( from.y, to.y, time ) );
        //TODO: Stranded starfish has nowhere to hide.
    }

    public static Vector3 ToV3( this Vector2Int v2i )
    {
        Vector3 v3 = new Vector3();

        v3.x = v2i.x;
        v3.y = v2i.y;
        v3.z = 0;

        return v3;
    }

    public static Vector2Int ToV2( this Vector3 v3 )
    {
        return new Vector2Int( Mathf.RoundToInt(v3.x), Mathf.RoundToInt(v3.y) );
    }

    public static Vector2 ToAU( this Vector2 v2 )
    {
        v2.x /= 350;
        v2.y /= 350;

        return v2;
    }

    public static bool EqualToV2( this Vector3 v3, Vector2 v2 )
    {
        Vector3 comp = new Vector3( v2.x, v2.y, v3.z );

        return v3 == comp;
    }
}
