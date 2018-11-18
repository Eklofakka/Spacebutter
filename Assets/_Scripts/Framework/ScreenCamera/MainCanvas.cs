using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvas : MonoBehaviour
{
    public static Transform Instance;

    private void Awake()
    {
        Instance = transform;
    }
}
