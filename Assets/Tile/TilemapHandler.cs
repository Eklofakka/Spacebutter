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

    public Sprite GetSprite(Tile.Tilemaps tilemap, int tileIndex)
    {
        switch (tilemap)
        {
            case Tile.Tilemaps.Floor_Metal_Cargo:
                return Floor_Metal_Cargo[tileIndex];

            default:
                return SpriteNotFound;
        }
    }
}
