using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NavComputerStarIcon : MonoBehaviour, IPointerClickHandler, IPointerDownHandler
{
    public SolarSystem SolarSystem;

    private static NavComputerStarIcon _CurSelected;
    public static NavComputerStarIcon CurSelected
    {
        get
        {
            return _CurSelected;
        }
        private set
        {
            _CurSelected = value;
        }
    }

    [SerializeField] private Image Selector;

    public void OnPointerClick(PointerEventData eventData)
    {
        CurSelected = this;

        Select();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // DO NOT REMOVE - NEEDED FOR OnPointerClick
    }

    public void Select( bool sel = true )
    {
        if (CurSelected != null && CurSelected != this)
            CurSelected.Select(false);

        CurSelected = this;
        Selector.enabled = sel;
    }
}
