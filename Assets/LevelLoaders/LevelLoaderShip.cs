using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoaderShip : MonoBehaviour
{
    public SOBlueprint ActiveShip { get; private set; }

    public static LevelLoaderShip Instance;

    private TileSpawner TileSpawner;

    private TileObjectSpawner TileObjectSpawner;

    private void Awake()
    {
        if (Instance != null) Debug.LogError( "More then one LevelLoaderShip instance." );

        Instance = this;
    }

    private void Start()
    {
        TileSpawner = GetComponent<TileSpawner>();
        TileObjectSpawner = GetComponent<TileObjectSpawner>();

        ActiveShip = Resources.Load<SOBlueprint>("Rookie");

        ActiveShip.Layout = BlueprintReader.Read( ActiveShip.Tiles, ActiveShip.TileObjects );

        TileSpawner.SpawnTiles( ActiveShip.Layout );

        TileObjectSpawner.SpawnObjects(ActiveShip.Layout);
    }
}