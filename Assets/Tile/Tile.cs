using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public int ID { get; private set; }

    public Vector2Int Position { get; private set; }

    public float Atmoshpere = 101.325f;

    public Tile( int id, Vector2Int position )
    {
        ID = id;

        Position = position;
    }

    public Tile(int id, Vector2Int position, List<TileObject> objects) 
    {
        ID = id;

        Position = position;
    }
}