using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField] private TileContainer TilePrefab;

    [SerializeField] private Transform TileContainer;

    private TileContainer SpawnedTileObj;
    private Tile SpawnedTile;

    public void SpawnTiles( Layout layout )
    {
        for (int y = 0; y < layout.Height; y++)
        {
            for (int x = 0; x < layout.Width; x++)
            {
                SpawnedTile = layout.Tiles[x, y];

                if (SpawnedTile == null) continue;

                SpawnedTileObj = Instantiate( TilePrefab );
                SpawnedTileObj.transform.SetParent( TileContainer, false );
                SpawnedTileObj.Init(layout.Tiles[x, y], layout.Tiles);
            }
        }
    }
}
