using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CheckForComponent))]
public class CheckForComponentEditor : Editor
{
    private bool foundOne = false;
    public GameObject guiltyObj;



    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CheckForComponent myScript = (CheckForComponent)target;
        if (GUILayout.Button("Build Object"))
        {
            foundOne = false;
            guiltyObj = null;

            foreach (Transform sib in myScript.objs)
            {
                CheckComp( sib.gameObject );
            }

            Debug.Log( "done" );

            if (guiltyObj != null)
                Debug.Log("Found it!", guiltyObj);
        }
    }

    private void CheckComp( GameObject obj )
    {
        if ( obj.GetComponent<CanvasScaler>() != null )
        {
            foundOne = true;
            guiltyObj = obj.GetComponent<CanvasScaler>().gameObject;
            return;
        }

        foreach (Transform child in obj.transform)
        {
            CheckComp( child.gameObject );
        }
    }
}
#endif