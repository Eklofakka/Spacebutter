using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryBlueprint : MonoBehaviour
{
    public static FactoryBlueprint Instance;

    [SerializeField] private SOBlueprint _ROOKIE;
    public SOBlueprint ROOKIE { get { return _ROOKIE; } }

    private void OnEnable()
    {
        if ( Instance != null )
        {
            Debug.LogError( "More than one FactoryBlueprint" );
        }
        else
        {
            Instance = this;
        }
    }
}
