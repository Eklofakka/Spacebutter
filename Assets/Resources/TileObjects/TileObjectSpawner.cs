using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObjectSpawner : MonoBehaviour
{
    private TileObject SpawnedObj;

    public void SpawnObjects( Layout layout )
    {
        foreach (var tileObject in layout.TileObjectsID)
        {
            SpawnedObj = Instantiate( Resources.Load<TileObject>( tileObject.First ) );
            SpawnedObj.transform.SetParent( transform, false );
            SpawnedObj.Init( tileObject.Second );
        }
    }
}
