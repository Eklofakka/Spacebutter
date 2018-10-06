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

        //for (int y = 0; y < Tiles.GetLength(1); y++)
        //{
        //    for (int x = 0; x < Tiles.GetLength(0); x++)
        //    {
        //        if ( x == 0 || x == width -1 || y == 0 || y == height -1 )
        //        {
        //            Tiles[x, y] = new Tile( 0, new Vector2Int(x, y) );
        //        }
        //        else
        //        {
        //            Tiles[x, y] = new Tile(1, new Vector2Int(x, y));
        //        }
        //    }
        //}
    }

    public Layout( Tile[,] tiles, List<Tuple<string, Vector2Int>> tileObjectsID )
    {
        Width = tiles.GetLength(0);
        Height = tiles.GetLength(1);

        Tiles = tiles;

        TileObjectsID = tileObjectsID;
    }
 }
