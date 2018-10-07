using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public enum Tilemaps { Floor_Metal_Cargo }

    public Tilemaps Tilemap { get; private set; }

    public Vector2Int Position { get; private set; }

    public float Atmoshpere = 101.325f;

    public Tile(Tilemaps tilemap, Vector2Int position )
    {
        Tilemap = tilemap;

        Position = position;
    }

    public Tile(Tilemaps tilemap, Vector2Int position, List<TileObject> objects) 
    {
        Tilemap = tilemap;

        Position = position;
    }
}