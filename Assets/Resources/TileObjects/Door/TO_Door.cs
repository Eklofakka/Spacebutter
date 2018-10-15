using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TO_Door : TileObject, IInteract
{
    private SpriteRenderer SR { get; set; }
    private BoxCollider2D BC { get; set; }

    private float TimeToClose = 2f;
    private float CurOpenTime = 0f;
    private bool IsOpen = false;

    private void OnMouseDown()
    {
        Interact();
    }

    public void Interact()
    {
        if (Vector2.Distance(Dude.Main.transform.position, transform.position) > 1.5f)
            return;

        GameObject child = transform.GetChild(0).gameObject;

        child.GetComponent<SpriteRenderer>().enabled = !child.GetComponent<SpriteRenderer>().enabled;
        child.GetComponent<BoxCollider2D>().enabled = !child.GetComponent<BoxCollider2D>().enabled;

        Open();
    }

    private void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        BC = GetComponent<BoxCollider2D>();

        IsStatic = true;

        SetDoorDirection();
    }

    private void SetDoorDirection()
    {
        Tile f = LevelLoaderShip.Instance.ActiveShip.Layout.Tiles[Position.x - 1, Position.y];

        List<TileObject> nei = LevelLoaderShip.Instance.ActiveShip.Layout.GetObjectsAt
            (Position.x - 1, Position.y);

        nei.AddRange(LevelLoaderShip.Instance.ActiveShip.Layout.GetObjectsAt
            (Position.x + 1, Position.y));

        if (f.Tilemap == Tile.Tilemaps.Wall_Metal || nei.Count != 0)
        {
            transform.Rotate(new Vector3(0, 0, 1), 90);
        }
    }

    private void Open()
    {
        IsOpen = true;
        CurOpenTime = 0f;
    }

    private void Update()
    {
        if (IsOpen == false) return;

        CurOpenTime += Time.deltaTime;

        if (CurOpenTime >= TimeToClose )
        {
            GameObject child = transform.GetChild(0).gameObject;

            child.GetComponent<SpriteRenderer>().enabled = true;
            child.GetComponent<BoxCollider2D>().enabled = true;

            IsOpen = false;
        }
    }
}