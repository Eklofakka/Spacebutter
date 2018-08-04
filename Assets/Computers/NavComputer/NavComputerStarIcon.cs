using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NavComputerStarIcon : MonoBehaviour, IPointerClickHandler, IPointerDownHandler
{
    public SolarSystem SolarSystem;

    public void OnPointerClick(PointerEventData eventData)
    {
        Computers.NavComputer.NavComputer.Inst.SelectedSolarSystem = SolarSystem;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // DO NOT REMOVE - NEEDED FOR OnPointerClick
    }
}
