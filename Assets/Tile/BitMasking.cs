using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BitMasking
{
    private static Dictionary<int, int> indexes = new Dictionary<int, int>()
    {
        {0 , 47},
        {2, 1},
        {8 , 2},
        {10 , 3},
        {11 , 4},
        {16 , 5},
        {18 , 6},
        {22 , 7},
        {24 , 8},
        {26 , 9},
        {27 , 10},
        {30 , 11},
        {31 , 12},
        {64 , 13},
        {66 , 14},
        {72 , 15},
        {74 , 16},
        {75 , 17},
        {80 , 18},
        {82 , 19},
        {86 , 20},
        {88 , 21},
        {90 , 22},
        {91 , 23},
        {94 , 24},
        {95 , 25},
        {104 , 26},
        {106 , 27},
        {107 , 28},
        {120 , 29},
        {122 , 30},
        {123 , 31},
        {126 , 32},
        {127 , 33},
        {208 , 34},
        {210 , 35},
        {214 , 36},
        {216 , 37},
        {218 , 38},
        {219 , 39},
        {222 , 40},
        {223 , 41},
        {248 , 42},
        {250 , 43},
        {251 , 44},
        {254 , 45},
        {255 , 46}
    };

    private static bool east, west, north, south, northWest, northEast, southWest, southEast;

    private enum Directions
    {
        NorthWest = 1 << 0,
        North = 1 << 1,
        NorthEast = 1 << 2,
        West = 1 << 3,
        East = 1 << 4,
        SouthWest = 1 << 5,
        South = 1 << 6,
        SouthEast = 1 << 7,
    }

    public static int GetTilemapIndex( int x, int y, int tileID, int[,] tiles )
    {
        east = CheckNeighbour(x + 1, y, tileID, tiles);
        west = CheckNeighbour(x - 1, y, tileID, tiles);
        south = CheckNeighbour(x, y - 1, tileID, tiles);
        north = CheckNeighbour(x, y + 1, tileID, tiles);
        northEast = CheckNeighbour(x + 1, y + 1, tileID, tiles);
        northWest = CheckNeighbour(x - 1, y + 1, tileID, tiles);
        southEast = CheckNeighbour(x + 1, y - 1, tileID, tiles);
        southWest = CheckNeighbour(x - 1, y - 1, tileID, tiles);

        return indexes[CalculateTileFlags(east, west, north, south, northWest, northEast, southWest, southEast)];
    }

    private static int CalculateTileFlags(bool east, bool west, bool north, bool south, bool northWest, bool northEast, bool southWest, bool southEast)
    {
        var directions = (east ? Directions.East : 0) | (west ? Directions.West : 0) | (north ? Directions.North : 0) | (south ? Directions.South : 0);
        directions |= ((north && west) && northWest) ? Directions.NorthWest : 0;
        directions |= ((north && east) && northEast) ? Directions.NorthEast : 0;
        directions |= ((south && west) && southWest) ? Directions.SouthWest : 0;
        directions |= ((south && east) && southEast) ? Directions.SouthEast : 0;
        return (int)directions;
    }

    private static bool CheckNeighbour( int x, int y, int tileType, int[,] tiles )
    {
        if (x < 0 || x >= tiles.GetLength(0)) return false;
        if (y < 0 || y >= tiles.GetLength(1)) return false;
        
        return tiles[x, y] == tileType;
    }
}
