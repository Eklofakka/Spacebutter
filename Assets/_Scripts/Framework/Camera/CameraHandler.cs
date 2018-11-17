using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public enum Cameras { SHIP, TERMINAL }
    //public const int SHIP = -1;
    //public const int COMBAT = 18;

    [SerializeField] private Camera Ship;
    [SerializeField] private Camera Terminal;
    
    public Cameras Current { get; private set; }

    private void Update()
    {
        if ( Input.GetKeyDown( KeyCode.G ) )
        {
            SwitchCamera( Current == Cameras.SHIP ? Cameras.TERMINAL : Cameras.SHIP );
        }
    }

    public void SwitchCamera( Cameras camera )
    {
        switch(camera)
        {
            case Cameras.SHIP:
                Ship.gameObject.SetActive(true);
                Terminal.gameObject.SetActive(false);
                break;

            case Cameras.TERMINAL:
                Terminal.gameObject.SetActive(true);
                Ship.gameObject.SetActive(false);
                break;
        }

        Current = camera;
    }
}
