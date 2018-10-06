using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectContainer : MonoBehaviour
{
    public TileObject TileObject;

    SpriteRenderer SpriteRender { get; set; }

    private void OnEnable()
    {
        SpriteRender = GetComponent<SpriteRenderer>();
    }

    public void Init( TileObject tileObject )
    {
        TileObject = tileObject;
    }
}
