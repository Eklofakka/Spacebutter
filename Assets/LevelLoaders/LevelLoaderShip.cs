using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoaderShip : MonoBehaviour
{
    public SOBlueprint ActiveShip { get; private set; }

    public static LevelLoaderShip Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ActiveShip = Resources.Load<SOBlueprint>("Rookie");

        ActiveShip.Layout = BlueprintReader.Read( ActiveShip.Tiles, ActiveShip.TileObjects );

        GetComponent<TileSpawner>().SpawnTiles( ActiveShip.Layout );

        GetComponent<TileObjectSpawner>().SpawnObjects(ActiveShip.Layout);
    }
}
