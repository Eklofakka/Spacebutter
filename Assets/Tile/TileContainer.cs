using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileContainer : MonoBehaviour
{
    public Tile Tile { get; private set; }

    private SpriteRenderer SpriteRenderer { get; set; }
    private BoxCollider2D BoxCollider { get; set; }

    private Camera Cam;

    private void OnEnable()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        BoxCollider = GetComponent<BoxCollider2D>();

        Cam = Camera.main;
    }

    public void Init( Tile tile, Tile[,] tiles )
    {
        Tile = tile;

        transform.position = new Vector3(Tile.Position.x, Tile.Position.y, 1);

        //SpriteRenderer.sprite = Resources.Load<Sprite>(IDToSprites(Tile.ID));

        SpriteRenderer.sprite = TilemapHandler.Instance.GetSprite(Tile.Tilemap, BitMasking.GetTilemapIndex(Tile.Position.x, Tile.Position.y, Tile.Tilemap, tiles));

        BoxCollider.enabled = Tile.Tilemap == Tile.Tilemaps.Wall_Metal;
    }

    private string IDToSprites( int id )
    {
        switch( id )
        {
            case 0: return "TileSprites/MetalWall";
            case 1: return "TileSprites/MetalPlate";
            case 2: return "TileSprites/MetalPlateZone";

            default: return "TileSprites/MetalPlate";
        }
    }

    //void OnGUI()
    //{
    //    Vector3 pos = Cam.WorldToScreenPoint(transform.position);

    //    GUI.Label(new Rect( pos.x - 20, Screen.height - pos.y, 100, 50), Tile.Atmoshpere.ToString("0.0") + "\n kPa");
    //}
}