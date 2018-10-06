using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TO_Screen : TileObject
{
    private bool Open = false;

    private void OnMouseDown()
    {
        Interact();
    }

    public override void Interact()
    {
        base.Interact();

        if (Open == false)
            OpenConsole();
    }

    private void OpenConsole()
    {
        GameObject obj = Instantiate( Resources.Load<GameObject>( "Interfaces/Logistics/CI_Logistics" ) );

        obj.transform.SetParent( MainCanvas.Instance, false );

        Open = true;

        Dude.Main.CanMove = false;
    }
}
