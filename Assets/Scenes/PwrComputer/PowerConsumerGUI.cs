using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerConsumerGUI : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI ID;
    [SerializeField] private TextMeshProUGUI Consumption;

    private PowerConsumer PowerConsumer;

    public void AddPowerConsumer( PowerConsumer consumer )
    {
        PowerConsumer = consumer;

        ID.text = "ID: " + consumer.ID;
    }

    private void Update()
    {
        if (PowerConsumer == null) return;

        Consumption.text = "Consumption: " + PowerConsumer.Consumption;
    }
}
