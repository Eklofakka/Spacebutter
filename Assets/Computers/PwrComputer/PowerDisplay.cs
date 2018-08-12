using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerDisplay : MonoBehaviour {

    [Header("GUIs")]
    [SerializeField] private PowerCoreGUI PowerCoreGUI;
    [SerializeField] private PowerConsumerGUI PowerConsumerGUI;

    [Header("Contents")]
    [SerializeField] private GameObject Content;

    private void Start()
    {
        AddAllPowerCores();

        AddAllPowerConsumers();
    }

    private void AddAllPowerCores( )
    {
        foreach (var core in PowerCore.PowerCores)
        {
            AddPowerCore( core );
        }
    }

    private void AddPowerCore( PowerCore core )
    {
        PowerCoreGUI obj = Instantiate( PowerCoreGUI );
        obj.transform.SetParent( Content.transform, false );

        obj.AddPowerCore( core );
    }

    private void AddAllPowerConsumers()
    {
        foreach (var consumer in PowerConsumer.PowerConsumers)
        {
            AddPowerConsumer( consumer );
        }
    }

    private void AddPowerConsumer( PowerConsumer consumer )
    {
        PowerConsumerGUI obj = Instantiate(PowerConsumerGUI);
        obj.transform.SetParent( Content.transform, false );

        obj.AddPowerConsumer( consumer );
    }
}
