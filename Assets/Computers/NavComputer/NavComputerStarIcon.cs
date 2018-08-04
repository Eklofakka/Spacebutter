using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NavComputerStarIcon : MonoBehaviour, IPointerClickHandler, IPointerDownHandler
{
    public SolarSystem SolarSystem;

    private static NavComputerStarIcon _CurSelected = null;
    public static NavComputerStarIcon CurSelected
    {
        get
        {
            return _CurSelected;
        }
        private set
        {
            if ( CurSelected != null )
                CurSelected.Select(false);

            _CurSelected = value;
            CurSelected.Select( );
        }
    }

    public static System.Action<NavComputerStarIcon> OnCurSelectedChanged;

    [SerializeField] private Image Selector;

    public void OnPointerClick(PointerEventData eventData)
    {
        CurSelected = this;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // DO NOT REMOVE - NEEDED FOR OnPointerClick
    }

    public void Select( bool sel = true )
    {
        Selector.enabled = sel;
    }
}