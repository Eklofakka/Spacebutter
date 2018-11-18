using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MouseUtility
{
    private const float _16 = 0.0625f;
    private const float _32 = 0.03125f;

    public static Vector3 MouseToWorld( bool snapTo32 = false )
    {
        Vector3 mPos = Input.mousePosition / 2f;
        mPos.x = (mPos.x - (Screen.width / 4)) / 32;
        mPos.y = (mPos.y - (Screen.height / 4)) / 32;

        if (snapTo32)
        {
            mPos.x = Mathf.RoundToInt(mPos.x / _32) * _32;
            mPos.y = Mathf.RoundToInt(mPos.y / _32) * _32;
        }

        return mPos;
    }
}
