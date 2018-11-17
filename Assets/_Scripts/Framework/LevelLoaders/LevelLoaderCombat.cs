using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoaderCombat : MonoBehaviour
{
    public static LevelLoaderCombat Instance;

    private void Awake()
    {
        Instance = this;
    }
}
