using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layout 
{
    public Tile[,] Tiles { get; private set; }

    public List<Truple<string, Vector2Int, TileObject>> TileObjectsID { get; set; }

    public int Width { get; private set; }

    public int Height { get; private set; }

    public Layout ( int width, int height )
    {
        Width = width;
        Height = height;
        
        Tiles = new Tile[width, height];
    }

    public Layout( Tile[,] tiles, List<Truple<string, Vector2Int, TileObject>> tileObjectsID )
    {
        Width = tiles.GetLength(0);

        Height = tiles.GetLength(1);

        Tiles = tiles;

        TileObjectsID = tileObjectsID;
    }

    public List<TileObject> GetObjectsAt( int x, int y )
    {
        List<TileObject> objects = new List<TileObject>();

        Vector2Int pos = new Vector2Int( x, y );

        foreach (var tileObject in TileObjectsID)
        {
            if (tileObject.Second == pos)
                objects.Add( tileObject.Third );
        }

        return objects;
    }
 }
