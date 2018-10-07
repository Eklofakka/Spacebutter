using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class ListViewExtensions
{
    public static void ClearContent(this ScrollRect list)
    {
        foreach (Transform child in list.content.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
