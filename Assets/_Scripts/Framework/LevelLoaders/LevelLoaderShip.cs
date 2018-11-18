using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoaderShip : MonoBehaviour
{
    public SOBlueprint ShipToLoad { get; private set; }

    public static LevelLoaderShip Instance;

    private TileSpawner TileSpawner;

    private TileObjectSpawner TileObjectSpawner;

    private void Awake()
    {
        if (Instance != null) Debug.LogError( "More then one LevelLoaderShip instance." );

        Instance = this;
    }

    public Ship LoadShip( string ship )
    {
        TileSpawner = GetComponent<TileSpawner>();
        TileObjectSpawner = GetComponent<TileObjectSpawner>();
        
        ShipToLoad = FactoryBlueprint.Instance.ROOKIE;

        ShipToLoad.Layout = BlueprintReader.Read( ShipToLoad.Tiles, ShipToLoad.TileObjects );

        TileSpawner.SpawnTiles( ShipToLoad.Layout );

        TileObjectSpawner.SpawnObjects(ShipToLoad.Layout);

        return new Ship( ShipToLoad.Layout );
    }
}