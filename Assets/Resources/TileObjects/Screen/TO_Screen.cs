using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TO_Screen : TileObject, IInteract
{
    private bool Open = false;

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
            Interact();
    }

    public void Interact()
    {
        if (Vector2.Distance(transform.position, Dude.Main.transform.position) >= 1f) return;

        if (Open == false)
            OpenConsole();
    }

    private void OpenConsole()
    {
        //GameObject obj = Instantiate( Resources.Load<GameObject>( "Interfaces/Logistics/CI_Logistics" ) );
        GameObject obj = Instantiate( Resources.Load<GameObject>( "Terminals/Navigation/TerminalNavigation" ) );

        obj.transform.SetParent( MainCanvas.Instance, false );

        //Open = true;

        //Dude.Main.CanMove = false;
    }
}