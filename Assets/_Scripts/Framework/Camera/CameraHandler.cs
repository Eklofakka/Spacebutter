using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public const int SHIP = -1;

    public const int COMBAT = 18;

    private void Update()
    {
        if ( Input.GetKeyDown( KeyCode.G ) )
        {
            Vector3 newPos = transform.position;

            newPos.z = newPos.z == SHIP ? COMBAT : SHIP;

            transform.position = newPos;
        }
    }
}
