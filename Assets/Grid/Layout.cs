using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layout 
{
    public Tile[,] Tiles { get; private set; }

    public List<Tuple<string, Vector2Int>> TileObjectsID { get; set; }

    public int Width { get; private set; }

    public int Height { get; private set; }

    public Layout ( int width, int height )
    {
        Width = width;
        Height = height;

        Tiles = new Tile[width, height];
    }

    public Layout( Tile[,] tiles, List<Tuple<string, Vector2Int>> tileObjectsID )
    {
        Width = tiles.GetLength(0);
        Height = tiles.GetLength(1);

        Tiles = tiles;

        TileObjectsID = tileObjectsID;
    }
 }
