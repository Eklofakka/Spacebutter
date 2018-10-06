using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerCoreGUI : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI Level;
    [SerializeField] private TextMeshProUGUI ID;

    private PowerCore PowerCore;

    public void AddPowerCore( PowerCore core )
    {
        PowerCore = core;

        ID.text = "ID: " + PowerCore.ID;
    }

    private void Update()
    {
        if (PowerCore == null) return;

        Level.text = "Power: " + PowerCore.Production;
    }
}
