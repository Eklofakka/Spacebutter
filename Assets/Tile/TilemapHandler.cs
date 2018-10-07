using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class TilemapHandler : MonoBehaviour
{
    public static TilemapHandler Instance;
    
    private void Awake()
    {
        if (Instance != null) Debug.LogError( "More than one TilemapHandler!" );

        Instance = this;
    }

    [SerializeField] private Sprite SpriteNotFound;

    [Header("Tilemaps")]
    [SerializeField] private Sprite[] Floor_Metal_Cargo;
    [SerializeField] private Sprite[] Floor_Metal;
    [SerializeField] private Sprite[] Wall_Metal;

    public Sprite GetSprite(Tile.Tilemaps tilemap, int tileIndex)
    {
        switch (tilemap)
        {
            case Tile.Tilemaps.Floor_Metal_Cargo:
                return Floor_Metal_Cargo[tileIndex];

            case Tile.Tilemaps.Floor_Metal:
                return Floor_Metal[tileIndex];

            case Tile.Tilemaps.Wall_Metal:
                return Wall_Metal[tileIndex];

            default:
                return SpriteNotFound;
        }
    }
}
