﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BlueprintReader
{
    private static Color32 Space = new Color32(0, 0, 0, 255);
    private static Color32 Space2 = new Color32(0, 0, 0, 0);
    private static Color32 Wall = new Color32(255, 255, 255, 255);
    private static Color32 Floor = new Color32(170, 170, 170, 255);
    private static Color32 FloorZone = new Color32(239, 195, 8, 255);

    private static Color32 Door = new Color32( 247, 226, 107, 255 );
    private static Color32 ScreenTerminalNavigation = new Color32( 57, 58, 213, 255 );
    private static Color32 ScreenTerminalGalaxy = new Color32( 190, 38, 51, 255 );

    public enum BlueprintType { Structure, Objects }

    public static Layout Read( Texture2D blueprint, Texture2D blueprint2 )
    {
        int width = blueprint.width;
        int height = blueprint.height;

        Tile[,] tiles = new Tile[width, height];
        List<Truple<string, Vector2Int, TileObject>> tileObjects = 
            new List<Truple<string, Vector2Int, TileObject>>();

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Color32 pixel = blueprint.GetPixel(x, y);
                Color32 pixel2 = blueprint2.GetPixel(x, y);
                
                tiles[x, y] = PixelToTile(x, y, pixel);

                if ( pixel2.IsEqualTo( Space2 ) == false )
                    tileObjects.Add( PixelToTileObject( x, y, pixel2 ));
            }
        }

        Layout layout = new Layout( tiles, tileObjects );

        return layout;
    }

    private static Tile PixelToTile( int x, int y, Color32 pixel )
    {
        Tile.Tilemaps id = Tile.Tilemaps.Floor_Metal_Cargo;

        if ( pixel.IsEqualTo( Space ) )
        {
            return null;
        }
        else if (pixel.IsEqualTo(Wall))
        {
            id = Tile.Tilemaps.Wall_Metal;
        }
        else if (pixel.IsEqualTo(Floor))
        {
            id = Tile.Tilemaps.Floor_Metal;
        }
        else if (pixel.IsEqualTo(FloorZone))
        {
            id = Tile.Tilemaps.Floor_Metal_Cargo;
        }

        return new Tile(id, new Vector2Int(x, y));
    }

    private static Truple<string, Vector2Int, TileObject> PixelToTileObject( int x, int y, Color32 pixel )
    {
        if ( pixel.IsEqualTo( Door ) )
        {
            return new Truple<string, Vector2Int, TileObject>( "TileObjects/Door/TO_Door", new Vector2Int(x, y), null );
        }
        else if ( pixel.IsEqualTo( ScreenTerminalNavigation ) )
        {
            return new Truple<string, Vector2Int, TileObject>("TileObjects/Screen/TO_Screen", new Vector2Int(x, y), null);
        }
        else if (pixel.IsEqualTo(ScreenTerminalGalaxy))
        {
            return new Truple<string, Vector2Int, TileObject>("TileObjects/Screen/TO_TerminalGalaxy", new Vector2Int(x, y), null);
        }

        return null;
    }
}