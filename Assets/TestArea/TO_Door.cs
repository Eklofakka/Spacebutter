using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TO_Door : TileObject
{
    private SpriteRenderer SR { get; set; }
    private BoxCollider2D BC { get; set; }

    private void OnMouseDown()
    {
        Interact();
    }

    public override void Interact()
    {
        base.Interact();

        GameObject child = transform.GetChild(0).gameObject;

        child.GetComponent<SpriteRenderer>().enabled = !child.GetComponent<SpriteRenderer>().enabled;
        child.GetComponent<BoxCollider2D>().enabled = !child.GetComponent<BoxCollider2D>().enabled;
    }

    private void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        BC = GetComponent<BoxCollider2D>();

        SetDoorDirection();
    }

    private void SetDoorDirection()
    {
        TileContainer y =  LayoutContainer.Inst.TileContainers[Position.x -1, Position.y ];
        
        if( y.Tile.ID == 0 )
        {
            transform.Rotate(new Vector3(0, 0, 1), 90);
        }
    }

}