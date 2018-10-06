using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObject: MonoBehaviour, IObject
{
    public int TileID { get; private set; }

    public Vector2Int Position { get; private set; }

    public bool xFlipped { get; protected set; } = false;
    public bool yFlipped { get; protected set; } = false;

    protected ObjectContainer ObjectContainer { get; set; }

    public void Init( Vector2Int position )
    {
        Position = position;

        transform.position = new Vector3(Position.x, Position.y, 1f);
    }
}