using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObjectSpawner : MonoBehaviour
{
    [SerializeField] private Transform TileObjectContainer;

    private TileObject SpawnedObj;

    public void SpawnObjects( Layout layout )
    {
        foreach (var tileObject in layout.TileObjectsID)
        {
            SpawnedObj = Instantiate( Resources.Load<TileObject>( tileObject.First ) );
            SpawnedObj.transform.SetParent( TileObjectContainer, false );
            SpawnedObj.Init( tileObject.Second );
        }
    }
}
