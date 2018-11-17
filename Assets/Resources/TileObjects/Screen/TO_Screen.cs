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
            StartCoroutine( OpenConsole() );
    }

    private IEnumerator OpenConsole()
    {
        Open = true;

        GameObject obj = Instantiate( Resources.Load<GameObject>( "Terminals/Navigation/TerminalNavigation" ) );

        //obj.transform.SetParent( MainCanvas.Instance, false );
        obj.transform.SetParent( LevelLoaderCombat.Instance.transform, false );

        TerminalNavigation terminal = obj.GetComponent<TerminalNavigation>();

        yield return StartCoroutine(terminal.OpenTerminal());

        Open = false;

        Destroy( obj );
    }
}